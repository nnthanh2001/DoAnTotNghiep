using Entities.Invoice;
using HttpClient_API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DATN.PetShop.Admin.site.invoice
{
    public partial class invoice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var getInvoice = GetDataInvoice();
            main.InnerHtml = getInvoice;
        }

        public string GetDataInvoice()
        {
            var baseUrl = "https://localhost:44309";
            var apiUrl = "api/Invoice";
            var str = Restful.Get<List<InvoiceModel>>(baseUrl, apiUrl).Result;
            var html = "";

            var strBody = new StringBuilder();
            foreach (var item in str)
            {

                strBody.Append("<tr>");
                
                strBody.Append("<td><a href='site / invoices / invoiceDetail.aspx'>" + item.invoiceID + "</a></td>");
                strBody.Append("<td><a href='site / invoices / invoiceDetail.aspx'>" + item.customerName + "</a></td>");
                strBody.Append("<td><a href='site / invoices / invoiceDetail.aspx'>" + item.total + "</a></td>");
                strBody.Append("<td>" + item.deliveryAddress + "</td>");
                strBody.Append("<td>" + item.date + "</td>");
                strBody.Append("<td>" + item.customerPhone + "</td>");
                strBody.Append("<td>" + item.payment + "</td>");
                strBody.Append("<td>" + item.staffName + "</td>");
                strBody.Append("<td>" + item.status + "</td>");
                strBody.Append("</tr>");
            }

            //header
            var header = @"<div class='container-fluid'>
            <!-- Page-Title -->
            <div class='row'>
                <div class='col-sm-12'>
                    <div class='page-title-box'>
                        <div class='float-end'>
                            <ol class='breadcrumb'>
                                <li class='breadcrumb-item'><a href='#'>Pet shop</a></li>

                                <li class='breadcrumb-item active'>Hóa đơn</li>
                            </ol>
                        </div>
                        <h4 class='page-title'>Danh sách hóa đơn</h4>
                    </div>
                    <!--end page-title-box-->
                </div>
                <!--end col-->
            </div>
            <!-- end page title end breadcrumb -->
            <div class='row'>
                <div class='col-12'>
                    <div class='card'>
                        <div class='card-header'>
                            <h4 class='card-title'>Thông tin hóa đơn  </h4>
                        </div>
                        <!--end card-header-->

                        <div class='card-body'>

                            <div class='table-responsive'>
                                <table class='table' id='datatable_1'>
                                    <thead class='thead-light'>
                                        <tr>
                                            <th>Mã hóa đơn</th>
                                            <th>Tên khách hàng</th>
                                            <th>Tổng tiền</th>
                                            <th>Địa chỉ giao hàng</th>
                                            <th data-type='date' data-format='YYYY/DD/MM'>Ngày in</th>
                                            <th>Số điện thoại khách hàng</th>
                                            <th>Hình thức thanh toán</th>
                                            <th>Nhân viên lập hóa đơn</th>
                                            <th>Trạng thái</th>
                                        </tr>
                                    </thead>
                                    <tbody>";
            //footer
            var footer = @"</table>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- end col -->
            </div>
            <!-- end row -->




        </div>
        <!-- container -->
        <!--Start Rightbar-->
        <!--Start Rightbar/offcanvas-->
        <div class='offcanvas offcanvas-end' tabindex='-1' id='Appearance' aria-labelledby='AppearanceLabel'>
            <div class='offcanvas-header border-bottom'>
                <h5 class='m-0 font-14' id='AppearanceLabel'>Appearance</h5>
                <button type='button' class='btn-close text-reset p-0 m-0 align-self-center' data-bs-dismiss='offcanvas' aria-label='Close'></button>
            </div>
            <div class='offcanvas-body'>
                <h6>Account Settings</h6>
                <div class='p-2 text-start mt-3'>
                    <div class='form-check form-switch mb-2'>
                        <input class='form-check-input' type='checkbox' id='settings-switch1'>
                        <label class='form-check-label' for='settings-switch1'>Auto updates</label>
                    </div>
                    <!--end form-switch-->
                    <div class='form-check form-switch mb-2'>
                        <input class='form-check-input' type='checkbox' id='settings-switch2' checked>
                        <label class='form-check-label' for='settings-switch2'>Location Permission</label>
                    </div>
                    <!--end form-switch-->
                    <div class='form-check form-switch'>
                        <input class='form-check-input' type='checkbox' id='settings-switch3'>
                        <label class='form-check-label' for='settings-switch3'>Show offline Contacts</label>
                    </div>
                    <!--end form-switch-->
                </div>
                <!--end /div-->
                <h6>General Settings</h6>
                <div class='p-2 text-start mt-3'>
                    <div class='form-check form-switch mb-2'>
                        <input class='form-check-input' type='checkbox' id='settings-switch4'>
                        <label class='form-check-label' for='settings-switch4'>Show me Online</label>
                    </div>
                    <!--end form-switch-->
                    <div class='form-check form-switch mb-2'>
                        <input class='form-check-input' type='checkbox' id='settings-switch5' checked>
                        <label class='form-check-label' for='settings-switch5'>Status visible to all</label>
                    </div>
                    <!--end form-switch-->
                    <div class='form-check form-switch'>
                        <input class='form-check-input' type='checkbox' id='settings-switch6'>
                        <label class='form-check-label' for='settings-switch6'>Notifications Popup</label>
                    </div>
                    <!--end form-switch-->
                </div>
                <!--end /div-->
            </div>
            <!--end offcanvas-body-->
        </div>
        <!--end Rightbar/offcanvas-->
        <!--end Rightbar-->";


            html = string.Concat(header, strBody.ToString(), footer);
            return html;

        }

    }
}