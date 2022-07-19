<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="DetailProduct.aspx.cs" Inherits="BTL1.DetailProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
<form action="Cart.aspx" method="post" runat="server">
    <main id="main">
        <section class="wrapper productpage">
            <div class="container" id="productpage__container" runat="server">
                
            </div>
        </section>
        <section class="wrapper newproduct">
            <div class="newproduct__container container">
                <div class="product__container">
                    <a href="Products.aspx?type=new-watches" class="product__title">New products</a>
                    <div class="newproduct__slider product__slider" id="newproduct__slider" runat="server">
                        
                    </div>
                    <div class="product__navigation">
                        <i class="fas fa-long-arrow-alt-left swiper-prev"></i>
                        <i class="fas fa-long-arrow-alt-right swiper-next"></i>
                    </div>
                </div>
            </div>
        </section>
        <section class="wrapper specialproduct">
            <div class="specialproduct__container container">
                <div class="product__container">
                    <a href="Products.aspx?type=special-watches" class="product__title">Special products</a>
                    <div class="specialproduct__slider product__slider" id="specialproduct__slider" runat="server">
                        
                    </div>
                    <div class="product__navigation">
                        <i class="fas fa-long-arrow-alt-left swiper-prev"></i>
                        <i class="fas fa-long-arrow-alt-right swiper-next"></i>
                    </div>
                </div>
            </div>
        </section>
    </main>
</form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="server">
    <script src="assets/javascript/detailProduct.js"></script>
</asp:Content>
