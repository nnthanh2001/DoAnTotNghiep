<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="historyOrder.aspx.cs" Inherits="DATN.PetShop.User.site.historyOrder.historyOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="server">
    <div class="page-content-tab" id="main" runat="server">

        <div class="container-fluid">
            <div class="row">
                <div class="col-sm-12">
                    <div class="page-title-box">
                       
                        <h4 class="page-title">Lịch sử đơn hàng</h4>
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
                                            <th>Sản phẩm</th>
                                            <th>Tổng tiền</th>
                                            <th>Ngày đặt hàng</th>
                                            
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
