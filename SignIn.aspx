<%@ Page Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="SignIn.aspx.cs" Inherits="BTL1.SignIn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Sign In</title>
    <link rel="stylesheet" href="assets/css/account.css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <main id="main">
        <section class="wrapper">
            <div class="container">
                <div class="content flex cl-gap">
                    <div class="col-3 col-md-12 pd-gap">
                        <div class="column-left">
                            <div class="block-categories">
                                <h2 class="categories__title section-title" >Categories</h2>
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
                                <h2 class="section-title">Log In To Your Account</h2>
                                <div class="form-container">
                                    <form action="#" method="post" onsubmit="return validateSignIn()" runat="server">
                                        <div id="signinError_box" runat="server">
                                        </div>
                                        <div class="form-group">
                                            <div class="flex ai-center">
                                                <label class="form-label">Email</label>
                                                <div class="form-input-box">
                                                    <input class="form-control" name="email" id="email" type="email">
                                                </div>
                                            </div>
                                            <div class="felx">
                                                <div class="form-label"></div>
                                                <span class="form-error" id="email_error"></span>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <div class="flex ai-center">
                                                <label class="form-label">Password</label>
                                                <div class="form-input-box">
                                                    <div class="form-input-password">
                                                        <input class="form-control form-control-password" name="password" type="password" id="password">
                                                        <span class="form-password-btn">
                                                            <i class="fas fa-eye"></i>
                                                        </span>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="flex">
                                                <div class="form-label"></div>
                                                <span class="form-error" id="password_error"></span>
                                            </div>
                                        </div>
                                        <p class="form-text-top"><a href="ForgotPassword.aspx" class="form-link">Forgot your password?</a></p>
                                        <button type="submit" name="signin" value="signin" class="button button-gb sign-btn">Sign In</button>
                                        <p class="form-text-bottom">No account? <a href="SignUp.aspx" class="form-link">Create one here</a></p>
                                    </form>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </main>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="server">
    <script src="assets/javascript/account.js"></script>
</asp:Content>