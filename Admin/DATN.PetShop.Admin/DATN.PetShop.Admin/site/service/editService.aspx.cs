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

namespace DATN.PetShop.Admin.site.products.services
{
    public partial class addService : System.Web.UI.Page
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

                var getService = GetDataEditService(id);
                main.InnerHtml = getService;
            }
        }
        public string GetDataEditService(string id)
        {
            var baseUrl = Globals.baseAPI;
            var apiUser = Globals.editServiceAPI + "/" + id;

            var service = Restful.Get<ServiceFormModel>(baseUrl, apiUser).Result;
          
            var statusList = service.statusList;
            var conditionList = service.conditionList;

            var strListStatus = new StringBuilder();
            var strListCondition = new StringBuilder();

            if (conditionList != null && conditionList.Any())
            {
                foreach (var condition in conditionList)
                {
                    strListCondition.Append("<option value='" + condition.conditionID + "' " + condition.select + ">" + condition.condition + "</option>");
                }
            }
            if (statusList != null && statusList.Any())
            {
                foreach (var status in statusList)
                {
                    strListStatus.Append("<option value='" + status.statusID + "' " + status.select + ">" + status.statusName + "</option>");
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
                                <li class='breadcrumb-item'><a href='#'>Dịch vụ</a></li>
                                <li class='breadcrumb-item active'>Chỉnh sửa dịch vụ</li>
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
                                                                <input class='form-control' type='text' data_value='serviceName' placeholder='Nhập tên dịch vụ' value='" + service.serviceName + @"'>
                                                            </div>
                                                        </div>

                                                        <div class='mb-3 row'>
                                                            <label class='col-sm-2 col-form-label text-end'>Mã</label>
                                                            <div class='col-sm-4'>
                                                                <input class='form-control'placeholder='Mã dịch vụ' data_value='serviceID' value='" + service.serviceID+@"' />
                                                            </div>
                                                        </div>
                                                        <div class='mb-3 row'>
                                                          <label class='col-sm-2 col-form-label text-end'>Điều kiện</label>
                                                            <div class='col-sm-10'>
                                                                <select class='form-select' aria-label='Default select example' data_value='condition'>                                                                   
                                                                    " + strListCondition.ToString() + @"
                                                                </select>
                                                            </div>
                                                         </div>
                                                        <div class='mb-3 row'>
                                                            <label class='col-sm-2 col-form-label text-end'>Đơn vị tính</label>
                                                            <div class='col-sm-4'>
                                                                <select class='form-select' aria-label='Default select example' data_value='unit'>
                                                                   <option value='Lần'></option>
                                                                   <option value='Ngày'></option>
                                                                   

                                                                </select>
                                                            </div>
                                                            <label class='col-sm-2 col-form-label text-end'>Giá</label>
                                                            <div class='col-sm-4'>
                                                                <input class='form-control' type='number' data_value='price' placeholder='Giá' value='" + service.price +@"'>
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
                                                    <img src='"+service.image+ @"' style='width:150px; height:150px;' />
                                                </div>
                                                <button class='btn-de-blue' type='submit' id='btnUpload' style='margin-bottom: 10px;'>Chọn ảnh</button>
                                                <label class='col-sm-4 col-form-label '>Hoặc nhập địa chỉ hình ảnh</label>
                                                <div class='col-sm-4'><input type='text' data_value='image' value='' style='width: 300px'></div>
                                            </div>
                                            <div class='col-lg-12'>
                                                <div class='card'>
                                                    <div class='card-header'>
                                                        <h4 class='align-self-xxl-baseline'>Mô tả</h4>
                                                        <div class='col-lg-12'>
                                                            <div class='mb-3 row'>
                                                                <div class='col-sm-12'>
                                                                    <textarea class='form-control' rows='3' data_value='description' placeholder='Mô tả'></textarea>
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
            <button class='btn btn-primary' type='submit' jsaction='editServiceButton' value=''>Xác nhận chỉnh sửa</button>
           
        </div>

";


            return html;
        }
    }
}