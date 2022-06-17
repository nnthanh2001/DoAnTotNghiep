<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="service.aspx.cs" Inherits="DATN.PetShop.Admin.site.products.services.service" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="server">
    <div class="page-content-tab" id ="main" runat ="server" >

        <div class="container-fluid">
            <!-- Page-Title -->
            <div class="row">
                <div class="col-sm-12">
                    <div class="page-title-box">
                        
                        <h4 class="page-title">Danh sách dịch vụ</h4>
                    </div>
                    <!--end page-title-box-->
                </div>
                <!--end col-->
            </div>
            <!-- end page title end breadcrumb -->
            <div class='row'>
                        <div class='col-12'>
                            <div class='card'>
                                <div class='card-header'>
                                    <div class='row align-items-center'>
                                        <div class='col'>                      
                                            <h4 class='card-title'>Dịch vụ</h4>             
                                        </div><!--end col-->                                       
                                    </div>  <!--end row-->                                  
                                </div><!--end card-header-->
                                <div class='card-body'>    
                                    <div class='table-responsive'>
                                        <table class='table table-striped'>
                                            <thead class='thead-light'>
                                        <tr>
                                            <th>Mã dịch vụ</th>
                                            <th>Tên dịch vụ</th>
                                            <th>Trọng lượng Pet</th>
                                            <th>Mô tả</th>
                                            <th>Giá tiền</th>
                                            <th>Đơn vị tính</th>
                                            <th>Hành động</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            <td>1</td>
                                            <td>
                                                <img src="assets/images/service/01.png" alt="" height="40">
                                                <p class="d-inline-block align-middle mb-0">
                                                    <a href="" class="d-inline-block align-middle mb-0 product-name fw-semibold">Dịch vụ cắt tỉa lông</a>
                                                    <br>
                                                </p>
                                            </td>
                                            <td>10 - 20kg</td>
                                            <td>Bảng giá cắt lông chó mèo đã bao gồm dịch vụ tắm cho chó mèo  trọn gói, sấy khô, chải lông rụng, cắt dũa móng, vệ sinh tai mà không phát sinh thêm bất cứ phụ phí nào khác.</td>


                                            <td>250.000</td>
                                            <td>1 Pet</td>

                                            <td>
                                                <a href="site/product/editProduct.aspx" class="mr-2"><i class="las la-pen text-secondary font-16"></i></a>
                                                <a href="#"><i class="las la-trash-alt text-secondary font-16"></i></a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>2</td>
                                            <td>
                                                <img src="assets/images/service/02.png" alt="" height="40">
                                                <p class="d-inline-block align-middle mb-0">
                                                    <a href="jascript:void(0);" class="d-inline-block align-middle mb-0 product-name fw-semibold">Dịch vụ tắm spa</a>
                                                    <br>
                                                </p>
                                            </td>
                                            <td>5 - 10kg</td>
                                            <td>Bảng giá spa cho chó mèo trọn gói đã bao gồm gói tắm gội toàn diện, sấy khô, chải lông rụng, cắt dũa móng, vệ sinh tai theo yêu cầu mà không phải tính thêm bất cứ phụ phí nào khác.</td>
                                            <td>150.000</td>
                                            <td>Lần</td>
                                            <td>
                                                <a href="site/products/product/editProduct.aspx" class="mr-2"><i class="las la-pen text-secondary font-16"></i></a>
                                                <a href="jascript:void(0);"><i class="las la-trash-alt text-secondary font-16"></i></a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>3</td>
                                            <td>
                                                <img src="assets/images/service/03.png" alt="" height="40">
                                                <p class="d-inline-block align-middle mb-0">
                                                    <a href="" class="d-inline-block align-middle mb-0 product-name fw-semibold">Khách sạn chó mèo</a>
                                                    <br>
                                                </p>
                                            </td>
                                            <td>Vip B (10 - 20kg)</td>
                                            <td>Khách sạn chó mèo Pet Mart cung cấp những giá trị dịch vụ tốt nhất cho thú cưng trong thời gian gửi tại đây bao gồm: chăm sóc, dinh dưỡng, vệ sinh, tắm rửa, chải chuốt và cả những kế hoạch huấn luyện cơ bản.</td>
                                            <td>400.000</td>
                                            <td>Ngày</td>
                                            <td>
                                                <a href="site/products/product/editProduct.aspx" class="mr-2"><i class="las la-pen text-secondary font-16"></i></a>
                                                <a href="jascript:void(0);" onclick="executeExample('warningConfirm')"><i class="las la-trash-alt text-secondary font-16"></i></a>
                                            </td>
                                        </tr>

                                    </tbody>
                                </table>
                            </div>
                            <div class="row">
                                <div class="col">
                                    <a class="btn btn-outline-light btn-sm px-4 " href="#">+ Thêm mới</a>
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

       
        
    </div>
</asp:Content>
