using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTL1
{
    public partial class Layout : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string time = $@"
                <p class='account-item'>
                    <i class='fas fa-clock'></i>
                    {Session["timeLogin"]}
                </p>
            ";
            string visitors = $@"
                <p class='account-item'>
                    <i class='fas fa-globe'></i>
                    Number of visitors: {Application["numberVisitors"]}
                </p>
            ";
            if ((bool)Session["isAdmin"])
            {
                accountList.InnerHtml = $@"
                    <p class='account__name'>{(string)Session["userName"]}</p>
                    <a href='ProductManagement.aspx' class='account-item'>
                        <i class='fas fa-box'></i>
                        Product Management
                    </a>
                    <a href='SignOut.aspx' class='account-item'>
                        <i class='fas fa-sign-out-alt'></i>
                        Sign Out
                    </a>";
            } 
            else if ((int)Session["userID"] != -1)
            {
                accountList.InnerHtml = $@"
                    <p class='account__name'>{(string)Session["userName"]}</p>
                    <a href='Account.aspx' class='account-item'>
                        <i class='fas fa-user'></i>
                        My Account
                    </a>
                    <a href='Cart.aspx' class='account-item'>
                        <i class='fas fa-shopping-cart'></i>
                        My Cart
                    </a>
                    <a href='SignOut.aspx' class='account-item'>
                        <i class='fas fa-sign-out-alt'></i>
                        Sign Out
                    </a>";
            }
            else
            {
                accountList.InnerHtml = $@"
                    <a href='SignIn.aspx' class='account-item'>
                        <i class='fas fa-sign-in-alt'></i>
                        Sign In
                    </a>
                    <a href='SignUp.aspx' class='account-item'>
                        <i class='fas fa-user-plus'></i>
                        Sign Up
                    </a>";
            }

            cart__scroll.InnerHtml = renderCartScroll();
        }

        protected string renderCartScroll()
        {
            string htmls = "";
            List<Cart> listCart = (List<Cart>)Application["listCart"];
            List<Product> listProduct = (List<Product>)Application["listProduct"];

            foreach (Cart cart in listCart)
            {
                if (cart.IdUser == (int)Session["userID"])
                {
                    foreach (Product pr in listProduct)
                    {
                        if (pr.Id == cart.IdProduct)
                        {
                            string[] alts = pr.Alts.Split(',');
                            htmls += $@"
                                <div class='cart__item flex'>
                                    <a href='DetailProduct.aspx?id={pr.Id}' class='cart-img'>
                                        <img src='assets/image/{alts[0]}' alt='{alts[0]}'>
                                    </a>
                                    <div class='cart-info'>
                                        <a href='DetailProduct.aspx?id={pr.Id}' class='cart-name'>{pr.Name}</a>
                                        <p class='cart-price'>${(pr.Price * (1 - (pr.Discount / 100))):0.00}</p>
                                        <p class='cart-qty'>
                                            Quantity: 
                                            <span class='cart-qty-number'>{cart.Quantity}</span>
                                        </p>
                                    </div>
                                </div>
                            ";
                        }
                    }
                }
            }

            return htmls;
        }
    }
}