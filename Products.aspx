﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="BTL1.SanPham" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Products</title>
    <link rel="stylesheet" href="assets/css/products.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <main id="main">
        <section class="wrapper">
            <div class="container">
                <div class="flex cl-gap">
                    <div class="col-3 col-md-12 pd-gap">
                        <div class="column-left">
                            <div class="search-filter">
                                <h3 class="search-filter__title flex">
                                    <span>Filter By</span>
                                    <i class="fas fa-times search-filter__close"></i>
                                </h3>
                                <div class="search-filter__content" id="searchFilter" runat="server">
                                    
                                </div>
                            </div>
                            <a href="Products.aspx" class="left-banner hide-md">
                                <img src="assets/image/left-banner-1.png" alt="">
                            </a>
                        </div>
                    </div>
                    <div class="col-9 col-md-12 pd-gap">
                        <div class="column-right">
                            <div class="categories__banner">
                                <img src="assets/image/banner-products.png" alt="">
                            </div>
                            <h3 class="categories__title" id="categories__title" runat="server">Men Watches</h3>
                            <p class="categories__desc">The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable that it has a more-or-less normal distribution of letters.</p>
                            <div class="products">
                                <div class="products__list-sort flex">
                                    <div class="col-6 col-md-12">
                                        <div class="products__list-type flex">
                                            <i class="fas fa-th-large list-icon list-icon-grid active"></i>
                                            <i class="fas fa-th-list list-icon list-icon-list"></i>
                                            <span class="products__list-qty">
                                                There are <span class="list-qty">9</span> products.
                                            </span>
                                        </div>
                                    </div>
                                    <div class="col-6 col-md-12">  
                                        <div class="products__sort flex">
                                            <span class="sort-text">Sort by:</span>
                                            <div class="sort-select">
                                                <div class="sort__title">
                                                    <span class="sort__value">Auto</span>
                                                    <i class="fas fa-caret-down"></i>
                                                </div>
                                                <div class="sort__list">
                                                    <div data-value="auto" class="sort-item">Auto</div>
                                                    <div data-value="atoz" class="sort-item">Name, A to Z</div>
                                                    <div data-value="ztoa" class="sort-item">Name, Z to A</div>
                                                    <div data-value="ltoh" class="sort-item">Price, low to high</div>
                                                    <div data-value="htol" class="sort-item">Price, high to low</div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="search-filter__open">
                                            <div class="button button-gb">Filter</div>
                                        </div>
                                    </div>
                                </div>
                                <div class="products__active-filter flex">
                                    <span class="active-filter__title">Active filtes</span>
                                    <div class="active-filter__list flex">
                                    </div>
                                </div>
                                <form action="/" method="post">
                                    <div class="products__list flex cl-gap" id="products__list" runat="server">
                                    </div>
                                </form>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </main>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="server">
    <script src="assets/javascript/products.js"></script>
</asp:Content>
