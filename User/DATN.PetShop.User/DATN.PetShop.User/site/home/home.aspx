<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="DATN.PetShop.User.site.home.home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="server">
    <div class="page-content-tab" id="main" runat="server">


       <%-- <div class="slider-area">
            <div class="slider-active owl-dot-style owl-carousel">
                <div class="single-slider pt-100 pb-100 yellow-bg">
                    <div class="container">
                        <div class="row">
                            <div class="col-lg-6 col-md-6 col-12 col-sm-7">
                                <div class="slider-content slider-animated-1 pt-114">
                                    <h3 class="animated">We keep pets for pleasure.</h3>
                                    <h1 class="animated">Food & Vitamins
                                    <br>
                                        For all Pets</h1>
                                    <div class="slider-btn">
                                        <a class="animated" href="site/products/productPage.aspx">SHOP NOW</a>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-6 col-md-6 col-12 col-sm-5">
                                <div class="slider-single-img slider-animated-1">
                                    <img class="animated" src="assets/img/slider/slider-single-img.png" alt="">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div  class="single-slider pt-100 pb-100 yellow-bg">
                    <div class="container">
                        <div class="row">
                            <div class="col-lg-6 col-md-6 col-sm-7 col-12">
                                <div class="slider-content slider-animated-1 pt-114">
                                    <h3 class="animated">We keep pets for pleasure.</h3>
                                    <h1 class="animated">Food & Vitamins
                                    <br>
                                        For all Pets</h1>
                                    <div class="slider-btn">
                                        <a class="animated" href="site/products/productPage.aspx">SHOP NOW</a>
                                    </div>
                                </div>
                            </div>

                            <div class="col-lg-6 col-md-6 col-sm-5 col-12">
                                <div class="slider-single-img slider-animated-1">
                                    <img class="animated" src="assets/img/slider/slider-single-img-2.png" alt="">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="food-category food-category-col pt-100 pb-60">
            <div class="container">
                <div class="row">

                    <div class="col-lg-4 col-md-4">
                        <a href="site/products/productPage.aspx">
                            <div class="single-food-category cate-padding-1 text-center mb-30">
                                <div class="single-food-hover-2">
                                    <img src="../../assets/img/product/product-1.jpg" alt="">
                                </div>
                                <div class="single-food-content">
                                    <h3>Thức ăn</h3>
                                </div>
                            </div>
                        </a>
                    </div>
                    <div class="col-lg-4 col-md-4">
                        <div class="single-food-category cate-padding-2 text-center mb-30">
                            <div class="single-food-hover-2">
                                <img src="assets/img/product/product-2.jpg" alt="">
                            </div>
                            <div class="single-food-content">
                                <h3>Đồ dùng, phụ kiện</h3>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4 col-md-4">
                        <div class="single-food-category cate-padding-3 text-center mb-30">
                            <div class="single-food-hover-2">
                                <img src="assets/img/product/chamsoc-vesinh.jpg" alt="">
                            </div>
                            <div class="single-food-content">
                                <h3>Chăm sóc, vệ sinh</h3>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="product-area pt-95 pb-70 gray-bg">
            <div class="container">
                <div class="section-title text-center mb-55">
                    <h4>Sản phẩm phổ biến</h4>
                    <h2>Sản phẩm mới</h2>
                </div>
                <div class="row">

                    <div class="col-xl-3 col-lg-4 col-md-6 col-sm-6">
                        <div class="product-wrapper mb-10">
                            <div class="product-img">
                                <a href="product-details.html">
                                    <img src="../../assets/img/product/product-4.jpg" alt="">
                                </a>
                                <div class="product-action">
                                    <a title="Quick View" data-toggle="modal" data-target="#exampleModal" href="#">
                                        <i class="ti-plus"></i>
                                    </a>
                                    <a title="Add To Cart" href="#">
                                        <i class="ti-shopping-cart"></i>
                                    </a>
                                </div>
                                <div class="product-action-wishlist">
                                    <a title="Wishlist" href="#">
                                        <i class="ti-heart"></i>
                                    </a>
                                </div>
                            </div>
                            <div class="product-content">
                                <h4><a href="product-details.html">Dog Calcium Food</a></h4>
                                <div class="product-price">
                                    <span class="new">$20.00 </span>
                                    <span class="old">$50.00</span>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-xl-3 col-lg-4 col-md-6 col-sm-6">
                        <div class="product-wrapper mb-10">
                            <div class="product-img">
                                <a href="product-details.html">
                                    <img src="assets/img/product/product-5.jpg" alt="">
                                </a>
                                <div class="product-action">
                                    <a title="Quick View" data-toggle="modal" data-target="#exampleModal" href="#">
                                        <i class="ti-plus"></i>
                                    </a>
                                    <a title="Add To Cart" href="#">
                                        <i class="ti-shopping-cart"></i>
                                    </a>
                                </div>
                                <div class="product-action-wishlist">
                                    <a title="Wishlist" href="#">
                                        <i class="ti-heart"></i>
                                    </a>
                                </div>
                            </div>
                            <div class="product-content">
                                <h4><a href="product-details.html">Cat Buffalo Food</a></h4>
                                <div class="product-price">
                                    <span class="new">$22.00 </span>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-xl-3 col-lg-4 col-md-6 col-sm-6">
                        <div class="product-wrapper mb-10">
                            <div class="product-img">
                                <a href="product-details.html">
                                    <img src="assets/img/product/product-6.jpg" alt="">
                                </a>
                                <div class="product-action">
                                    <a title="Quick View" data-toggle="modal" data-target="#exampleModal" href="#">
                                        <i class="ti-plus"></i>
                                    </a>
                                    <a title="Add To Cart" href="#">
                                        <i class="ti-shopping-cart"></i>
                                    </a>
                                </div>
                                <div class="product-action-wishlist">
                                    <a title="Wishlist" href="#">
                                        <i class="ti-heart"></i>
                                    </a>
                                </div>
                            </div>
                            <div class="product-content">
                                <h4><a href="product-details.html">Legacy Dog Food</a></h4>
                                <div class="product-price">
                                    <span class="new">$50.00 </span>
                                    <span class="old">$70.00</span>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-xl-3 col-lg-4 col-md-6 col-sm-6">
                        <div class="product-wrapper mb-10">
                            <div class="product-img">
                                <a href="product-details.html">
                                    <img src="assets/img/product/product-7.jpg" alt="">
                                </a>
                                <div class="product-action">
                                    <a title="Quick View" data-toggle="modal" data-target="#exampleModal" href="#">
                                        <i class="ti-plus"></i>
                                    </a>
                                    <a title="Add To Cart" href="#">
                                        <i class="ti-shopping-cart"></i>
                                    </a>
                                </div>
                                <div class="product-action-wishlist">
                                    <a title="Wishlist" href="#">
                                        <i class="ti-heart"></i>
                                    </a>
                                </div>
                            </div>
                            <div class="product-content">
                                <h4><a href="product-details.html">Chicken Dry Cat Food</a></h4>
                                <div class="product-price">
                                    <span class="new">$60.00 </span>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-xl-3 col-lg-4 col-md-6 col-sm-6">
                        <div class="product-wrapper mb-10">
                            <div class="product-img">
                                <a href="product-details.html">
                                    <img src="assets/img/product/product-8.jpg" alt="">
                                </a>
                                <div class="product-action">
                                    <a title="Quick View" data-toggle="modal" data-target="#exampleModal" href="#">
                                        <i class="ti-plus"></i>
                                    </a>
                                    <a title="Add To Cart" href="#">
                                        <i class="ti-shopping-cart"></i>
                                    </a>
                                </div>
                                <div class="product-action-wishlist">
                                    <a title="Wishlist" href="#">
                                        <i class="ti-heart"></i>
                                    </a>
                                </div>
                            </div>
                            <div class="product-content">
                                <h4><a href="product-details.html">Stomach Dog Food</a></h4>
                                <div class="product-price">
                                    <span class="new">$70.00 </span>
                                    <span class="old">$90.00</span>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-xl-3 col-lg-4 col-md-6 col-sm-6">
                        <div class="product-wrapper mb-10">
                            <div class="product-img">
                                <a href="product-details.html">
                                    <img src="assets/img/product/product-9.jpg" alt="">
                                </a>
                                <div class="product-action">
                                    <a title="Quick View" data-toggle="modal" data-target="#exampleModal" href="#">
                                        <i class="ti-plus"></i>
                                    </a>
                                    <a title="Add To Cart" href="#">
                                        <i class="ti-shopping-cart"></i>
                                    </a>
                                </div>
                                <div class="product-action-wishlist">
                                    <a title="Wishlist" href="#">
                                        <i class="ti-heart"></i>
                                    </a>
                                </div>
                            </div>
                            <div class="product-content">
                                <h4><a href="product-details.html">Nourish Puppy Food</a></h4>
                                <div class="product-price">
                                    <span class="new">$80.00 </span>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-xl-3 col-lg-4 col-md-6 col-sm-6">
                        <div class="product-wrapper mb-10">
                            <div class="product-img">
                                <a href="product-details.html">
                                    <img src="assets/img/product/product-10.jpg" alt="">
                                </a>
                                <div class="product-action">
                                    <a title="Quick View" data-toggle="modal" data-target="#exampleModal" href="#">
                                        <i class="ti-plus"></i>
                                    </a>
                                    <a title="Add To Cart" href="#">
                                        <i class="ti-shopping-cart"></i>
                                    </a>
                                </div>
                                <div class="product-action-wishlist">
                                    <a title="Wishlist" href="#">
                                        <i class="ti-heart"></i>
                                    </a>
                                </div>
                            </div>
                            <div class="product-content">
                                <h4><a href="product-details.html">Tarpaulin Dog Food</a></h4>
                                <div class="product-price">
                                    <span class="new">$10.00 </span>
                                    <span class="old">$30.00</span>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-xl-3 col-lg-4 col-md-6 col-sm-6">
                        <div class="product-wrapper mb-10">
                            <div class="product-img">
                                <a href="product-details.html">
                                    <img src="assets/img/product/product-11.jpg" alt="">
                                </a>
                                <div class="product-action">
                                    <a title="Quick View" data-toggle="modal" data-target="#exampleModal" href="#">
                                        <i class="ti-plus"></i>
                                    </a>
                                    <a title="Add To Cart" href="#">
                                        <i class="ti-shopping-cart"></i>
                                    </a>
                                </div>
                                <div class="product-action-wishlist">
                                    <a title="Wishlist" href="#">
                                        <i class="ti-heart"></i>
                                    </a>
                                </div>
                            </div>
                            <div class="product-content">
                                <h4><a href="product-details.html">Dog Calcium Food</a></h4>
                                <div class="product-price">
                                    <span class="new">$22.00 </span>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="deal-area bg-img pt-95 pb-100">

            <div class="container">
                <div class="section-title text-center mb-50">
                    <h4>Sản phẩm tốt nhất</h4>
                    <h2>Ưu đãi trong tuần</h2>
                </div>
                <div class="row">
                    <div class="col-lg-6 col-md-6">
                        <div class="deal-img wow fadeInLeft">
                            <a href="#">
                                <img src="assets/img/banner/banner-4.png" alt=""></a>
                        </div>
                    </div>
                    <div class="col-lg-6 col-md-6">
                        <div class="deal-content">
                            <h3><a href="#">Name Your Product</a></h3>
                            <div class="deal-pro-price">
                                <span class="deal-old-price">$16.00 </span>
                                <span>$10.00</span>
                            </div>
                            <p>Lorem ipsum dolor sit amet, co adipisicing elit, sed do eiusmod tempor incididunt labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercita ullamco laboris nisi ut aliquip ex ea commodo </p>
                            <div class="timer timer-style">
                                <div data-countdown="2017/10/01"></div>
                            </div>
                            <div class="discount-btn mt-35">
                                <a class="btn-style" href="site/products/productDetail.aspx">SHOP NOW</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="blog-area pb-70">
		    <div class="container">
		        <div class="section-title text-center mb-60">
                    <h4>Dịch vụ</h4>
                    <h2>Chăm sóc tận tình</h2>
                </div>
                <div class="row">
                    <div class="col-lg-4 col-md-6">
                        <div class="blog-wrapper mb-30 gray-bg">
                            <div class="blog-img hover-effect">
                                <a href="blog-details.html"><img alt="" src="assets/img/blog/blog-1.jpg"></a>
                            </div>
                            <div class="blog-content">
                                <div class="blog-meta">
                                    <ul>
                                        <li>By: <span>Admin</span></li>
                                        <li>Sep 14, 2018</li>
                                    </ul>
                                </div>
                                <h4><a href="blog-details.html">Lorem ipsum dolor amet cons adipisicing elit</a></h4>
                            </div>
                        </div>
                    </div>
                   
                </div>
		    </div>
		</div>

        <div class="testimonial-area pt-90 pb-70 bg-img" style="background-image: url(assets/img/banner/banner-1.jpg);">
            <div class="container">
                <div class="row">
                    <div class="col-lg-10 ml-auto mr-auto">
                        <div class="testimonial-wrap">
                            <div class="testimonial-text-slider text-center">
                                <div class="sin-testiText">
                                    <p>Lorem ipsum dolor sit amet, co adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercita ullamco laboris nisi ut aliquip ex ea commodo</p>
                                </div>
                                <div class="sin-testiText">
                                    <p>There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or amro porano ja cai tomi tai go amro porano  amro porano ja cai tomi tai go  .... </p>
                                </div>
                                <div class="sin-testiText">
                                    <p>Lorem ipsum dolor sit amet, co adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercita ullamco laboris nisi ut aliquip ex ea commodo</p>
                                </div>
                                <div class="sin-testiText">
                                    <p>There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or amro porano ja cai tomi tai go amro porano  amro porano ja cai tomi tai go  .... </p>
                                </div>
                            </div>
                            <div class="testimonial-image-slider text-center">
                                <div class="sin-testiImage">
                                    <img src="assets/img/testi/3.jpg" alt="">
                                    <h3>Robiul Islam</h3>
                                    <h5>Customer</h5>
                                </div>
                                <div class="sin-testiImage">
                                    <img src="assets/img/testi/4.jpg" alt="">
                                    <h3>Robiul Islam</h3>
                                    <h5>Customer</h5>
                                </div>
                                <div class="sin-testiImage">
                                    <img src="assets/img/testi/3.jpg" alt="">
                                    <h3>F. H. Shuvo</h3>
                                    <h5>Developer</h5>
                                </div>
                                <div class="sin-testiImage">
                                    <img src="assets/img/testi/5.jpg" alt="">
                                    <h3>T. T. Rayed</h3>
                                    <h5>CEO</h5>
                                </div>
                            </div>
                            <div class="testimonial-shap">
                                <img src="assets/img/icon-img/testi-shap.png" alt="">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="service-area bg-img pt-100 pb-65">
            <div class="container">
                <div class="row">
                    <div class="col-lg-4 col-md-4">
                        <div class="service-content text-center mb-30 service-color-1">
                            <img src="assets/img/icon-img/shipping.png" alt="">
                            <h4>Miễn phí vận chuyển</h4>
                            <p>Giao hàng miễn phí cho tất cả các đơn đặt hàng</p>
                        </div>
                    </div>
                    <div class="col-lg-4 col-md-4">
                        <div class="service-content text-center mb-30 service-color-2">
                            <img src="assets/img/icon-img/support.png" alt="">
                            <h4>HỖ TRỢ TRỰC TUYẾN</h4>
                            <p>Hỗ trợ trực tuyến 24 giờ một ngày</p>
                        </div>
                    </div>
                    <div class="col-lg-4 col-md-4">
                        <div class="service-content text-center mb-30 service-color-3">
                            <img src="assets/img/icon-img/money.png" alt="">
                            <h4>Tích điểm</h4>
                            <p>Tặng PetCoin cho mỗi hóa đơn</p>
                        </div>
                    </div>
                </div>
            </div>
        </div>


        <!-- modal -->
        <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-hidden="true">
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                <span class="ti-close" aria-hidden="true"></span>
            </button>
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-body">
                        <div class="qwick-view-left">
                            <div class="quick-view-learg-img">
                                <div class="quick-view-tab-content tab-content">
                                    <div class="tab-pane active show fade" id="modal1" role="tabpanel">
                                        <img src="assets/img/quick-view/l1.jpg" alt="">
                                    </div>
                                    <div class="tab-pane fade" id="modal2" role="tabpanel">
                                        <img src="assets/img/quick-view/l2.jpg" alt="">
                                    </div>
                                    <div class="tab-pane fade" id="modal3" role="tabpanel">
                                        <img src="assets/img/quick-view/l3.jpg" alt="">
                                    </div>
                                </div>
                            </div>
                            <div class="quick-view-list nav" role="tablist">
                                <a class="active" href="#modal1" data-toggle="tab">
                                    <img src="assets/img/quick-view/s1.jpg" alt="">
                                </a>
                                <a href="#modal2" data-toggle="tab" role="tab">
                                    <img src="assets/img/quick-view/s2.jpg" alt="">
                                </a>
                                <a href="#modal3" data-toggle="tab" role="tab">
                                    <img src="assets/img/quick-view/s3.jpg" alt="">
                                </a>
                            </div>
                        </div>
                        <div class="qwick-view-right">
                            <div class="qwick-view-content">
                                <h3>Dog Calcium Food</h3>
                                <div class="product-price">
                                    <span class="new">$20.00 </span>
                                    <span class="old">$50.00</span>
                                </div>
                                <div class="product-rating">
                                    <i class="icon-star theme-color"></i>
                                    <i class="icon-star theme-color"></i>
                                    <i class="icon-star theme-color"></i>
                                    <i class="icon-star"></i>
                                    <i class="icon-star"></i>
                                </div>
                                <p>Lorem ipsum dolor sit amet, consectetur adip elit, sed do amt tempor incididun ut labore et dolore magna aliqua. Ut enim ad mi , quis nostrud veniam exercitation .</p>
                                <div class="quick-view-select">
                                    <div class="select-option-part">
                                        <label>Size*</label>
                                        <select class="select">
                                            <option value="">- Please Select -</option>
                                            <option value="">XS</option>
                                            <option value="">S</option>
                                            <option value="">M</option>
                                            <option value="">L</option>
                                            <option value="">XL</option>
                                            <option value="">XXL</option>
                                        </select>
                                    </div>
                                    <div class="select-option-part">
                                        <label>Color*</label>
                                        <select class="select">
                                            <option value="">- Please Select -</option>
                                            <option value="">orange</option>
                                            <option value="">pink</option>
                                            <option value="">yellow</option>
                                        </select>
                                    </div>
                                </div>
                                <div class="quickview-plus-minus">
                                    <div class="cart-plus-minus">
                                        <input type="text" value="2" name="qtybutton" class="cart-plus-minus-box">
                                    </div>
                                    <div class="quickview-btn-cart">
                                        <a class="btn-style" href="#">add to cart</a>
                                    </div>
                                    <div class="quickview-btn-wishlist">
                                        <a class="btn-hover" href="#"><i class="ti-heart"></i></a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <footer class="footer-area">
        <div class="testimonial-area pt-90 pb-70 bg-img" style="background-image: url(assets/img/banner/banner-7.png);">
        <div class="footer-top pt-80 pb-50 gray-bg-2">
            <div class="container">
                <div class="row">
                    <div class="col-xl-3 col-lg-3 col-md-6 col-sm-6">
                        <div class="footer-widget mb-30">
                            <div class="footer-info-wrapper">
                                <div class="footer-logo">
                                    <a href="#">
                                        <img src="assets/img/logo/NT.svg" alt="">
                                    </a>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-xl-2 col-lg-3 col-md-6 col-sm-6">
                        <div class="footer-widget mb-30 pl-50">
                            <h4 class="footer-title">Theo dõi</h4>
                            <ul class="footer-content">
                            <a href="#"><i class="icon-social-twitter"></i>Twitter</a>
                            <a href="#"><i class="icon-social-instagram"></i>Instagram</a>
                            <a href="#"><i class="icon-social-skype"></i>Skype</a>
                            <a href="#"><i class="icon-social-facebook">Facebook</i></a>
                        </div>
                    </div>
                    <div class="col-xl-2 col-lg-3 col-md-6 col-sm-6">
                        <div class="footer-widget mb-30 pl-50">
                            <h4 class="footer-title">Liên hệ</h4>
                            <div class="footer-content">
                                <ul>
                                    <li><a href="#">Help & Contact Us</a></li>
                                    <li><a href="#">Returns & Refunds</a></li>
                                    <li><a href="#">Online Stores</a></li>
                                    <li><a href="#">Terms & Conditions</a></li>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <div class="col-xl-2 col-lg-2 col-md-6 col-sm-6">
                        <div class="footer-widget mb-30 pl-70">
                            <h4 class="footer-title">Hỗ trợ</h4>
                            <div class="footer-content">
                                <ul>
                                    <li><a href="#">Faq's </a></li>
                                    <li><a href="#">Pricing Plans</a></li>
                                    <li><a href="#">Order Traking</a></li>
                                    <li><a href="#">Returns </a></li>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <div class="col-xl-3 col-lg-4 col-md-6 col-sm-6">
                        <div class="footer-widget">
                            <div class="newsletter-wrapper">
                                <p>Subscribe to our newsletter and get 10% off your first purchase..</p>
                                <div class="newsletter-style">
                                    <div id="mc_embed_signup" class="subscribe-form">
                                        <form action="#" method="post" id="mc-embedded-subscribe-form" name="mc-embedded-subscribe-form" class="validate" target="_blank" novalidate>
                                            <div id="mc_embed_signup_scroll" class="mc-form">
                                                <input type="email" value="" name="EMAIL" class="email" placeholder="Your mail address" required>
                                                <!-- real people should not fill this in and expect good things - do not remove this or risk form bot signups-->
                                                <div class="mc-news" aria-hidden="true">
                                                    <input type="text" name="b_6bbb9b6f5827bd842d9640c82_05d85f18ef" tabindex="-1" value="">
                                                </div>
                                                <div class="clear">
                                                    <input type="submit" value="SEND" name="subscribe" id="mc-embedded-subscribe" class="button">
                                                </div>
                                            </div>
                                        </form>
                                    </div>
                                </div>
                            </div>
                            <div class="payment-img">
                                <a href="index.html">
                                    <img src="assets/img/icon-img/payment.png" alt="">
                                </a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="footer-bottom gray-bg-3 pt-17 pb-15">
            <div class="container">
                <div class="row">
                    <div class="col-12">
                        <div class="copyright text-center">
                            <p>Copyright © <a href="#">Marten.</a> All Right Reserved.</p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </footer>--%>


    </div>
</asp:Content>
