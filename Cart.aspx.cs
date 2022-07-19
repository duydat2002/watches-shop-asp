using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Serialization;

namespace BTL1
{
    public partial class Cart1 : System.Web.UI.Page
    {
        Functions fs = new Functions();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((int)Session["userID"] == -1)
            {
                Response.Redirect("Home.aspx");
            }

            List<Cart> listCart = (List<Cart>)Application["listCart"];
            List<Contact> listContact = (List<Contact>)Application["listContact"];
            List<Product> listProduct = (List<Product>)Application["listProduct"];

            if (Request.Form["order"] != null && (int)Session["userId"] != -1)
            {
                int qty = Request.Form["qty"] == null ? 1 : int.Parse(Request.Form["qty"]);
                addCart(listCart, (int)Session["userID"], int.Parse(Request.Form["order"]), qty);

                XmlSerializer xml = new XmlSerializer(typeof(List<Cart>));
                FileStream file = File.Create(Server.MapPath("listCart.xml"));
                xml.Serialize(file, listCart);
                file.Close();
            }
            address_modal.Attributes.Add("class", "payment-modal");

            if (IsPostBack)
            {
                if (Request.Form["delete"] != null)
                {
                    int productID = int.Parse(Request.Form["delete"]);

                    foreach (Cart cart in listCart)
                    {
                        if (cart.IdUser == (int)Session["userID"] && cart.IdProduct == productID)
                        {
                            listCart.Remove(cart);
                            break;
                        }
                    }

                    XmlSerializer xml = new XmlSerializer(typeof(List<Cart>));
                    FileStream file = File.Create(Server.MapPath("listCart.xml"));
                    xml.Serialize(file, listCart);
                    file.Close();
                }

                if (Request.Form["change-cart"] != null)
                {
                    string[] productIDs = Request.Form["id"].Split(',');
                    string[] qtys = Request.Form["qty"].Split(',');

                    for (int i=0; i<productIDs.Length; i++)
                    {
                        foreach (Cart cart in listCart)
                        {
                            if (cart.IdUser == (int)Session["userId"] && cart.IdProduct == int.Parse(productIDs[i]))
                            {
                                bool check = true;
                                foreach (Product pr in listProduct)
                                {
                                    if (int.Parse(productIDs[i]) == pr.Id && pr.Qty < int.Parse(qtys[i]))
                                    {
                                        cartError_box.InnerHtml = "<span class='alert-server alert-server-error'>Số lượng vượt quá mức hàng có sẵn</span>";
                                        check = false;
                                    }
                                }

                                if (check)
                                {
                                    cart.Quantity = int.Parse(qtys[i]);
                                }
                            }
                        }
                    }

                    XmlSerializer xml = new XmlSerializer(typeof(List<Cart>));
                    FileStream file = File.Create(Server.MapPath("listCart.xml"));
                    xml.Serialize(file, listCart);
                    file.Close();
                }

                if (Request.Form["purchase"] != null)
                {
                    bool checkContact = false;
                    foreach (Contact ct in listContact)
                    {
                        if (ct.IdUser == (int)Session["userId"])
                        {
                            checkContact = true;
                            break;
                        }
                    }

                    if (checkContact)
                    {
                        payment_modal.Attributes.Add("class", "payment-modal active");
                        List<Cart> listCartCopy = new List<Cart>(listCart);
                        foreach (Cart cart in listCartCopy)
                        {
                            if (cart.IdUser == (int)Session["userId"])
                            {
                                listCart.Remove(cart);
                            }
                        }

                        XmlSerializer xml = new XmlSerializer(typeof(List<Cart>));
                        FileStream file = File.Create(Server.MapPath("listCart.xml"));
                        xml.Serialize(file, listCart);
                        file.Close();
                    }
                    else
                    {
                        address_modal.Attributes.Add("class", "payment-modal active");
                    }
                }
            }

            cartpage__list.InnerHtml = renderCart(listCart, (int)Session["userID"]);
        }

        protected void addCart(List<Cart> listCart, int userID, int productID, int quantity)
        {
            
            bool check = false;

            foreach (Cart cart in listCart)
            {
                if (cart.IdUser == userID && cart.IdProduct == productID)
                {
                    cart.Quantity += quantity;
                    check = true;
                }
            }
            
            if (!check)
            {
                Cart cart = new Cart(userID, productID, quantity);
                listCart.Add(cart);
            }
        }

        protected string renderCart(List<Cart> listCart, int userID)
        {
            List<Product> listProduct = (List<Product>)Application["listProduct"];
            string htmls = "";
            bool checkEmpty = true;

            foreach (Cart cart in listCart)
            {
                if (cart.IdUser == userID)
                {
                    foreach (Product pr in listProduct)
                    {
                        if (pr.Id == cart.IdProduct)
                        {
                            checkEmpty = false;
                            string[] alts = pr.Alts.Split(',');
                            htmls += $@"
                                <div class='cartpage-item'>
                                    <div class='flex cl-gap'>
                                        <div class='col-3 col-xsm-12 pd-gap'>
                                            <a href='DetailProduct.aspx?id={pr.Id}' class='cartpage-item__img'>
                                                <img src='assets/image/{alts[0]}' alt='{alts[0]}'>
                                            </a>
                                        </div>
                                        <div class='col-9 col-xsm-12 pd-gap'>
                                            <div class='flex cl-gap'>
                                                <div class='col-5 col-sm-12 pd-gap'>
                                                    <div class='cartpage-item__detail'>
                                                        <input type='text' name='id' value='{cart.IdProduct}' style='display: none;'>
                                                        <a href='DetailProduct.aspx?id={pr.Id}' class='product__name'>{pr.Name}</a>
                                                        <div class='product__rating'>
                                                            {fs.renderStars(pr.Stars)}
                                                        </div>
                                                        <div class='product__price-box'>
                                                            {(pr.Discount == 0 ?
                                                                $"<span class='product__price-sale'>${pr.Price:0.00}</span>" :
                                                                $@"<span class='product__price'>${pr.Price:0.00}</span>
                                                            <span class='product__price-sale'>${(pr.Price * (1 - (pr.Discount / 100))):0.00}</span>")}                                
                                                        </div>
                                                        <div class='product__size'>
                                                            <span class='action__title'>Size</span>
                                                            <span class='action__item size-item'>{pr.Size}mm</span>
                                                        </div>
                                                        <div class='product__color'>
                                                            <span class='action__title'>Color</span>
                                                            <div class='action__item color-item color-{pr.Color.ToLower()}'></div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class='col-7 col-sm-12 pd-gap'>
                                                    <div class='flex align-items-center cl-gap'>
                                                        <div class='col-5 pd-gap'>
                                                            <div class='cartpage-item__quantity'>
                                                                <div class='quantity'>
                                                                    <input type='text' name='qty' value='{cart.Quantity}' class='quantity__input'>
                                                                    <div class='quantity__btns'>
                                                                        <i class='fas fa-angle-up quantity-up'></i>
                                                                        <i class='fas fa-angle-down quantity-down'></i>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class='col-5 pd-gap'>
                                                            <span class='cartpage-item__total'></span>
                                                        </div>
                                                        <div class='col-2 pd-gap'>
                                                            <button type='submit' name='delete' value='{cart.IdProduct}' class='cartpage-item-delete'>
                                                                <i class='fas fa-trash-alt'></i>
                                                            </button>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            ";
                        }
                    }
                }
            }

            if (checkEmpty)
            {
                change_cart.Attributes.Add("type", "button");
                purchase.Attributes.Add("type", "button");

                change_cart.Attributes.Add("class", "change-qty button button-gb button-disable");
                purchase.Attributes.Add("class", "cartpage__button button button-gb button-disable");
                return "<p class='cartpage-empty' style='color: #888;'>There are no more items in your cart</p>";
            }
            else
            {
                return htmls;
            }
        }
    }
}