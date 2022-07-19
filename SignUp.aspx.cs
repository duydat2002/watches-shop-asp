using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Serialization;

namespace BTL1
{
    public partial class SignUp : System.Web.UI.Page
    {
        Functions fs = new Functions();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((int)Session["userId"] != -1)
            {
                Response.Redirect("Home.aspx");
            }

            if (IsPostBack)
            {
                if (Request.Form["signup"] == "signup")
                {
                    // Check trùng
                    List<User> listUser = (List<User>)Application["listUser"];
                    string email = Request.Form["email"];
                    bool checkTrung = false;

                    foreach (User us in listUser)
                    {
                        if (us.Email == email)
                        {
                            signupError_box.InnerHtml = "<span class='alert-server alert-server-error'>The email is already used.</span>";
                            checkTrung = true;
                            break;
                        }
                    }
                    
                    if (!checkTrung)
                    {
                        User us = new User(
                            listUser.Count + 1,
                            Request.Form["firstname"],
                            Request.Form["lastname"],
                            Request.Form["email"],
                            Request.Form["password"],
                            Request.Form["birthdate"],
                            Request.Form["sex"] == "male" ? true : false
                        );
                        listUser.Add(us);

                        // Lưu File
                        XmlSerializer xml = new XmlSerializer(typeof(List<User>));
                        FileStream file = File.Create(Server.MapPath("listUser.xml"));
                        xml.Serialize(file, listUser);
                        file.Close();

                        // Tạo session
                        Session["userID"] = us.Id;
                        Session["userName"] = $"{us.Firstname} {us.Lastname}";
                        Application["numberVisitors"] = (int)Application["numberVisitors"] + 1;
                        Response.Redirect("Home.aspx");
                    }
                }
            }
        }
    }
}