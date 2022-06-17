<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="listUser.aspx.cs" Inherits="DATN.PetShop.Admin.site.users.user.user" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="server">
    <div class="page-content-tab" id="main" runat="server">

        <div class="container-fluid">
            <!-- Page-Title -->
            <div class="row">
                <div class="col-sm-12">
                    <div class="page-title-box">
                        <div class="float-end">
                            <ol class="breadcrumb">
                                <li class="breadcrumb-item"><a href="#">Unikit</a>
                                </li>
                                <!--end nav-item-->
                                <li class="breadcrumb-item"><a href="#">Projects</a>
                                </li>
                                <!--end nav-item-->
                                <li class="breadcrumb-item active">Users</li>
                            </ol>
                        </div>
                        <h4 class="page-title">Nhân Viên</h4>
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
                                        <%--<tr>
                                                <td><img src="assets/images/users/user-4.jpg" alt="" class="rounded-circle thumb-sm me-1"> Richard Ali</td>
                                                <td>Administrator</td>
                                                <td>RichardAli@example.com</td>
                                                <td>Quận Nhà Bè,Tp.HCM</td>
                                                <td>+41 123456789</td>
                                                <td><span class="badge badge-soft-success">Active</span></td>
                                                <td>                                                       
                                                    <a href="site/users/user/editUser.aspx"><i class="las la-pen text-secondary font-16"></i></a>
                                                    <a href="#"><i class="las la-trash-alt text-secondary font-16"></i></a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td><img src="assets/images/users/user-8.jpg" alt="" class="rounded-circle thumb-sm me-1"> Thomas Milligan</td>
                                                <td>Administrator</td>
                                                <td>homasMilligan@example.com</td>
                                                <td>Q.Cầu Giấy,Tp.Hà Nội</td>
                                                <td>+35 123456789</td>
                                                <td><span class="badge badge-soft-danger">Deactivated</span></td>
                                                <td>
                                                    <a href="site/users/user/editUser.aspx"><i class="las la-pen text-secondary font-16"></i></a>
                                                    <a href="#"><i class="las la-trash-alt text-secondary font-16"></i></a>
                                                </td>
                                            </tr>--%>
                                    </tbody>
                                </table>
                                <!--end /table-->
                            </div>
                            <!--end /tableresponsive-->
                            <div class="row">
                                <div class="col">
                                    <button  class="btn btn-outline-light btn-sm px-4 "><a href="site/user/addUser.aspx">+ Thêm mới</a></button>
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
