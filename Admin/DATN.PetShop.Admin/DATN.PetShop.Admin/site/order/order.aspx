<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="order.aspx.cs" Inherits="DATN.PetShop.Admin.site.order.order" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="server">
    <div class="page-content-tab">

        <div class="container-fluid">
            <!-- Page-Title -->
            <div class="row">
                <div class="col-sm-12">
                    <div class="page-title-box">
                        <div class="float-end">
                            <ol class="breadcrumb">
                                <li class="breadcrumb-item"><a href="#">Pet shop</a></li>

                                <li class="breadcrumb-item active">Hóa đơn</li>
                            </ol>
                        </div>
                        <h4 class="page-title">Danh sách đơn hàng</h4>
                    </div>
                    <!--end page-title-box-->
                </div>
                <!--end col-->
            </div>
            <!-- end page title end breadcrumb -->
            <div class="row">
                <div class="col-12">
                    <div class="card">
                        <div class="card-header">
                            <h4 class="card-title">Thông tin khách đặt hàng </h4>
                        </div>
                        <!--end card-header-->

                        <div class="card-body">

                            <div class="table-responsive">
                                <table class="table" id="datatable_1">
                                    <thead class="thead-light">
                                        <tr>
                                            <th>Mã đơn hàng</th>
                                            <th>Họ và tên</th>
                                            <th>Tổng tiền hóa đơn</th>
                                            <th>Địa chỉ giao hàng</th>
                                            <th>Email</th>
                                            <th>Số điện thoại</th>
                                            <th>Hình thức thanh toán</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            <td><a href="site/order/orderDetail.aspx">DH234</a></td>

                                            <td>Nguyễn Như Thành</td>
                                            <td>600.000</td>
                                            <td>18/2 Trần Thị Do, P.Hiệp Thành, Quận 12, TP.HCM</td>
                                            <td>nguyennhuthanh2001@gmail.com</td>
                                            <td>0769899123</td>
                                            <td>Thanh toán online</td>
                                        </tr>
                                        <tr>
                                            <td><a href="#">DH234</a></td>
                                            <td>Nguyễn Như Thành</td>
                                            <td>600.000</td>
                                            <td>18/2 Trần Thị Do, P.Hiệp Thành, Quận 12, TP.HCM</td>
                                            <td>nguyennhuthanh2001@gmail.com</td>
                                            <td>0769899123</td>
                                            <td>Thanh toán online</td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- end col -->
            </div>
            <!-- end row -->




        </div>
        <!-- container -->
        <!--Start Rightbar-->
        <!--Start Rightbar/offcanvas-->
        <div class="offcanvas offcanvas-end" tabindex="-1" id="Appearance" aria-labelledby="AppearanceLabel">
            <div class="offcanvas-header border-bottom">
                <h5 class="m-0 font-14" id="AppearanceLabel">Appearance</h5>
                <button type="button" class="btn-close text-reset p-0 m-0 align-self-center" data-bs-dismiss="offcanvas" aria-label="Close"></button>
            </div>
            <div class="offcanvas-body">
                <h6>Account Settings</h6>
                <div class="p-2 text-start mt-3">
                    <div class="form-check form-switch mb-2">
                        <input class="form-check-input" type="checkbox" id="settings-switch1">
                        <label class="form-check-label" for="settings-switch1">Auto updates</label>
                    </div>
                    <!--end form-switch-->
                    <div class="form-check form-switch mb-2">
                        <input class="form-check-input" type="checkbox" id="settings-switch2" checked>
                        <label class="form-check-label" for="settings-switch2">Location Permission</label>
                    </div>
                    <!--end form-switch-->
                    <div class="form-check form-switch">
                        <input class="form-check-input" type="checkbox" id="settings-switch3">
                        <label class="form-check-label" for="settings-switch3">Show offline Contacts</label>
                    </div>
                    <!--end form-switch-->
                </div>
                <!--end /div-->
                <h6>General Settings</h6>
                <div class="p-2 text-start mt-3">
                    <div class="form-check form-switch mb-2">
                        <input class="form-check-input" type="checkbox" id="settings-switch4">
                        <label class="form-check-label" for="settings-switch4">Show me Online</label>
                    </div>
                    <!--end form-switch-->
                    <div class="form-check form-switch mb-2">
                        <input class="form-check-input" type="checkbox" id="settings-switch5" checked>
                        <label class="form-check-label" for="settings-switch5">Status visible to all</label>
                    </div>
                    <!--end form-switch-->
                    <div class="form-check form-switch">
                        <input class="form-check-input" type="checkbox" id="settings-switch6">
                        <label class="form-check-label" for="settings-switch6">Notifications Popup</label>
                    </div>
                    <!--end form-switch-->
                </div>
                <!--end /div-->
            </div>
            <!--end offcanvas-body-->
        </div>
        <!--end Rightbar/offcanvas-->
        <!--end Rightbar-->

    </div>
</asp:Content>
