<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="product.aspx.cs" Inherits="DATN.PetShop.Admin.site.products.product.product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="server">
    <div class="page-content-tab" id="main" runat="server">

        <%--<div class="container-fluid">
            <!-- Page-Title -->
            <div class="row">
                <div class="col-sm-12">
                    <div class="page-title-box">
                        <div class="float-end">
                            <ol class="breadcrumb">
                                <li class="breadcrumb-item">
                                    <a href="#">Unikit</a>
                                </li>
                                <!--end nav-item-->
                                <li class="breadcrumb-item">
                                    <a href="#">Ecommerce</a>
                                </li>
                                <!--end nav-item-->
                                <li class="breadcrumb-item active">List</li>
                            </ol>
                        </div>
                        <h4 class="page-title">Danh sách sản phẩm</h4>
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
                            <div class="row align-items-center">
                                <div class="col">
                                    <h4 class="card-title">Thực phẩm, đồ dùng, phụ kiện</h4>
                                </div>
                                <!--end col-->
                            </div>
                            <!--end row-->
                        </div>
                        <!--end card-header-->
                        <div class="card-body">
                            <div class="table-responsive">
                                <table class="table table-striped">
                                    <thead class="thead-light">
                                        <tr>
                                            <th>Mã sản phẩm</th>
                                            <th>Tên sản phẩm</th>
                                            <th>Loại thú cưng</th>
                                            <th>Loại sản phẩm</th>
                                            <th>Mô tả</th>
                                            <th>Số lượng</th>
                                            <th>Hình ảnh</th>
                                            <th>Giá tiền</th>
                                            <th>Trạng thái</th>
                                            <th>Hành động</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            <td>SP3456</td>
                                            <td>
                                                <img src="assets/images/products/04.png" alt="" height="40">
                                                <p class="d-inline-block align-middle mb-0">
                                                    <a href="" class="d-inline-block align-middle mb-0 product-name fw-semibold">ROYAL CANIN Kitten</a>
                                                    <br>
                                                </p>
                                            </td>
                                            <td>Mèo Ai Cập</td>
                                            <td>Thức ăn</td>

                                            <td>JERHIGH Chicken Vegetable Gravy chứa đầy đủ giá trị dinh dưỡng.</td>

                                            <td>32</td>
                                            <td>$39</td>
                                            <td><span class="badge badge-soft-purple">Stock</span></td>

                                            <td>
                                                <a href="site/product/editProduct.aspx" class="mr-2"><i class="las la-pen text-secondary font-16"></i></a>
                                                <button href="#"><i class="las la-trash-alt text-secondary font-16" onclick="executeExample('warningConfirm')"></i></button>
                                            </td>
                                        </tr>
                                       

                                    </tbody>
                                </table>
                            </div>
                            <div class="row">
                                <div class="col">
                                    <a class="btn btn-outline-light btn-sm px-4 " href="site/product/addProduct.aspx">+ Thêm mới</a>
                                </div>
                                <!--end col-->

                                <div class="col-auto">
                                    <nav aria-label="...">
                                        <ul class="pagination pagination-sm mb-0">
                                            <li class="page-item disabled">
                                                <a class="page-link" href="#" tabindex="-1">Trang trước</a>
                                            </li>
                                            <li class="page-item active"><a class="page-link" href="#">1</a></li>
                                            <li class="page-item">
                                                <a class="page-link" href="#">2 <span class="sr-only">(current)</span></a>
                                            </li>
                                            <li class="page-item"><a class="page-link" href="#">3</a></li>
                                            <li class="page-item">
                                                <a class="page-link" href="#">Trang tiếp theo</a>
                                            </li>
                                        </ul>
                                        <!--end pagination-->
                                    </nav>
                                    <!--end nav-->
                                </div>
                                <!--end col-->
                            </div>
                            <!--end row-->
                        </div>
                        <!--end card-body-->
                    </div>
                    <!--end card-->
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
        </div>--%>
        <!--end Rightbar/offcanvas-->
        <!--end Rightbar-->
    </div>

      <script src="assets/pages/sweet-alert.init.js"></script>  
</asp:Content>
