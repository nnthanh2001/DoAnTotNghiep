using Entities.Category;
using Entities.Product;
using Entities.Service;
using HttpClient_API;
using HttpClient_API.Core.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DATN.PetShop.User.site.home
{
    public partial class home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            var getProduct = GetData();
            main.InnerHtml = getProduct;
        }
        public string GetData()
        {
            var baseUrl = Globals.baseAPI;
            var apiProduct = Globals.productTop;
            
            var apiBestProduct = Globals.bestProductAPI;
            var apiServiceTop = Globals.serviceTop;
            var apiCategoryParent = Globals.categoryParentAPI;


            var strProduct = Restful.Get<List<ProductModel>>(baseUrl, apiProduct).Result;
            
            var strBestProduct = Restful.Get<List<ProductModel>>(baseUrl, apiBestProduct).Result;
            var strService = Restful.Get<List<ServiceModel>>(baseUrl, apiServiceTop).Result;
            var strCategoryParent = Restful.Get<List<CategoryModel>>(baseUrl, apiCategoryParent).Result;

            var html = "";




            //header
            var strHeaderSlider = new StringBuilder();

            var header = @"
        <div class='slider-area'>
            <div class='slider-active owl-dot-style owl-carousel'>
                <div class='single-slider pt-100 pb-100 yellow-bg'>
                    <div class='container'>
                        <div class='row'>
                            <div class='col-lg-6 col-md-6 col-12 col-sm-7'>
                                <div class='slider-content slider-animated-1 pt-114'>
                                    <h3 class='animated'>Chăm sóc bằng cả trái tim.</h3>
                                    <h1 class='animated'>Thực phẩm & Vitamins
                                    <br>
                                        Dành cho tất cả thú cưng</h1>
                                    <div class='slider-btn'>
                                        <a class='animated' href='/san-pham'>Xem sản phẩm</a>
                                    </div>
                                </div>
                            </div>
                            <div class='col-lg-6 col-md-6 col-12 col-sm-5'>
                                <div class='slider-single-img slider-animated-1'>
                                    <img class='animated' src='assets/img/slider/slider-single-img.png' alt=''>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class='single-slider pt-100 pb-100 yellow-bg'>
                    <div class='container'>
                        <div class='row'>
                            <div class='col-lg-6 col-md-6 col-sm-7 col-12'>
                                <div class='slider-content slider-animated-1 pt-114'>
                                    <h3 class='animated'>We keep pets for pleasure.</h3>
                                    <h1 class='animated'>Food & Vitamins
                                    <br>
                                        For all Pets</h1>
                                    <div class='slider-btn'>
                                        <a class='animated' href='site/products/productPage.aspx'>SHOP NOW</a>
                                    </div>
                                </div>
                            </div>

                            <div class='col-lg-6 col-md-6 col-sm-5 col-12'>
                                <div class='slider-single-img slider-animated-1'>
                                    <img class='animated' src='assets/img/slider/slider-single-img-2.png' alt=''>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class='food-category food-category-col pt-100 pb-60'>
            <div class='container'>
                <div class='row'>";
            var htmlHeader = string.Format(header);
            strHeaderSlider.Append(htmlHeader);


            //body
            var strBodyProductType = new StringBuilder();
            var strBodyProduct = new StringBuilder();
            var strBodyBestProduct = new StringBuilder();
            var strBodyService = new StringBuilder();

            foreach (var productType in strCategoryParent)
            {
                strBodyProductType.Append("<div class='col-lg-4 col-md-4'>");
                strBodyProductType.Append("<a href='/san-pham/" + productType.categoryHandle + "-" + productType._id + "'>");
                strBodyProductType.Append("<div class='single-food-category cate-padding-1 text-center mb-30'>");
                strBodyProductType.Append("<div class='single-food-hover-2'>");
                strBodyProductType.Append("<img src='../../assets/img/product/product-1.jpg' alt=''>");
                strBodyProductType.Append("</div>");
                strBodyProductType.Append("<div class='single-food-content'>");
                strBodyProductType.Append("<h3>" + productType.categoryName + "</h3>");
                strBodyProductType.Append("</div>");
                strBodyProductType.Append("</div>");
                strBodyProductType.Append("</a>");
                strBodyProductType.Append("</div>");
            }

            var a = @"</div>
            </div>
        </div>

        <div class='product-area pt-95 pb-70 gray-bg'>
            <div class='container'>
                <div class='section-title text-center mb-55'>
                    <h4>Sản phẩm phổ biến</h4>
                    <h2>Sản phẩm mới</h2>
                </div>
                <div class='row'>";



            foreach (var product in strProduct)
            {
                strBodyProduct.Append("<div class='col-xl-3 col-lg-4 col-md-6 col-sm-6'>");
                strBodyProduct.Append(" <div class='product-wrapper mb-10'>");
                strBodyProduct.Append(" <div class='product-img'>");
                strBodyProduct.Append("<a href='/san-pham/" + product.productHandle + "-" + product._id + "'>");
                strBodyProduct.Append(" <img src='../../assets/img/product/product-4.jpg' alt=''>");
                strBodyProduct.Append("</a>");
                strBodyProduct.Append(" <div class='product-action'>");
                strBodyProduct.Append("<a title='Xem nhanh' data-toggle='modal'  data-target='#" + product._id + "' href='" + product._id + "'>");
                strBodyProduct.Append(" <i class='ti-plus'></i>");
                strBodyProduct.Append(" </a>");
                strBodyProduct.Append(" <a title='Them vào giỏ hàng' href='#'>");
                strBodyProduct.Append("<i class='ti-shopping-cart'></i>");
                strBodyProduct.Append("</a>");
                strBodyProduct.Append("</div>");
                strBodyProduct.Append("<div class='product-action-wishlist'>");
                strBodyProduct.Append("<a title='Wishlist' href='#'>");
                strBodyProduct.Append("<i class='ti-heart'></i>");
                strBodyProduct.Append(" </a>");
                strBodyProduct.Append(" </div>");
                strBodyProduct.Append("</div>");
                strBodyProduct.Append(" <div class='product-content'>");
                strBodyProduct.Append("<h4><a href='/san-pham/" + product.productHandle + "-" + product._id + "'>" + product.productName + "</a></h4>");
                strBodyProduct.Append(" <div class='product-price'>");
                strBodyProduct.Append("<span class='new'>" + product.price + "đ</span>");
                strBodyProduct.Append("</div>");
                strBodyProduct.Append("</div>");
                strBodyProduct.Append("</div>");
                strBodyProduct.Append("</div>");
                var getQuickView = GetQuickView(product._id);
                strBodyProduct.Append(getQuickView);
            }


            foreach (var productBest in strBestProduct)
            {
                var strFormmat = @"<div class='row'>
                    <div class='col-lg-6 col-md-6'>
                        <div class='deal-img wow fadeInLeft'>
                            <a href='/san-pham/{6}-{7}'>
                                <img src='{0}' alt=''></a>
                        </div>
                    </div>
                    <div class='col-lg-6 col-md-6'>
                        <div class='deal-content'>
                            <h3><a href='/san-pham/{6}-{7}'>{1}</a></h3>
                            <div class='deal-pro-price'>
                                <span class='deal-old-price'>9700.000đ</span>
                                   
                                 <span>{2}đ</span>
                                 <span>{3}</span>
                            </div>
                            <p>{4} </p>
                            <div class='timer timer-style'>
                                
                                <div data-countdown='{5}'></div>
                            </div>
                            <div class='discount-btn mt-35'>
                                <a class='btn-style' href='/san-pham/{6}-{7}'>XEM SẢN PHẨM </a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>";

                var htmlBestProduct = string.Format(strFormmat, productBest.imageID, productBest.productName, productBest.price, "", productBest.description, productBest.bestProductExpired, productBest.productHandle, productBest._id);
                strBodyBestProduct.Append(htmlBestProduct);

            }


            foreach (var service in strService)
            {
                var strFormmat = @"
                
                    <div class='col-lg-4 col-md-6'>
                        <div class='box'>
                            <div class='blog-img hover-effect'>
                                <a href='/dich-vu/{3}-{4}'><img alt='' src='https://www.vietnambooking.com/wp-content/uploads/2017/10/khach-san-co-cho-phep-thu-cung-vao-hay-khong-7-7-2018-2.jpg'></a>
                            </div>
                            <div class='blog-content'>
                                <div class='blog-meta'>
                                    <ul>
                                        <li><span>{0}</span></li>
                                        <li>{1}</li>
                                    </ul>
                                </div>
                                <h4><a href=''>{2}</a></h4>
                            <div class='discount-btn mt-35'>
                                <a class='btn-style' href='/dich-vu/{3}-{4}'>Đặt ngay</a>
                            </div>
                            </div>
                        </div>
                    </div>
                
		    ";
                var htmlService = string.Format(strFormmat, service.statusName, "", service.serviceName, service.serviceHandle, service._id);
                strBodyService.Append(htmlService);

            }










            //footer
            var footer = @"
             </div>
            </div>
        </div>

       <div class='deal-area bg-img deal-style-white pt-95 pb-100 bg-img' style='background-image:url(assets/img/banner/banner-2.jpg);'>

            <div class='container'>
                <div class='section-title section-title-white text-center mb-50'>
                    
                        <h4>Sản phẩm tốt nhất</h4>
                        <h2>Ưu đãi trong tuần</h2>
                  
                </div>
                " + strBodyBestProduct.ToString() +
                @"

            <div class='product-area pt-95 pb-70 gray-bg'>
		    <div class='container'>
		        <div class='section-title text-center mb-60'>
                    <h4>Dịch vụ</h4>
                    <h2>Chăm sóc tận tình</h2>
                </div>
            <div class='row'>" + strBodyService.ToString() + @"
            </div>
        </div>
		</div>
        <div class='testimonial-area pt-90 pb-70 bg-img' style='background-image: url(assets/img/banner/banner-1.jpg);'>
            <div class='container'>
                <div class='row'>
                    <div class='col-lg-10 ml-auto mr-auto'>
                        <div class='testimonial-wrap'>
                            <div class='testimonial-text-slider text-center'>
                                <div class='sin-testiText'>
                                    <p>Chú chó của bạn là điều duy nhất trên trái đất</p><p> yêu bạn hơn yêu sinh mạng của chính nó</p>
                                </div>
                                <div class='sin-testiText'>
                                    <p>Trên đĩa thức ăn của bạn</p><p> có thể ngày hôm qua đã là người bạn nằm trong vòng tay một đứa trẻ ...</p>
                                </div>
                                <div class='sin-testiText'>
                                    <p>Chú chó của bạn là điều duy nhất trên trái đất</p><p> yêu bạn hơn yêu sinh mạng của chính nó</p>
                                </div>
                                <div class='sin-testiText'>
                                    <p>Trên đĩa thức ăn của bạn</p><p> có thể ngày hôm qua đã là người bạn nằm trong vòng tay một đứa trẻ ...</p>
                                </div>
                            </div>
                            <div class='testimonial-image-slider text-center'>
                                <div class='sin-testiImage'>
                                    <img src='assets/img/testi/3.jpg' alt=''>
                                    <h3>Nguyễn Như Thành</h3>
                                    <h5>Customer</h5>
                                </div>
                                <div class='sin-testiImage'>
                                    <img src='assets/img/testi/4.jpg' alt=''>
                                    <h3>Trần Quang Khải</h3>
                                    <h5>Customer</h5>
                                </div>
                                <div class='sin-testiImage'>
                                    <img src='assets/img/testi/3.jpg' alt=''>
                                    <h3>Nguyễn Như Thành</h3>
                                    <h5>Developer</h5>
                                </div>
                                <div class='sin-testiImage'>
                                    <img src='assets/img/testi/5.jpg' alt=''>
                                    <h3>Trần Quang Khải</h3>
                                    <h5>CEO</h5>
                                </div>
                            </div>
                            <div class='testimonial-shap'>
                                <img src='assets/img/icon-img/testi-shap.png' alt=''>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class='service-area bg-img pt-100 pb-65'>
            <div class='container'>
                <div class='row'>
                    <div class='col-lg-4 col-md-4'>
                        <div class='service-content text-center mb-30 service-color-1'>
                            <img src='assets/img/icon-img/shipping.png' alt=''>
                            <h4>Miễn phí vận chuyển</h4>
                            <p>Giao hàng miễn phí </p>
                        </div>
                    </div>
                    <div class='col-lg-4 col-md-4'>
                        <div class='service-content text-center mb-30 service-color-2'>
                            <img src='assets/img/icon-img/support.png' alt=''>
                            <h4>HỖ TRỢ TRỰC TUYẾN</h4>
                            <p>Hỗ trợ trực tuyến 24 giờ một ngày</p>
                        </div>
                    </div>
                    <div class='col-lg-4 col-md-4'>
                        <div class='service-content text-center mb-30 service-color-3'>
                            <img src='assets/img/icon-img/money.png' alt=''>
                            <h4>Tích điểm</h4>
                            <p>Tặng PetCoin cho mỗi hóa đơn</p>
                        </div>
                    </div>
                </div>
            </div>
        <div class='blog-area pb-70'>
		    <div class='container'>
		        <div class='section-title text-center mb-60'>
                    <h4>Kiến thức và kinh nghiệm</h4>
                    <h2>Chăm sóc chó mèo</h2>
                </div>
                <div class='row'>
                    <div class='col-lg-4 col-md-6'>
                        <div class='blog-wrapper mb-30 gray-bg'>
                            <div class='blog-img hover-effect'>
                                <a  href ='/site/blog/blog_1.aspx'><img style='height: 250px' alt='' src='https://www.petcity.vn/media/news/2705_pasted-image-0-78.png'></a>
                             </div>
                            <div style='min-height: 175px' class='blog-content'>
                                <div class='blog-meta'>
                                    <ul>
                                        <li>Tạo bởi: <span>Nguyễn Như Thành</span></li>
                                        <li>09/06/2022</li>
                                    </ul>
                                </div>
                                <h4><a href='/site/blog/blog_1.aspx'>Bé chó bị bệnh đường ruột - đừng quá lo lắng!</a></h4>
                            </div>
                        </div>
                    </div>
                    <div class='col-lg-4 col-md-6'>
                        <div class='blog-wrapper mb-30 gray-bg'>
                            <div class='blog-img hover-effect'>
                                <a  href='/site/blog/blog_2.aspx'><img style='height: 250px' alt='' src='https://asie.vn/wp-content/uploads/2020/11/meo-beo-3.jpg'></a>
                            </div>
                            <div style='min-height: 175px'class='blog-content'>
                                <div class='blog-meta'>
                                   <ul>
                                        <li>Tạo bởi: <span>Nguyễn Như Thành</span></li>
                                        <li>09/06/2022</li>
                                    </ul>
                                </div>
                                <h4><a href='/site/blog/blog_2.aspx'>Cách chăm sóc mèo nhanh béo mà không ảnh hưởng đến sức khỏe</a></h4>
                            </div>
                        </div>
                    </div>
                    <div class='col-lg-4 col-md-6'>
                        <div class='blog-wrapper mb-30 gray-bg'>
                            <div class='blog-img hover-effect'>
                                <a  href='/site/blog/blog_3.aspx'><img style='height: 250px' alt='' src='https://www.petcity.vn/media/news/1404_ch___m__o_b____nhi___m_giun_s__n.jpg'></a>
                            </div>
                            <div style='min-height: 175px' class='blog-content'>
                                <div class='blog-meta'>
                                   <ul>
                                        <li>Tạo bởi: <span>Nguyễn Như Thành</span></li>
                                        <li>09/06/2022</li>
                                    </ul>
                                </div>
                                <h4><a href='/site/blog/blog_3.aspx'>Hướng dẫn cách tẩy giun sán cho chó mèo tại nhà an toàn hiệu quả</a></h4>
                            </div>
                        </div>
                    </div>
                </div>
		    </div>
		</div>
        </div>";


            html = string.Concat(strHeaderSlider, strBodyProductType.ToString(), a, strBodyProduct.ToString(), footer);

            return html;




        }
        public string GetQuickView(string id)
        {
            var baseUrl = Globals.baseAPI;
            var apiProductDetail = Globals.getOneProductAPI + "/" + id;
            var strBodyProductDetail = new StringBuilder();
            var productDetail = Restful.Get<ProductModel>(baseUrl, apiProductDetail).Result;


            var quickView = @"
        <!-- modal -->
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
                                <h3>" + productDetail.productName + @"</h3>
                                <div class='product-price'>
                                    <span>" + productDetail.price + @".000đ</span>
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
                                    <div class='cart-plus-minus'>
                                        <input type = 'text' value='2' name='qtybutton' class='cart-plus-minus-box'>
                                    </div>
                                    <div class='quickview-btn-cart'>
                                        <a class='btn-style' href='#'>Thêm vào giỏ hàng</a>
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

            return quickView;
        }
    }
}