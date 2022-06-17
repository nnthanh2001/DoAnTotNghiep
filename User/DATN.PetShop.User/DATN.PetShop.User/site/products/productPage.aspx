<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="productPage.aspx.cs" Inherits="DATN.PetShop.User.site.products.productPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="server">
    <div class="page-content-tab" id="main" runat="server">
        <div class="breadcrumb-area pt-95 pb-95 bg-img" style="background-image: url(assets/img/banner/banner-2.jpg);">
            <div class="container">
                <div class="breadcrumb-content text-center">
                    <h2>Trang sản phẩm</h2>
                    <ul>
                        <li><a href="site/home/home.aspx">home</a></li>
                        <li class="active">All products</li>
                    </ul>
                </div>
            </div>
        </div>
        <div class="shop-area pt-100 pb-100 gray-bg">
            <div class="container">
                <div class="row flex-row-reverse">
                    <div class="col-lg-9">
                        <div class="grid-list-product-wrapper">
                            <div class="product-view product-grid">
                                <div class="row">

                                    <div class="product-width col-lg-6 col-xl-4 col-md-6 col-sm-6">
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
                                                <h4><a href="product-details.html">Dog Calcium Food</a></h4>
                                                <div class="product-price">
                                                    <span class="new">$20.00 </span>
                                                    <span class="old">$50.00</span>
                                                </div>
                                            </div>
                                            <div class="product-list-content">
                                                <h4><a href="#">Dog Calcium Food</a></h4>
                                                <div class="product-price">
                                                    <span class="new">$19.00 </span>
                                                </div>
                                                <p>Lorem ipsum dolor sit amet, consect adipis elit, sed do eiusmod tempor incididu ut labore et dolore magna aliqua. Ut enim ad quis nostrud exerci ullamco laboris nisi ut aliquip ex ea commodo consequat, Duis aute irure dolor.</p>
                                                <div class="product-list-action">
                                                    <div class="product-list-action-left">
                                                        <a class="addtocart-btn" title="Add to cart" href="#"><i class="ion-bag"></i>Add to cart</a>
                                                    </div>
                                                    <div class="product-list-action-right">
                                                        <a title="Wishlist" href="#"><i class="ti-heart"></i></a>
                                                        <a title="Quick View" data-toggle="modal" data-target="#exampleModal" href="#"><i class="ti-plus"></i></a>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    
                                </div>
                                <div class="pagination-style text-center mt-10">
                                    <ul>
                                        <li>
                                            <a href="#"><i class="icon-arrow-left"></i></a>
                                        </li>
                                        <li>
                                            <a href="#">1</a>
                                        </li>
                                        <li>
                                            <a href="#">2</a>
                                        </li>
                                        <li>
                                            <a class="active" href="#"><i class="icon-arrow-right"></i></a>
                                        </li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-3">
                        <div class="shop-sidebar">
                            <div class="shop-widget">
                                <h4 class="shop-sidebar-title">Tìm kiếm sản phẩm</h4>
                                <div class="shop-search mt-25 mb-50">
                                    <form class="shop-search-form">
                                        <input type="text" placeholder="Find a product">
                                        <button type="submit">
                                            <i class="icon-magnifier"></i>
                                        </button>
                                    </form>
                                </div>
                            </div>

                            <div class="shop-widget mt-50">
                                <h4 class="shop-sidebar-title">Thức ăn, dinh dưỡng</h4>
                                <div class="shop-list-style mt-20">
                                    <ul>
                                        <li><a href="shop-page.html">Hạt khô</a></li>
                                        <li><a href="shop-page.html">Pate</a></li>
                                        <li><a href="shop-page.html">Bánh thưởng</a></li>
                                        <li><a href="shop-page.html">Vitamin & Dinh dưỡng</a></li>
                                        <li><a href="shop-page.html">Thuốc thú y</a></li>
                                    </ul>
                                </div>
                            </div>
                            <div class="shop-widget mt-50">
                                <h4 class="shop-sidebar-title">Đồ dùng, phụ kiện</h4>
                                <div class="shop-list-style mt-20">
                                    <ul>
                                        <li><a href="shop-page.html">Quần áo</a></li>
                                        <li><a href="shop-page.html">Vòng cổ</a></li>
                                        <li><a href="shop-page.html">Lồng vận chuyển</a></li>
                                        <li><a href="shop-page.html">Đồ chơi</a></li>
                                        <li><a href="shop-page.html">Bát ăn, bình uống nước</a></li>
                                    </ul>
                                </div>
                            </div>
                            <div class="shop-widget mt-50">
                                <h4 class="shop-sidebar-title">Chăm sóc vệ sinh </h4>
                                <div class="shop-list-style mt-20">
                                    <ul>
                                        <li><a href="shop-page.html">Tả bỉm, lót vệ sinh</a></li>
                                        <li><a href="shop-page.html">Khay vệ sinh, cát</a></li>
                                        <li><a href="shop-page.html">Sữa tắm, xịt dưỡng</a></li>
                                        <li><a href="shop-page.html">Máy sấy, lược chải</a></li>
                                        <li><a href="shop-page.html">Máy mài móng, kìm cắt móng</a></li>
                                    </ul>
                                </div>
                            </div>

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
                                <a class="active" href="#modal1" data-toggle="tab" role="tab">
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
                                    <span>$19.00 </span>
                                </div>
                                <div class="product-rating">
                                    <i class="ion-star theme-color"></i>
                                    <i class="ion-star theme-color"></i>
                                    <i class="ion-star theme-color"></i>
                                    <i class="ion-star theme-color"></i>
                                    <i class="ion-star theme-color"></i>
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
    </div>
</asp:Content>
