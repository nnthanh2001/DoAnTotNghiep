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

namespace DATN.PetShop.User.site.checkout
{
    public partial class checkout : System.Web.UI.Page
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
                var data = DataCheckout();
                main.InnerHtml = data;

            }
        }
        public string DataCheckout()
        {
            var html = "";
            if (Session["Order"] != null)
            {
                var strOrder = Session["Order"] != null ? Session["Order"]?.ToString() : "";
                strOrder = Session["Order"].ToString();
                //var strOrder = Session["Order"]?.ToString() ?? "";
                var order = JsonConvert.DeserializeObject<OrderModel>(strOrder);
                var orderID = 0;
                string subTotal = "";
                var itemBody = new StringBuilder();
                if (order != null)
                {
                    orderID = order.orderID;

                    subTotal = String.Format("{0:0,00₫}", order.subTotal);
                    string currentDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                    order.date = currentDate;
                    foreach (var item in order.productList)
                    {
                        string price = String.Format("{0:0,00₫}", item.price);
                        string total = String.Format("{0:0,00₫}", item.total);


                        var proHTML = @" <tr>
                                               <td style='width: 235px;'>
                                                    <p class='d-inline-block align-middle mb-0 product-name'>" + item.productName + @"</p>
                                                </td>
                                                <td>" + item.price + " * " + item.quantity + @"</td>
                                                <td>" + total + @"</td>
                                            </tr>";
                        itemBody.Append(proHTML);
                    }
                }



                var header = @"<div class='breadcrumb-area pt-95 pb-95 bg-img' style='background-image: url(assets/img/banner/banner-2.jpg);'>
            <div class='container'>
                <div class='breadcrumb-content text-center'>
                    <h2>Kiểm tra đơn hàng</h2>
                    <ul>
                        <li><a href='site/home/home.aspx.cs'>Trang chủ</a></li>
                        <li class='active'>Thanh toán</li>
                    </ul>
                </div>
            </div>
        </div>";




                var body = @"<div class='cart-main-area pt-95 pb-100'>
            <div class='container'>
                <h3 class='page-title'>Hoàn thành đơn hàng</h3>
                <div class='row'>

                    <div class='col-lg-6'>
                        <div class='card'>
                            <div class='card-header'>
                                <div class='row align-items-center'>
                                    <div class='col'>
                                        <h4 class='card-title'>Sản phẩm</h4>
                                    </div>
                                    <!--end col-->
                                </div>
                                <!--end row-->
                            </div>
                            <!--end card-header-->
                            <div class='card-body'>
                                <div class='table-responsive shopping-cart'>
                                    <table class='table mb-0'>
                                        <thead>
                                            <tr>
                                                <th>Tên</th>
                                                <th>Giá tiền</th>
                                                <th>Tổng tiền</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            " + itemBody.ToString() + @"
                                            <tr>
                                                <td class=' border-bottom-0'>
                                                    <h6>Thành tiền :</h6>
                                                </td>
                                                <td class=' border-bottom-0'></td>
                                                <td class='text-dark border-bottom-0'><strong>" + subTotal + @"</strong></td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                                <!--end re-table-->
                                <div class='total-payment'>
                                    <table class='table mb-0'>
                                        <tbody>
                                            
                                            <tr>
                                                <td class='fw-semibold'>Hình thức thanh toán</td>
                                                <td>" + order.payment + @"</td>
                                            </tr>
                                            <tr>
                                                <td class='fw-semibold  border-bottom-0'>Tổng hóa đơn</td>
                                                <td class='text-dark  border-bottom-0'><strong>" + subTotal + @"</strong></td>
                                            </tr>
                                        </tbody>
                                    </table>
                                    <!--end table-->
                                </div>
                                <!--end total-payment-->
                            </div>
                            <!--end card-body-->
                        </div>
                        <!--end card-->
                    </div>
                    <div class='col-lg-6'>
                        <div class='card'>
                            <div class='card-header'>
                                <div class='row align-items-center'>
                                    <div class='col'>
                                        <h4 class='card-title'>Thông tin giao hàng</h4>
                                    </div>
                                    <!--end col-->
                                </div>
                                <!--end row-->
                            </div>
                            <div class='card-body'>

                                <div class='mb-6 row'>
                                    <label class='col-sm-6'>Tổng tiền hóa đơn</label>
                                    <div class='col-sm-6'>
                                        <span>" + subTotal + @"</span>
                                    </div>
                                </div>
                                 <div class='mb-6 row'>
                                    <label class='col-sm-6'>Mã đơn hàng:</label>
                                    <div class='col-sm-6'>
                                        <span>HD" + orderID + @"</span>
                                    </div>
                                </div>
                                 <div class='mb-6 row'>
                                    <label class='col-sm-6'>Ngày mua hàng:</label>
                                    <div class='col-sm-6'>
                                        <span>" + order.date + @"</span>
                                    </div>
                                </div>
                                 <div class='mb-6 row'>
                                    <label class='col-sm-6'>Họ và tên:</label>
                                    <div class='col-sm-6'>
                                        <span>" + order.shipping.userName + @"</span>
                                    </div>
                                </div>
                                 <div class='mb-6 row'>
                                    <label class='col-sm-6'>Email:</label>
                                    <div class='col-sm-6'>
                                        <span>" + order.shipping.email + @"</span>
                                    </div>
                                </div>
                                 <div class='mb-6 row'>
                                    <label class='col-sm-6'>Địa chỉ giao hàng:</label>
                                    <div class='col-sm-6'>
                                        <span>" + order.shipping.addressDelivery + @"</span>
                                    </div>
                                </div>
                                <div class='mb-6 row'>
                                    <label class='col-sm-6'>Số điện thoại:</label>
                                    <div class='col-sm-6'>
                                        <span>" + order.shipping.phone + @"</span>
                                    </div>
                                </div>
                                <p>Cảm ơn quý khách đã đặt hàng. Nhân viên của chúng tôi sẽ gọi điện lại cho quý khách để xác nhận đơn hàng, thông báo phí giao hàng (nếu có) và hướng dẫn quý khách các phương thức thanh toán. Mọi chi tiết xin liên hệ Tổng đài 024.7106.9906 – 028.7106.9906 để được hỗ trợ.</p>
                                <button class='btn-style' type='button' jsaction='Order'><a href='hoan-tat-dat-hang'>Xác nhận</a></button>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>";


                html = string.Concat(header, body);
            }
            else
            {
                Response.Redirect("trang-chu");
            }

            return html;
        }

    }
}