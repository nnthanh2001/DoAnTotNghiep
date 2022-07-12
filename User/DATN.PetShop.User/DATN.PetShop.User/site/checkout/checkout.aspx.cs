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
                        var proHTML = @"<tr>
                                    <td class='product-name' style='padding-left:20px;'> " + item.productName + @"</td>
                                     <td class='product-quantity-cart' style='text-align: center;'><span class='amount'>" + price + @"<b>x" + item.quantity + @"</b></span></td>
                                    <td class='product-subtotal'>" + total + @"</td>
                                </tr>";
                        itemBody.Append(proHTML);
                    }
                }



                var header = @"<div class='breadcrumb-area pt-95 pb-95 bg-img' style='background-image: url(assets/img/banner/banner-2.jpg);'>
            <div class='container'>
                <div class='breadcrumb-content text-center'>
                    <h2>Checkout</h2>
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

                    <div class='col-lg-7 '>
                        <div class='table-content table-responsive'>
                            <table>
                                <tr>
                                    <th>Tên sản phẩm</th>

                                    <th>Giá tiền</th>
                                    <th>Tổng tiền</th>
                                </tr>
                               " + itemBody.ToString() + @"
                            </table>
                        </div>
                    </div>
                    <div class='col-lg-5 '>
                        <div class='grand-totall'style='width: 580px;'>


                            <div class='large-7 col'>

                                <section class='woocommerce-order-details'>
                                    <h2 class='woocommerce-order-details__title'  style='text-align: center;'>Kiểm tra thông tin</h2>
                                    <table class='woocommerce-table woocommerce-table--order-details shop_table order_details'>
                                        <thead>
                                            <tr>
                                                <th class='woocommerce-table__product-name product-name'>Tổng tiền hóa đơn</th>
                                                <th class='woocommerce-table__product-table product-total'>" + subTotal + @"</th>
                                            </tr>
                                        </thead>

                                        <tfoot>
                                            <tr>
                                                <th scope='row'>Mã đơn hàng:</th>
                                                <td>" + orderID + @"</td>
                                            </tr>
                                            <tr>
                                                <th scope='row'style='white-space: nowrap'>Phương thức thanh toán:</th>
                                                <td>Thanh toán sau khi nhận hàng</td>
                                            </tr>
                                            <tr>
                                                <th scope='row'>Ngày mua hàng:</th>
                                                <td>" + order.date + @"</td>
                                            </tr>
                                            <tr>
                                                <th scope='row'>Họ và tên:</th>
                                                <td>" + order.shipping.userName + @"</td>
                                            </tr>
                                            <tr>
                                                <th scope='row'>Email:</th>
                                                <td>" + order.shipping.email + @"</td>
                                            </tr>
                                            <tr>
                                                <th scope='row'>Địa chỉ giao hàng:</th>
                                                <td>" + order.shipping.addressDelivery + @"</td>
                                            </tr>
                                            <tr>
                                                <th scope='row'>Số điện thoại:</th>
                                                <td>" + order.shipping.phone + @"</td>
                                            </tr>
                                        </tfoot>
                                    </table>
                                </section>
                                <p>Cảm ơn quý khách đã đặt hàng. Nhân viên của chúng tôi sẽ gọi điện lại cho quý khách để xác nhận đơn hàng, thông báo phí giao hàng (nếu có) và hướng dẫn quý khách các phương thức thanh toán. Mọi chi tiết xin liên hệ Tổng đài 0987654321 – 0123456789 để được hỗ trợ.</p>
                                <button class='btn-style' type='button'><a jsaction='Order' href='cam-on'>Xác nhận</a></button>
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