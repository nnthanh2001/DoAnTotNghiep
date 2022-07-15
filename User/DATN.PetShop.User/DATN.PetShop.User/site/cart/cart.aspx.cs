using Entities.Order;
using Entities.Product;
using Entities.Request;
using Entities.User;
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
            var checkLoginHtml = new StringBuilder();
            var strcheckCart = new StringBuilder();
            //var order = Restful.Get<OrderModel>(baseUrl, orderApi).Result;
            string subTotal = "0";
            
            if (Session["Order"] == null)
            {
                var itemHtml = @"<h4 style='text-align: center;'>Hiện tại không có sản phẩm nào trong giỏ hàng!</h4>";
                itemBody.Append(itemHtml);
            }
            else
            {
                var strorder = Session["Order"].ToString();
                var order = JsonConvert.DeserializeObject<OrderModel>(strorder);
                subTotal = String.Format("{0:0,00đ}", order.subTotal);

                foreach (var item in order.productList)
                {


                    string price = String.Format("{0:0,00₫}", item.price);
                    string total = String.Format("{0:0,00₫}", item.total);

                    var itemHtml = @" <tbody><tr>
                                            <td class='product-remove'><a href='javascript:void(0);' jsaction='deleteItemButton' value='" + item._id + @"'><i class='ti-trash'></i></a></td>
                                            <td class='product-thumbnail'>
                                                <a href='/chi-tiet-san-pham/" + item.productHandle + "-" + item._id + "-" + item.categoryID + @"'>
                                                    <img src='" + item.image + @"' alt=''style='height: 150px;'></a>
                                             </td>
                                            <td class='product-name'><a href='/chi-tiet-san-pham/" + item.productHandle + "-" + item._id + "-" + item.categoryID + @"'>" + item.productName + @"</a></td>
                                            <td class='product-price-cart'><span class='amount'>" + price + @"</span></td>
                                            <td class='product-quantity'>
                                                <div class='cart-plus-minus'>
                                                    <input class='cart-plus-minus-box' type='text' name='qtybutton' value='" + item.quantity + @"'>
                                                </div>
                                            </td>
                                            <td class='product-subtotal'>" + total + @"</td>
                                           
                                        </tr>
                                      </tbody>";
                    itemBody.Append(itemHtml);
                }
            }


            if (Session["login"] == null)
            {
                var checkLogin = @"<div class='panel-heading'>
                                    <h5 class='panel-title'><a data-toggle='collapse'href='javascript:void(0);' jsaction='notification'>Tiến hành thanh toán</a></h5>
                                </div>";
                checkLoginHtml.AppendLine(checkLogin);
            }

            if (Session["login"] != null)
            {
                var strCustomer = Session["login"].ToString();
                var customer = JsonConvert.DeserializeObject<RequestModel<UserModel>>(strCustomer);
                var user = customer.model;

                if (Session["Order"] != null)
                {
                   
                    if (Session["ProductGuid"] == null)
                    {
                        var buttonCheckout = @"<div class='billing-btn'>
                    <button type='submit'><a jsaction='checkListProduct'>Tiếp tục</a></button>
                </div>";
                        strcheckCart.Append(buttonCheckout);
                    }
                    else
                    {
                        var buttonCheckout = @"<div class='billing-btn'>
                    <button type='submit'><a jsaction='checkOut'>Tiếp tục</a></button>
                </div>";
                        strcheckCart.Append(buttonCheckout);
                    }
                }
                    
                var dataOrder = @"
<div class='panel-heading'>
    <h5 class='panel-title'><a data-toggle='collapse' data-parent='#faq' href='#payment-5'>Tiến hành thanh toán</a></h5>
</div>
<div id='payment-5' class='panel-collapse collapse'>
    <div class='panel-body'>
        <div class='payment-info-wrapper'>
            <h4>Thông tin nhận hàng</h4>
            <div class='payment-info'>
                <div class='row'>
                    <div class='col-lg-12 col-md-12'>
                        <div class='billing-select card-mrg'>
                            <label>Họ và tên (Full name)</label>
                            <input type='text' data_value='userName' value='" + user.userName + @"'>
                        </div>
                    </div>
                    <div class='col-lg-12 col-md-12'>
                        <div class='billing-select card-mrg'>
                            <label>Email (Email address)</label>
                            <input type='text' data_value='email' value='" + user.email + @"'>
                        </div>
                    </div>
                    <div class='col-lg-12 col-md-12'>
                        <div class='billing-select card-mrg'>
                            <label>Địa chỉ giao hàng (Vui lòng nhập chính xác, đây sẽ là địa chỉ hàng giao đến) </label>
                            <input type='text' data_value='addressDelivery' value='" + user.address + @"'>
                        </div>
                    </div>
                </div>

                <div class='row'>
                    <div class='col-lg-12 col-md-12'>
                        <div class='billing-select card-mrg'>
                            <label>Số điện thoại (Phone number)</label>
                            <input type='number' data_value='phone' value='" + user.phone + @"'>
                        </div>
                    </div>
                </div>
            </div>
            <div class='ship-wrapper'>
            <h6>Phương thức thanh toán:</h6>
                <div class='single-ship'>
                    <input type='radio'  data_value='1' name='payment' checked=''>
                    <label>Thanh toán sau khi nhận hàng </label>
                </div>
                <div class='single-ship'>
                    <input type='radio' data_value='2' name='payment'>
                    <label>Thanh toán online </label>
                </div>
            </div>
            <div class='billing-back-btn'>
                <div class='billing-back'>
                    <a href='#'><i class='ti-arrow-up'></i>Quay lại trang trước</a>
                </div>
                " + strcheckCart.ToString() + @"

            </div>
        </div>
    </div>
</div>";
                checkLoginHtml.Append(dataOrder);
            }
            
            var header = @"<div class='breadcrumb-area pt-95 pb-95 bg-img' style='background-image: url(assets/img/banner/banner-2.jpg);'>
            <div class='container'>
                <div class='breadcrumb-content text-center'>
                    <h2>Giỏ hàng</h2>
                    <ul>
                        <li><a href='trang-chu'>Trang chủ</a></li>
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
                                    <th>Xóa</th>
                                    <th>Hình ảnh</th>
                                    <th>Tên sản phẩm</th>
                                    <th>Giá sản phẩm</th>
                                    <th>Số lượng</th>
                                    <th>Tổng tiền</th>
                                </tr>
                            </thead>
                           
                                " + itemBody.ToString() + @"
                            
                        </table>
                    </div>
                    <div class='row'>
                        <div class='col-lg-12'>
                            <div class='cart-shiping-update-wrapper'>
                                <div class='cart-shiping-update'>
                                    <a href='san-pham'>Tiếp tục mua hàng</a>
                                    <a href='#'>Cập nhật giỏ hàng</a>
                                </div>
                                <div class='cart-clear' jsaction='deleteAllButton'>
                                    <a>Xóa toàn bộ sản phẩm trong giỏ hàng</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </form>
                <div class='col-lg-12'>
                    <div class='grand-totall'>
                        <h5>Tổng tiền:" + subTotal + @"</h5>
                        " + checkLoginHtml.ToString() + @"     
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