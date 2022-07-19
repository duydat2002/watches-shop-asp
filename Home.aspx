﻿<%@ Page Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="BTL1.TrangChu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Home</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <main id="main">
        <section class="home-banner">
            <div class="home-banner__slider">
                <div class="swiper">
                    <div class="swiper-wrapper">
                        <div class="home-banner-item swiper-slide">
                            <a href="Products.aspx" class="home-banner__img">
                                <img src="assets/image/Slider-1.png" alt="">
                            </a>
                            <div class="home-banner__text">
                                <p class="home-banner__sale">20% Save</p>
                                <p class="home-banner__title">Latest Smartwatch</p>
                                <p class="home-banner__desc">Lorem ipsum dolor sit amet consectetur adipisicing elit. Quisquam sit doloremque, sequi deleniti reprehenderit ad omnis quis laboriosam!</p>
                                <a href="Products.aspx" class="home-banner__button button button-bg">Shop now</a>
                            </div>
                        </div>
                        <div class="home-banner-item swiper-slide">
                            <a href="Products.aspx"class="home-banner__img">
                                <img src="assets/image/Slider-2.png" alt="">
                            </a>
                            <div class="home-banner__text">
                                <p class="home-banner__sale">20% Save</p>
                                <p class="home-banner__title">Couple Watch</p>
                                <p class="home-banner__desc">Lorem ipsum dolor sit amet consectetur adipisicing elit. Quisquam sit doloremque, sequi deleniti reprehenderit ad omnis quis laboriosam!</p>
                                <a href="Products.aspx" class="home-banner__button button button-bg">Shop now</a>
                            </div>
                        </div>
                    </div>
                    <div class="swiper-navigation">
                        <i class="fas fa-angle-left swiper-prev hide-md"></i>
                        <i class="fas fa-angle-right swiper-next hide-md"></i>
                    </div>
                    <div class="swiper-pagination"></div>
                </div>
            </div>
        </section>
        <section class="section categories">
            <div class="container">
                <div class="categories__container flex cl-gap">
                    <div class="col-3 col-md-12 pd-gap">
                        <div class="categories__box">
                            <div class="categories__desc">
                                <h2 class="categories__title section-title">Categories</h2>
                                <p class="categories__text">Lorem Ipsum Is Simply Dummy Text Of The Printing And Typesetting The Industry's Standard.</p>
                            </div>
                            <div class="categories__navigation">
                                <i class="fas fa-long-arrow-alt-left swiper-prev"></i>
                                <i class="fas fa-long-arrow-alt-right swiper-next"></i>
                            </div>
                        </div>
                    </div>
                    <div class="col-9 col-md-12 pd-gap">
                        <div class="categories__slider">
                            <div class="swiper">
                                <div class="swiper-wrapper">
                                    <div class="categories-item swiper-slide">
                                        <a href="Products.aspx?type=men-watches" class="categories__img">
                                            <img src="assets/image/Categories-1.png" alt="">
                                        </a>
                                        <div class="categories__desc">
                                            <a href="Products.aspx?type=men-watches" class="categories__name">Men Watches</a>
                                            <span class="categoies__qty" id="menwatches__qty" runat="server">0 Items</span>
                                            <span></span>
                                        </div>
                                    </div>
                                    <div class="categories-item swiper-slide">
                                        <a href="Products.aspx?type=women-watches" class="categories__img">
                                            <img src="assets/image/Categories-2.png" alt="">
                                        </a>
                                        <div class="categories__desc">
                                            <a href="Products.aspx?type=women-watches" class="categories__name">Women Watches</a>
                                            <span class="categoies__qty" id="womenwatches__qty" runat="server">0 Items</span>
                                        </div>
                                    </div>
                                    <div class="categories-item swiper-slide">
                                        <a href="Products.aspx?type=luxury-watches" class="categories__img">
                                            <img src="assets/image/Categories-3.png" alt="">
                                        </a>
                                        <div class="categories__desc">
                                            <a href="Products.aspx?type=luxury-watches" class="categories__name">Luxury Watches</a>
                                            <span class="categoies__qty" id="luxurywatches__qty" runat="server">0 Items</span>
                                        </div>
                                    </div>
                                    <div class="categories-item swiper-slide">
                                        <a href="Products.aspx?type=sport-watches" class="categories__img">
                                            <img src="assets/image/Categories-4.png" alt="">
                                        </a>
                                        <div class="categories__desc">
                                            <a href="Products.aspx?type=sport-watches" class="categories__name">Sport Watches</a>
                                            <span class="categoies__qty" id="sportwatches__qty" runat="server">0 Items</span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
        <section class="service">
            <div class="container">
                <div class="service__container flex">
                    <div class="col-4 col-sm-12">
                        <div class="service-item item-1 has-separate flex">
                            <div class="service__icon"></div>
                            <div class="service__content">
                                <p class="service__name">Free delivery</p>
                                <p class="service__desc">Free shipping on all order</p>
                            </div>
                        </div>
                    </div>
                    <div class="col-4 col-sm-12">
                        <div class="service-item item-2 has-separate flex">
                            <div class="service__icon"></div>
                            <div class="service__content">
                                <p class="service__name">Money return</p>
                                <p class="service__desc">Back guarantee in 7 days</p>
                            </div>
                        </div>
                    </div>
                    <div class="col-4 col-sm-12">
                        <div class="service-item item-3 flex">
                            <div class="service__icon"></div>
                            <div class="service__content">
                                <p class="service__name">Member Discount</p>
                                <p class="service__desc">Onevery order over $130.00</p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
        <section class="section newproduct">
            <div class="newproduct__container container">
                <div class="product__container">
                    <a href="Products.aspx?type=new-watches" class="product__title">New products</a>
                    <form action="Cart.aspx" method="post">
                        <div class="newproduct__slider product__slider" id="newproduct__slider" runat="server">
                        </div>
                    </form>
                    <div class="product__navigation">
                        <i class="fas fa-long-arrow-alt-left swiper-prev"></i>
                        <i class="fas fa-long-arrow-alt-right swiper-next"></i>
                    </div>
                </div>
            </div>
        </section>
        <section class="banner">
            <div class="container">
                <div class="banner__row row-1 flex cl-gap">
                    <div class="col-8 col-sm-12 pd-gap">
                        <div class="banner-item">
                            <a href="Products.aspx" class="banner__img">
                                <img src="assets/image/Banner-1.png" alt="">
                            </a>
                            <div class="banner__text text-1">
                                <p class="banner__text-title">
                                    Latest Smart
                                    <br>
                                    Watch Collection
                                </p>
                                <a href="Products.aspx" class="banner__button button button-wg">Shop now</a>
                            </div>
                        </div>
                    </div>
                    <div class="col-4 hide-sm pd-gap">
                        <div class="banner-item">
                            <a href="Products.aspx" class="banner__img">
                                <img src="assets/image/Banner-2.png" alt="">
                            </a>
                            <div class="banner__text text-2">
                                <span class="banner__text-discount">Up to 40% discount</span>
                                <p class="banner__text-title">Girls Watch Collection</p>
                                <a href="Products.aspx" class="banner__button button button-wg">Shop now</a>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="banner__row row-2 flex cl-gap">
                    <div class="col-4 hide-sm pd-gap">
                        <div class="banner-item">
                            <a href="Products.aspx" class="banner__img">
                                <img src="assets/image/Banner-3.png" alt="">
                            </a>
                        </div>
                    </div>
                    <div class="col-8 col-sm-12 pd-gap">
                        <div class="banner-item">
                            <a href="Products.aspx" class="banner__img">
                                <img src="assets/image/Banner-4.png" alt="">
                            </a>
                            <div class="banner__text text-1">
                                <span class="banner__text-discount">30% Discount</span>
                                <p class="banner__text-title">
                                    Black Couple
                                    <br>
                                    Watch Collection
                                </p>
                                <a href="Products.aspx" class="banner__button button button-wg">Shop now</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
        <section class="section specialproduct">
            <div class="specialproduct__container container">
                <div class="product__container">
                    <a href="Products.aspx?type=special-watches" class="product__title">Special products</a>
                    <form action="/" method="post">
                        <div class="specialproduct__slider product__slider" id="specialproduct__slider" runat="server">
                        </div>
                    </form>
                    <div class="product__navigation">
                        <i class="fas fa-long-arrow-alt-left swiper-prev"></i>
                        <i class="fas fa-long-arrow-alt-right swiper-next"></i>
                    </div>
                </div>
            </div>
        </section>
        <section class="brand">
            <div class="brand__container container">
                <div class="brand__slider">
                    <div class="swiper">
                        <div class="swiper-wrapper">
                            <div class="brand-item swiper-slide">
                                <a href="Products.aspx" class="brand__img">
                                    <img src="assets/image/Brand-1.png" alt="">
                                </a>
                            </div>
                            <div class="brand-item swiper-slide">
                                <a href="Products.aspx" class="brand__img">
                                    <img src="assets/image/Brand-2.png" alt="">
                                </a>
                            </div>
                            <div class="brand-item swiper-slide">
                                <a href="Products.aspx" class="brand__img">
                                    <img src="assets/image/Brand-3.png" alt="">
                                </a>
                            </div>
                            <div class="brand-item swiper-slide">
                                <a href="Products.aspx" class="brand__img">
                                    <img src="assets/image/Brand-4.png" alt="">
                                </a>
                            </div>
                            <div class="brand-item swiper-slide">
                                <a href="Products.aspx" class="brand__img">
                                    <img src="assets/image/Brand-5.png" alt="">
                                </a>
                            </div>
                            <div class="brand-item swiper-slide">
                                <a href="Products.aspx" class="brand__img">
                                    <img src="assets/image/Brand-6.png" alt="">
                                </a>
                            </div>
                            <div class="brand-item swiper-slide">
                                <a href="Products.aspx" class="brand__img">
                                    <img src="assets/image/Brand-7.png" alt="">
                                </a>
                            </div>
                        </div>
                        <div class="brand__navigation">
                            <i class="fas fa-long-arrow-alt-left swiper-prev"></i>
                            <i class="fas fa-long-arrow-alt-right swiper-next"></i>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </main>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="server">

</asp:Content>