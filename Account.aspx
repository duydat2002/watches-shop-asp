﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="Account.aspx.cs" Inherits="BTL1.Account" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Account</title>
    <link rel="stylesheet" href="assets/css/account.css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <main id="main">
        <section class="wrapper" id="account">
            <div class="container">
                <div class="content flex cl-gap">
                    <div class="col-3 col-md-12 pd-gap">
                        <div class="column-left">
                            <div class="block-categories">
                                <h2 class="categories__title section-title" >Account</h2>
                                <div class="categories__list">
                                    <div class="categories-item active" id="profileTitle">
                                        <i class="fas fa-id-card categories-icon"></i>
                                        My Profile
                                    </div>
                                    <div class="categories-item" id="contactTitle">
                                        <i class="fas fa-map-marked-alt categories-icon"></i>
                                        My Contact
                                    </div>
                                    <div class="categories-item" id="change-passwordTitle">
                                        <i class="fas fa-key categories-icon"></i>
                                        Change Password
                                    </div>
                                </div>
                            </div>
                            <a href="Products.aspx" class="left-banner hide-md">
                                <img src="assets/image/left-banner-1.png" alt="">
                            </a>
                        </div>
                    </div>
                    <div class="col-9 col-md-12 pd-gap">
                        <div class="column-right">
                            <form action="#" method="post" class="form-account" runat="server">
                                <div class="tab-container">
                                    <div class="tab-item profile__container active" id="profile">
                                        <h2 class="section-title">My Profile</h2>
                                        <div class="form-container">
                                            <div id="profileMessage_box" runat="server">
                                            </div>
                                            <div class="sign-form" id="profileForm" runat="server">
                                            </div>
                                        </div>
                                    </div>
                                    <div class="tab-item address__container" id="contact">
                                        <h2 class="section-title">My Contact</h2>
                                        <div class="form-container">
                                            <div id="contactMessage_box" runat="server">
                                            </div>
                                            <div class="sign-form">
                                                <input class="form-control" name="ordernumber" type="text" style="display: none;">
                                                <div class="form-group">
                                                    <div class="flex ai-center">
                                                        <label class="form-label">Phone Number</label>
                                                        <div class="form-input-box">
                                                            <input class="form-control" name="phonenumber" type="text">
                                                        </div>
                                                    </div>
                                                    <div class="flex">
                                                        <div class="form-label"></div>
                                                        <span class="form-error" id="phonenumber_error"></span>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <div class="flex ai-center">
                                                        <label class="form-label">Address</label>
                                                        <div class="form-input-box">
                                                            <input class="form-control" name="address" type="text">
                                                        </div>
                                                    </div>
                                                    <div class="flex">
                                                        <div class="form-label"></div>
                                                        <span class="form-error" id="address_error"></span>
                                                    </div>
                                                </div>
                                                <button type="submit" name="saveContact" value="saveContact" class="button button-gb sign-btn" formaction="Account.aspx?tab=contact" onclick='return validateContact()'>Save</button>
                                                <button type="submit" name="editContact" value="editContact" class="button button-gb sign-btn" formaction="Account.aspx?tab=contact" onclick='return validateContact()'>Edit</button>
                                            </div>
                                        </div>
                                        <div class="contact-list__container">
                                            <h2 class="section-title">Contact List</h2>
                                            <div class="contact-list" id="contact_list" runat="server">
                                                
                                            </div>
                                        </div>
                                    </div>
                                    <div class="tab-item change-password__container" id="change-password">
                                        <h2 class="section-title">Change Password</h2>
                                        <div class="form-container">
                                            <div id="passwordMessage_box" runat="server">
                                            </div>
                                            <div class="sign-form">
                                            <div class="form-group">
                                                <div class="flex ai-center">
                                                    <label class="form-label">Current Password</label>
                                                    <div class="form-input-box">
                                                        <div class="form-input-password">
                                                            <input class="form-control form-control-password" name="password" type="password" autocomplete="new-password">
                                                            <span class="form-password-btn">
                                                                <i class="fas fa-eye"></i>
                                                            </span>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="flex">
                                                    <div class="form-label"></div>
                                                    <span class="form-error" id="current_password_error"></span>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <div class="flex ai-center">
                                                    <label class="form-label">New Password</label>
                                                    <div class="form-input-box">
                                                        <div class="form-input-password">
                                                            <input class="form-control form-control-password" name="newpassword" type="password">
                                                            <span class="form-password-btn">
                                                                <i class="fas fa-eye"></i>
                                                            </span>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="flex">
                                                    <div class="form-label"></div>
                                                    <span class="form-error" id="newpassword_error"></span>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <div class="flex ai-center">
                                                    <label class="form-label">New Password Comfirmation</label>
                                                    <div class="form-input-box">
                                                        <div class="form-input-password">
                                                            <input class="form-control form-control-password" name="re_newpassword" type="password">
                                                            <span class="form-password-btn">
                                                                <i class="fas fa-eye"></i>
                                                            </span>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="flex">
                                                    <div class="form-label"></div>
                                                    <span class="form-error" id="re_newpassword_error"></span>
                                                </div>
                                            </div>
                                            <button type="submit" name="changePassword" value="changePassword" class="button button-gb sign-btn" formaction="Account.aspx?tab=change-password" onclick='return validatePassword()'>Save</button>
                                            <p class="form-text-bottom">Have a good day <3</p>
                                        </div>
                                        </div>
                                    </div>
                                </div>
                            </form>
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
