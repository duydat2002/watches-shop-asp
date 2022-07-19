using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Xml.Serialization;

namespace BTL1
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            Application["listUser"] = getListUser();
            Application["listProduct"] = getListProduct();
            Application["listCart"] = getListCart();
            Application["listContact"] = getListContact();
            Application["countError"] = 0;
            Application["timeError"] = null;
            Application["numberVisitors"] = 0;
        }

        protected List<User> getListUser()
        {
            string path = "listUser.xml";
            List<User> listUser = new List<User>();
            if (File.Exists(Server.MapPath(path)))
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<User>));
                StreamReader file = new StreamReader(Server.MapPath(path));

                listUser = (List<User>)xml.Deserialize(file);
                file.Close();
            }
            return listUser;
        }

        protected List<Product> getListProduct()
        {
            string path = "listProduct.xml";
            List<Product> listProduct = new List<Product>();
            if (File.Exists(Server.MapPath(path)))
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<Product>));
                StreamReader file = new StreamReader(Server.MapPath(path));

                listProduct = (List<Product>)xml.Deserialize(file);
                file.Close();
            }
            return listProduct;
        }

        protected List<Cart> getListCart()
        {
            string path = "listCart.xml";
            List<Cart> listCart = new List<Cart>();
            if (File.Exists(Server.MapPath(path)))
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<Cart>));
                StreamReader file = new StreamReader(Server.MapPath(path));

                listCart = (List<Cart>)xml.Deserialize(file);
                file.Close();
            }
            return listCart;
        }

        protected List<Contact> getListContact()
        {
            string path = "listContact.xml";
            List<Contact> listContact = new List<Contact>();
            if (File.Exists(Server.MapPath(path)))
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<Contact>));
                StreamReader file = new StreamReader(Server.MapPath(path));

                listContact = (List<Contact>)xml.Deserialize(file);
                file.Close();
            }
            return listContact;
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Session["isAdmin"] = false;
            Session["userName"] = "";
            Session["userID"] = -1;
            Session["timeLogin"] = null;
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}