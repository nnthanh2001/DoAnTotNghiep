using Entities.Order;
using HttpClient_API;
using HttpClient_API.Core.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DATN.PetShop.User.site.historyOrder
{
    public partial class detailOrder : System.Web.UI.Page
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

                var data = DataOrderDetail(id);
                main.InnerHtml = data;
            }

        }
        public string DataOrderDetail(string id)
        {
            var baseUrl = Globals.baseAPI;
            var apiUrl = Globals.orderDetailAPI + "/" + id;
            var order = Restful.Get<OrderModel>(baseUrl, apiUrl).Result;
            var value = new StringBuilder();
            var productList = order.productList;

            string subTotal = String.Format("{0:0,00₫}", order.subTotal);
            if (productList != null)
            {
                foreach (var product in productList)
                {
                    string price = String.Format("{0:0,00₫}", product.price);
                    string total = String.Format("{0:0,00₫}", product.total);
                    var str = @"<tr>
                                            <td>
                                                <img src='" + product.image + @"' alt='' height='40' class='me-2'>
                                                <p class='d-inline-block align-middle mb-0'>
                                                    <a href='' class='d-inline-block align-middle mb-0 product-name'>" + product.productName + @"</a>
                                                    <br>
                                                   
                                                </p>
                                            </td>
                                            <td>" + price + @"</td>
                                            <td>" + product.quantity + @"</td>
                                            <td>" + total + @"</td>
                                        </tr>";
                    value.Append(str);
                }
            }



            var html = @"
<div class='breadcrumb-area pt-95 pb-95 bg-img' style='background-image: url(assets/img/banner/banner-2.jpg);'>
            <div class='container'>
                <div class='breadcrumb-content text-center'>
                    <h2>Chi tiết đơn hàng</h2>
                    <ul>
                        <li><a href='trang-chu'>Trang chủ</a></li>
                        <li class='active'>Chi tiết đơn hàng</li>
                    </ul>
                </div>
            </div>
        </div>

<div class='cart-main-area pt-95 pb-100'>
        <div class='container'>
            <!-- end page title end breadcrumb -->
            <div class='row'>
                <div class='col-lg-12'>
                    <div class='card'>
                        <div class='card-header'>
                            <div class='row align-items-center'>
                                <div class='col'>
                                    <h4 class='card-title'>Đơn hàng: DH" + order.orderID + @"</h4>
                                </div>
                                <!--end col-->
                            </div>
                            <!--end row-->
                        </div>
                        <!--end card-header-->
                        <div class='card-body'>
                            
                            <div class='table-responsive'>
                                <table class='table mb-0'>
                                    <thead>
                                        <tr>
                                            <th>Tên sản phẩm</th>
                                            <th>Giá tiền</th>
                                            <th>Số lượng</th>
                                            <th>Tổng tiền</th>

                                        </tr>
                                    </thead>
                                    <tbody>
                                        " + value.ToString() + @"
                                    </tbody>
                                </table>
                            </div>
                            <div class='row justify-content-center'>
                                <div class='col-md-6 align-self-center'>
                                </div>
                                <!--end col-->
                                <div class='col-md-6'>
                                    <div class='total-payment p-3 mt-4'>
                                        <table class='table'>
                                            <tbody>
                                               
                                                <tr>
                                                    <td class='border-bottom-0'>Tổng hóa đơn</td>
                                                    <td class='text-dark border-bottom-0'><strong>" + subTotal + @"</strong></td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                                <!--end col-->
                            </div>
                            <!--end row-->
                        </div>
                        <!--end card-->
                    </div>
                    <!--end card-body-->
                </div>
                <!--end col-->
            </div>
            <!--end row-->
        </div>
       </div>";

            return html;
        }
    }
}