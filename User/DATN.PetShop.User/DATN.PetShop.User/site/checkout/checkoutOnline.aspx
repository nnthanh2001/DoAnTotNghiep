<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="checkoutOnline.aspx.cs" Inherits="DATN.PetShop.User.site.checkout.checkoutOnline" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="server">
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
    <div class="cart-main-area pt-95 pb-100">
        <div class="container">
            <div class="row">
                <div class="col-lg-4">
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
                <!--end col-->

                <div class="col-lg-8">
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

                        <!--end card-header-->
                        <div class="card-body">
                            <form class="mb-0">
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="form-label">Họ và tên <small class="text-danger font-13">*</small></label>
                                            <input type="text" class="form-control" id="firstname" required="">
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="form-label">Email <small class="text-danger font-13">*</small></label>
                                            <input type="email" class="form-control" id="lastname" required="">
                                        </div>
                                    </div>
                                    <!--end col-->
                                </div>
                                <!--end row-->
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="form-label my-2">Địa chỉ giao hàng <small class="text-danger font-13">*</small></label>
                                            <input type="text" class="form-control" required="">
                                        </div>
                                    </div>
                                    <!--end col-->
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="form-label my-2">Số điện thoại <small class="text-danger font-13">*</small></label>
                                            <input type="text" class="form-control" required="">
                                        </div>
                                    </div>
                                    <!--end col-->
                                </div>
                                <!--end row-->
                                <div class="row">
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label class="form-label my-2">City <small class="text-danger font-13">*</small></label>
                                            <input type="text" class="form-control" id="city" required="">
                                        </div>
                                    </div>
                                    <!--end col-->
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label class="form-label my-2">State <small class="text-danger font-13">*</small></label>
                                            <select class="form-select">
                                                <option>Select</option>
                                                <option>Gujarat</option>
                                                <option>New york</option>
                                                <option>California</option>
                                            </select>
                                        </div>
                                    </div>
                                    <!--end col-->
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label class="form-label my-2">Country <small class="text-danger font-13">*</small></label>
                                            <select class="form-select">
                                                <option>Select</option>
                                                <option>India</option>
                                                <option>USA</option>
                                                <option>New Zealand</option>
                                            </select>
                                        </div>
                                    </div>
                                    <!--end col-->
                                </div>
                                <!--end row-->
                                <div class="row">
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label class="form-label my-2">Zip code <small class="text-danger font-13">*</small></label>
                                            <input type="text" class="form-control" required="">
                                        </div>
                                    </div>
                                    <!--end col-->
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="form-label my-2">Email Address <small class="text-danger font-13">*</small></label>
                                            <input type="email" class="form-control" required="">
                                        </div>
                                    </div>
                                    <!--end col-->
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label class="form-label my-2">Mobile No <small class="text-danger font-13">*</small></label>
                                            <input type="text" class="form-control" required="">
                                        </div>
                                    </div>
                                    <!--end col-->
                                </div>
                                <!--end row-->
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="form-group mt-3">
                                            <div class="form-check">
                                                <input class="form-check-input" type="checkbox" value="" id="flexCheckDefault">
                                                <label class="form-check-label" for="flexCheckDefault">
                                                    Confirm Shipping Address
                                                       
                                                </label>
                                            </div>
                                        </div>
                                    </div>
                                    <!--end col-->
                                </div>
                                <!--end row-->
                            </form>
                            <!--end form-->

                        </div>
                        <!--end card-body-->

                    </div>
                    <!--end card-->
                    <div class="col-6 text-end" style="font-size: 25px;">
                        <a href="ecommerce-checkout.html" class="text-primary">Checkout <i class="fas fa-long-arrow-alt-right ml-1"></i></a>
                    </div>
                </div>
                <!--end col-->
            </div>
        </div>
    </div>
</asp:Content>
