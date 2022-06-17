using Entities.Category;
using Entities.Product;
using HttpClient_API;
using HttpClient_API.Core.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace DATN.PetShop.User.site.products
{
    public partial class productPage : System.Web.UI.Page
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
                
                var getProduct = GetDataProduct();
                main.InnerHtml = getProduct;
            }

        }
        public string GetDataProduct()
        {
            var baseUrl = Globals.baseAPI;
            var apiUrl = Globals.productAPI;
            var apiCategory = Globals.categoryAPI;





            var strBodyProduct = new StringBuilder();
            var strBodyCategory = new StringBuilder();


            var strProduct = Restful.Get<List<ProductModel>>(baseUrl, apiUrl).Result;
            var strCategory = Restful.Get<List<CategoryModel>>(baseUrl, apiCategory).Result;


            var html = "";



            //body

            foreach (var product in strProduct)
            {
                strBodyProduct.Append("<div class='product-width col-lg-6 col-xl-4 col-md-6 col-sm-6'>");
                strBodyProduct.Append("<div class='product-wrapper mb-10'>");
                strBodyProduct.Append(" <div class='product-img'>");
                strBodyProduct.Append("<a href='/san-pham/" + product.productHandle + "-" + product._id + "'>");
                strBodyProduct.Append("<img src='assets/img/product/product-5.jpg' alt=''>");
                strBodyProduct.Append(" </a>");
                strBodyProduct.Append("<div class='product-action'>");
                strBodyProduct.Append("<a title='Xem nhanh' data-toggle='modal' data-target='#" + product._id + "' href='" + product._id + "'>");
                strBodyProduct.Append("<i class='ti-plus'></i>");
                strBodyProduct.Append("</a>");
                strBodyProduct.Append("<a title='Thêm vào giỏ han' href='#'>");
                strBodyProduct.Append("<i class='ti-shopping-cart'></i>");
                strBodyProduct.Append("</a>");
                strBodyProduct.Append("</div>");
                strBodyProduct.Append("<div class='product-action-wishlist'>");
                strBodyProduct.Append("<a title='Wishlist' href='#'>");
                strBodyProduct.Append("<i class='ti-heart'></i>");
                strBodyProduct.Append("</a>");
                strBodyProduct.Append("</div>");
                strBodyProduct.Append("</div>");
                strBodyProduct.Append("<div class='product-content'>");
                strBodyProduct.Append("<h4><a href='/san-pham/" + product.productHandle + "-" + product._id + "'>" + product.productName + "</a></h4>");
                strBodyProduct.Append("<div class='product-price'>");
                strBodyProduct.Append("<span class='new'>" + product.price +".000đ</span>");
                //strBodyProduct.Append(" <span class='old'>$50.00</span>");
                strBodyProduct.Append("</div>");
                strBodyProduct.Append("</div>");
                strBodyProduct.Append("  <div class='product-list-content'>");
                strBodyProduct.Append(" <h4><a href='#'>Dog</a></h4>");
                strBodyProduct.Append("<div class='product-price'>");
                strBodyProduct.Append("<span class='new'>$19.00 </span>");
                strBodyProduct.Append("</div>");
                strBodyProduct.Append(" <p>Lorem ipsum dolor sit amet, consect adipis elit, sed do eiusmod tempor incididu ut labore et dolore magna aliqua. Ut enim ad quis nostrud exerci ullamco laboris nisi ut aliquip ex ea commodo consequat, Duis aute irure dolor.</p>");
                strBodyProduct.Append(" <div class='product-list-action'>");
                strBodyProduct.Append("<div class='product-list-action-left'>");
                strBodyProduct.Append("<a class='addtocart-btn' title='Add to cart' href='#'><i class='ion-bag'></i>Add to cart</a>");
                strBodyProduct.Append(" </div>");
                strBodyProduct.Append("<div class='product-list-action-right'>");
                strBodyProduct.Append(" <a title='Wishlist' href='#'><i class='ti-heart'></i></a>");
                strBodyProduct.Append("<a title='Quick View' data-toggle='modal' data-target='#exampleModal' href='#'><i class='ti-plus'></i></a>");
                strBodyProduct.Append("</div>");
                strBodyProduct.Append("</div>");
                strBodyProduct.Append("</div>");
                strBodyProduct.Append(" </div>");
                strBodyProduct.Append(" </div>");
                var getQuickView = GetQuickView(product._id);
                strBodyProduct.Append(getQuickView);
            }


            if (strCategory != null && strCategory.Any())
            {
                var categoryParentList = strCategory.Where(x => x.categoryParent.Equals(0));
                foreach (var category in categoryParentList)
                {
                    var categortId = category.categoryID;
                    var categoryChildList = strCategory.Where(x => x.categoryParent.Equals(categortId));
                    var strBChild = new StringBuilder();
                    if (categoryChildList != null && categoryChildList.Any())
                    {
                        foreach (var categoryChild in categoryChildList)
                        {
                            strBChild.Append("<li><a href='shop-page.html'>" + categoryChild.categoryName + "</a></li>");
                        }

                    }
                    var categoryList = @"<div class='shop-widget mt-50'>
                                <h4 class='shop-sidebar-title'>" + category.categoryName + @"</h4>
                                 <div class='shop-list-style mt-20'>
                                    <ul>
                                       " + strBChild.ToString() + @"
                                    </ul>
                                </div>
                            </div>";
                    strBodyCategory.Append(categoryList);

                }
            }


            //header
            var header = @"<div class='breadcrumb-area pt-95 pb-95 bg-img' style='background-image: url(assets/img/banner/banner-2.jpg);'>
            <div class='container'>
                <div class='breadcrumb-content text-center'>
                    <h2>Trang sản phẩm</h2>
                    <ul>
                        <li><a href='site/home/home.aspx.cs'>Trang chủ</a></li>
                        <li class='active'>Sản phẩm</li>
                    </ul>
                </div>
            </div>
        </div>
        <div class='shop-area pt-100 pb-100 gray-bg'>
            <div class='container'>
                <div class='row flex-row-reverse'>
                    <div class='col-lg-9'>
                        <div class='grid-list-product-wrapper'>
                            <div class='product-view product-grid'>
                                <div class='row'>";



            //footer
            var footer = @"</div>
                                <div class='pagination-style text-center mt-10'>
                                    <ul>
                                        <li>
                                            <a href='#'><i class='icon-arrow-left'></i></a>
                                        </li>
                                        <li>
                                            <a href='#'>1</a>
                                        </li>
                                        <li>
                                            <a href='#'>2</a>
                                        </li>
                                        <li>
                                            <a class='active' href='#'><i class='icon-arrow-right'></i></a>
                                        </li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class='col-lg-3'>
                        <div class='shop-sidebar'>
                            <div class='shop-widget'>
                                <h4 class='shop-sidebar-title'>Tìm kiếm sản phẩm</h4>
                                <div class='shop-search mt-25 mb-50'>
                                    <form class='shop-search-form'>
                                        <input type='text' placeholder='Nhập từ khóa'>
                                        <button type='submit'>
                                            <i class='icon-magnifier'></i>
                                        </button>
                                    </form>
                                </div>
                            </div>

                            " + strBodyCategory.ToString() + @"
                        </div>
                    </div>
                </div>
            </div>
        </div>";





            html = string.Concat(header, strBodyProduct.ToString(), footer);

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
        <div class='modal fade' id='"+ id +@"' tabindex='-1' role='dialog' aria-hidden='true'>
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



