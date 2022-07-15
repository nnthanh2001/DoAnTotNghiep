using Entities.Product;
using HttpClient_API;
using Newtonsoft.Json;
using HttpClient_API.Core.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entities.ProductDetailPage;

namespace DATN.PetShop.User.site.products
{
    public partial class productDetail : System.Web.UI.Page
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
                var categoryID = request["categoryID"] != null && request["categoryID"].ToString() != ""
              ? request["categoryID"].ToString().ToLower().Trim()
              : "";

                var categoryId = int.Parse(categoryID);
                var getProduct = GetDataProductDetail(id, categoryId);
                main.InnerHtml = getProduct;

            }


        }
        public string GetDataProductDetail(string id , int categoryID)
        {
            var baseUrl = Globals.baseAPI;
            var apiProductDetail = Globals.productDetailPage + "?_id=" + id + "&CategoryId=" + categoryID;



            var strBodyProductDetail = new StringBuilder();

            var product = Restful.Get<ProductDetailModel>(baseUrl, apiProductDetail).Result;
            var productDetail = product.productDetail;
            var productList =product.productList;

            //HTML Header
            var header = @"<div class='breadcrumb-area pt-95 pb-95 bg-img' style='background-image: url(assets/img/banner/banner-2.jpg);'>
            <div class='container'>
                <div class='breadcrumb-content text-center'>
                    <h2>Chi tiết sản phẩm</h2>
                    <ul>
                         <li><a href='trang-chu'>Trang chủ</a></li>
                        <li class='active'>Chi tiết sản phẩm</li>
                    </ul>
                </div>
            </div>
        </div>";

            
            var productDetailHTML = @"<div class='shop-area pt-95 pb-100'>
            <div class='container'>
                <div class='row'>
                    <div class='col-lg-6 col-md-6'>
                        <div class='product-details-img'>
                            <img id='zoompro' src='"+ productDetail.image+ @"' data-zoom-image='" + productDetail.image + @"' alt='zoom' />
                           
                        </div>
                    </div>
                    <div class='col-lg-6 col-md-6'>
                        <div class='product-details-content'>
                            <h2>{0}</h2>
                            <div class='product-rating'>
                                <i class='ti-star theme-color'></i>
                                <i class='ti-star theme-color'></i>
                                <i class='ti-star theme-color'></i>
                                <i class='ti-star'></i>
                                <i class='ti-star'></i>
                                <span></span>
                            </div>
                            <div class='product-price'>
                                
                                <span class='new'>{1}</span>
                                
                            </div>
                            <div class='in-stock'>
                                <span><i class='ion-android-checkbox-outline'></i>{2}</span>
                            </div>
                            <div class='sku'>
                                <span>Mã hàng: {3}</span>
                            </div>

                            <div class='quality-wrapper mt-30 product-quantity'>
                                <label>Số lượng:</label>
                                <div class='cart-plus-minus'>
                                    <input class='cart-plus-minus-box' type='text' name='qtybutton' value='1'>
                                </div>
                            </div>
                            <div class='product-list-action'>
                                <div class='product-list-action-left'>
                                    <a title='Thêm vào giỏ hàng' href='javascript:void(0);' jsaction='addItemToCartButton' value='" + productDetail._id + @"'>
                                        <i class='ion-bag'></i>
                                        Thêm vào giỏ hàng
                                    </a>
                                </div>

                                <div class='product-list-action-right'>
                                    <a href='#' title='Wishlist'>
                                        <i class='ti-heart'></i>
                                    </a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class='description-review-area pb-100'>
            <div class='container'>
                <div class='description-review-wrapper gray-bg pt-40'>
                    <div class='description-review-topbar nav text-center'>
                        <a class='active' data-toggle='tab' href='#des-details1'>Mô tả</a>
                        
                        <a data-toggle='tab' href='#des-details3'>Đánh giá (2)</a>
                    </div>
                    <div class='tab-content description-review-bottom'>

                        {4}
                        
                        <div id='des-details3' class='tab-pane'>
                            <div class='rattings-wrapper'>
                                <div class='sin-rattings'>
                                    <div class='star-author-all'>
                                        <div class='product-rating f-left'>
                                            <i class='ti-star theme-color'></i>
                                            <i class='ti-star theme-color'></i>
                                            <i class='ti-star theme-color'></i>
                                            <i class='ti-star theme-color'></i>
                                            <i class='ti-star theme-color'></i>
                                            <span>(5)</span>
                                        </div>
                                        <div class='ratting-author f-right'>
                                            <h3>Minh be de</h3>
                                            <span>12:24</span>
                                            <span>9 tháng 06 năm 2022</span>
                                        </div>
                                    </div>
                                    <p>Thật tuyệt vời</p>
                                </div>
                                <div class='sin-rattings'>
                                    <div class='star-author-all'>
                                        <div class='product-rating f-left'>
                                            <i class='ti-star theme-color'></i>
                                            <i class='ti-star theme-color'></i>
                                            <i class='ti-star theme-color'></i>
                                            <i class='ti-star theme-color'></i>
                                            <i class='ti-star'></i>
                                            <span>(4)</span>
                                        </div>
                                        <div class='ratting-author f-right'>
                                            <h3>Nghĩa điện</h3>
                                            <span>12:24</span>
                                            <span>9 tháng 06 năm 2022</span>
                                        </div>
                                    </div>
                                    <p>Sản phẩm ngon lắm ạ </p>
                                </div>
                            </div>
                            <div class='ratting-form-wrapper'>
                                <h3>Bình luận về sản phẩm :</h3>
                                <div class='ratting-form'>
                                    <form action='#'>
                                        <div class='star-box'>
                                            <h2>Đánh giá:</h2>
                                            <div class='product-rating'>
                                                <i class='ti-star theme-color'></i>
                                                <i class='ti-star theme-color'></i>
                                                <i class='ti-star theme-color'></i>
                                                <i class='ti-star'></i>
                                                <i class='ti-star'></i>
                                                <span>(3)</span>
                                            </div>
                                        </div>
                                        <div class='row'>
                                            <div class='col-md-6'>
                                                <div class='rating-form-style mb-20'>
                                                    <input placeholder='Tên' type='text'>
                                                </div>
                                            </div>
                                            <div class='col-md-6'>
                                                <div class='rating-form-style mb-20'>
                                                    <input placeholder='Email' type='text'>
                                                </div>
                                            </div>
                                            <div class='col-md-12'>
                                                <div class='rating-form-style form-submit'>
                                                    <textarea name='message' placeholder='Message'></textarea>
                                                    <input type='submit' value='Thêm bình luận'>
                                                </div>
                                            </div>
                                        </div>
                                    </form>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>";

            string price = String.Format("{0:0,00₫}", productDetail.price);
            var htmlProductDetail = string.Format(productDetailHTML, productDetail.productName, price, productDetail.statusName, productDetail.productID, productDetail.description);
            strBodyProductDetail.Append(htmlProductDetail);

            var strProductPopular = new StringBuilder();
            foreach(var pro in productList)
            {
                string pricePop = String.Format("{0:0,00₫}", pro.price);
                var productPopularHTML = @"<div class='product-wrapper'>
                        <div class='product-img'>
                            <a href='/chi-tiet-san-pham/" + pro.productHandle + @"-" + pro._id + "-" + pro.categoryID + @"'>
                                <img src='" + pro.image + @"' alt=''>
                            </a>
                            <div class='product-action'>
                                 <a title='Xem nhanh' data-toggle='modal' data-target='#" + pro._id + @"' href='" + pro._id + @"'>
                                    <i class='ti-plus'></i>
                                </a>
                                <a title='Add To Cart' href='javascript:void(0);' jsaction='addItemToCartButton' value='" + pro._id + @"'>
                                    <i class='ti-shopping-cart'></i>
                                </a>
                            </div>
                            <div class='product-action-wishlist'>
                                <a title='Wishlist' href='#'>
                                    <i class='ti-heart'></i>
                                </a>
                            </div>
                        </div>
                        <div class='product-content'>
                            <h4><a href='/chi-tiet-san-pham/" + pro.productHandle + @"-" + pro._id + "-" + pro.categoryID + @"'>" + pro.productName + @"</a></h4>
                            <div class='product-price'>
                                <span class='new'>" + pricePop + @"</span>
                                
                            </div>
                        </div>
                    </div>";
                strProductPopular.Append(productPopularHTML);
            }
            var productPopular = @"<div class='related-product-area pt-95 pb-80 gray-bg'>
            <div class='container'>
                <div class='section-title text-center mb-55'>
                    <h4>Phổ biến nhất</h4>
                    <h2>Sản phẩm tương tự</h2>
                </div>
                <div class='related-product-active owl-carousel'>
                    " + strProductPopular.ToString() + @"
                </div>
            </div>
        </div>";



            var QuickViewProduct = @"<!-- modal -->
        <div class='modal fade' id='" + id + @"' tabindex='-1' role='dialog' aria-hidden='true'>
            <button type='button' class='close' data-dismiss='modal' aria-label='Close'>
                <span class='ti-close' aria-hidden='true'></span>
            </button>
            <div class='modal-dialog' role='document'>
                <div class='modal-content'>
                    <div class='modal-body'>
                        <div class='qwick-view-left'>
                            <div class='quick-view-learg-img'>
                                <div class='quick-view-tab-content tab-content'>
                                    <div class='tab-pane active show fade' id='modal1' role='tabpanel'>
                                        <img src='" + productDetail.image + @"' alt=''>
                                    </div>
                                    <div class='tab-pane fade' id='modal2' role='tabpanel'>
                                        <img src='" + productDetail.image + @"' alt=''>
                                    </div>
                                    <div class='tab-pane fade' id='modal3' role='tabpanel'>
                                        <img src='" + productDetail.image + @"' alt=''>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class='qwick-view-right'>
                            <div class='qwick-view-content'>
                                <h3>" + productDetail.productName + @"</h3>
                                <div class='product-price'>
                                    <span  style='font-size: 20px;color: red;'>" + price + @"</span>
                                </div>
                                <div class='product-rating'>
                                    <i class='ion-star theme-color'></i>
                                    <i class='ion-star theme-color'></i>
                                    <i class='ion-star theme-color'></i>
                                    <i class='ion-star theme-color'></i>
                                    <i class='ion-star theme-color'></i>
                                </div>
                                <p>" + productDetail.description + @"</p>
                                
                                <div class='quickview-plus-minus'>
                                  
                                    <div class='quickview-btn-cart'>
                                        <a title='Thêm vào giỏ hàng' href='javascript:void(0);' jsaction='addItemToCartButton' value='" + productDetail._id + @"'>Thêm vào giỏ hàng</a>
                                    </div>
                                   
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>";
            var html = string.Concat(header, strBodyProductDetail.ToString(), productPopular, QuickViewProduct);
            return html;

        }
    }
}