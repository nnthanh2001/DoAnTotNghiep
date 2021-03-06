using Entities.Product;
using HttpClient_API;
using HttpClient_API.Core.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DATN.PetShop.Admin.site.products.product
{
    public partial class addProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var addProduct = AddProduct();
            main.InnerHtml = addProduct;
        }

        public string AddProduct()
        {

            var baseUrl = Globals.baseAPI;
            var apiAddProduct = Globals.addProductAPI;



            var strBodyAddProduct = new StringBuilder();
            var strPetType = new StringBuilder();
            var strListStatus = new StringBuilder();
            var strListCategory = new StringBuilder();



            var product = Restful.Get<ProductFormModel>(baseUrl, apiAddProduct).Result;

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
                                <li class='breadcrumb-item active'>Thêm mới sản phẩm</li>
                            </ol>
                        </div>
                        <h4 class='page-title'>Thêm mới</h4>
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
                                                          <label class='col-sm-2 col-form-label text-end'>Loại</label>
                                                            <div class='col-sm-10'>
                                                                <select class='form-select' aria-label='Default select example' placeholder='Hạt khô' data_value='categoryID'>                                                                   
                                                                    " + strListCategory.ToString() + @"
                                                                </select>
                                                            </div>
                                                         </div>
                                                        <div class='mb-6 row'>
                                                            <label class='col-sm-2 col-form-label text-end'>Số lượng</label>
                                                            <div class='col-sm-10'>
                                                                <input class='form-control'  type='number' placeholder='Số lượng' data_value='quantity' value='{2}' />
                                                            </div>
                                                        </div>
                                                        <div class='mb-3 row' style='margin-top: 20px;'>
                                                            <label class='col-sm-2 col-form-label text-end'>Loài</label>
                                                            <div class='col-sm-4'>
                                                                <select class='form-select' aria-label='Default select example' placeholder='Chó' data_value='petTypeID'>
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
                                                                <select class='form-select' aria-label='Default select example' placeholder='Còn hàng' data_value='statusID'>
                                                                    " + strListStatus.ToString() + @"
                                                                </select>
                                                            </div>
                                                        </div>
                                                       
                                                        <div class='mb-3 row'>
                                                           <label class='col-sm-4 col-form-label text-end'>Sản phẩm tốt nhất</label>
                                                           <div class='col-sm-1'>
                                                               <div class='form-check form-switch form-switch-success' style='margin-left:auto;margin-right:auto;display:block;margin-top:22%;margin-bottom:0%'>
                                                                    <input class='form-check-input' type='checkbox' id='customSwitchSuccess' data_value='usingExpired'>
                                                               </div>
                                                           </div>
                                                           <label class='col-sm-2 col-form-label text-end'>Thời hạn:</label>
                                                           <div class='col-sm-4'>
                                                                    <input type='date' data_value='bestProductExpired'>
                                                            </div>
                                                        </div>          
                                                       
                                                    </div>
                                                </div>
                                            </div>
                                            <div class='col-lg-6'>
                                                <div style='display: none;'>
                                                    <form method='post' enctype='multipart/form-data'>
                                                        <input type='file' id='fileUploadVersion' name='fileUploadVersion'>
                                                    </form>
                                                </div>
                                               
                                                <div data-img='upload'>
                                                    <img src='https://media.istockphoto.com/vectors/picture-gallery-icon-logo-vector-illustrattion-photo-gallery-icon-vector-id1219544458?k=20&m=1219544458&s=170667a&w=0&h=pOS74M1YmaSx9awGtS_JH1cEnT7wpNUx3mC3Curkqzg=' style='width:150px; height:150px;' />
                                                </div>
                                                <button class='btn-de-blue' type='submit' id='btnUpload' style='margin-bottom: 10px;'>Chọn ảnh</button>
                                                <label class='col-sm-4 col-form-label '>Hoặc nhập địa chỉ hình ảnh</label>
                                                <div class='col-sm-4'><input type='text' data_value='image' style='width: 300px'></div>
                                            </div>
                                            <div class='col-lg-12'>
                                                <div class='card'>
                                                    <div class='card-header'>
                                                        <h4 class='align-self-xxl-baseline'>Mô tả</h4>
                                                        <div class='col-lg-12'>
                                                            <div class='mb-3 row'>
                                                                <div class='col-sm-12'>
                                                                    <textarea class='form-control' rows='3' data_value='description' placeholder='Nhập mô tả'>{7}</textarea>
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
            <button class='btn btn-primary' type='submit' jsaction='addProductButton'>Xác nhận thêm mới</button>
        </div>

";




            var htmlAddProduct = string.Format(html, product.productName, product.productID, product.quantity, product.petTypeName, product.categoryName, product.price, product.statusName, product.description);

            strBodyAddProduct.Append(htmlAddProduct);

            html = string.Concat(strBodyAddProduct.ToString());
            return html;
        }

    }
}