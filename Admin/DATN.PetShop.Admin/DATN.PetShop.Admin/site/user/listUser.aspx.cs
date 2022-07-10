using Entities.User;

using HttpClient_API;
using HttpClient_API.Core.Global;
using System;
using System.Collections.Generic;
using System.Text;

namespace DATN.PetShop.Admin.site.users.user
{
    public partial class user : System.Web.UI.Page
    {
        public void Page_Load(object sender, EventArgs e)
        {
            var getUser = GetDataUser();
            main.InnerHtml = getUser;
        }
        public string GetDataUser()
        {
            var baseUrl = Globals.baseAPI;
            var apiUrl = Globals.userAPI;


            var strUser = Restful.Get<List<UserModel>>(baseUrl, apiUrl).Result;
            var html = "";

            //body
            var strBody = new StringBuilder();
            foreach (var user in strUser)
            {
                strBody.Append("<tr>");
                strBody.Append("<td>" + user.userID + "</td>");
                strBody.Append("<td>" + user.userName + "</td>");
                strBody.Append("<td>" + user.roleName +"</td>");
                strBody.Append("<td>" + user.email + "</td>");
                strBody.Append("<td>" + user.address + "</td>");
                strBody.Append("<td>" + user.phone + "</td>");
                strBody.Append("<td>" + user.statusName + "</td>");
                strBody.Append("<td><a href='nhan-vien/"+ user.userHandle + "-" + user._id +"'><i class='las la-pen text-secondary font-16'></i></a>");
                strBody.Append("<a type='button'><i class='las la-trash-alt text-secondary font-16' jsaction='deleteUserButton' value='" + user._id + "'></i></a></td>");
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
                                       <li class='breadcrumb-item'><a href='#'>Pet shop</a></li>
                                        <li class='breadcrumb-item active'>Nhân viên</li>
                                    </ol>
                                </div>
                                <h4 class='page-title'>Chức vụ nhân Viên</h4>
                            </div><!--end page-title-box-->
                        </div><!--end col-->
                    </div>
                    <!-- end page title end breadcrumb -->
                    <div class='row'>
                        <div class='col-lg-4'>
                            <div class='card'>
                                <div class='card-body p-0'>
                                    <div class='media p-3  align-users-center'>                                                
                                        <img src='assets/images/users/user-1.jpg' alt='user' class='rounded-circle thumb-lg'>                                        
                                        <div class='media-body ms-3 align-self-center'>
                                            <h5 class='m-0'>Nguyễn Như Thành<span class='badge badge-warning font-10'>New</span></h5>
                                            <p class='mb-0 text-muted'>Quản lí</p>                                              
                                        </div>
                                                                                                                 
                                    </div>                                    
                                </div><!--end card-body-->                 
                            </div><!--end card--> 
                        </div><!--end col-->
                        <div class='col-lg-4'>
                            <div class='card'>
                                <div class='card-body p-0'>
                                    <div class='media p-3  align-users-center'>                                                
                                        <img src='assets/images/users/user-5.jpg' alt='user' class='rounded-circle thumb-lg'>                                        
                                        <div class='media-body ms-3 align-self-center'>
                                            <h5 class='m-0'>Trung Nghĩa<span class='badge badge-secondary font-10'>New</span></h5>
                                            <p class='mb-0 text-muted'>NV chăm sóc thú cưng</p>                                                
                                        </div>
                                                                                                                  
                                    </div>                                    
                                </div><!--end card-body-->                 
                            </div><!--end card--> 
                        </div><!--end col-->
                        <div class='col-lg-4'>
                            <div class='card'>
                                <div class='card-body p-0'>
                                    <div class='media p-3  align-users-center'>                                                
                                        <img src='assets/images/users/user-8.jpg' alt='user' class='rounded-circle thumb-lg'>                                        
                                        <div class='media-body ms-3 align-self-center'>
                                            <h5 class='m-0'>Nguyễn Tuấn Minh</h5>
                                            <p class='mb-0 text-muted'>NV tư vấn</p> 
                                        </div>
                                                                                                                
                                    </div>                                    
                                </div><!--end card-body-->                 
                            </div><!--end card--> 
                        </div><!--end col-->
                    </div><!--end row-->    
                    <div class='row'>
                        <div class='col-12'>
                            <div class='card'>
                                
                                <div class='card-header'>
                                <div class='col'>
                                    <a class='btn btn-outline-light btn-sm px-4' href='them-moi-nhan-vien' style='float:right;'>+ Thêm mới</a>
                                </div>
                                    <div class='row align-users-center'>
                                        <div class='col'>                      
                                            <h4 class='card-title'>Nhân viên của Pet Shop</h4>             
                                        </div><!--end col-->                                       
                                    </div>  <!--end row-->                                  
                                </div><!--end card-header-->
                                <div class='card-body'>    
                                    <div class='table-responsive'>
                                        <table class='table table-striped'>
                                            <thead class='thead-light'>
                                            <tr>
                                                <th style='white-space: nowrap'>ID</th>
                                                <th style='white-space: nowrap'>Tên nhân viên</th>
                                                <th style='white-space: nowrap'>Vai trò</th>
                                                <th style='white-space: nowrap'>Email</th>
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


            html = string.Concat(header, strBody.ToString(), footer);

            return html;
        }
    }
}