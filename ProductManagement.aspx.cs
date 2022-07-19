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
    public partial class ProductManagement : System.Web.UI.Page
    {
        Functions fs = new Functions();

        protected void Page_Load(object sender, EventArgs e)
        {
            //if ((bool)Session["isAdmin"] != true)
            //{
            //    Response.Redirect("Home.aspx");
            //}

            List<Product> listProduct = (List<Product>)Application["listProduct"];
            productError_box.InnerHtml = "";

            if (IsPostBack)
            {
                if (Request.Form["save"] == "Save")
                {
                    bool check = true;

                    foreach(Product pr in listProduct) {
                        if (pr.Name.ToLower() == Request.Form["name"].ToLower())
                        {
                            productError_box.InnerHtml = "<span class='alert-server alert-server-error'>Tên sản phẩm đã có.</span>";
                            check = false;
                        }
                    }

                    if (check)
                    {
                        HttpFileCollection files = Request.Files;
                        for (int i = 0; i < files.Count; i++)
                        {
                            HttpPostedFile f = files[i];
                            if (f.FileName != "")
                                f.SaveAs(Server.MapPath("~/assets/image/") + f.FileName);
                        }

                        Product pr = new Product(
                            listProduct[listProduct.Count - 1].Id + 1,
                            Request.Form["name"],
                            double.Parse(Request.Form["price"]),
                            float.Parse(Request.Form["discount"]),
                            Request.Form["desc"],
                            Request.Form["alts"],
                            float.Parse(Request.Form["size"]),
                            Request.Form["color"],
                            Request.Form["stars"] == "" ? 0 : float.Parse(Request.Form["stars"]),
                            Request.Form["type"],
                            100
                        );
                        listProduct.Add(pr);
                    }
                }

                if (Request.Form["edit"] == "Edit" && Request.Form["id"] != null)
                {
                    foreach (Product pr in listProduct)
                    {
                        if (int.Parse(Request.Form["id"]) == pr.Id)
                        {
                            pr.Name = Request.Form["name"];
                            pr.Price = double.Parse(Request.Form["price"]);
                            pr.Discount = float.Parse(Request.Form["discount"]);
                            pr.Desc = Request.Form["desc"];
                            pr.Alts = Request.Form["alts"];
                            pr.Size = float.Parse(Request.Form["size"]);
                            pr.Color = Request.Form["color"];
                            pr.Stars = float.Parse(Request.Form["stars"]);
                            pr.Type = Request.Form["type"];
                            break;
                        }
                    }
                }

                if (Request.Form["delete"] != null)
                {
                    foreach (Product pr in listProduct)
                    {
                        if (int.Parse(Request.Form["delete"]) == pr.Id)
                        {
                            listProduct.Remove(pr);
                            break;
                        }
                    }
                }

                XmlSerializer xml = new XmlSerializer(typeof(List<Product>));
                FileStream file = File.Create(Server.MapPath("listProduct.xml"));
                xml.Serialize(file, listProduct);
                file.Close();
            }

            product_list.InnerHtml = RenderProducts(listProduct);
        }

        public string RenderProducts(List<Product> listProduct)
        {
            List<Product> listProductCopy = new List<Product>(listProduct);
            string htmls = "";

            listProductCopy.Reverse();
            foreach (Product pr in listProductCopy)
            {
                string[] alts = pr.Alts.Split(',');
                htmls += $@"
                    <div class='product-item flex cl-gap'>
                        <div class='col-2 col-md-4 col-sm-12 pd-gap'>
                            <a href='DetailProduct.aspx?id={pr.Id}' class='product__img'>
                                <img src='assets/image/{alts[0]}' alt='{alts[0]}'>
                            </a>
                        </div>
                        <div class='col-8 col-sm-12 pd-gap'>
                            <div class='product__detail'>
                                <a href='DetailProduct.aspx?id={pr.Id}' class='product__name'>{pr.Name}</a>
                                <div class='product__rating'>
                                    {fs.renderStars(pr.Stars)}
                                </div>
                                <div class='product__price-box'>
                                    {(pr.Discount == 0 ?
                                    $"<span class='product__price-sale'>${pr.Price:0.00}</span>" :
                                    $@"<span class='product__price'>${pr.Price:0.00}</span>
                                    <span class='product__price-sale'>${(pr.Price * (1 - (pr.Discount / 100))):0.00}</span>")}   
                                    <span class='product__discount'>Save {pr.Discount}%</span>
                                </div>
                                <p class='product__desc'>{pr.Desc}</p>
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
                        <div class='col-2 col-md-4 col-sm-12 pd-gap'>
                            <div class='product__action'>
                                <a href='ProductManagement.aspx?id={pr.Id}&name={pr.Name}&price={pr.Price}&discount={pr.Discount}&desc={pr.Desc}&alts={pr.Alts}&size={pr.Size}&color={pr.Color}&stars={pr.Stars}&type={pr.Type}' class='product-edit'>Edit</a>
                                <div data-id='{pr.Id}' class='product-delete'>Delete</div>
                            </div>
                        </div>
                    </div>
                ";
            }

            return htmls;
        }
    }
}