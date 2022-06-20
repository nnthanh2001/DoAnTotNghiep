<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="listCustomer.aspx.cs" Inherits="DATN.PetShop.Admin.site.user.listCustomer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="server">

    <div class="page-content-tab" id="main" runat="server">

        <div class="container-fluid">
            <!-- Page-Title -->
            <div class="row">
                <div class="col-sm-12">
                    <div class="page-title-box">
                        <div class="float-end">
                            <ol class="breadcrumb">
                                <li class="breadcrumb-item"><a href="#">NTPet</a>
                                </li>
                                <!--end nav-item-->
                                <li class="breadcrumb-item"><a href="#">Projects</a>
                                </li>
                                <!--end nav-item-->
                                <li class="breadcrumb-item active">Customer</li>
                            </ol>
                        </div>
                        <h4 class="page-title">Khách hàng</h4>
                    </div>
                    <!--end page-title-box-->
                </div>
                <!--end col-->
            </div>
            <!-- end page title end breadcrumb -->
            <div class="row">
                <div class="col-lg-4">
                    <div class="card">
                        <div class="card-body p-0">
                            <div class="media p-3  align-items-center">
                                <img src="assets/images/users/user-1.jpg" alt="user" class="rounded-circle thumb-lg">
                                <div class="media-body ms-3 align-self-center">
                                    <h5 class="m-0">Merri Diamond <span class="badge badge-warning font-10">New</span></h5>
                                    <p class="mb-0 text-muted">@SaraHopkins.com</p>
                                </div>
                                <div class="action-btn">
                                    <a href="#"><i class="las la-pen text-secondary font-16"></i></a>
                                    <a href="#"><i class="las la-trash-alt text-secondary font-16"></i></a>
                                </div>
                            </div>
                        </div>
                        <!--end card-body-->
                    </div>
                    <!--end card-->
                </div>
                <!--end col-->
                <div class="col-lg-4">
                    <div class="card">
                        <div class="card-body p-0">
                            <div class="media p-3  align-items-center">
                                <img src="assets/images/users/user-5.jpg" alt="user" class="rounded-circle thumb-lg">
                                <div class="media-body ms-3 align-self-center">
                                    <h5 class="m-0">Paul Schmidt <span class="badge badge-secondary font-10">New</span></h5>
                                    <p class="mb-0 text-muted">@SaraHopkins.com</p>
                                </div>
                                <div class="action-btn">
                                    <a href="#"><i class="las la-pen text-secondary font-16"></i></a>
                                    <a href="#"><i class="las la-trash-alt text-secondary font-16"></i></a>
                                </div>
                            </div>
                        </div>
                        <!--end card-body-->
                    </div>
                    <!--end card-->
                </div>
                <!--end col-->
                <div class="col-lg-4">
                    <div class="card">
                        <div class="card-body p-0">
                            <div class="media p-3  align-items-center">
                                <img src="assets/images/users/user-8.jpg" alt="user" class="rounded-circle thumb-lg">
                                <div class="media-body ms-3 align-self-center">
                                    <h5 class="m-0">Harry McCall</h5>
                                    <p class="mb-0 text-muted">@SaraHopkins.com</p>
                                </div>
                                <div class="action-btn">
                                    <a href="#"><i class="las la-pen text-secondary font-16"></i></a>
                                    <a href="#"><i class="las la-trash-alt text-secondary font-16"></i></a>
                                </div>
                            </div>
                        </div>
                        <!--end card-body-->
                    </div>
                    <!--end card-->
                </div>
                <!--end col-->
            </div>
            <!--end row-->
            <div class="row">
                <div class="col-12">
                    <div class="card">
                        <div class="card-header">
                            <div class="row align-items-center">
                                <div class="col">
                                    <h4 class="card-title">Nhân viên của Pet Shop</h4>
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
                                            <th>Nhân viên</th>
                                            <th>Vai trò</th>
                                            <th>Email</th>
                                            <th>Địa chỉ</th>
                                            <th>Liên hệ</th>
                                            <th>Trạng thái</th>
                                            <th>Hành động</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                    </tbody>
                                </table>
                                <!--end /table-->
                            </div>
                            <!--end /tableresponsive-->
                            <div class="row">
                                <div class="col">
                                    <button class="btn btn-outline-light btn-sm px-4 "><a href="site/user/addUser.aspx">+ Thêm mới</a></button>
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
                                                <a class="page-link" href="#">Trang sau</a>
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
            <!--end row-->

        </div>


    </div>
</asp:Content>
