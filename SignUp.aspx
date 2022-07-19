﻿<%@ Page Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="BTL1.SignUp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Sign Up</title>
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
                                <h2 class="section-title">Create An Account</h2>
                                <div class="form-container">
                                    <form method="post" onsubmit="return validateSignUp()" runat="server">
                                        <div id="signupError_box" runat="server">
                                        </div>
                                        <div class="form-group">
                                            <div class="flex ai-center">
                                                <label class="form-label required-input">First name</label>
                                                <div class="form-input-box">
                                                    <input class="form-control" name="firstname" id="firstname"  type="text">
                                                </div>
                                            </div>
                                            <div class="flex">
                                                <div class="form-label"></div>
                                                <span class="form-error" id="firstname_error"></span>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <div class="flex ai-center">
                                                <label class="form-label required-input">Last name</label>
                                                <div class="form-input-box">
                                                    <input class="form-control" name="lastname" id="lastname" type="text">
                                                </div>
                                            </div>
                                            <div class="flex">
                                                <div class="form-label"></div>
                                                <span class="form-error" id="lastname_error"></span>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <div class="flex ai-center">
                                                <label class="form-label required-input">Email</label>
                                                <div class="form-input-box">
                                                    <input class="form-control" name="email" id="email" type="text">
                                                </div>
                                            </div>
                                            <div class="flex">
                                                <div class="form-label"></div>
                                                <span class="form-error" id="email_error"></span>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <div class="flex ai-center">
                                                <label class="form-label required-input">Password</label>
                                                <div class="form-input-box">
                                                    <div class="form-input-password">
                                                        <input class="form-control form-control-password" name="password"  type="password" id="password" autocomplete="new-password">
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
                                        <div class="form-group">
                                            <div class="flex ai-center">
                                                <label class="form-label">Birthdate</label>
                                                <div class="form-input-box">
                                                    <input class="form-control" name="birthdate" type="date" id="birthdate">
                                                </div>
                                            </div>
                                            <div class="flex">
                                                <div class="form-label"></div>
                                                <span class="form-error" id="birthdate_error"></span>
                                            </div>
                                        </div>
                                        <div class="form-group social-group">
                                            <div class="flex ai-center">
                                                <label class="form-label required-input">Social title</label>
                                                <div class="form-input-box">
                                                    <input class="form-social" name="sex" 
                                                    id="social-male" type="radio" value="male" checked>
                                                    <label for="social-male"> Mr</label>
                                                    <input class="form-social" name="sex" 
                                                    id="social-female" type="radio" value="female">
                                                    <label for="social-female"> Mrs</label>
                                                </div>
                                            </div>
                                        </div>
                                        <p class="form-text-top">Already have an account? <a href="SignIn.aspx" class="form-link">Log in instead!</a></p>
                                        <button type="submit" name="signup" value="signup" class="button button-gb sign-btn">Save</button>
                                        <p class="form-text-bottom">Have a good day <3</p>
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