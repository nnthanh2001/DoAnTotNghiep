<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="addUser.aspx.cs" Inherits="DATN.PetShop.Admin.site.users.user.addUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="server">
    
    <div class="page-content-tab" id="main" runat="server">

        <div class="container-fluid">
            <!-- Page-Title -->
            <div class="row">
                <div class="col-sm-12">
                    <div class="page-title-box">
                        <div class="float-end">
                            <ol class="breadcrumb">
                                <li class="breadcrumb-item"><a href="#">Trang chủ</a></li>
                                <li class="breadcrumb-item"><a href="#">Nhân viên</a></li>
                                <li class="breadcrumb-item active">Thêm nhân viên</li>
                            </ol>
                        </div>
                        <h4 class="page-title">Thêm nhân viên </h4>
                    </div>
                    <!--end page-title-box-->
                </div>
                <!--end col-->
            </div>
            <!-- end page title end breadcrumb -->

            <div class="row">
                <div class="col-lg-6">
                    <div class="card">
                        <div class="card-header">
                            <h4 class="align-self-xxl-baseline">Thông tin cơ bản</h4>

                        </div>
                        <!--end card-header-->
                        <div class="card-body">
                            <div margin="text-align: left">
                                <%-- <div class="col-lg-3">
                                    <img src="assets/img_product/01.jpg" alt="" height="400" width="400">
                                    <button class="btn-de-blue" type="submit">Chọn ảnh</button>
                                </div>--%>
                                <div class="col-lg-12">

                                    <div class="mb-3 row">
                                        <label for="example-email-input" class="col-sm-2 col-form-label text-end">Tên nhân viên</label>
                                        <div class="col-sm-10">
                                            <input class="form-control" type="text" id="tensp">
                                        </div>
                                    </div>
                                    <div class="mb-3 row">
                                        <label class="col-sm-2 col-form-label text-end">Mã</label>
                                        <div class="col-sm-4">
                                            <input class="form-control" />
                                        </div>
                                        <label class="col-sm-2 col-form-label text-end">Số lượng</label>
                                        <div class="col-sm-4">
                                            <input class="form-control" />
                                        </div>

                                    </div>
                                    <div class="mb-3 row">
                                        <label class="col-sm-2 col-form-label text-end">Vai trò</label>
                                        <div class="col-sm-4">
                                            <select class="form-select" aria-label="Default select example">
                                                <option value="2">Quản lí </option>
                                                <option value="3">Nhân viên chăm sóc</option>
                                                <option value="3">Nhân viên tư vấn</option>
                                                <option value="3">Nhân viên kế toán</option>
                                            </select>
                                        </div>
                                       
                                       <label class="col-sm-2 col-form-label text-end">Email</label>
                                        <div class="col-sm-4">
                                            <input class="form-control" />
                                        </div>
                                    </div>

                                    <div class="mb-3 row">
                                       <label class="col-sm-2 col-form-label text-end">Địa chỉ</label>
                                        <div class="col-sm-4">
                                            <input class="form-control" />
                                        </div>
                                        <label class="col-sm-2 col-form-label text-end">Liên hệ</label>
                                        <div class="col-sm-4">
                                            <input class="form-control" />
                                        </div>
                                    </div>

                                    <div class="mb-3 row">
                                        <label class="col-sm-2 col-form-label text-end">Trạng thái</label>
                                        <div class="col-sm-4">
                                            <select class="form-select" aria-label="Default select example">

                                                <option value="1">Còn hàng</option>
                                                <option value="2">Hết hàng</option>

                                            </select>
                                        </div>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>

                <div class="col-lg-6">
                    <div class="card">
                        <div class="card-header">
                            <h4 class="align-self-xxl-baseline">Mô tả</h4>
                            <div class="col-lg-12">
                                <div class="mb-3 row">

                                    <div class="col-sm-12">
                                        <textarea class="form-control" rows="3" id="example-text-input"></textarea>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!--end card-header-->

                    </div>
                </div>
                <!--end card-body-->
            </div>

            <button class="btn btn-primary" type="submit" onclick="executeExample('threeButtons')">Xác nhận thêm</button>

            <!--end card-->
        </div>
        <!--end col-->
    </div>

</asp:Content>
