using Entities.Order;
using HttpClient_API;
using HttpClient_API.Core.Global;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace DATN.PetShop.Admin.site.order
{
    public partial class order : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var Route = HttpContext.Current.Request.RequestContext.RouteData;
            if (Route.Route == null) return;
            var request = Route.Values;
            if (!Page.IsPostBack)
            {
                var month = Request["m"] != null && Request["m"].ToString() != ""
                ? Request["m"].ToString().ToLower().Trim()
                : "";
                var date = Request["d"] != null && Request["d"].ToString() != ""
               ? Request["d"].ToString().ToLower().Trim()
               : "";
                var userID = Request["u"] != null && Request["u"].ToString() != ""
              ? Request["u"].ToString().ToLower().Trim()
              : "";
                var pageIndex = Request["p"] != null && Request["p"].ToString() != ""
               ? int.Parse(Request["p"]?.ToString() ?? "0")
               : 0;

                var orderList = DataOrder(date, userID);
                main.InnerHtml = orderList;
            }

        }
        public string DataOrder(string d = "", string u = "")
        {

            var baseUrl = Globals.baseAPI;
            var apiUrl = Globals.getOrderByCustomerAPI + "?userId=" + u;
            var apiUrlGetOrderByDay = Globals.orderByDayAPI + "?date=" + d;
            var strGetOrderByCustomer = new List<OrderModel>();


            var strGetOrderByDay = Restful.Get<List<OrderModel>>(baseUrl, apiUrlGetOrderByDay).Result;

            var value = new StringBuilder();

            if (!string.IsNullOrEmpty(u))
            {



                strGetOrderByCustomer = Restful.Get<List<OrderModel>>(baseUrl, apiUrl).Result;
                foreach (var order in strGetOrderByCustomer)
                {

                    var notification = (order.status == "Đang chờ xác nhận" || order.status == "Đã thanh toán") ? "" : @"<i class='fas fa-bell'></i>";

                    string subTotal = String.Format("{0:0,00₫}", order.subTotal);
                    var str = @"<tr>
                                            <td><a href='chi-tiet-don-hang-" + order._id + @"'>" + order.orderID + @"</a></td>
                                            <td><a href='don-hang?u=" + order.shipping.userId + @"'>" + order.shipping.userName + @"</td>
                                            <td>" + subTotal + @"</td>
                                            <td>" + order.date + @"</td>
                                            <td>" + order.shipping.phone + @"</td>
                                            <td>" + order.payment + @"</td>
                                            <td data_value='status'>" + order.status + @"</td>
                                            <td><a href='javascript:void(0);' jsaction='updateStatusOrder' value='" + order._id + @"'>" + notification + @"</a></td>
                                        </tr>";
                    value.Append(str);
                }
            }
            else
            {

                foreach (var order in strGetOrderByDay)
                {
                    var notification = (order.status == "Đang chờ xác nhận" || order.status == "Đã thanh toán") ? "" : @"<i class='fas fa-bell'></i>";
                    string subTotal = String.Format("{0:0,00₫}", order.subTotal);
                    var str = @"<tr>
                                            <td><a href='chi-tiet-don-hang-" + order._id + @"'>" + order.orderID + @"</a></td>
                                            <td><a href='don-hang?u=" + order.shipping.userId + @"'>" + order.shipping.userName + @"</td>
                                            <td>" + subTotal + @"</td>
                                            <td>" + order.date + @"</td>
                                            <td>" + order.shipping.phone + @"</td>
                                            <td>" + order.payment + @"</td>
                                            <td>" + order.status + @"</td>
                                            <td><a href='javascript:void(0);' jsaction='updateStatusOrder' value='" + order._id + @"'>" + notification + @"</a></td>
                                        </tr>";
                    value.Append(str);
                }

            }


            var html = @"<div class='topbar'>
        <!-- Navbar -->
        <nav class='navbar-custom' id='navbar-custom'>
            <ul class='list-unstyled topbar-nav mb-0'>
                <li>
                    <button class='nav-link button-menu-mobile nav-icon' id='togglemenu'>
                        <i class='ti ti-menu-2'></i>
                    </button>
                </li>
                <li class='hide-phone app-search'>
                    <form role='' action='' method='get'>
                        <input type='k' name='k' class='form-control top-search mb-0' placeholder='Tìm kiếm...'>
                        <button type='submit'><i class='ti ti-search'></i></button>
                    </form>
                </li>
            </ul>
        </nav>
        <!-- end navbar-->
    </div>



<div class='container-fluid'>
            <div class='row'>
                <div class='col-sm-12'>
                    <div class='page-title-box'>
                        <div class='float-end'>
                            <ol class='breadcrumb'>
                                <li class='breadcrumb-item'><a href='#'>Pet shop</a></li>

                                <li class='breadcrumb-item active'>Đơn đặt hàng</li>
                            </ol>
                        </div>
                        <h4 class='page-title'>Danh sách đơn hàng</h4>
                    </div>
                </div>
            </div>
            <div class='row'>
                <div class='col-12'>
                    <div class='card'>
                        <div class='card-header'>
                            <h4 class='card-title'>Thông tin đơn hàng </h4>
                        </div>
                        <div class='card-body'>
                            <div class='table-responsive'>
                                <table class='table' id='datatable_1'>
                                    <thead class='thead-light'>
                                        <tr>
                                            <th>Mã đơn hàng</th>
                                            <th>Họ và tên</th>
                                            <th>Tổng tiền</th>
                                            <th>Ngày đặt hàng</th>
                                            <th>Số điện thoại</th>
                                            <th>Hình thức thanh toán</th>
                                            <th>Trạng thái</th>
                                            <th></th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        " + value.ToString() + @"
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>";



            return html;
        }

    }
}