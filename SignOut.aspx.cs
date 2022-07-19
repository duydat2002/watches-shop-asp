using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTL1
{
    public partial class SignOut : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Application["countError"] = 0;
            Application["timeError"] = null;
            Session.Abandon();
            Response.Redirect("Home.aspx");
        }
    }
}