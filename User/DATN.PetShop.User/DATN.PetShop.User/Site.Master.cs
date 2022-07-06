using Entities.Order;
using Entities.Request;
using Entities.User;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DATN.PetShop.User
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            header.InnerHtml = DataHeader();
        }
        public string DataHeader()
        {
           
               
            
            var quantityProductInCart = 0;
            var sumTotal = "";
            var itemProduct = new StringBuilder();
            var itemCart = new StringBuilder();
            if (Session["Order"] != null)
            {
                var strorder = Session["Order"].ToString();
                var order = JsonConvert.DeserializeObject<OrderModel>(strorder);
                var subTotal = String.Format("{0:0,00đ}", order.subTotal);
                var productList = order.productList;
                quantityProductInCart = productList.Count;
                sumTotal = subTotal;
                
                foreach (var item in productList)
                {
                    string price = String.Format("{0:0,00₫}", item.price);
                    string total = String.Format("{0:0,00₫}", item.total);

                    var itemHTML = @"<ul>
                                        <li class='single-shopping-cart'>
                                           <div class='row'>
                                            <div class='shopping-cart-img'>
                                                <a href='/chi-tiet-san-pham/" + item.productHandle + "-" + item._id + "-" + item.categoryID + @"'>
                                                    <img alt='' src='" + item.image + @"'></a>
                                            </div>
                                            <div class='shopping-cart-title' style='width: 300px;'>
                                                <h4><a href='/chi-tiet-san-pham/" + item.productHandle + "-" + item._id + "-" + item.categoryID + @"'>" + item.productName + @"</a></h4>
                                                <h6>Số lượng: " + item.quantity + @"</h6>
                                                <span>" + price + @"</span>
                                            </div>
                                           </div>
                                        </li>
                                    </ul>";
                    itemProduct.Append(itemHTML);
                }
            }

            var checkLoginHtml = new StringBuilder();
            var checkLoginHtml2 = new StringBuilder();
            var checkLoginHtml3 = new StringBuilder();
            if(Session["login"] == null)
            {
                var checkLoginButtonAccount = @"<div class='header-login same-style'>
                                <a href='/dang-nhap'>
                                    <i class='icon-user icons'></i>
                                </a>
                            </div>";
                checkLoginHtml2.Append(checkLoginButtonAccount);


                var checkLoginInButtonPay = @" <a href='/dang-nhap'>Thanh toán</a>";
                checkLoginHtml.AppendLine(checkLoginInButtonPay);
            }
            else
            {
                
                var strCustomer = Session["login"].ToString();
                var customer = JsonConvert.DeserializeObject<RequestModel<UserModel>>(strCustomer);
                var customerName = customer.model.userName;

                var checkLoginButtonAccount = @"<div class='header-login same-style'>
                                <a href='/tai-khoan/{_id}'>
                                    <i class='icon-user icons'></i>
                                </a>
                            </div>";
                checkLoginHtml2.Append(checkLoginButtonAccount);

                var customerNameHtml = @"<div class='header-cart same-style'>
                                <p style='width: 160px;'>"+ customerName + @"</p>
                            </div>";
                checkLoginHtml3.Append(customerNameHtml);

                var checkLoginInButtonPay = @" <a href='/thanh-toan'>Thanh toán</a>";
                checkLoginHtml.Append(checkLoginInButtonPay);
            }

            var header = @"<div class='header-bottom transparent-bar'>
            <div class='container'>
                <div class='row'>
                    <div class='col-xl-2 col-lg-3 col-md-4 col-sm-4 col-5'>
                        <div class='logo pt-10 '>
                            <a href='/trang-chu'>
                                <img alt='' src='assets/img/logo/NT.svg'></a>
                        </div>
                    </div>
                    <div class='col-xl-8 col-lg-7 d-none d-lg-block'>
                        <div class='main-menu text-center'>
                            <nav>
                                <ul>
                                    <li><a href='/trang-chu'>Trang chủ</a></li>
                                    <li><a href='/san-pham'>Sản phẩm</a></li>
                                    <li><a href='/dich-vu'>Dịch vụ</a></li>
                                    <li><a href='/thong-tin'>Thông tin</a></li>
                                    <li><a href='/lien-he'>Liên hệ</a></li>
                                    <li><a href='/huong-dan-cham-soc'>Tips chăm sóc</a></li>

                                </ul>
                            </nav>
                        </div>
                    </div>
                    <div class='col-xl-2 col-lg-2 col-md-8 col-sm-8 col-7'>
                        <div class='search-login-cart-wrapper'>
                            <div class='header-search same-style'>
                                <button class='search-toggle'>
                                    <i class='icon-magnifier s-open'></i>
                                    <i class='ti-close s-close'></i>
                                </button>
                                <div class='search-content'>
                                    <form action='#'>
                                        <input type='text' placeholder='Nhập từ khóa'>
                                        <button>
                                            <i class='icon-magnifier'></i>
                                        </button>
                                    </form>
                                </div>
                            </div>
                            " + checkLoginHtml2.ToString() + @"
                            <div class='header-cart same-style'>
                                <button class='icon-cart'>
                                    <i class='icon-handbag'></i>
                                    <span class='count-style'>" + quantityProductInCart + @"</span>
                                </button>
                                <div class='shopping-cart-content'style='width: 490px;'>
                                    " + itemProduct.ToString() + @"
                                    <div class='shopping-cart-total'>
                                        <h4>Tổng tiền : <span class='shop-total'>" + sumTotal + @"</span></h4>
                                    </div>
                                    <div class='shopping-cart-btn'>
                                        <a href='/gio-hang'>Giỏ hàng</a>
                                       " + checkLoginHtml.ToString() + @"
                                    </div>
                                </div>
                            </div>
                                " + checkLoginHtml3.ToString() + @"
                        </div>
                    </div>
                </div>
            </div>
        </div>";



            var html = string.Concat(header);
            return html;
        }
    }
}