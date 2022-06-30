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

namespace DATN.PetShop.Admin.site.users.user
{
    public partial class addUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var addUser = AddUser();
            main.InnerHtml = addUser;
        }

        public string AddUser()
        {

            var baseUrl = Globals.baseAPI;
            var apiAddUser = Globals.addUserAPI;



            var strBodyAddUser = new StringBuilder();
            var strRoleList = new StringBuilder();
            var strStatusList = new StringBuilder();
           



            var user = Restful.Get<UserFormModel>(baseUrl, apiAddUser).Result;

            var RoleList = user.roleList;
            var StatusList = user.statusList;
            

            if (RoleList != null && RoleList.Any())
            {
                foreach (var role in RoleList)
                {
                    strRoleList.Append("<option value='" + role.roleID + "' " + role.select + ">" + role.roleName + "</option>");
                }
            }
            if (StatusList != null && StatusList.Any())
            {
                foreach (var status in StatusList)
                {
                    strStatusList.Append("<option value='" + status.statusID + "' " + status.select + ">" + status.statusName + "</option>");
                }
            }
            

            var html = @"<div class='container-fluid'>
            <!-- Page-Title -->
            <div class='row'>
                <div class='col-sm-12'>
                    <div class='page-title-box'>
                        <div class='float-end'>
                            <ol class='breadcrumb'>
                                <li class='breadcrumb-item'><a href='#'>Trang chủ</a></li>
                                <li class='breadcrumb-item'><a href='#'>Nhân viên</a></li>
                                <li class='breadcrumb-item active'>Thêm nhân viên</li>
                            </ol>
                        </div>
                        <h4 class='page-title'>Thêm nhân viên </h4>
                    </div>
                    <!--end page-title-box-->
                </div>
                <!--end col-->
            </div>
            <!-- end page title end breadcrumb -->

            <div class='row'>
                <div class='col-lg-6'>
                    <div class='card'>
                        <div class='card-header'>
                            <h4 class='align-self-xxl-baseline'>Thông tin cơ bản</h4>

                        </div>
                        <!--end card-header-->
                        <div class='card-body'>
                            <div margin='text-align: left'>

                                <div class='col-lg-12'>

                                    <div class='mb-3 row'>
                                        <label for='example-email-input' class='col-sm-2 col-form-label text-end'>Tên nhân viên</label>
                                        <div class='col-sm-10'>
                                            <input class='form-control' type='text' data_value='userName' placehoder='Nhập tên nhân viên' value='{0}'>
                                        </div>
                                    </div>
                                    <div class='mb-3 row'>
                                        <label class='col-sm-2 col-form-label text-end'>Mã</label>
                                        <div class='col-sm-4'>
                                            <input class='form-control' data_value='userID' placehoder='Nhập mã nhân viên' value='{1}' />
                                        </div>
                                        <label class='col-sm-2 col-form-label text-end'>Vai trò</label>
                                        <div class='col-sm-4'>
                                            <select class='form-select' aria-label='Default select example' data_value='roleID'>
                                                " + strRoleList.ToString() + @"
                                                
                                            </select>
                                        </div>

                                    </div>
                                    <div class='mb-3 row'>
                                        <label class='col-sm-2 col-form-label text-end'>Email</label>
                                        <div class='col-sm-10'>
                                            <input class='form-control' data_value='email' placehoder='Nhập email ' value='{3}' />
                                        </div>
                                    </div>

                                    <div class='mb-3 row'>
                                        <label class='col-sm-2 col-form-label text-end'>Địa chỉ</label>
                                        <div class='col-sm-4'>
                                            <input class='form-control' data_value='address' placehoder='Nhập địa chỉ ' value='{4}' />
                                        </div>
                                        <label class='col-sm-2 col-form-label text-end'>Liên hệ</label>
                                        <div class='col-sm-4'>
                                            <input class='form-control' data_value='phone' placehoder='Nhập số điện thoại' value='{5}' />
                                        </div>
                                    </div>

                                    <div class='mb-3 row'>
                                        <label class='col-sm-2 col-form-label text-end'>Tạo mật khẩu</label>
                                        <div class='col-sm-4'>
                                            <input class='form-control' data_value='password' placehoder='Nhập mật khẩu' value='{7}' />
                                        </div>
                                        <label class='col-sm-2 col-form-label text-end'>Trạng thái</label>
                                        <div class='col-sm-4'>
                                            <select class='form-select' aria-label='Default select example' data_value='statusID'>
                                                " + strStatusList.ToString() + @"
                                            </select>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!--end card-body-->
            </div>
            <button class='btn btn-primary' type='submit' jsaction='addUserButton'>Xác nhận thêm mới</button>
        </div>";


            var htmlAddUser = string.Format(html, user.userName, user.userID, user.roleName, user.email, user.address, user.phone, user.statusName,user.password);
            strBodyAddUser.Append(htmlAddUser);

            html = string.Concat(strBodyAddUser.ToString());
            return html;
        }
    }
}
