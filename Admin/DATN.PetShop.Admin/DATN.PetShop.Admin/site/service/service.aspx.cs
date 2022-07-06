using Entities.Service;
using HttpClient_API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DATN.PetShop.Admin.site.products.services
{
    public partial class service : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var getService = GetDataService();
            main.InnerHtml = getService;
        }

        public string GetDataService()
        {
            var baseUrl = "https://localhost:44309";
            var apiUrl = "api/Service";



            var strService = Restful.Get<List<ServiceModel>>(baseUrl, apiUrl).Result;
            var html = "";

            var strBody = new StringBuilder();
            foreach (var service in strService)
            {
                string price = String.Format("{0:0,00vnđ}", service.price);
                strBody.Append("<tr>");
                strBody.Append("<td>" + service.serviceID + "</td>");
                //strBody.Append("<td> <img src = 'assets/images/products/04.png' alt ='' height = '40'/></td>");
                strBody.Append("<td> <img src = '" + service.image + "' alt ='' height = '40'/></td>");
                strBody.Append("<td>" + service.serviceName + "</td>");
                strBody.Append("<td>" + service.unit + "</td>");
                strBody.Append("<td>" + service.description + "</td>");
                strBody.Append("<td>" + service.condition + "</td>");
                strBody.Append("<td>" + price + "</td>");
                strBody.Append("<td>" + service.statusName + "</td>");
                strBody.Append("<td><a href='dich-vu/" + service.serviceHandle + "-" + service._id + "'><i class='las la-pen text-secondary font-16'></i></a> <a href='dich-vu'><i class='las la-trash-alt text-secondary font-16 jsaction='deleteServiceButton' value='" + service._id + @"'></i></a></td>");
                strBody.Append("</tr>");
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
                            <li class='breadcrumb-service'>
                                <a href='#'>Unikit</a>
                            </li>
                            <!--end nav-service-->
                            <li class='breadcrumb-service'>
                                <a href='#'>Ecommerce</a>
                            </li>
                            <!--end nav-service-->
                            <li class='breadcrumb-service active'>List</li>
                        </ol>
                    </div>
                    <h4 class='page-title'>Danh sách dịch vụ</h4>
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
                                    <div class='row align-services-center'>
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
                                        <th>Hình ảnh</th>
                                        <th>Tên dịch vụ</th>
                                        <th>Đơn vị tính</th>
                                        <th>Mô tả</th>
                                        <th>Điều kiện</th>
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
                               
                                <!--end col-->

                                <div class='col-auto'>
                                    <nav aria-label='...'>
                                        <ul class='pagination pagination-sm mb-0'>
                                            <li class='page-service disabled'>
                                                <a class='page-link' href='#' tabindex='-1'>Trang trước</a>
                                            </li>
                                            <li class='page-service active'><a class='page-link' href='#'>1</a></li>
                                            <li class='page-service'>
                                                <a class='page-link' href='#'>2 <span class='sr-only'>(current)</span></a>
                                            </li>
                                            <li class='page-service'><a class='page-link' href='#'>3</a></li>
                                            <li class='page-service'>
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
        ";

            html = string.Concat(header, strBody.ToString(), footer);
            return html;
        }
    }
}