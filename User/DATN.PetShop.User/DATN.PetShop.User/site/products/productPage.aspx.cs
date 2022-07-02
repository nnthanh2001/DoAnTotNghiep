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
                var id = request["_id"] != null && request["_id"].ToString() != ""
                ? request["_id"].ToString().ToLower().Trim()
                : "";
                if (id == null || id == "")
                {
                    var categoryID = 0;
                    var getProduct = GetDataProduct(categoryID);
                    main.InnerHtml = getProduct;
                }
                else
                {
                    var categoryId = int.Parse(id);
                    var getProduct = GetDataProduct(categoryId);
                    main.InnerHtml = getProduct;
                }
            }

        }
        public string GetDataProduct(int categoryId)
        {

            var baseUrl = Globals.baseAPI;
            var apiUrl = Globals.productPageAPI + "?id=" + categoryId;

            var productPage = Restful.Get<ProductPage>(baseUrl, apiUrl).Result;

            var strBodyProduct = new StringBuilder();
            var strBodyCategory = new StringBuilder();

            //body

            if (productPage.product.Count == 0)
            {
                var itemHtml = @"<tr><h3>Không tồn tại sản phẩm </h3></tr>";
                strBodyProduct.Append(itemHtml);
            }
            else
            {
                foreach (var product in productPage.product)
                {
                    string price = String.Format("{0:0,00₫}", product.price);
                    var body = @"<div class='product-width col-lg-6 col-xl-4 col-md-6 col-sm-6'>
      <div class='col-inner'>
        <div class='product-wrapper mb-10'>
           <div class='product-small box'>
            <div class='product-img'>
                <a href='/chi-tiet-san-pham/" + product.productHandle + "-" + product._id + "-" + product.categoryID + @"'>
                    <img src='" + product.image + @"' alt=''>
                </a>
                <div class='product-action'>
                    <a title='Xem nhanh' data-toggle='modal' data-target='#" + product._id + @"' href='" + product._id + @"'>
                        <i class='ti-plus'></i>
                    </a>
                    <a title='Thêm vào giỏ hàng' href='javascript:void(0);' jsaction='addItemToCartButton' value='" + product._id + @"'>
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
                <h4><a href='/chi-tiet-san-pham/" + product.productHandle + @"-" + product._id + "-" + product.categoryID + @"'>" + product.productName + @"</a></h4>
                <div class='product-price'>
                    <span class='new'>" + price + @"</span>
                </div>
            </div>
           </div>
          </div>
        </div>
    </div>";
                    var getQuickView = GetQuickView(product._id);
                    strBodyProduct.Append(body);
                    strBodyProduct.Append(getQuickView);
                }


            }


            var categoryAll = productPage.category;
            if (categoryAll != null && categoryAll.Any())
            {
                var categoryParentList = categoryAll.Where(x => x.categoryParent.Equals(0));
                foreach (var category in categoryParentList)
                {
                    var categortId = category.categoryID;
                    var categoryChildList = categoryAll.Where(x => x.categoryParent.Equals(categortId));
                    var strBChild = new StringBuilder();
                    if (categoryChildList != null && categoryChildList.Any())
                    {
                        foreach (var categoryChild in categoryChildList)
                        {
                            strBChild.Append("<li><a href='/san-pham/" + categoryChild.categoryHandle + "-" + categoryChild.categoryID + @"'>" + categoryChild.categoryName + "</a></li>");
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
                        <li><a href='trang-chu'>Trang chủ</a></li>
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


            //var ketqua = from product in strProduct
            //             where product.price == 400
            //             select product;

            //foreach (var product in ketqua)
            //    Console.WriteLine(product.ToString());


            var html = string.Concat(header, strBodyProduct.ToString(), footer);

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
                                    <span>" + price + @"</span>
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
                                        <input type = 'text' value='1' name='qtybutton' class='cart-plus-minus-box'>
                                    </div>
                                    <div class='quickview-btn-cart'>
                                        <a title='Thêm vào giỏ hàng' href='javascript:void(0);' jsaction='addItemToCartButton' value='" + productDetail._id + @"'>Thêm vào giỏ hàng</a>
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



