using Entities.Product;
using HttpClient_API;
using HttpClient_API.Core.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace DATN.PetShop.User.site.ModalQuickView
{
    public class QuickView
    {
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