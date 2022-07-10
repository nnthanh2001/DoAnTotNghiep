using Entities.Category;
using Entities.Home;
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
            var homeApi = Globals.homePageAPI;
            

            var home = Restful.Get<HomeModel>(baseUrl, homeApi).Result;
            

            var categoryBody = new StringBuilder();
            var productNewBody = new StringBuilder();
            var productBestBody = new StringBuilder();
            var serviceBody = new StringBuilder();

            foreach (var category in @home.category)
            {
                var categoryId = category.categoryID.ToString();
                var categoryList = @"<div class='col-lg-4 col-md-4'>
                    <a href='/san-pham/" + category.categoryHandle + "-"+categoryId+ @"'>
                        <div class='single-food-category cate-padding-1 text-center mb-30'>
                            <div class='single-food-hover-2'>
                                <img style='height: 270px' src='" + category.image+ @"' alt='' >
                             </div>
                            <div class='single-food-content'>
                                <h3>" + category.categoryName + @"</h3>
                            </div>
                        </div>
                    </a>
                </div>";
                categoryBody.Append(categoryList);
            }
            foreach (var productNew in home.productNew)
            {
                string price = String.Format("{0:0,00₫}", productNew.price);
                var productNewHTML = @"<div class='col-xl-3 col-lg-4 col-md-6 col-sm-6'>
                    <div class='product-wrapper mb-10'>
                        <div class='product-img'>
                            <a href='/chi-tiet-san-pham/" + productNew.productHandle + @"-" + productNew._id + "-" + productNew.categoryID + @"'>
                                <img src='" +productNew.image+@"' alt=''>
                            </a>
                            <div class='product-action'>
                                <a title='Xem nhanh' data-toggle='modal' data-target='#" + productNew._id + @"' href='" + productNew._id + @"'>
                                    <i class='ti-plus'></i>
                                </a>
                                <a title='Thêm vào giỏ hàng' href='javascript:void(0);' jsaction='addItemToCartButton' value='" + productNew._id + @"'>
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
                            <h4><a href='/chi-tiet-san-pham/" + productNew.productHandle + "-" + productNew._id + "-" + productNew.categoryID +"' data_value='productName' value='"+productNew.productName+"'>"+productNew.productName+@"</a></h4>
                            <div class='product-price' data_value='price' value='" + productNew.price + @"'>
                                <span class='new'>" + price + @"</span>
                            </div>
                        </div>
                    </div>
                </div>";
                var getQuickView = GetQuickView(productNew._id);
                productNewBody.Append(productNewHTML);
                productNewBody.Append(getQuickView);

            }
            foreach (var productBest in home.productBest)
            {
                string price = String.Format("{0:0,00₫}", productBest.price);
                var productBestHTML = @"<div class='row'>
                <div class='col-lg-6 col-md-6'>
                    <div class='deal-img wow fadeInLeft'>
                        <a href='/chi-tiet-san-pham/" + productBest.productHandle + "-" + productBest._id + @"'>
                            <img src='" + productBest.image+ @"' alt=''>
                        </a>
                    </div>
                </div>
                <div class='col-lg-6 col-md-6'>
                    <div class='deal-content'>
                        <h3><a href='/chi-tiet-san-pham/" + productBest.productHandle + "-" + productBest._id + @"'>" + productBest.productName + @"</a></h3>
                        <div class='deal-pro-price'>
                            <span style='color: #b1ff89;'>" + price + @"</span>
                           
                        </div>
                        <p>" + productBest.description + @"</p>
                        <div class='timer timer-style'>

                            <div data-countdown='" + productBest.bestProductExpired + @"'></div>
                        </div>
                        <div class='discount-btn mt-35'>
                            <a class='btn-style' href='/chi-tiet-san-pham/" + productBest.productHandle + @"-" + productBest._id + "-" + productBest.categoryID + @"'>XEM SẢN PHẨM </a>
                        </div>
                    </div>
                </div>
            </div>";

                productBestBody.Append(productBestHTML);

            }
            foreach (var service in home.service)
            {

                var serviceHTML = @"<div class='col-lg-4 col-md-6'>
                        <div class='box'>
                            <div class='blog-img hover-effect'>
                                <a href='/dich-vu/" + service.serviceHandle + "-" + service._id + @"'><img style='height: 300px' alt='' src='" + service.image+@"'></a>
                            </div>
                            <div class='blog-content'>
                                <div class='blog-meta'>
                                    <ul>
                                        <li><span>" + service.statusName + @"</span></li>
                                    </ul>
                                </div>
                                <h4><a href=''>" + service.serviceName + @"</a></h4>
                            <div class='discount-btn mt-35'>
                                <a class='btn-style' href='/dich-vu/" + service.serviceHandle + "-" + service._id + @"'>Đặt ngay</a>
                            </div>
                            </div>
                        </div>
                    </div>";

                serviceBody.Append(serviceHTML);

            }



            //header
            var header = @"<div class='slider-area'>
        <div class='slider-active owl-dot-style owl-carousel'>
            <div class='single-slider pt-100 pb-100 yellow-bg'>
                <div class='container'>
                    <div class='row'>
                        <div class='col-lg-6 col-md-6 col-12 col-sm-7'>
                            <div class='slider-content slider-animated-1 pt-114'>
                                <h3 class='animated'>Chăm sóc bằng cả trái tim.</h3>
                                <h1 class='animated'>
                                    Thực phẩm & Vitamins
                                    <br>
                                    Dành cho tất cả thú cưng
                                </h1>
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
                                <h1 class='animated'>
                                    Food & Vitamins
                                    <br>
                                    For all Pets
                                </h1>
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
    </div>";
            //body
            var body = @"<div class='food-category food-category-col pt-100 pb-60 gray-bg-4'>
        <div class='container'>
            <div class='row'>
                " + categoryBody.ToString() + @"
            </div>
        </div>
    </div>
    <div class='product-area pt-95 pb-70 gray-bg'>
        <div class='container'>
            <div class='section-title text-center mb-55'>
                <h4>Sản phẩm phổ biến</h4>
                <h2>Sản phẩm mới</h2>
            </div>
            <div class='row'>
                " + productNewBody.ToString() + @"
            </div>
        </div>
    </div>
    <div class='deal-area bg-img deal-style-white pt-95 pb-100 bg-img' style='background-image:url(assets/img/banner/banner-2.jpg);'>

        <div class='container'>
            <div class='section-title section-title-white text-center mb-50'>
                <h4>Sản phẩm tốt nhất</h4>
                <h2>Ưu đãi trong tuần</h2>
            </div>
                " + productBestBody.ToString() + @"
        </div>
    </div>
    <div class='product-area pt-95 pb-70 gray-bg'>
        <div class='container'>
            <div class='section-title text-center mb-60'>
                <h4>Dịch vụ</h4>
                <h2>Chăm sóc tận tình</h2>
            </div>
            <div class='row'>
                " + serviceBody.ToString() + @"
            </div>
        </div>
    </div>";

            //footer
            var footer = @"
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
                                <a href='/site/blog/blog_1.aspx'><img style='height: 250px' alt='' src='https://www.petcity.vn/media/news/2705_pasted-image-0-78.png'></a>
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
                                <a href='/site/blog/blog_2.aspx'><img style='height: 250px' alt='' src='https://asie.vn/wp-content/uploads/2020/11/meo-beo-3.jpg'></a>
                            </div>
                            <div style='min-height: 175px' class='blog-content'>
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
                                <a href='/site/blog/blog_3.aspx'><img style='height: 250px' alt='' src='https://www.petcity.vn/media/news/1404_ch___m__o_b____nhi___m_giun_s__n.jpg'></a>
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

            var html = string.Concat(header, body, footer);
            return html;
        }
        public string GetQuickView(string id)
        {
            var baseUrl = Globals.baseAPI;
            var apiProductDetail = Globals.getOneProductAPI + "/" + id;
            var productDetail = Restful.Get<ProductModel>(baseUrl, apiProductDetail).Result;
            string price = String.Format("{0:0,00₫}", productDetail.price);

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
                                    <span style='font-size: 20px;color: red;'>" + price + @"</span>
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

            return quickView;
        }
    }
}