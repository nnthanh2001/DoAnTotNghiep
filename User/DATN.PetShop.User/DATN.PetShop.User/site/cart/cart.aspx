<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="cart.aspx.cs" Inherits="DATN.PetShop.User.site.cart.cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="server">
    <div class="page-content-tab" id="main" runat="server">

        <div class="breadcrumb-area pt-95 pb-95 bg-img" style="background-image: url(assets/img/banner/banner-2.jpg);">
            <div class="container">
                <div class="breadcrumb-content text-center">
                    <h2>Giỏ hàng</h2>
                    <ul>
                        <li><a href="site/home/home.aspx.cs">Trang chủ</a></li>
                        <li class="active">Cart Page</li>
                    </ul>
                </div>
            </div>
        </div>
        <!-- shopping-cart-area start -->
        <div class="cart-main-area pt-95 pb-100">
            <div class="container">
                <h3 class="page-title">Mục giỏ hàng của bạn</h3>
                <div class="row">
                    <div class="col-lg-12 col-md-12 col-sm-12 col-12">

                        <form action="#">
                            <div class="table-content table-responsive">
                                <table>
                                    <thead>
                                        <tr>
                                            <th>Hình ảnh</th>
                                            <th>Tên sản phẩm</th>
                                            <th>Giá sản phẩm</th>
                                            <th>Số lượng</th>
                                            <th>Tổng tiền</th>
                                            <th>Xóa</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            <td class="product-thumbnail">
                                                <a href="#">
                                                    <img src="assets/img/cart/cart-3.jpg" alt=""></a>
                                            </td>
                                            <td class="product-name"><a href="#">Nhà nhỏ ABC cỡ 34x34x24cm</a></td>
                                            <td class="product-price-cart"><span class="amount">240.000</span></td>
                                            <td class="product-quantity">
                                                <div class="cart-plus-minus">
                                                    <input class="cart-plus-minus-box" type="text" name="qtybutton" value="1">
                                                </div>
                                            </td>
                                            <td class="product-subtotal">240.000</td>
                                            <td class="product-remove"><a href="#"><i class="ti-trash"></i></a></td>
                                        </tr>

                                    </tbody>
                                </table>
                            </div>
                            <div class="row">
                                <div class="col-lg-12">
                                    <div class="cart-shiping-update-wrapper">
                                        <div class="cart-shiping-update">
                                            <a href="site/products/productPage.aspx">Tiếp tục mua hàng</a>
                                            <a href="#">Cập nhật giỏ hàng</a>
                                        </div>
                                        <div class="cart-clear">
                                            <a href="#">Xóa toàn bộ sản phẩm trong giỏ hàng</a>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </form>

                        <div class="col-lg-12">
                            <div class="grand-totall">
                                <span>Tạm tính:   $155.00</span>
                                <h5>Tổng tiền:   $353.00</h5>
                                <div class="panel-heading">
                                    <h5 class="panel-title"><a data-toggle="collapse" data-parent="#faq" href="#payment-5">Tiến hành thanh toán</a></h5>
                                </div>

                                <div id="payment-5" class="panel-collapse collapse">
                                    <div class="panel-body">
                                        <div class="payment-info-wrapper">
                                            <div class="ship-wrapper">
                                                <div class="single-ship">
                                                    <input type="radio" checked="" value="address" name="address">
                                                    <label>Thanh toán online </label>
                                                </div>
                                                <div class="single-ship">
                                                    <input type="radio" value="dadress" name="address">
                                                    <label>Thanh toán sau khi nhận hàng </label>
                                                </div>
                                            </div>
                                            <div class="payment-info">
                                                <div class="row">
                                                    <div class="col-lg-12 col-md-12">
                                                        <div class="billing-select card-mrg">
                                                            <label>Họ và tên (Full name)</label>
                                                            <input type="text">
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-12 col-md-12">
                                                        <div class="billing-select card-mrg">
                                                            <label>Email (Email address)</label>
                                                            <input type="text">
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-12 col-md-12">
                                                        <div class="billing-select card-mrg">
                                                            <label>Địa chỉ giao hàng (Address) </label>
                                                            <input type="text">
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="row">
                                                    <div class="col-lg-12 col-md-12">
                                                        <div class="billing-select card-mrg">
                                                            <label>Số điện thoại (Phone number)</label>
                                                            <input type="text">
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="billing-back-btn">
                                                <div class="billing-back">
                                                    <a href="site/checkout/checkout.aspx"><i class="ti-arrow-up"></i>Quay lại trang trước</a>
                                                </div>
                                                <div class="billing-btn">
                                                    <button type="submit" href="thanh-toan">Tiếp tục</button>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>

    </div>
</asp:Content>
