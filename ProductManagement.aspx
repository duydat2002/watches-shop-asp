<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="ProductManagement.aspx.cs" Inherits="BTL1.ProductManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="assets/css/manage.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
<form method="post" enctype="multipart/form-data" runat="server">
    <div class="alertbox alertbox-delete">
        <div class="alertbox-close">
            <i class="fas fa-times"></i>
        </div>
        <div class="alertbox__icon">
            <i class="fas fa-times"></i>
        </div>
        <p class="alertbox__title">Are you sure?</p>
        <p class="alertbox__desc">
            Do you really want to delete this product?
            <br/>
            This process cannot be undone.
        </p>
        <button type="button" class="alertbox__button button-cancel">Cancel</button>
        <button type="submit" name="delete" value="-1" class="alertbox__button button-delete" formnovalidate>Delete</button>
    </div>
    <section class="product-info wrapper">
        <div class="container">
            <div class="product-info__container">
                <h2 class="section-title">Product Information</h2>
                <input type="text" name="id" id="id" style="display: none;" readonly>
                <div id="productError_box" runat="server">
                </div>
                <div class="form-group">
                    <label class="form-label">Name</label>
                    <div class="form-input-box">
                        <input type="text" name="name" id="name" class="form-control">
                        <span class="form-error" id="name_error"></span>
                    </div>
                </div>
                <div class="form-group flex cl-gap">
                    <div class="col-2 col-md-4 col-sm-6 pd-gap">
                        <label class="form-label">Price</label>
                        <div class="form-input-box">
                            <input type="text" name="price" id="price" class="form-control">
                            <span class="form-error" id="price_error"></span>
                        </div>
                    </div>
                    <div class="col-2 col-md-4 col-sm-6 pd-gap">
                        <label class="form-label">Discount</label>
                        <div class="form-input-box">
                            <input type="text" name="discount" id="discount" class="form-control">
                            <span class="form-error" id="discount_error" runat="server"></span>
                        </div>
                    </div>
                    <div class="col-2 col-md-4 col-sm-6 pd-gap">
                        <label class="form-label">Size</label>
                        <div class="form-input-box">
                            <input type="text" name="size" id="size" class="form-control">
                            <span class="form-error" id="size_error"></span>
                        </div>
                    </div>
                    <div class="col-2 col-md-4 col-sm-6 pd-gap">
                        <label class="form-label">Color</label>
                        <div class="select-box select-radio select-color">
                            <div class="select-box-title">
                                <div class="select-box-value">
                                </div>
                                <i class="fas fa-caret-down"></i>
                            </div>
                            <div class="select-box-list">
                            </div>
                        </div>
                    </div>
                    <div class="col-2 col-md-4 col-sm-6 pd-gap">
                        <label class="form-label">Stars</label>
                        <div class="select-box select-radio select-stars">
                            <div class="select-box-title">
                                <div class="select-box-value">
                                </div>
                                <i class="fas fa-caret-down"></i>
                            </div>
                            <div class="select-box-list">
                            </div>
                        </div>
                    </div>
                    <div class="col-2 col-md-4 col-sm-6 pd-gap">
                        <label class="form-label">Type</label>
                        <div class="select-box select-checkbox select-type">
                            <div class="select-box-title">
                                <input type="text" name="type" id="type" class="type-input" readonly>
                                <i class="fas fa-caret-down"></i>
                            </div>
                            <div class="select-box-list">
                            </div>
                        </div>
                        <span class="form-error" id="type_error"></span>
                    </div>
                </div>
                <div class="form-group">
                    <label class="form-label">Description</label>
                    <div class="form-input-box">
                        <textarea name="desc" id="desc" rows="3" class="form-control"></textarea>
                        <span class="form-error" id="desc_error"></span>
                    </div>
                </div>
                <div class="form-group">
                    <label class="form-label">Images</label>
                    <div class="form-input-box flex upload-box">
                        <input type="file" name="imgs" id="imgs" multiple accept=".jpg, .png, .jpeg">
                        <div class="form-btns">
                            <a href="ProductManagement.aspx">Reset</a>
                            <input type="submit" id="edit" name="edit" value="Edit" formaction="ProductManagement.aspx">
                            <input type="submit" id="save" name="save" value="Save">
                        </div>
                    </div>
                    <span class="form-error" id="imgs_error"></span>
                    <input type="text" id="alts" name="alts" style="display: none;" readonly>
                </div>
                <div class="imgs-show flex cl-gap">
                </div>
            </div>
        </div>
    </section>
    <section class="product-list-wrapper wrapper">
        <div class="container">
            <div class="product-list__container">
                <h2 class="section-title">Product List</h2>
                <div class="product-list" id="product_list" runat="server">
                </div>
            </div>
        </div>
    </section>
</form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="server">
    <script src="assets/javascript/productManagement.js"></script>
</asp:Content>
