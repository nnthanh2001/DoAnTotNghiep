using Entities.User;
using HttpClient_API;
using HttpClient_API.Core.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DATN.PetShop.Admin.site.user
{
    public partial class listCustomer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var getCustomer = GetCustomerData();
            main.InnerHtml = getCustomer;
        }
        public string GetCustomerData()
        {
            var baseUrl = Globals.baseAPI;
            var apiUrl = Globals.customerAPI;


            var strUser = Restful.Get<List<UserModel>>(baseUrl, apiUrl).Result;
          

            //body
            var strBody = new StringBuilder();
            foreach (var user in strUser)
            {
                strBody.Append("<tr>");
                strBody.Append("<td>" + user.userID + "</td>");
                strBody.Append("<td>" + user.userName + "</td>");
                strBody.Append("<td>" + user.email + "</td>");
                strBody.Append("<td>" + user.address + "</td>");
                strBody.Append("<td>" + user.phone + "</td>");
                strBody.Append("<td>" + user.statusName + "</td>");
                strBody.Append("<td><a href='nhan-vien/" + user.userHandle + "-" + user._id + "'><i class='las la-pen text-secondary font-16'></i></a> ");
                strBody.Append("<a href='#'><i class='las la-trash-alt text-secondary font-16 onclick='executeExample('warningConfirm')''></i></a></td>");
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
                                        <li class='breadcrumb-user'><a href='#'>PetShop</a>
                                        </li><!--end nav-user-->
                                        <li class='breadcrumb-user'><a href='#'>User</a>
                                        </li><!--end nav-user-->
                                        <li class='breadcrumb-user active'>User</li>
                                    </ol>
                                </div>
                                <h4 class='page-title'>Khách hàng</h4>
                            </div><!--end page-title-box-->
                        </div><!--end col-->
                    </div>
                    <!-- end page title end breadcrumb -->
                    
                    <div class='row'>
                        <div class='col-12'>
                            <div class='card'>
                                <div class='card-header'>
                                    <div class='row align-users-center'>
                                        <div class='col'>                      
                                            <h4 class='card-title'>Khách hàng đăng ký tài khoản</h4>             
                                        </div><!--end col-->                                       
                                    </div>  <!--end row-->                                  
                                </div><!--end card-header-->
                                <div class='card-body'>    
                                    <div class='table-responsive'>
                                        <table class='table table-striped'>
                                            <thead class='thead-light'>
                                            <tr>
                                                <th style='white-space: nowrap'>Mã KH</th>
                                                <th style='white-space: nowrap'>Tên KH</th>
                                               
                                                <th>Email</th>
                                                <th>Địa chỉ</th>
                                                <th>Liên hệ</th>
                                                <th style='white-space: nowrap'>Trạng thái</th>
                                                <th style='white-space: nowrap'>Hành động</th>
                                            </tr>
                                            </thead>
                                            <tbody>";



            //footer
            var footer = @"</tbody>
                                </table>
                                <!--end /table-->
                            </div>
                            <!--end /tableresponsive-->
                            <div class='row'>
                                
                                <!--end col-->
                                <div class='col-auto'>
                                    <nav aria-label='...'>
                                        <ul class='pagination pagination-sm mb-0'>
                                            <li class='page-user disabled'>
                                                <a class='page-link' href='#' tabindex='-1'>Trang trước</a>
                                            </li>
                                            <li class='page-user active'><a class='page-link' href='#'>1</a></li>
                                            <li class='page-user'>
                                                <a class='page-link' href='#'>2 <span class='sr-only'>(current)</span></a>
                                            </li>
                                            <li class='page-user'><a class='page-link' href='#'>3</a></li>
                                            <li class='page-user'>
                                                <a class='page-link' href='#'>Trang sau</a>
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

        ";


            var html = string.Concat(header, strBody.ToString(), footer);

            return html;
        }
    }
}