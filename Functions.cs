using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTL1
{
    public class Functions
    {
        public Product FindProduct(List<Product> listProduct, int idFind)
        {
            Product pr = new Product();

            foreach (Product item in listProduct)
            {
                if (item.Id == idFind)
                {
                    pr = item;
                    break;
                }
            }

            return pr;
        }

        public string RenderProducts(int userID, List<Product> listProduct, string searchStr, string sortType, string typeFind, string colorFind, string sizeFind, string priceFind)
        {
            searchStr = searchStr == null ? "" : searchStr;
            sortType = sortType == null ? "" : sortType;
            colorFind = colorFind == null ? "" : colorFind;
            sizeFind = sizeFind == null ? "" : sizeFind;
            priceFind = priceFind == null ? "" : priceFind;
            string htmls = "";

            switch (sortType)
            {
                case "atoz":
                    listProduct = listProduct.OrderBy(item => item.Name).ToList();
                    break;
                case "ztoa":
                    listProduct = listProduct.OrderByDescending(item => item.Name).ToList();
                    break;
                case "ltoh":
                    listProduct = listProduct.OrderBy(item => (item.Price * (1 - (item.Discount / 100)))).ToList();
                    break;
                case "htol":
                    listProduct = listProduct.OrderByDescending(item => (item.Price * (1 - (item.Discount / 100)))).ToList();
                    break;
            }

            foreach (Product pr in listProduct)
            {
                bool checkColor = false;
                string[] colors = colorFind.Split('-');
                foreach (string color in colors)
                {
                    if (pr.Color.IndexOf(color) != -1)
                    {
                        checkColor = true;
                        break;
                    }
                }

                bool checkSize = false;
                string[] sizes = sizeFind.Split('-');
                if (sizes[0] != "")
                {
                    foreach (string size in sizes)
                    {
                        if (pr.Size.Equals(float.Parse(size)))
                        {
                            checkSize = true;
                            break;
                        }
                    }
                } 
                else
                    checkSize = true;

                bool checkPrice = true;
                string[] prices = priceFind.Split('-');
                double price = pr.Price * (1 - (pr.Discount / 100));
                if (prices.Length == 2)
                {
                    checkPrice = double.Parse(prices[0]) <= price;
                    if (prices[1] != "inf")
                    {
                        checkPrice = (checkPrice && price <= double.Parse(prices[1]));
                    }
                }

                if (pr.Name.ToLower().Contains(searchStr.ToLower().Trim()) && (pr.Type.IndexOf(typeFind) != -1) && checkColor && checkSize && checkPrice)
                {
                    htmls += RenderProduct(userID, pr);
                }
            }

            return htmls;
        }

        public string RenderProductsSlider(int userID, List<Product> listProduct, string typeFind)
        {
            string htmls = "<div class='swiper'> <div class='swiper-wrapper'>";

            foreach (Product pr in listProduct)
            {
                if (pr.Type.IndexOf(typeFind) != -1)
                {
                    htmls += RenderProductSlider(userID, pr);
                }
            }

            htmls += "</div> </div>";

            return htmls;
        }

        public string RenderProduct(int userID, Product pr)
        {
            string[] alts = pr.Alts.Split(',');
            return $@"
                <div class='col-4 col-sm-6 col-pr-12 pd-gap'>
                    <div class='product-item'>
                        <div class='product__thumb-container'>
                            <a href='DetailProduct.aspx?id={pr.Id}' class='product__img'>
                                <img src='assets/image/{alts[0]}' alt='{alts[0]}' class='img-main'>
                                <img src='assets/image/{alts[1]}' alt='{alts[1]}' class='img-secondary'>
                            </a>
                            <div class='product__functions'>
                                <a href='DetailProduct.aspx?id={pr.Id}' class='product__quickview'>
                                    <i class='fas fa-eye'></i>
                                </a>
                                {(userID == -1 ? 
                                $@"
                                    <a class='product__cart' href='SignIn.aspx'>
                                        <i class='fas fa-shopping-cart'></i>
                                    </a>
                                " : 
                                $@"
                                    <button class='product__cart' type='submit' name='order' value='{pr.Id}' formaction='Cart.aspx'>
                                        <i class='fas fa-shopping-cart'></i>
                                    </button>
                                ")}
                            </div>
                        </div>
                        <div class='product__desc'>
                            <div class='product__rating'>
                                {renderStars(pr.Stars)}
                            </div>
                            <a href='DetailProduct.aspx' class='product__name'>{pr.Name}</a>
                            <div class='product__price-box'>
                                {(pr.Discount == 0 ? 
                                $"<span class='product__price-sale'>${pr.Price:0.00}</span>" : 
                                $@"<span class='product__price'>${pr.Price:0.00}</span>
                                <span class='product__price-sale'>${(pr.Price * (1 - (pr.Discount / 100))):0.00}</span>")}                                
                            </div>
                        </div>
                        {(pr.Discount == 0 ? "" :
                        $@"<div class='product__flags'>
                            <span class='product__onsale'>On sale!</span>
                            <span class='product__discount'>-{pr.Discount}%</span>
                        </div>")}
                    </div>
                </div>
                ";
        }

        public string RenderProductSlider(int userID, Product pr)
        {
            string[] alts = pr.Alts.Split(',');
            return $@"
                <div class='product-item swiper-slide'>
                    <div class='product__thumb-container'>
                        <a href='DetailProduct.aspx?id={pr.Id}' class='product__img'>
                            <img src='assets/image/{alts[0]}' alt='{alts[0]}' class='img-main'>
                            <img src='assets/image/{alts[1]}' alt='{alts[1]}' class='img-secondary'>
                        </a>
                        <div class='product__functions'>
                            <a href='DetailProduct.aspx?id={pr.Id}' class='product__quickview'>
                                <i class='fas fa-eye'></i>
                            </a>
                            {(userID == -1 ?
                            $@"
                                <a class='product__cart' href='SignIn.aspx'>
                                    <i class='fas fa-shopping-cart'></i>
                                </a>
                            " :
                            $@"
                                <button class='product__cart' type='submit' name='order' value='{pr.Id}' formaction='Cart.aspx'>
                                    <i class='fas fa-shopping-cart'></i>
                                </button>
                            ")}
                        </div>
                    </div>
                    <div class='product__desc'>
                        <div class='product__rating'>
                            {renderStars(pr.Stars)}
                        </div>
                        <a href='DetailProduct.aspx' class='product__name'>{pr.Name}</a>
                        <div class='product__price-box'>
                            {(pr.Discount == 0 ? 
                            $"<span class='product__price-sale'>${pr.Price:0.00}</span>" : 
                            $@"<span class='product__price'>${pr.Price:0.00}</span>
                            <span class='product__price-sale'>${(pr.Price * (1 - (pr.Discount / 100))):0.00}</span>")}                                
                        </div>
                    </div>
                    {(pr.Discount == 0 ? "" :
                    $@"<div class='product__flags'>
                        <span class='product__onsale'>On sale!</span>
                        <span class='product__discount'>-{pr.Discount}%</span>
                    </div>")}
                </div>
                ";
        }

        public string renderStars(float stars)
        {
            string starsHTML = "";
            for (int i = 1; i <= 5; i++)
            {
                if (i <= stars)
                    starsHTML += " <i class='fas fa-star'></i> ";
                else if (i - stars == 0.5)
                    starsHTML += "<i class='fas fa-star-half-alt'></i> ";
                else
                    starsHTML += "<i class='far fa-star'></i> ";
            }
            return starsHTML;
        }
    }
}