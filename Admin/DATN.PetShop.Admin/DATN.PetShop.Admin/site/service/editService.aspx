<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="editService.aspx.cs" Inherits="DATN.PetShop.Admin.site.products.services.addService" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="server">
    <div class="page-content-tab" id ="main" runat ="server" >

            
            <div class="container-fluid">
            <!-- Page-Title -->
            <div class="row">
                <div class="col-sm-12">
                    <div class="page-title-box">
                        <div class="float-end" >
                            <ol class="breadcrumb">
                                <li class="breadcrumb-item"><a href="#">Trang chủ</a></li>
                                <li class="breadcrumb-item"><a href="#">Dịch vụ</a></li>
                                <li class="breadcrumb-item active">Sửa dịch vụ</li>
                            </ol>
                        </div>
                        <h4 class="page-title">Chỉnh sửa thông tin </h4>
                    </div>
                    <!--end page-title-box-->
                </div>
                <!--end col-->
            </div>
            <!-- end page title end breadcrumb -->
            <div class="row">
                <div class="col-lg-12">
                    <div class="col-lg-12">
                        <div class="card">
                            <div class="card-header">
                                <h4 class="align-self-xxl-baseline">Thông tin cơ bản</h4>

                            </div>
                            <!--end card-header-->
                            <div class="card-body">
                                <div margin="text-align: left">
                                    <div class="col-lg-12">
                                        <div class="row">
                                            <div class="col-lg-6">
                                                <div class="card">
                                                    <div class="card-header">
                                                        <div class="mb-3 row">
                                                            <label for="example-email-input" class="col-sm-2 col-form-label text-end">Tên</label>
                                                            <div class="col-sm-10">
                                                                <input class="form-control" type="text" id="tensp" >
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
                                                            <label class="col-sm-2 col-form-label text-end">Đơn vị tính</label>
                                                            <div class="col-sm-4">
                                                                <select class="form-select" aria-label="Default select example">
                                                                    <option selected="">Chọn loại sản phẩm</option>
                                                                    <option value="2">Ngày </option>
                                                                    <option value="3">Lần</option>
                                                                </select>
                                                            </div>
                                                            <label class="col-sm-2 col-form-label text-end">Điều kiện</label>
                                                            <div class="col-sm-4">
                                                                <select class="form-select" aria-label="Default select example">
                                                                    <option selected="">Chọn loại sản phẩm</option>
                                                                    <option value="1">Thức ăn</option>
                                                                    <option value="2">Dinh dưỡng</option>
                                                                    <option value="3">Đồ dùng, phụ kiện</option>
                                                                </select>
                                                            </div>
                                                        </div>

                                                        <div class="mb-3 row">

                                                            <label class="col-sm-2 col-form-label text-end">Giá bán</label>
                                                            <div class="col-sm-4">
                                                                <input class="form-control" type="number" value="" id="">
                                                            </div>
                                                            <label class="col-sm-2 col-form-label text-end">Trạng thái</label>
                                                            <div class="col-sm-4">
                                                                <select class="form-select" aria-label="Default select example">
                                                                    <option selected="">Chọn loại sản phẩm</option>
                                                                    <option value="1">Còn hàng</option>
                                                                    <option value="2">Hết hàng</option>
                                                                </select>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-lg-3">
                                                <img src="assets/img_product/01.jpg" alt="" height="200" width="200">
                                                <button class="btn-de-blue" type="submit">Chọn ảnh</button>
                                            </div>
                                            <div class="col-lg-12">
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


                                        </div>

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
            <button class="btn btn-primary" type="submit" onclick="executeExample('threeButtons')">Xác nhận chỉnh sửa</button>
            <!--end card-->
        </div>
           
        </div>
</asp:Content>
