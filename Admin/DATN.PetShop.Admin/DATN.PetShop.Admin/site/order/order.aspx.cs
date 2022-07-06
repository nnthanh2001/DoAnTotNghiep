using Entities.Order;
using HttpClient_API;
using HttpClient_API.Core.Global;
using System;
using System.Collections.Generic;
using System.Text;

namespace DATN.PetShop.Admin.site.order
{
    public partial class order : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var orderList = DataOrder();
            main.InnerHtml = orderList;
        }
        public string DataOrder()
        {
           
            var baseUrl = Globals.baseAPI;
            var apiUrl = Globals.orderAPI;
            var orderList = Restful.Get<List<OrderModel>>(baseUrl, apiUrl).Result;
            var value = new StringBuilder();
            foreach (var order in orderList)
            {
                string subTotal = String.Format("{0:0,00₫}", order.subTotal);
                var str = @"<tr>
                                            <td><a  href='chi-tiet-don-hang-" + order._id+ @"'>" + order.orderID+ @"</a></td>
                                            <td>" + order.shipping.userName + @"</td>
                                            <td>" + subTotal + @"</td>
                                            <td>" + order.date + @"</td>
                                            <td>" + order.shipping.phone + @"</td>
                                            <td>" + order.payment + @"</td>
                                            <td>" + order.status + @"</td>
                                        </tr>";
                value.Append(str);
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