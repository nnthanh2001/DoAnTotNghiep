<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="costDetail.aspx.cs" Inherits="DATN.PetShop.Admin.site.dashboard.costDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="server">
    <div class="page-content-tab" id="main" runat="server">
        <div class="container-fluid">
            <div class="row">
                <div class="col-sm-12">
                    <div class="page-title-box">
                        <div class="float-end">
                            <ol class="breadcrumb">
                                <li class="breadcrumb-item"><a href="#">Pet shop</a></li>

                                <li class="breadcrumb-item active">Đơn đặt hàng</li>
                            </ol>
                        </div>
                        <h4 class="page-title">Danh sách đơn hàng</h4>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-12">
                    <div class="card">
                        <div class="card-header">
                            <h4 class="card-title">Thông tin đơn hàng </h4>
                        </div>
                        <div class="card-body">
                            <div class="table-responsive">
                                <table class="table" id="datatable_1">
                                    <thead class="thead-light">
                                        <tr>
                                            <th>Mã đơn hàng</th>
                                            <th>Họ và tên</th>
                                            <th>Tổng tiền</th>
                                            <th>Ngày đặt hàng</th>
                                            <th>Số điện thoại</th>
                                            <th>Hình thức thanh toán</th>
                                            <th>Trạng thái</th>
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
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
