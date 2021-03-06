<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="detailOrder.aspx.cs" Inherits="DATN.PetShop.User.site.historyOrder.detailOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="server">
    <div class="page-content-tab" id="main" runat="server">
        <div class="row">
            <div class="col-lg-12">
                <div class="card">
                    <div class="card-header">
                        <div class="row align-items-center">
                            <div class="col">
                                <h4 class="card-title">Đơn hàng: DH234</h4>
                            </div>
                            <!--end col-->
                        </div>
                        <!--end row-->
                    </div>
                    <!--end card-header-->
                    <div class="card-body">
                        <p class="mb-4 text-muted">Khách hàng: Nguyễn Như Thành</p>
                        <div class="table-responsive">
                            <table class="table mb-0">
                                <thead>
                                    <tr>
                                        <th>Tên sản phẩm</th>
                                        <th>Giá tiền</th>
                                        <th>Số lượng</th>
                                        <th>Tổng tiền sản phẩm</th>

                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td>
                                            <img src="assets/images/products/01.png" alt="" height="40" class="me-2">
                                            <p class="d-inline-block align-middle mb-0">
                                                <a href="" class="d-inline-block align-middle mb-0 product-name">Reebok Shoes</a>
                                                <br>
                                                <span class="text-muted font-13">size-08 (Model 2019)</span>
                                            </p>
                                        </td>
                                        <td>120.000</td>
                                        <td>2 </td>
                                        <td>240.000</td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                        <div class="row justify-content-center">
                            <div class="col-md-6 align-self-center">
                            </div>
                            <!--end col-->
                            <div class="col-md-6">
                                <div class="total-payment p-3 mt-4">
                                    <table class="table">
                                        <tbody>

                                            <tr>
                                                <td class="border-bottom-0">Tổng hóa đơn</td>
                                                <td class="text-dark border-bottom-0"><strong>600.000</strong></td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                            <!--end col-->
                        </div>
                        <!--end row-->
                    </div>
                    <!--end card-->
                </div>
                <!--end card-body-->
            </div>
            <!--end col-->
        </div>
    </div>
</asp:Content>
