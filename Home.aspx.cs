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
    public partial class TrangChu : System.Web.UI.Page
    {
        Functions fs = new Functions();

        protected void Page_Load(object sender, EventArgs e)
        {
            List<Product> listProduct = (List<Product>)Application["listProduct"];

            newproduct__slider.InnerHtml = fs.RenderProductsSlider((int)Session["userID"], listProduct, "New");
            specialproduct__slider.InnerHtml = fs.RenderProductsSlider((int)Session["userID"], listProduct, "Special");

            int men_qty = 0, women_qty = 0, luxury_qty = 0, sport_qty = 0;
            foreach (Product pr in listProduct)
            {
                if (pr.Type.ToLower().Contains("men"))
                    men_qty++;
                if (pr.Type.ToLower().Contains("women"))
                    women_qty++;
                if (pr.Type.ToLower().Contains("luxury"))
                    luxury_qty++;
                if (pr.Type.ToLower().Contains("sport"))
                    sport_qty++;
            }
            menwatches__qty.InnerHtml = $"{men_qty} Items";
            womenwatches__qty.InnerHtml = $"{women_qty} Items";
            luxurywatches__qty.InnerHtml = $"{luxury_qty} Items";
            sportwatches__qty.InnerHtml = $"{sport_qty} Items";
        } 
    }
}