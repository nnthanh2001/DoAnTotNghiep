using Entities.Product;
using HttpClient_API;
using HttpClient_API.Core.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DATN.PetShop.Admin.site.products.product
{
    public partial class editProduct : System.Web.UI.Page
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

                var getHTML = GetDataEditProduct(id);
                main.InnerHtml = getHTML;
            }
        }

        public string GetDataEditProduct(string id)
        {

            var baseUrl = Globals.baseAPI;
            var apiEditProduct = Globals.editProductAPI + "/" + id;



            var strBodyEditProduct = new StringBuilder();
            var strPetType = new StringBuilder();
            var strListStatus = new StringBuilder();
            var strListCategory = new StringBuilder();



            var product = Restful.Get<ProductFormModel>(baseUrl, apiEditProduct).Result;

            var petTypeList = product.petTypeList;
            var statusList = product.statusList;
            var categoryList = product.categoryList;

            if (petTypeList != null && petTypeList.Any())
            {
                foreach (var petType in petTypeList)
                {
                    strPetType.Append("<option value='" + petType.petTypeID + "' " + petType.select + ">" + petType.petTypeName + "</option>");
                }
            }
            if (statusList != null && statusList.Any())
            {
                foreach (var status in statusList)
                {
                    strListStatus.Append("<option value='" + status.statusID + "' " + status.select + ">" + status.statusName + "</option>");
                }
            }
            if (categoryList != null && categoryList.Any())
            {
                foreach (var category in categoryList)
                {
                    strListCategory.Append("<option value='" + category.categoryID + "' " + category.select + ">" + category.categoryName + "</option>");
                }
            }

            var html = @"<div class='container-fluid'>
            <!-- Page-Title -->
            <div class='row'>
                <div class='col-sm-12'>
                    <div class='page-title-box'>
                        <div class='float-end'>
                            <ol class='breadcrumb'>
                                <li class='breadcrumb-item'><a href='#'>Trang chủ</a></li>
                                <li class='breadcrumb-item'><a href='#'>Sản phẩm</a></li>
                                <li class='breadcrumb-item active'>Sửa sản phẩm</li>
                            </ol>
                        </div>
                        <h4 class='page-title'>Chỉnh sửa thông tin </h4>
                    </div>
                    <!--end page-title-box-->
                </div>
                <!--end col-->
            </div>
            <!-- end page title end breadcrumb -->
            <div class='row'>
                <div class='col-lg-12'>
                    <div class='col-lg-12'>
                        <div class='card'>
                            <div class='card-header'>
                                <h4 class='align-self-xxl-baseline'>Thông tin cơ bản</h4>

                            </div>
                            <!--end card-header-->
                            <div class='card-body'>
                                <div margin='text-align: left'>
                                    <div class='col-lg-12'>
                                        <div class='row'>
                                            <div class='col-lg-6'>
                                                <div class='card'>
                                                    <div class='card-header'>
                                                        <div class='mb-3 row'>
                                                            <label for='example-email-input' class='col-sm-2 col-form-label text-end'>Tên</label>
                                                            <div class='col-sm-10'>
                                                                <input class='form-control' type='text' data_value='productName' placeholder='Nhập tên sản phẩm' value='{0}'>
                                                            </div>
                                                        </div>

                                                        <div class='mb-3 row'>
                                                            <label class='col-sm-2 col-form-label text-end'>Mã</label>
                                                            <div class='col-sm-4'>
                                                                <input class='form-control'placeholder='Mã sản phẩm' data_value='productID' value='{1}' />
                                                            </div>
                                                            <label class='col-sm-2 col-form-label text-end'>Số lượng</label>
                                                            <div class='col-sm-4'>
                                                                <input class='form-control'  type='number' placeholder='Số lượng' data_value='quantity' value='{2}' />
                                                            </div>

                                                        </div>
                                                        <div class='mb-3 row'>
                                                          <label class='col-sm-2 col-form-label text-end'>Loại</label>
                                                            <div class='col-sm-10'>
                                                                <select class='form-select' aria-label='Default select example' data_value='categoryID'>                                                                   
                                                                    " + strListCategory.ToString() + @"
                                                                </select>
                                                            </div>
                                                         </div>
                                                        <div class='mb-3 row'>
                                                            <label class='col-sm-2 col-form-label text-end'>Loài</label>
                                                            <div class='col-sm-4'>
                                                                <select class='form-select' aria-label='Default select example' data_value='petTypeID'>
                                                                   
                                                                   " + strPetType.ToString() + @"
                                                                </select>
                                                            </div>
                                                            <label class='col-sm-2 col-form-label text-end'>Giá bán</label>
                                                            <div class='col-sm-4'>
                                                                <input class='form-control' type='number' data_value='price' placeholder='Giá bán' value='{5}'>
                                                            </div>
                                                        </div>
                                                        <div class='mb-3 row'>

                                                            
                                                            <label class='col-sm-2 col-form-label text-end'>Trạng thái</label>
                                                            <div class='col-sm-4'>
                                                                <select class='form-select' aria-label='Default select example' data_value='statusID'>
                                                                   
                                                                    " + strListStatus.ToString() + @"
                                                                </select>
                                                            </div>
                                                        </div>
                                                        <div class='mb-3 row'>
                                                            <label for='example-email-input' class='col-sm-2 col-form-label text-end'>Handle Request</label>
                                                            <div class='col-sm-10'>
                                                                <input class='form-control' type='text' data_value='productHandle' placeholder='Handle Request Name' value='" + product.productHandle + @"'>
                                                            </div>
                                                        </div>
                                                        <div class='mb-3 row'>
                                                           <label class='col-sm-4 col-form-label text-end'>Sản phẩm tốt nhất</label>
                                                           <div class='col-sm-1'>
                                                               <div class='form-check form-switch form-switch-success' style='margin-left:auto;margin-right:auto;display:block;margin-top:22%;margin-bottom:0%'>
                                                                    <input class='form-check-input' type='checkbox'  value='" + product.usingExpired + @"' data_value='usingExpired'>
                                                               </div>
                                                           </div>
                                                           <label class='col-sm-2 col-form-label text-end'>Thời hạn:</label>
                                                           <div class='col-sm-4'>
                                                                <form action='/action_page.php' data_value='bestProductExpried'>
                                                                    <input type='date' data_value='bestProductExpired' value='" + product.bestProductExpired + @"'>
                                                                </form>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class='col-lg-3'>
                                                <img src='assets/img_product/01.jpg' alt='' height='200' width='200'>
                                                <button class='btn-de-blue' type='submit'>Chọn ảnh</button>
                                            </div>
                                            <div class='col-lg-12'>
                                                <div class='card'>
                                                    <div class='card-header'>
                                                        <h4 class='align-self-xxl-baseline'>Mô tả</h4>
                                                        <div class='col-lg-12'>
                                                            <div class='mb-3 row'>
                                                                <div class='col-sm-12'>
                                                                    <textarea class='form-control' rows='3' data_value='description' placeholder='Mô tả'>{7}</textarea>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <!--end card-header-->
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <button class='btn btn-primary' type='submit' jsaction='editProductButton' value='" + product._id+@"'>Xác nhận chỉnh sửa</button>
           
        </div>

";

            var htmlEditProductDetail = string.Format(html, product.productName, product.productID, product.quantity, product.petTypeName, product.categoryName, product.price, product.statusName, product.description);
            strBodyEditProduct.Append(htmlEditProductDetail);

            html = string.Concat(strBodyEditProduct.ToString());
            return html;
        }
    }
}