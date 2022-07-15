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

                    <div class="col-lg-6">
                        <div class="card">
                            <div class="card-header">
                                <div class="row align-items-center">
                                    <div class="col">
                                        <h4 class="card-title">Sản phẩm</h4>
                                    </div>
                                    <!--end col-->
                                </div>
                                <!--end row-->
                            </div>
                            <!--end card-header-->
                            <div class="card-body">
                                <div class="table-responsive shopping-cart">
                                    <table class="table mb-0">
                                        <thead>
                                            <tr>
                                                <th>Tên</th>
                                                <th>Số lượng</th>
                                                <th>Tổng tiền</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <td>
                                                    <img src="#" alt="" height="40">
                                                    <p class="d-inline-block align-middle mb-0 product-name">Reebok Shoes</p>
                                                </td>
                                                <td>2
                                                    </td>
                                                <td>$198</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <img src="#" alt="" height="40">
                                                    <p class="d-inline-block align-middle mb-0 product-name">Night Lamp</p>
                                                </td>
                                                <td>2
                                                    </td>
                                                <td>$150</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <img src="#" alt="" height="40">
                                                    <p class="d-inline-block align-middle mb-0 product-name">Lava Purse</p>
                                                </td>
                                                <td>1
                                                    </td>
                                                <td>$49</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <img src="#" alt="" height="40">
                                                    <p class="d-inline-block align-middle mb-0 product-name">Important Chair</p>
                                                </td>
                                                <td>1
                                                    </td>
                                                <td>$99</td>
                                            </tr>
                                            <tr>
                                                <td class=" border-bottom-0">
                                                    <h6>Thành tiền :</h6>
                                                </td>
                                                <td class=" border-bottom-0"></td>
                                                <td class="text-dark border-bottom-0"><strong>$496</strong></td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                                <!--end re-table-->
                                <div class="total-payment">
                                    <table class="table mb-0">
                                        <tbody>

                                            <tr>
                                                <td class="fw-semibold">Hình thức thanh toán</td>
                                                <td>Thanh toán trả sau</td>
                                            </tr>
                                            <tr>
                                                <td class="fw-semibold  border-bottom-0">Tổng hóa đơn</td>
                                                <td class="text-dark  border-bottom-0"><strong>$491.00</strong></td>
                                            </tr>
                                        </tbody>
                                    </table>
                                    <!--end table-->
                                </div>
                                <!--end total-payment-->
                            </div>
                            <!--end card-body-->
                        </div>
                        <!--end card-->
                    </div>
                    <div class="col-lg-6">
                        <div class="card">
                            <div class="card-header">
                                <div class="row align-items-center">
                                    <div class="col">
                                        <h4 class="card-title">Thông tin giao hàng</h4>
                                    </div>
                                    <!--end col-->
                                </div>
                                <!--end row-->
                            </div>
                            <div class="card-body">

                                <div class="mb-6 row">
                                    <label class="col-sm-6">Tổng tiền hóa đơn</label>
                                    <div class="col-sm-6">
                                        <span>240.000</span>
                                    </div>
                                </div>
                                 <div class="mb-6 row">
                                    <label class="col-sm-6">Mã đơn hàng:</label>
                                    <div class="col-sm-6">
                                        <span>12340</span>
                                    </div>
                                </div>
                                 <div class="mb-6 row">
                                    <label class="col-sm-6">Ngày mua hàng:</label>
                                    <div class="col-sm-6">
                                        <span>240.000</span>
                                    </div>
                                </div>
                                 <div class="mb-6 row">
                                    <label class="col-sm-6">Họ và tên:</label>
                                    <div class="col-sm-6">
                                        <span>240.000</span>
                                    </div>
                                </div>
                                 <div class="mb-6 row">
                                    <label class="col-sm-6">Email:</label>
                                    <div class="col-sm-6">
                                        <span>nguyenhuthanh2001@gmail.com</span>
                                    </div>
                                </div>
                                 <div class="mb-6 row">
                                    <label class="col-sm-6">Địa chỉ giao hàng:</label>
                                    <div class="col-sm-6">
                                        <span>HCM</span>
                                    </div>
                                </div>
                                <div class="mb-6 row">
                                    <label class="col-sm-6">Số điện thoại:</label>
                                    <div class="col-sm-6">
                                        <span>32488734634</span>
                                    </div>
                                </div>
                                <p>Cảm ơn quý khách đã đặt hàng. Nhân viên của chúng tôi sẽ gọi điện lại cho quý khách để xác nhận đơn hàng, thông báo phí giao hàng (nếu có) và hướng dẫn quý khách các phương thức thanh toán. Mọi chi tiết xin liên hệ Tổng đài 024.7106.9906 – 028.7106.9906 để được hỗ trợ.</p>
                                <button class="btn-style" type="button" jsaction="Order"><a href="hoan-tat-dat-hang">Xác nhận</a></button>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>




</asp:Content>
