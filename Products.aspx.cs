using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTL1
{
    public partial class SanPham : System.Web.UI.Page
    {
        Functions fs = new Functions();

        protected void Page_Load(object sender, EventArgs e)
        {
            string typeFind = "";
            switch(Request.QueryString["type"])
            {
                case "men-watches":
                    categories__title.InnerHtml = "Men Watches";
                    typeFind = "Men";
                    break;
                case "women-watches":
                    categories__title.InnerHtml = "Women Watches";
                    typeFind = "Women";
                    break;
                case "sport-watches":
                    categories__title.InnerHtml = "Sport Watches";
                    typeFind = "Sport";
                    break;
                case "luxury-watches":
                    categories__title.InnerHtml = "Luxury Watches";
                    typeFind = "Luxury";
                    break;
                case "new-watches":
                    categories__title.InnerHtml = "New Watches";
                    typeFind = "New";
                    break;
                case "special-watches":
                    categories__title.InnerHtml = "Special Watches";
                    typeFind = "Special";
                    break;
                default:
                    categories__title.InnerHtml = "Watches";
                    break;
            }

            List<Product> listProduct = (List<Product>)Application["listProduct"];

            products__list.InnerHtml = fs.RenderProducts((int)Session["userID"], listProduct, Request.QueryString["search"], Request.QueryString["sort"], typeFind, Request.QueryString["color"], Request.QueryString["size"], Request.QueryString["price"]);

            searchFilter.InnerHtml = renderFilters(listProduct, Request.QueryString["search"], typeFind);
        }

        protected string renderFilters(List<Product> listProduct, string searchStr, string typeFind)
        {
            List<string> colors = new List<string>() { "Black", "White", "Sliver", "Gold", "Blue", "Green", "Red", "Brown", "Pink", "Purple" };
            int[] colorCounts = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            List<float> sizes = new List<float>() { 36, 39, 40, 43, 45 };
            int[] sizeCounts = { 0, 0, 0, 0, 0, 0 };

            searchStr = searchStr == null ? "" : searchStr;

            foreach (Product pr in listProduct)
            {
                if (pr.Type.IndexOf(typeFind) != -1 && pr.Name.ToLower().Contains(searchStr.ToLower().Trim()))
                {
                    foreach (string color in colors)
                    {
                        if (color == pr.Color)
                        {
                            colorCounts[colors.IndexOf(color)]++;
                        }
                    }

                    foreach (float size in sizes)
                    {
                        if (size == pr.Size)
                        {
                            sizeCounts[sizes.IndexOf(size)]++;
                        }
                    }
                }
            }

            string colorHtml = "";
            string sizeHtml = "";
            foreach (string color in colors)
            {
                colorHtml += $@"
                    <div class='filter__item' data-value='{color}'>
                        <span class='color__box color-{color.ToLower()}''>
                            <i class='fas fa-check filter-check-icon'></i>
                        </span>
                        <span class='color__name'>{color}</span>
                        <span class='color__qty'>({colorCounts[colors.IndexOf(color)]})</span>
                    </div>
                ";
            }

            foreach (float size in sizes)
            {
                sizeHtml += $@"
                    <div class='filter__item' data-value='{size}'>
                        <span class='size__box'>
                            <i class='fas fa-check filter-check-icon'></i>
                        </span>
                        <span class='size__name'>{size}</span>mm
                        <span class='size__qty'>({sizeCounts[sizes.IndexOf(size)]})</span>
                    </div>
                ";
            }

            return $@"
                <a href='Products.aspx' class='search-filter-clearall'>
                    <i class='fas fa-times'></i>
                    Clear All
                </a>
                <div class='filter__color'>
                    <h4 class='filter__title'>Color</h4>
                    <div class='filter__desc'>
                        {colorHtml}
                    </div>
                </div>
                <div class='filter__price'>
                    <h4 class='filter__title'>Price</h4>
                    <div class='filter__desc'>
                        <div class='filter__price-input flex'>
                            <input type='number' name='priceFrom' min='0'  placeholder='$ From'>
                            <div class='seperate'>-</div>
                            <input type='number' name='priceTo' min='0'  placeholder='$ To'>
                        </div>
                    </div>
                </div>
                <div class='filter__size'>
                    <h4 class='filter__title'>Size</h4>
                    <div class='filter__desc'>
                        {sizeHtml}
                    </div>
                </div>
                <div class='button button-gb filter__price-btn'>Apply</div>
            ";
        }
    }
}