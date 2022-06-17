using Entities.Product;
using HttpClient_API;
using HttpClient_API.Core.Global;
using System;
using System.Collections.Generic;
using System.Text;

namespace DATN.PetShop.Admin.site.products.product
{
    public partial class product : System.Web.UI.Page
    {
        public void Page_Load(object sender, EventArgs e)
        {
            var getProduct = GetDataProduct();
            main.InnerHtml = getProduct;
        }
        public string GetDataProduct()
        {
            var baseUrl = Globals.baseAPI;
            var apiUrl = Globals.listProductAPI;


            var strProduct = Restful.Get<List<ProductModel>>(baseUrl, apiUrl).Result;
            var html = "";
            
            
            //body
            var strBody = new StringBuilder();
            foreach (var product in strProduct)
            {

                strBody.Append("<tr>");
                strBody.Append("<td>" + product.productID + "</td>");
                //strBody.Append("<td> <img src = 'assets/images/products/04.png' alt ='' height = '40'/></td>");
                strBody.Append("<td> <img src = '" + product.imageID + "' alt ='' height = '40'/></td>");
                strBody.Append("<td>" + product.productName + "</td>");
                strBody.Append("<td>" + product.petTypeName + "</td>");
                strBody.Append("<td>" + product.categoryName + "</td>");
                strBody.Append("<td>" + product.description + "</td>");
                strBody.Append("<td>" + product.quantity + "</td>");
                strBody.Append("<td>" + product.price + "</td>");
                strBody.Append("<td>" + product.statusName + "</td>");
                strBody.Append("<td><a href='/san-pham/chinh-sua-san-pham-" + product.productHandle + "-" + product._id + "'><i class='las la-pen text-secondary font-16'></i></a> ");
                strBody.Append("<button type='button'><i class='las la-trash-alt text-secondary font-16' jsaction='deleteProductButton'></i></button></td>");
                strBody.Append("</tr>");
            }

            //header
            var header = @"<div class='container-fluid'>
        <!-- Page-Title -->
        <div class='row'>
            <div class='col-sm-12'>
                <div class='page-title-box'>
                    <div class='float-end'>
                        <ol class='breadcrumb'>
                            <li class='breadcrumb-item'>
                                <a href='#'>Unikit</a>
                            </li>
                            <!--end nav-item-->
                            <li class='breadcrumb-item'>
                                <a href='#'>Ecommerce</a>
                            </li>
                            <!--end nav-item-->
                            <li class='breadcrumb-item active'>List</li>
                        </ol>
                    </div>
                    <h4 class='page-title'>Danh sách sản phẩm</h4>
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
                                            <h4 class='card-title'>Thực phẩm, đồ dùng, phụ kiện</h4>             
                                        </div><!--end col-->                                       
                                    </div>  <!--end row-->                                  
                                </div><!--end card-header-->
                                <div class='card-body'>    
                                    <div class='table-responsive'>
                                        <table class='table table-striped'>
                                            <thead class='thead-light'>
                                                <tr>
                                                    <th>Mã sản phẩm</th>
                                                    <th>Hình ảnh</th>
                                                    <th>Tên sản phẩm</th>
                                                    <th>Loại thú cưng</th>
                                                    <th>Loại sản phẩm</th>
                                                    <th>Mô tả</th>
                                                    <th>Số lượng</th>
                                                    <th>Giá tiền</th>
                                                    <th>Trạng thái</th>
                                                    <th>Hành động</th>
                                                </tr>
                                            </thead>
                                            <tbody>";
            //footer
            var footer = @"</tbody>
                                </table>
                            </div>
                            <div class='row'>
                                <div class='col'>
                                    <a class='btn btn-outline-light btn-sm px-4 ' href='site/product/addProduct.aspx'>+ Thêm mới</a>
                                </div>
                                <!--end col-->

                                <div class='col-auto'>
                                    <nav aria-label='...'>
                                        <ul class='pagination pagination-sm mb-0'>
                                            <li class='page-item disabled'>
                                                <a class='page-link' href='#' tabindex='-1'>Trang trước</a>
                                            </li>
                                            <li class='page-item active'><a class='page-link' href='#'>1</a></li>
                                            <li class='page-item'>
                                                <a class='page-link' href='#'>2 <span class='sr-only'>(current)</span></a>
                                            </li>
                                            <li class='page-item'><a class='page-link' href='#'>3</a></li>
                                            <li class='page-item'>
                                                <a class='page-link' href='#'>Trang tiếp theo</a>
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
        <div class='offcanvas offcanvas-end' tabindex='-1' id='Appearance' aria-labelledby='AppearanceLabel'>
            <div class='offcanvas-header border-bottom'>
                <h5 class='m-0 font-14' id='AppearanceLabel'>Appearance</h5>
                <button type='button' class='btn-close text-reset p-0 m-0 align-self-center' data-bs-dismiss='offcanvas' aria-label='Close'></button>
            </div>
            <div class='offcanvas-body'>
                <h6>Account Settings</h6>
                <div class='p-2 text-start mt-3'>
                    <div class='form-check form-switch mb-2'>
                        <input class='form-check-input' type='checkbox' id='settings-switch1'>
                        <label class='form-check-label' for='settings-switch1'>Auto updates</label>
                    </div>
                    <!--end form-switch-->
                    <div class='form-check form-switch mb-2'>
                        <input class='form-check-input' type='checkbox' id='settings-switch2' checked>
                        <label class='form-check-label' for='settings-switch2'>Location Permission</label>
                    </div>
                    <!--end form-switch-->
                    <div class='form-check form-switch'>
                        <input class='form-check-input' type='checkbox' id='settings-switch3'>
                        <label class='form-check-label' for='settings-switch3'>Show offline Contacts</label>
                    </div>
                    <!--end form-switch-->
                </div>
                <!--end /div-->
                <h6>General Settings</h6>
                <div class='p-2 text-start mt-3'>
                    <div class='form-check form-switch mb-2'>
                        <input class='form-check-input' type='checkbox' id='settings-switch4'>
                        <label class='form-check-label' for='settings-switch4'>Show me Online</label>
                    </div>
                    <!--end form-switch-->
                    <div class='form-check form-switch mb-2'>
                        <input class='form-check-input' type='checkbox' id='settings-switch5' checked>
                        <label class='form-check-label' for='settings-switch5'>Status visible to all</label>
                    </div>
                    <!--end form-switch-->
                    <div class='form-check form-switch'>
                        <input class='form-check-input' type='checkbox' id='settings-switch6'>
                        <label class='form-check-label' for='settings-switch6'>Notifications Popup</label>
                    </div>
                    <!--end form-switch-->
                </div>
                <!--end /div-->
            </div>
            <!--end offcanvas-body-->
        </div>
        <!--end Rightbar/offcanvas-->
        <!--end Rightbar-->";

            html = string.Concat(header, strBody.ToString(), footer);
            return html;
        }
    }
}