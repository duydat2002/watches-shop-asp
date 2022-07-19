<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="BTL1.Cart1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="assets/css/cart.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
<form action="Cart.aspx" method="post" runat="server">
    <main id="main">
        <div class="modals">
            <div class="payment-modal" id="payment_modal" runat="server" ClientIDMode="Static">
                <i class="payment-close fas fa-times"></i>
                <div class="payment__icon">
                    <i class="fas fa-check"></i>
                </div>
                <p class="payment__title">Payment Successful</p>
                <p class="payment__desc">
                    <span>We received your purchase request.</span>
                    <span>We'll be in touch shortly!</span>
                </p>
            </div>
            <div class="missing-address-modal" id="address_modal" runat="server" ClientIDMode="Static">
                <i class="missing-address-close fas fa-times"></i>
                <div class="missing-address__icon">
                    <i class="fas fa-address-card"></i>
                </div>
                <p class="missing-address__title">To order, please add a delivery address</p>
                <a href="Account.aspx?tab=contact" class="missing-address__link">Add a new address</a>
            </div>
        </div>
        <div class="cartpage wrapper">
            <div class="container">
                <div class="cartpage__container flex cl-gap">
                    <div class="col-8 col-md-12 pd-gap">
                        <div class="cartpage__body">
                            <div class="cartpage__detail">
                                <div class="cartpage__title-box">
                                    <h2 class="cartpage__title">Shopping Cart</h2>
                                    <button type="submit" id="change_cart" name="change-cart" value="change-cart" class="change-qty button button-gb" runat="server" ClientIDMode="Static">Save Changes</button>
                                </div>
                                <div id="cartError_box" runat="server">
                                </div>
                                <div class="cartpage__list" id="cartpage__list" runat="server">
                                </div>
                            </div>
                            <a href="Home.aspx" class="backto-home flex align-items-center">
                                <i class="fas fa-angle-left"></i>
                                Continue shopping
                            </a>
                        </div>
                    </div>
                    <div class="col-4 col-md-12 pd-gap">
                        <div class="cartpage__right">
                            <div class="cartpage__summary__container">
                                <div class="cartpage__summary">
                                    <div class="summary__subtotal-products">
                                        <span class="subtotal-products-count">0 Items</span>
                                        <span class="subtotal-products-price">$0.00</span>
                                    </div>
                                    <div class="summary__subtotal-shipping">
                                        <span>Shipping</span>
                                        <span class="subtotal-shipping-price">$0.00</span>
                                    </div>
                                </div>
                                <div class="cartpage__total">
                                    <span>Total</span>
                                    <span class="total-price">$0.00</span>
                                </div>
                                <button type="submit" id="purchase" name="purchase" value="purchase" class="cartpage__button button button-gb" runat="server" ClientIDMode="Static">Proceed to checkout</button>
                            </div>
                            <div class="cartpage__reassurance">
                                <div class="reassurance-item">
                                    <i class="fas fa-shield-alt"></i>
                                    Security policy (edit with Customer reassurance module)
                                </div>
                                <div class="reassurance-item">
                                    <i class="fas fa-truck-moving"></i>
                                    Delivery policy (edit with Customer reassurance module)
                                </div>
                                <div class="reassurance-item">
                                    <i class="fas fa-exchange-alt"></i>
                                    Return policy (edit with Customer reassurance module)
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </main>
</form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="server">
    <script src="assets/javascript/cart.js"></script>
</asp:Content>
