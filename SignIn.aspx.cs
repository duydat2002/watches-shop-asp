using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTL1
{
    public partial class SignIn : System.Web.UI.Page
    {
        Functions fs = new Functions();

        protected void Page_Load(object sender, EventArgs e)
        {
            bool check = true;
            if (IsPostBack)
            {
                if (Application["timeError"] == null)
                {
                    if ((int)Application["countError"] >= 3)
                    {
                        check = false;
                        Application["timeError"] = DateTime.Now.AddSeconds(15);
                        signinError_box.InnerHtml = $"<span class='alert-server alert-server-error'>You have had too many failed login attempts. Please try again in {Application["timeError"]}.</span>";
                    }
                    else
                    {
                        check = true;
                    }
                }
                else
                {
                    if ((DateTime)Application["timeError"] <= DateTime.Now)
                    {
                        check = true;
                        Application["countError"] = 0;
                        Application["timeError"] = null;
                    }
                    else
                    {
                        check = false;
                    }
                }

                if (check)
                {
                    if (Request.Form["email"] == "admin@gmail.com" && Request.Form["password"] == "12345678")
                    {
                        Session["isAdmin"] = true;
                        Session["userName"] = $"Admin";
                        Session["userID"] = 1;
                    }

                    if (Request.Form["signin"] == "signin")
                    {
                        List<User> listUser = (List<User>)Application["listUser"];
                        string email = Request.Form["email"];
                        string password = Request.Form["password"];
                        bool checkExitsAccount = false;

                        foreach (User us in listUser)
                        {
                            if (us.Email == email)
                            {
                                checkExitsAccount = true;
                                if (us.Password == password)
                                {
                                    Session["userID"] = us.Id;
                                    Session["userName"] = $"{us.Firstname} {us.Lastname}";
                                    Session["timeLogin"] = DateTime.Now;
                                    Application["numberVisitors"] = (int)Application["numberVisitors"] + 1;
                                    Response.Redirect("Home.aspx");
                                } 
                            } 
                        }
                        if (checkExitsAccount)
                        {
                            signinError_box.InnerHtml = "<span class='alert-server alert-server-error'>Wrong password.</span>";
                            Application["countError"] = (int)Application["countError"] + 1;
                        }    
                        else
                            signinError_box.InnerHtml = "<span class='alert-server alert-server-error'>This account does not exist.</span>";
                    }
                }
            }
        }
    }
}