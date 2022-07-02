<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="checkout.aspx.cs" Inherits="DATN.PetShop.User.site.checkout.checkout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="server">
    <div class="page-content-tab" id="main" runat="server">
        <div class="breadcrumb-area pt-95 pb-95 bg-img" style="background-image: url(assets/img/banner/banner-2.jpg);">
            <div class="container">
                <div class="breadcrumb-content text-center">
                    <h2>Checkout</h2>
                    <ul>
                        <li><a href="site/home/home.aspx.cs">Trang chủ</a></li>
                        <li class="active">Thanh toán</li>
                    </ul>
                </div>
            </div>
        </div>
        <!-- shopping-cart-area start -->
        <div class="cart-main-area pt-95 pb-100">
            <div class="container">
                <h3 class="page-title">Hoàn thành đơn hàng</h3>
                <div class="row">

                    <div class="col-lg-6 ">
                        <div class="table-content table-responsive">
                            <table>
                                <tr>
                                    <th>Tên sản phẩm</th>

                                    <th>Số lượng</th>
                                    <th>Tổng tiền</th>
                                </tr>
                                <tr>
                                    <td class="product-name" style='white-space: nowrap'><a href="#">Nhà nhỏ ABC cỡ 34x34x24cm</a></td>
                                    <td class="product-price-cart"><span>2</span></td>
                                    <td class="product-subtotal">240.000</td>
                                </tr>
                            </table>
                        </div>
                    </div>
                    <div class="col-lg-6 ">
                        <div class="grand-totall">


                            <div class="large-7 col">

                                <section class="woocommerce-order-details">
                                    <h2 class="woocommerce-order-details__title">Kiểm tra thông tin</h2>
                                    <table class="woocommerce-table woocommerce-table--order-details shop_table order_details">
                                        <thead>
                                            <tr>
                                                <th class="woocommerce-table__product-name product-name">Tổng tiền sản phẩm</th>
                                                <th class="woocommerce-table__product-table product-total">240.000</th>
                                            </tr>
                                        </thead>

                                        <tfoot>
                                            <tr>
                                                <th scope='row'>Mã đơn hàng:</th>
                                                <td>1234</td>
                                            </tr>
                                            <tr>
                                                <th scope="row">Phương thức thanh toán:</th>
                                                <td>Chuyển khoản ngân hàng</td>
                                            </tr>
                                            <tr>
                                                <th scope="row">Ngày mua hàng:</th>
                                                <td>01/07/2022</td>
                                            </tr>
                                            <tr>
                                                <th scope="row">Họ và tên:</th>
                                                <td>Nguyễn Như Thành</td>
                                            </tr>
                                            <tr>
                                                <th scope="row">Email:</th>
                                                <td>nguyenhuthanh2001@gmail.com</td>
                                            </tr>
                                            <tr>
                                                <th scope="row">Địa chỉ giao hàng:</th>
                                                <td>HCM</td>
                                            </tr>
                                            <tr>
                                                <th scope="row">Số điện thoại:</th>
                                                <td>32488734634</td>
                                            </tr>
                                        </tfoot>
                                    </table>
                                </section>
                                <p>Cảm ơn quý khách đã đặt hàng. Nhân viên của chúng tôi sẽ gọi điện lại cho quý khách để xác nhận đơn hàng, thông báo phí giao hàng (nếu có) và hướng dẫn quý khách các phương thức thanh toán. Mọi chi tiết xin liên hệ Tổng đài 024.7106.9906 – 028.7106.9906 để được hỗ trợ.</p>
                                <button class="btn-style" type="button" jsaction="Order">Xác nhận</button>
                            </div>
                        </div>
                    </div>

                </div>

            </div>
        </div>
    </div>
</asp:Content>
