using Entities.Request;
using Entities.User;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DATN.PetShop.Admin
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["login"] != null) {
                leftSidebar.InnerHtml = dataLeftSidebar();
            }
            else
            {
                Response.Redirect("~/site/login/login.aspx");
            }


        }
        public string dataLeftSidebar()
        {
            var strUser = Session["login"]?.ToString() ?? "";
            var model = JsonConvert.DeserializeObject<RequestModel<UserModel>>(strUser);
            var user = model.model;
            var checkAdmin = new StringBuilder();
            if(user.roleID == 1)
            {
                var htmlListUser = @" <li class='nav-item'>
                            <a class='nav-link' href='#sidebarProjects' data-bs-toggle='collapse' role='button'
                                aria-expanded='false' aria-controls='sidebarProjects'>
                                <i class='ti ti-brand-asana menu-icon'></i>
                                <span>Nhân viên_Khách hàng</span>
                            </a>
                            <div class='collapse ' id='sidebarProjects'>
                                <ul class='nav flex-column'>
                                    <!--end nav-item-->
                                    <li class='nav-item'>
                                        <a class='nav-link' href='/nhan-vien'>Danh sách nhân viên</a>
                                    </li>
                                    <li class='nav-item'>
                                        <a class='nav-link' href='/khach-hang'>Danh sách khách hàng</a>
                                    </li>
                                    <!--end nav-item-->
                                </ul>
                                <!--end nav-->
                            </div>
                            <!--end sidebarProjects-->
                        </li>
                        <!--end nav-item-->";
                checkAdmin.Append(htmlListUser);
            }


            var html = @"  <div class='brand'>
            <a href='index.html' class='logo'>
                <span>
                     <img src='assets/images/logos/NT.svg '' alt='logo-small' height='50'>
                </span>
                <span>
                    <img src='assets/images/Layer 2.svg' alt='logo-small' class='logo-lg logo-light'>
                    <img src='assets/images/logo-dark.png' alt='logo-large' class='logo-lg logo-dark'>
                </span>
            </a>
        </div>
        <div class='sidebar-user-pro media border-end'>

            <div class='media-body ms-2 user-detail align-self-center'>
                <h5 class='font-14 m-0 fw-bold'>" + user.userName + @"</h5>
                <p class='opacity-50 mb-0'>" + user.roleName + @"</p>
            </div>
        </div>
        <div class='border-end'>
            <ul class='nav nav-tabs menu-tab nav-justified' role='tablist'>
                <li class='nav-item'>
                    <a class='nav-link active' data-bs-toggle='tab' href='#Main' role='tab' aria-selected='true'><span>Danh sách dữ liệu NTPET</span></a>
                </li>

            </ul>
        </div>
        <!-- Tab panes -->
        <!--end logo-->
        <div class='menu-content h-100'>
            <div class='menu-body navbar-vertical'>
                <div class='collapse navbar-collapse tab-content' id='sidebarCollapse'>
                    <!-- Navigation -->
                    <ul class='navbar-nav tab-pane active' id='Main' role='tabpanel'>
                        <li class='menu-label mt-0 text-primary font-12 fw-semibold'><span>Dữ liệu</span><br>
                            <span class='font-10 text-secondary fw-normal'>Bảng dữ liệu</span></li>

                         " + checkAdmin.ToString() + @"
                       

                        <li class='nav-item'>
                            <a class='nav-link' href='#sidebarEcommerce' data-bs-toggle='collapse' role='button'
                                aria-expanded='false' aria-controls='sidebarEcommerce'>
                                <i class='ti ti-planet menu-icon'></i>
                                <span>Cửa hàng</span>
                            </a>
                            <div class='collapse ' id='sidebarEcommerce'>
                                <ul class='nav flex-column'>

                                    <li class='nav-item'>
                                        <a class='nav-link' href='/san-pham'><span>Danh sách sản phẩm</span></a>
                                    </li>

                                    <!--end nav-item-->
                                    <li class='nav-item'>
                                        <a class='nav-link' href='/dich-vu'><span>Danh sách dịch vụ</span></a>
                                    </li>
                                    <!--end nav-item-->
                                </ul>
                                <!--end nav-->
                            </div>
                            <!--end sidebarEcommerce-->
                        </li>

                        <li class='nav-item'>
                            <a class='nav-link' href='#sidebarTables' data-bs-toggle='collapse' role='button'
                                aria-expanded='false' aria-controls='sidebarTables'>
                                <i class='ti ti-table menu-icon'></i>
                                <span>Thống kê</span>
                            </a>
                            <div class='collapse ' id='sidebarTables'>
                                <ul class='nav flex-column'>
                                    <li class='nav-item'>
                                        <a class='nav-link' href='/thong-ke-doanh-thu'><i class='ti ti-stack menu-icon'></i><span>Thống kê doanh thu</span></a>
                                    </li>
                                    <!--end nav-item-->
                                    <li class='nav-item'>
                                        <a class='nav-link' href='/don-hang'><i class='ti ti-file-invoice menu-icon'></i><span>Đơn hàng</span></a>
                                    </li>

                                    <!--end nav-item-->

                                </ul>
                                <!--end nav-->
                            </div>
                            <!--end sidebarTables-->
                        </li>
                        <li class='nav-item'>
                            <a class='nav-link active' href='dang-nhap'><span>Đăng xuất</span></a>
                        </li>
                        <!--end nav-item-->
                    </ul>

                    <!--end navbar-nav--->
                </div>
                <!--end sidebarCollapse-->
            </div>
        </div>";

           
            return html;
        }
    }
}