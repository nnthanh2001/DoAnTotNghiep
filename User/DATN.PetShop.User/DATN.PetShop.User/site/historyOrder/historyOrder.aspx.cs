using Entities.Order;
using HttpClient_API;
using HttpClient_API.Core.Global;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DATN.PetShop.User.site.historyOrder
{
    public partial class historyOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var Route = HttpContext.Current.Request.RequestContext.RouteData;
            if (Route.Route == null) return;
            var request = Route.Values;
            if (!Page.IsPostBack)
            {
               
                var userID = Request["u"] != null && Request["u"].ToString() != ""
               ? Request["u"].ToString().ToLower().Trim()
               : "";
                

                var orderList = DataOrder(userID);
                main.InnerHtml = orderList;
            }

        }
        public string DataOrder(string u = "")
        {

            var baseUrl = Globals.baseAPI;
            var apiUrl = Globals.getOrderByCustomerAPI + "?userId=" + u;
            

            var strGetOrderByCustomer = Restful.Get<List<OrderModel>>(baseUrl, apiUrl).Result;
            //var orderList = Restful.Get<List<OrderModel>>(baseUrl, apiUrl).Result;
            var value = new StringBuilder();

            
            foreach (var order in strGetOrderByCustomer)
            {
                string subTotal = String.Format("{0:0,00₫}", order.subTotal);
                var str = @"<tr>
                                            <td><a  href='chi-tiet-don-hang-"+order._id+@"'>DH" + order.orderID + @"</a></td>
                                            <td>" + order.productList.Count + @"</td>
                                            <td>" + subTotal + @"</td>
                                            <td>" + order.date + @"</td>
                                            <td>" + order.payment + @"</td>
                                            <td>" + order.status + @"</td>
                                        </tr>";
                value.Append(str);
            }

            var html = @"
<div class='breadcrumb-area pt-95 pb-95 bg-img' style='background-image: url(assets/img/banner/banner-2.jpg);'>
            <div class='container'>
                <div class='breadcrumb-content text-center'>
                    <h2>Lịch sử mua hàng</h2>
                    <ul>
                        <li><a href='trang-chu'>Trang chủ</a></li>
                        <li class='active'>Lịch sử mua hàng</li>
                    </ul>
                </div>
            </div>
        </div>


<div class='cart-main-area pt-95 pb-100'>
        <div class='container'>
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
                                            <th>Sản phẩm</th>
                                            <th>Tổng tiền</th>
                                            <th>Ngày đặt hàng</th>
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
            </div>
        </div>";



            return html;
        }
    }
}