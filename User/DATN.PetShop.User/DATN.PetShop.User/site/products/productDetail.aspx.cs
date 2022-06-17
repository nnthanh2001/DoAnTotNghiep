﻿using Entities.Product;
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

                var getProduct = GetDataProductDetail(id);
                main.InnerHtml = getProduct;
            }


        }
        public string GetDataProductDetail(string id)
        {
            var baseUrl = Globals.baseAPI;
            var apiProductDetail = Globals.getOneProductAPI + "/" + id;



            var strBodyProductDetail = new StringBuilder();

            var product = Restful.Get<ProductModel>(baseUrl, apiProductDetail).Result;



            var header = @"<div class='breadcrumb-area pt-95 pb-95 bg-img' style='background-image: url(assets/img/banner/banner-2.jpg);'>
            <div class='container'>
                <div class='breadcrumb-content text-center'>
                    <h2>Chi tiết sản phẩm</h2>
                    <ul>
                         <li><a href='site/home/home.aspx.cs'>Trang chủ</a></li>
                        <li class='active'>Chi tiết sản phẩm</li>
                    </ul>
                </div>
            </div>
        </div>";


            var productDetail = @"<div class='shop-area pt-95 pb-100'>
            <div class='container'>
                <div class='row'>
                    <div class='col-lg-6 col-md-6'>
                        <div class='product-details-img'>
                            <img id='zoompro' src='assets/img/product-details/l1.jpg' data-zoom-image='assets/img/product-details/bl1.jpg' alt='zoom' />
                            <div id='gallery' class='mt-12 product-dec-slider owl-carousel'>
                                <a data-image='assets/img/product-details/l1.jpg' data-zoom-image='assets/img/product-details/bl1.jpg'>
                                    <img src='assets/img/product-details/s1.jpg' alt=''>
                                </a>
                                <a data-image='assets/img/product-details/l2.jpg' data-zoom-image='assets/img/product-details/bl2.jpg'>
                                    <img src='assets/img/product-details/s2.jpg' alt=''>
                                </a>
                                <a data-image='assets/img/product-details/l3.jpg' data-zoom-image='assets/img/product-details/bl3.jpg'>
                                    <img src='assets/img/product-details/s3.jpg' alt=''>
                                </a>
                                <a data-image='assets/img/product-details/l4.jpg' data-zoom-image='assets/img/product-details/bl4.jpg'>
                                    <img src='assets/img/product-details/s4.jpg' alt=''>
                                </a>
                                <a data-image='assets/img/product-details/l3.jpg' data-zoom-image='assets/img/product-details/bl3.jpg'>
                                    <img src='assets/img/product-details/s3.jpg' alt=''>
                                </a>
                            </div>
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
                                
                                <span class='new'>{1}.000đ</span>
                                
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
                                    <a class='addtocart-btn' href='#' title='Thêm vào giỏ hàng'>
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
                            <div class='social-icon mt-30'>
                                <ul>
                                    <li><a href='#'><i class='icon-social-twitter'></i></a></li>
                                    <li><a href='#'><i class='icon-social-instagram'></i></a></li>
                                    <li><a href='#'><i class='icon-social-linkedin'></i></a></li>
                                    <li><a href='#'><i class='icon-social-skype'></i></a></li>
                                    <li><a href='#'><i class='icon-social-dribbble'></i></a></li>
                                </ul>
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
                        
                        <a data-toggle='tab' href='#des-details3'>Đánh giá</a>
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
                                <h3>Add your Comments :</h3>
                                <div class='ratting-form'>
                                    <form action='#'>
                                        <div class='star-box'>
                                            <h2>Rating:</h2>
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
                                                    <input placeholder='Name' type='text'>
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


            var htmlProductDetail = string.Format(productDetail, product.productName, product.price, product.statusName, product.productID, product.description);
            strBodyProductDetail.Append(htmlProductDetail);






            var productPopular = @"<div class='related-product-area pt-95 pb-80 gray-bg'>
            <div class='container'>
                <div class='section-title text-center mb-55'>
                    <h4>Phổ biến nhất</h4>
                    <h2>Sản phẩm tương tự</h2>
                </div>
                <div class='related-product-active owl-carousel'>
                    <div class='product-wrapper'>
                        <div class='product-img'>
                            <a href='product-details.html'>
                                <img src='assets/img/product/product-4.jpg' alt=''>
                            </a>
                            <div class='product-action'>
                                <a title='Quick View' data-toggle='modal' data-target='#exampleModal' href='#'>
                                    <i class='ti-plus'></i>
                                </a>
                                <a title='Add To Cart' href='#'>
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
                            <h4><a href='product-details.html'>Dog Calcium Food</a></h4>
                            <div class='product-price'>
                                <span class='new'>$20.00 </span>
                                <span class='old'>$50.00</span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>";


            var QuickViewProduct = @"<div class='modal fade' id='exampleModal' tabindex='-1' role='dialog' aria-hidden='true'>
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
                                        <img src='assets/img/quick-view/l1.jpg' alt=''>
                                    </div>
                                    <div class='tab-pane fade' id='modal2' role='tabpanel'>
                                        <img src='assets/img/quick-view/l2.jpg' alt=''>
                                    </div>
                                    <div class='tab-pane fade' id='modal3' role='tabpanel'>
                                        <img src='assets/img/quick-view/l3.jpg' alt=''>
                                    </div>
                                </div>
                            </div>
                            <div class='quick-view-list nav' role='tablist'>
                                <a class='active' href='#modal1' data-toggle='tab' role='tab'>
                                    <img src='assets/img/quick-view/s1.jpg' alt=''>
                                </a>
                                <a href='#modal2' data-toggle='tab' role='tab'>
                                    <img src='assets/img/quick-view/s2.jpg' alt=''>
                                </a>
                                <a href='#modal3' data-toggle='tab' role='tab'>
                                    <img src='assets/img/quick-view/s3.jpg' alt=''>
                                </a>
                            </div>
                        </div>
                        <div class='qwick-view-right'>
                            <div class='qwick-view-content'>
                                <h3>Dog Calcium Food</h3>
                                <div class='product-price'>
                                    <span>$19.00 </span>
                                </div>
                                <div class='product-rating'>
                                    <i class='ion-star theme-color'></i>
                                    <i class='ion-star theme-color'></i>
                                    <i class='ion-star theme-color'></i>
                                    <i class='ion-star theme-color'></i>
                                    <i class='ion-star theme-color'></i>
                                </div>
                                <p>Lorem ipsum dolor sit amet, consectetur adip elit, sed do amt tempor incididun ut labore et dolore magna aliqua. Ut enim ad mi , quis nostrud veniam exercitation .</p>
                                <div class='quick-view-select'>
                                    <div class='select-option-part'>
                                        <label>Size*</label>
                                        <select class='select'>
                                            <option value=''>- Please Select -</option>
                                            <option value=''>XS</option>
                                            <option value=''>S</option>
                                            <option value=''>M</option>
                                            <option value=''>L</option>
                                            <option value=''>XL</option>
                                            <option value=''>XXL</option>
                                        </select>
                                    </div>
                                    <div class='select-option-part'>
                                        <label>Color*</label>
                                        <select class='select'>
                                            <option value=''>- Please Select -</option>
                                            <option value=''>orange</option>
                                            <option value=''>pink</option>
                                            <option value=''>yellow</option>
                                        </select>
                                    </div>
                                </div>
                                <div class='quickview-plus-minus'>
                                    <div class='cart-plus-minus'>
                                        <input type='text' value='2' name='qtybutton' class='cart-plus-minus-box'>
                                    </div>
                                    <div class='quickview-btn-cart'>
                                        <a class='btn-style' href='#'>add to cart</a>
                                    </div>
                                    <div class='quickview-btn-wishlist'>
                                        <a class='btn-hover' href='#'><i class='ti-heart'></i></a>
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