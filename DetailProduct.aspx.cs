using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTL1
{
    public partial class DetailProduct : System.Web.UI.Page
    {
        Functions fs = new Functions();

        protected void Page_Load(object sender, EventArgs e)
        {
            List<Product> listProduct = (List<Product>)Application["listProduct"];

            int productId = Request.QueryString["id"] == null ? 1 : int.Parse(Request.QueryString["id"]);
            Product pr = fs.FindProduct(listProduct, productId);

            productpage__container.InnerHtml = RenderProductpage(pr);

            newproduct__slider.InnerHtml = fs.RenderProductsSlider((int)Session["userID"], listProduct, "New");
            specialproduct__slider.InnerHtml = fs.RenderProductsSlider((int)Session["userID"], listProduct, "Special");
        }

        protected string RenderProductpage(Product pr)
        {
            string[] alts = pr.Alts.Split(',');
            return $@"
                <div class='productpage__container flex cl-gap'>
                    <div class='col-5 col-sm-12 pd-gap'>
                        <div class='productpage__slider-container'>
                            <div class='productpage__mainimg'>
                                <img src='assets/image/{alts[0]}' alt='{alts[0]}'>
                            </div>
                            <div class='productpage__slider'>
                                <div class='swiper'>
                                    <div class='swiper-wrapper'>
                                        {RenderProductpageSlider(alts)}
                                    </div>
                                </div>
                                <div class='productpage__navigation'>
                                    <i class='fas fa-long-arrow-alt-left swiper-prev'></i>
                                    <i class='fas fa-long-arrow-alt-right swiper-next'></i>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class='col-7 col-sm-12 pd-gap'>
                        <div class='productpage__detail'>
                            <h1 class='productpage__name'>{pr.Name}</h1>
                            <div class='productpage__price-box'>
                                <span class='productpage__price'>${pr.Price:0.00}</span>
                                <span class='productpage__price-sale'>${(pr.Price * (1 - (pr.Discount / 100))):0.00}</span>
                                <span class='productpage__discount'>Save {pr.Discount}%</span>
                            </div>
                            <p class='productpage__desc'>{pr.Desc}</p>
                            <div class='productpage__size'>
                                <span class='action__title'>Size</span>
                                <span class='action__item size-item'>{pr.Size}mm</span>
                            </div>
                            <div class='productpage__color'>
                                <span class='action__title'>Color</span>
                                <div class='action__item color-item color-{pr.Color.ToLower()}'></div>
                            </div>
                            <div class='productpage__action'>
                                <div class='productpage__quantity'>
                                    <div class='quantity'>
                                        <input type='text' name='qty' value='1' class='quantity__input'>
                                        <div class='quantity__btns'>
                                            <i class='fas fa-angle-up quantity-up'></i>
                                            <i class='fas fa-angle-down quantity-down'></i>
                                        </div>
                                    </div>
                                    {((int)Session["userID"] == -1 ?
                                    "<a class='button button-gb addCart' href='SignIn.aspx'>Add To Cart</a>" :
                                    $"<button type='submit' name='order' value='{pr.Id}' class='button button-gb addCart'>Add To Cart</button>")}
                                </div>
                            </div>
                            <div class='productpage__social'>
                                <a href='#' class='social-item facebook-icon'>
                                    <i class='fab fa-facebook-f'></i>
                                </a>
                                <a href='#' class='social-item twitter-icon'>
                                    <i class='fab fa-twitter'></i>
                                </a>
                                <a href='#' class='social-item google-icon'>
                                    <i class='fab fa-google-plus-g'></i>
                                </a>
                                <a href='#' class='social-item instagram-icon'>
                                    <i class='fab fa-instagram'></i>
                                </a>
                            </div>
                            <div class='productpage__reassurance'>
                                <div class='reassurance-item'>
                                    <i class='fas fa-shield-alt'></i>
                                    Security policy (edit with Customer reassurance module)
                                </div>
                                <div class='reassurance-item'>
                                    <i class='fas fa-truck-moving'></i>
                                    Delivery policy (edit with Customer reassurance module)
                                </div>
                                <div class='reassurance-item'>
                                    <i class='fas fa-exchange-alt'></i>
                                    Return policy (edit with Customer reassurance module)
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class='detail-product flex'>
                        <div class='col-6 col-md-12 pd-gap'>
                            <div class='detail-product__desc'>
                                <h2>DESCRIPTION</h2>
                                <div class='product__desc-wrapper'>
                                    <p>The especially dramatic and enduring design concept of the OMEGA Constellation line is characterized by its famous “Griffes”, or claws, and striking dials.</p>
                                    <p>This model features a grey lacquered dial decorated with a feathered pattern. The dial is complete with 11 diamond indexes and a date window at 6 o'clock.</p>
                                    <p>The diamond-set, stainless steel bezel is mounted on a 27 mm stainless steel casebody and is presented on a stainless steel bracelet. This timepiece is powered by the OMEGA Co-Axial calibre 8520.</p>
                                    <p>In this 44.25 mm model, the Speedmaster's lunar history is celebrated on the blackened movement, which has been laser-ablated to represent the moon's surface. The near side can be seen through the blackened skeletonised dial, while the far side can be seen through the caseback.</p>
                                </div>
                            </div>
                        </div>
                        <div class='col-6 col-md-12 pd-gap'>
                            <div class='detail-product__info'>
                                <div class='product-info-item'>
                                    <h3 class='product-info__title'>5-YEAR WARRANTY</h3>
                                    <div class='product-info__desc'>
                                        <p>All OMEGA watches are delivered with a 5-year warranty that covers the repair of any material or manufacturing defects. Please refer to the operating instructions for specific information about the warranty conditions and restrictions.</p>
                                    </div>
                                </div>
                                <div class='product-info-item'>
                                    <h3 class='product-info__title'>TECHNICAL DATA</h3>
                                    <div class='product-info__desc'>
                                        <p><b>Between lugs:</b> 18 mm</p>
                                        <p><b>Bracelet:</b> steel</p>
                                        <p><b>Case:</b> Steel</p>
                                        <p><b>Case diameter:</b> 27 mm</p>
                                        <p><b>Dial colour:</b> Grey</p>
                                        <p><b>Crystal:</b> Domed scratch-resistant sapphire crystal with anti-reflective treatment on both sides</p>
                                        <p><b>Water resistance:</b> 10 bar (100 metres / 330 feet)</p>
                                        <p><b>Movement Type:</b> Self winding</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            ";
        }

        protected string RenderProductpageSlider(string[] alts)
        {
            string htmls = "";

            for (int i=0; i<alts.Length; i++)
            {
                htmls += $@"
                    <div class='productpage-item {(i==0 ? "active" : "")} swiper-slide'>
                        <div class='productpage__img'>
                            <img src='assets/image/{alts[i]}' alt='{alts[i]}'>
                        </div>
                    </div>
                ";
            }

            return htmls;
        }
    }
}