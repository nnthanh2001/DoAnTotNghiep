using Entities.Status;
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
    public partial class editUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var Route = HttpContext.Current.Request.RequestContext.RouteData;
            if (Route.Route == null) return;
            var request = Route.Values;
            if (!Page.IsPostBack)
            {
                var handle = request["handle"] != null && request["handle"].ToString() != ""
                ? request["handle"].ToString().ToLower().Trim()
                : "";
                var id = request["_id"] != null && request["_id"].ToString() != ""
               ? request["_id"].ToString().ToLower().Trim()
               : "";

                var getHTML = GetDataEditUser(id);
                main.InnerHtml = getHTML;
            }
        }
        public string GetDataEditUser(string id)
        {

            var baseUrl = Globals.baseAPI;
            var apiUser = Globals.editUserAPI + "/" + id;


            var strBodyEditUser = new StringBuilder();
            var strListRole = new StringBuilder();
            var strListStatus = new StringBuilder();

            var userList = Restful.Get<UserFormModel>(baseUrl, apiUser).Result;

            var roleList = userList.roleList;
            var statusList = userList.statusList;


            if (roleList != null && roleList.Any())
            {
                foreach (var role in roleList)
                {
                    strListRole.Append("<option value='" + role.roleID + "' " + role.select + ">" + role.roleName + "</option>");
                }
            }
            if (statusList != null && statusList.Any())
            {
                foreach (var status in statusList)
                {
                    strListStatus.Append("<option value='" + status.statusID + "'" + status.select + ">" + status.statusName + "</option>");
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
                                <li class='breadcrumb-item active'>Sứa nhân viên</li>
                            </ol>
                        </div>
                        <h4 class='page-title'>Chỉnh sửa thông tin </h4>
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
                                            <input class='form-control' type='text' id='tensp' placehoder='Nhập tên nhân viên' value='{0}'>
                                        </div>
                                    </div>
                                    <div class='mb-3 row'>
                                        <label class='col-sm-2 col-form-label text-end'>Mã</label>
                                        <div class='col-sm-4'>
                                            <input class='form-control' placehoder='Nhập mã nhân viên' value='{1}'/>
                                        </div>
                                        <label class='col-sm-2 col-form-label text-end'>Vai trò</label>
                                        <div class='col-sm-4'>
                                            <select class='form-select' aria-label='Default select example'>
                                                <option selected=''>{2}</option>
                                                " + strListRole.ToString() + @"
                                                
                                            </select>
                                        </div>

                                    </div>
                                    <div class='mb-3 row'>
                                       <label class='col-sm-2 col-form-label text-end'>Email</label>
                                        <div class='col-sm-10'>
                                            <input class='form-control' placehoder='Nhập email ' value='{3}'/>
                                        </div>
                                    </div>

                                    <div class='mb-3 row'>
                                       <label class='col-sm-2 col-form-label text-end'>Địa chỉ</label>
                                        <div class='col-sm-4'>
                                            <input class='form-control' placehoder='Nhập địa chỉ ' value='{4}'/>
                                        </div>
                                        <label class='col-sm-2 col-form-label text-end'>Liên hệ</label>
                                        <div class='col-sm-4'>
                                            <input class='form-control' placehoder='Nhập số điện thoại' value='{5}'/>
                                        </div>
                                    </div>

                                    <div class='mb-3 row'>
                                        <label class='col-sm-2 col-form-label text-end'>Trạng thái</label>
                                         <div class='col-sm-4'>
                                           <select class='form-select' aria-label='Default select example'>
                                              <option selected=''>{6}</option>
                                              " + strListStatus.ToString() + @"
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

            <button class='btn btn-primary' type='submit' onclick='executeExample('threeButtons')'>Xác nhận sửa</button>

            <!--end card-->
        </div>";


            var htmlEditUser = string.Format(html, userList.userName, userList.userID, userList.roleName, userList.email, userList.address, userList.phone, userList.statusName);
            strBodyEditUser.Append(htmlEditUser);

            html = string.Concat(strBodyEditUser.ToString());
            return html;
        }
    }

}
