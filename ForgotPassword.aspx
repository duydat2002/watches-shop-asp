<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="BTL1.ForgotPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="assets/css/account.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <main id="main">
        <section class="wrapper">
            <div class="container">
                <div class="content flex cl-gap">
                    <div class="col-3 col-md-12 pd-gap">
                        <div class="column-left">
                            <div class="block-categories">
                                <h2 class="categories__title section-title">Categories</h2>
                                <div class="categories__list">
                                    <a href="Products.aspx" class="categories-item">Men Watches</a>
                                    <a href="Products.aspx" class="categories-item">Women Watches</a>
                                    <a href="Products.aspx" class="categories-item">Sport Watches</a> 
                                    <a href="Products.aspx" class="categories-item">Luxury Watches</a> 
                                </div>
                            </div>
                            <a href="Products.aspx" class="left-banner hide-md">
                                <img src="assets/image/left-banner-1.png" alt="">
                            </a>
                        </div>
                    </div>
                    <div class="col-9 col-md-12 pd-gap">
                        <div class="column-right">
                            <div class="signup__container">
                                <h2 class="section-title">Forgot Your Password?</h2>
                                <form action="#" method="post" class="sign-form">
                                    <p class="form-text">
                                        Please enter the email address you used to register. You will receive a temporary link to reset your password.
                                    </p>
                                    <div class="form-group">
                                        <div class="flex ai-center">
                                            <label class="form-label">Email</label>
                                            <div class="form-input-box">
                                                <input class="form-control" name="email" id="email" type="email" required>
                                            </div>
                                        </div>
                                        <div class="felx">
                                            <div class="form-label"></div>
                                            <span class="form-error" id="email_error" runat="server" ClientIDMode="Static"></span>
                                        </div>
                                    </div>
                                    <button type="submit" class="button button-gb sign-btn">Send Reset Link</button>
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
</asp:Content>
