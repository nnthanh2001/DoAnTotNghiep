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
                string price = String.Format("{0:0,00₫}", product.price);
                strBody.Append("<tr>");
                strBody.Append("<td>" + product.productID + "</td>");
                //strBody.Append("<td> <img src = 'assets/images/products/04.png' alt ='' height = '40'/></td>");
                strBody.Append("<td> <img src = '" + product.image + "' alt ='' height = '80'/><p>" + product.productName + "</p></td>");
                //strBody.Append("<td>" + product.productName + "</td>");
                strBody.Append("<td>" + product.petTypeName + "</td>");
                strBody.Append("<td>" + product.categoryName + "</td>");
                strBody.Append("<td><div class='line-clamp'>" + product.description + "</div></td>");
                strBody.Append("<td>" + product.quantity + "</td>");
                strBody.Append("<td>" + price + "</td>");
                strBody.Append("<td>" + product.statusName + "</td>");
                strBody.Append("<td><a href='/san-pham/" + product.productHandle + "-" + product._id + "'><i class='las la-pen text-secondary font-16'></i></a> ");
                strBody.Append("<a type='button'><i class='las la-trash-alt text-secondary font-16' jsaction='deleteProductButton' value='" + product._id + "'></i></a></td>");
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
                                <a href='#'>NTPet</a>
                            </li>
                            <!--end nav-item-->
                            <li class='breadcrumb-item'>
                                <a href='#'>Sản phẩm</a>
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
                                <div class='col'>
                                    <a class='btn btn-outline-light btn-sm px-4' href='them-moi-san-pham' style='float:right;'>+ Thêm mới</a>
                                </div>
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
                                                    <th style='white-space: nowrap'>Mã sản phẩm</th>
                                                    <th style='white-space: nowrap'>Tên sản phẩm</th>
                                                    
                                                    <th style='white-space: nowrap'>Loại thú cưng</th>
                                                    <th style='white-space: nowrap'>Loại sản phẩm</th>
                                                    <th>Mô tả</th>
                                                    <th style='white-space: nowrap'>Số lượng</th>
                                                    <th style='white-space: nowrap'>Giá tiền</th>
                                                    <th style='white-space: nowrap'>Trạng thái</th>
                                                    <th style='white-space: nowrap'>Hành động</th>
                                                </tr>
                                            </thead>
                                            <tbody>";
            //footer
            var footer = @"</tbody>
                                </table>
                            </div>
                            <div class='row'>
                                
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
       
        ";

            html = string.Concat(header, strBody.ToString(), footer);
            return html;
        }
    }
}