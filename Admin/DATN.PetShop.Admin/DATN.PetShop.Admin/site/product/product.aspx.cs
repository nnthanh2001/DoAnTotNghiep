using Entities.Product;
using HttpClient_API;
using HttpClient_API.Core.Global;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace DATN.PetShop.Admin.site.products.product
{
    public partial class product : System.Web.UI.Page
    {
        public void Page_Load(object sender, EventArgs e)
        {
            var Route = HttpContext.Current.Request.RequestContext.RouteData;
            if (Route.Route == null) return;
            var request = Route.Values;
            if (!Page.IsPostBack)
            {
                var keyword = Request["k"] != null && Request["k"].ToString() != ""
                ? Request["k"].ToString().ToLower().Trim()
                : "";
                var pageIndex = Request["p"] != null && Request["p"].ToString() != ""
               ?int.Parse(Request["p"]?.ToString()??"0")
               : 0;

                var getProduct = GetDataProduct(keyword, pageIndex);
                main.InnerHtml = getProduct;
            }
           


        }
        public string GetDataProduct(string k = "",int pageIndex=1)
        {
            var baseUrl = Globals.baseAPI;
            var apiUrl = Globals.listProductAPI;
            if (k != "") apiUrl += "?k=" + k+"&pageIndex="+ pageIndex;

            var strProduct = Restful.Get<List<ProductModel>>(baseUrl, apiUrl).Result;
            
            



            //body
            var strBody = new StringBuilder();
            foreach (var product in strProduct)
            {
                string price = String.Format("{0:0,00₫}", product.price);
                var strProductList = @" <tr>
                <td>" + product.productID + @"</td>
                <td>
                     <img src='" + product.image + @"' alt='' height='40' class='me-2'>
                     <p class='d-inline-block align-middle mb-0'>
                     <a href='/san-pham/" + product.productHandle + @"-" + product._id + @"' class='d-inline-block align-middle mb-0 product-name' style='width: 111px;'>" + product.productName + @"</a>
                     <br>
                     </p>
                </td>
                <td>" + product.petTypeName + @"</td>
                <td>" + product.categoryName + @"</td>
                <td><div class='line-clamp'>" + product.description + @" </div></td>
                <td>" + product.quantity + @"</td>
                <td>" + price + @"</td>
                <td>" + product.statusName + @"</td>
                <td><a href='/san-pham/" + product.productHandle + "-" + product._id + @"'><i class='las la-pen text-secondary font-16'></i></a> 
                <a type='button'><i class='las la-trash-alt text-secondary font-16' jsaction='deleteProductButton' value='" + product._id + @"'></i></a></td>
                </tr>";

                strBody.Append(strProductList);
            }

            //header
            var header = @"<div class='topbar'>
        <!-- Navbar -->
        <nav class='navbar-custom' id='navbar-custom'>
            <ul class='list-unstyled topbar-nav mb-0'>
                <li>
                    <button class='nav-link button-menu-mobile nav-icon' id='togglemenu'>
                        <i class='ti ti-menu-2'></i>
                    </button>
                </li>
                <li class='hide-phone app-search'>
                    <form role='k' action='' method='get'>
                        <input type='k' name='k' class='form-control top-search mb-0' placeholder='Tìm kiếm...'>
                        <button type='submit'><i class='ti ti-search'></i></button>
                    </form>
                </li>
            </ul>
        </nav>
        <!-- end navbar-->
    </div>



<div class='container-fluid'>
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
                                                    <th style='white-space: nowrap'>ID</th>
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

            var html = string.Concat(header, strBody.ToString(), footer);
            return html;
        }
    }
}