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

namespace DATN.PetShop.User.site.account
{
    public partial class account : System.Web.UI.Page
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

                var getAccount = GetDataAccount(id);
                main.InnerHtml = getAccount;
            }
        }

        public string GetDataAccount(string id)
        {
            var baseUrl = Globals.baseAPI;
            var apiUser = Globals.userAPI + "/" + id;
            var user = Restful.Get<UserModel>(baseUrl, apiUser).Result;

            var html = "";
            if (Session["login"] != null)
            {
                 html = @" <div class='breadcrumb-area pt-95 pb-95 bg-img' style='background-image: url(assets/img/banner/banner-2.jpg);'>
            <div class='container'>
                <div class='breadcrumb-content text-center'>
                    <h2>Tài khoản</h2>
                    <h2>" + user.userName + @"</h2>
                </div>
            </div>
        </div>
        <div class='my-account-area pt-100 pb-70'>
            <div class='container'>
                <div class='row'>
                    <div class='col-lg-12'>
                        <div class='checkout-wrapper'>
                            <div id='faq' class='panel-group'>
                                <div class='panel panel-default'>
                                    <div class='panel-heading'>
                                        <h5 class='panel-title'><span>1</span> <a data-toggle='collapse' data-parent='#faq' href='#my-account-1' aria-expanded='false' class='collapsed'>Chỉnh sửa thông tin</a></h5>
                                    </div>
                                    <div id='my-account-1' class='panel-collapse collapse' style=''>
                                        <div class='panel-body'>
                                            <div class='billing-information-wrapper'>
                                                <div class='account-info-wrapper'>
                                                    <h4>Thông tin tài khoản</h4>
                                                    <h5>" + user.userName + @"</h5>
                                                </div>
                                                <div class='row'>
                                                    <div class='col-lg-12 col-md-12'>
                                                        <div class='billing-info'>
                                                            <label>Họ và tên</label>
                                                            <input type='text' value='" + user.userName + @"'>
                                                        </div>
                                                    </div>

                                                    <div class='col-lg-12 col-md-12'>
                                                        <div class='billing-info'>
                                                            <label>Email</label>
                                                            <input type='email' value='" + user.email + @"'>
                                                        </div>
                                                    </div>
                                                    <div class='col-lg-6 col-md-6'>
                                                        <div class='billing-info'>
                                                            <label>Số điện thoại</label>
                                                            <input type='text' value='" + user.phone + @"'>
                                                        </div>
                                                    </div>
                                                    <div class='col-lg-6 col-md-6'>
                                                        <div class='billing-info'>
                                                            <label>Địa chỉ</label>
                                                            <input type='text' value='" + user.address + @"'>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class='billing-back-btn'>
                                                    <div class='billing-btn'>
                                                        <button type='submit'>Lưu thay đổi</button>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class='panel panel-default'>
                                    <div class='panel-heading'>
                                        <h5 class='panel-title'><span>2</span> <a data-toggle='collapse' data-parent='#faq' href='#my-account-2' class='collapsed' aria-expanded='false'>Mật khẩu của bạn</a></h5>
                                    </div>
                                    <div id='my-account-2' class='panel-collapse collapse'>
                                        <div class='panel-body'>
                                            <div class='billing-information-wrapper'>
                                                <div class='account-info-wrapper'>
                                                    <h4>Đổi mật khẩu</h4>
                                                    <h5>Your Password</h5>
                                                </div>
                                                <div class='row'>
                                                    <div class='col-lg-12 col-md-12'>
                                                        <div class='billing-info'>
                                                            <label>Mật khẩu</label>
                                                            <input type='password'>
                                                        </div>
                                                    </div>
                                                    <div class='col-lg-12 col-md-12'>
                                                        <div class='billing-info'>
                                                            <label>Xác nhận mật khẩu</label>
                                                            <input type='password'>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class='billing-back-btn'>
                                                  
                                                    <div class='billing-btn'>
                                                        <button type='submit'>Lưu thay đổi</button>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                               <div class='panel panel-default'>
                                    <div class='panel-heading'>
                                        <h5 class='panel-title'><span>3</span> <a href='lich-su-don-hang?u="+ user._id+ @"'>Lịch sử mua hàng</a></h5>
                                    </div>
                                </div>
                                <div class='billing-btn'>
                                    <button type='submit'jsaction='signOut'>Đăng xuất</button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>";

                html = string.Concat(html.ToString());
            }
            else
            {
                Response.Redirect("dang-nhap");
            }





            return html;
        }
    }
}