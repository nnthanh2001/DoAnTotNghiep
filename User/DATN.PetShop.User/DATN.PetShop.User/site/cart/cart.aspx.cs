using Entities.Order;
using Entities.Product;
using HttpClient_API;
using HttpClient_API.Core.Global;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DATN.PetShop.User.site.cart
{
    public partial class cart : System.Web.UI.Page
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
                var getShoppingCart = GetDataCart(id);
                main.InnerHtml = getShoppingCart;
            }

        }

        public string GetDataCart(string id)
        {
            var baseUrl = Globals.baseAPI;
            var orderApi = Globals.orderAPI + "/" + id;
            var itemBody = new StringBuilder();
            //var order = Restful.Get<OrderModel>(baseUrl, orderApi).Result;
            string subTotal = "0";
            if (Session["Order"] != null)
            {
                var strorder = Session["Order"].ToString();

                var order = JsonConvert.DeserializeObject<OrderModel>(strorder);
                subTotal = String.Format("{0:0,00đ}", order.subTotal);

                foreach (var item in order.productList)
                {
                    string price = String.Format("{0:0,00vnđ}", item.price);
                    string total = String.Format("{0:0,00vnđ}", item.total);

                    var itemHtml = @"<tr>
                                            <td class='product-thumbnail'>
                                                <a href='#'>
                                                    <img src='"+item.image+@"' alt=''></a>
                                            </td>
                                            <td class='product-name'><a href='#'>" + item.productName + @"</a></td>
                                            <td class='product-price-cart'><span class='amount'>" + price + @"</span></td>
                                            <td class='product-quantity'>
                                                <div class='cart-plus-minus'>
                                                    <input class='cart-plus-minus-box' type='text' name='qtybutton' value='" + item.quantity + @"'>
                                                </div>
                                            </td>
                                            <td class='product-subtotal'>" + total + @"</td>
                                            <td class='product-remove'><a href='#'><i class='ti-trash'></i></a></td>
                                        </tr>";
                    itemBody.Append(itemHtml);


                }
            }
            else
            {
                var itemHtml = @"<tr><h3>Hiện tại không có sản phẩm nào trong giỏ hàng! </h3></tr>";
                itemBody.Append(itemHtml);
            }

            var header = @"<div class='breadcrumb-area pt-95 pb-95 bg-img' style='background-image: url(assets/img/banner/banner-2.jpg);'>
            <div class='container'>
                <div class='breadcrumb-content text-center'>
                    <h2>Giỏ hàng</h2>
                    <ul>
                        <li><a href='site/home/home.aspx.cs'>Trang chủ</a></li>
                        <li class='active'>Cart Page</li>
                    </ul>
                </div>
            </div>
        </div>";

            var body = @"<div class='cart-main-area pt-95 pb-100'>
            <div class='container'>
                <h3 class='page-title'>Mục giỏ hàng của bạn</h3>
                <div class='row'>
                    <div class='col-lg-12 col-md-12 col-sm-12 col-12'>

                        <form action='#'>
                            <div class='table-content table-responsive'>
                                <table>
                                    <thead>
                                        <tr>
                                            <th>Hình ảnh</th>
                                            <th>Tên sản phẩm</th>
                                            <th>Giá sản phẩm</th>
                                            <th>Số lượng</th>
                                            <th>Tổng tiền</th>
                                            <th>Xóa</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        " + itemBody.ToString() + @"
                                    </tbody>
                                </table>
                            </div>
                            <div class='row'>
                                <div class='col-lg-12'>
                                    <div class='cart-shiping-update-wrapper'>
                                        <div class='cart-shiping-update'>
                                            <a href='san-pham'>Tiếp tục mua hàng</a>
                                            <a href='#'>Cập nhật giỏ hàng</a>
                                        </div>
                                        <div class='cart-clear'>
                                            <a href='#'>Xóa toàn bộ sản phẩm trong giỏ hàng</a>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </form>

                        <div class='col-lg-12'>
                            <div class='grand-totall'>
                               
                                <h5>Tổng tiền:   " + subTotal + @"</h5>
                                <div class='panel-heading'>
                                    <h5 class='panel-title'><a data-toggle='collapse' data-parent='#faq' href='#payment-5'>Tiến hành thanh toán</a></h5>
                                </div>

                                <div id='payment-5' class='panel-collapse collapse'>
                                    <div class='panel-body'>
                                        <div class='payment-info-wrapper'>
                                            <div class='ship-wrapper'>
                                                <div class='single-ship'>
                                                    <input type='radio' checked='' value='address' name='address'>
                                                    <label>Thanh toán online </label>
                                                </div>
                                                <div class='single-ship'>
                                                    <input type='radio' value='dadress' name='address'>
                                                    <label>Thanh toán sau khi nhận hàng </label>
                                                </div>
                                            </div>
                                            <div class='payment-info'>
                                                <div class='row'>
                                                    <div class='col-lg-12 col-md-12'>
                                                        <div class='billing-select card-mrg'>
                                                            <label>Họ và tên (Full name)</label>
                                                            <input type='text'>
                                                        </div>
                                                    </div>
                                                    <div class='col-lg-12 col-md-12'>
                                                        <div class='billing-select card-mrg'>
                                                            <label>Email (Email address)</label>
                                                            <input type='text'>
                                                        </div>
                                                    </div>
                                                    <div class='col-lg-12 col-md-12'>
                                                        <div class='billing-select card-mrg'>
                                                            <label>Địa chỉ giao hàng (Address) </label>
                                                            <input type='text'>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class='row'>
                                                    <div class='col-lg-12 col-md-12'>
                                                        <div class='billing-select card-mrg'>
                                                            <label>Số điện thoại (Phone number)</label>
                                                            <input type='text'>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class='billing-back-btn'>
                                                <div class='billing-back'>
                                                    <a href='site/checkout/checkout.aspx'><i class='ti-arrow-up'></i>Quay lại trang trước</a>
                                                </div>
                                                <div class='billing-btn'>
                                                    <button type='submit'><a href='/thanh-toan'>Tiếp tục</a></button>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>";

            var footer = @"";




            var html = string.Concat(header, body, footer);
            return html;
        }
    }
}