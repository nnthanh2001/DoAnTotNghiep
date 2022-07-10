using Entities.Order;
using Entities.Statistical;
using HttpClient_API;
using HttpClient_API.Core.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DATN.PetShop.Admin.site.dashboard
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var Route = HttpContext.Current.Request.RequestContext.RouteData;
            if (Route.Route == null) return;
            var request = Route.Values;
            if (!Page.IsPostBack)
            {
                var month = Request["m"] != null && Request["m"].ToString() != ""
                ? Request["m"].ToString().ToLower().Trim()
                : "";
                var date = Request["d"] != null && Request["d"].ToString() != ""
               ? Request["d"].ToString().ToLower().Trim()
               : "";
                var pageIndex = Request["p"] != null && Request["p"].ToString() != ""
               ? int.Parse(Request["p"]?.ToString() ?? "0")
               : 0;

                main.InnerHtml = DataDashboard(month);
            }
            
        }
        public string DataDashboard(string m = "")
        {
            var baseUrl = Globals.baseAPI;
            var apiUrl = Globals.statisticalAPI2 + "?month=" + m;
           
            string currentMonth = DateTime.Now.ToString("MM");
            string currentDate = DateTime.Now.ToString("dd/MM/yyyy");

            var strStatistical = Restful.Get<StatisticalPage>(baseUrl, apiUrl).Result;
            

            string totalOfAllBill = String.Format("{0:0,00₫}", strStatistical.totalOfAllBill);
            string totalMoneyToDay = String.Format("{0:0,00₫}", strStatistical.totalMoneyToDay);
            var strStatisticalList = new StringBuilder();
            foreach(var statistical in strStatistical.statisticalList)
            {
                string totalIncome = String.Format("{0:0,00₫}", statistical.totalIncome);
                string totalCost = String.Format("{0:0,00₫}", statistical.totalCost);
                string turnover = String.Format("{0:0,00₫}", statistical.turnover);
                var statisticalList = @" <tbody>
                                        <tr>
                                            <td><a href='don-hang?d=" + statistical.date + @"'>" + statistical.date + @"</td>
                                            <td>" + statistical.nuberOfOrder + @"</td>
                                            <td>" + totalIncome + @"</td>
                                            <td><a href='chi-tiet-chi-phí-" + statistical._id + @"'  class='text-danger'>" + totalCost + @"</td>
                                            <td>" + turnover + @"</td>
                                        </tr>
                                        <!--end tr-->
                                    </tbody>";
                strStatisticalList.Append(statisticalList);
            }

            var monthList = new StringBuilder();
            for(int i =1;i<=12;i++)
            {
                var a = @"<option value='"+i+ @"'>" + i+@"/2022</option>";
               
                monthList.Append(a);
            }

            var html = @"<div class='container-fluid'>
            <!-- Page-Title -->
            <div class='row'>
                <div class='col-sm-12'>
                    <div class='page-title-box'>
                        <div class='float-end'>
                            <ol class='breadcrumb'>
                                <li class='breadcrumb-item'><a href='#'>NTPet</a></li>

                                <li class='breadcrumb-item active'>Thống kê doanh thu</li>
                            </ol>
                        </div>
                        <h4 class='page-title'>Thống kê doanh thu</h4>
                    </div>
                    <!--end page-title-box-->
                </div>
                <!--end col-->
            </div>
            <!-- end page title end breadcrumb -->
            <div class='row'>

                <div class='col-lg-4'>
                    <div class='card'>
                        <div class='card-body'>
                            <div class='row'>
                                <div class='col align-self-center'>
                                    <div class='media'>
                                        <img src='assets/images/logos/money-beg.png' alt='' class='align-self-center' height='40'>
                                        <div class='media-body align-self-center ms-3'>
                                            <h6 class='m-0 font-24 fw-bold'>"+ totalOfAllBill + @"</h6>
                                            <p class='text-muted mb-0'>Tổng doanh thu năm 2022</p>
                                        </div>
                                        <!--end media body-->
                                    </div>
                                    <!--end media-->
                                </div>
                                <!--end col-->
                                <div class='col-auto align-self-center'>
                                    <div class=''>
                                        <div id='Revenu_Status_bar' class='apex-charts mb-n4'></div>
                                    </div>
                                </div>
                                <!--end col-->
                            </div>
                            <!--end row-->
                        </div>
                        <!--end card-body-->
                    </div>
                    <!--end card-->
                    <div class='row'>
                        <div class='col-12 col-lg-6'>
                            <div class='card'>
                                <div class='card-body'>
                                    <div class='row align-items-center'>
                                        <div class='col text-center'>
                                            <span class='h5  fw-bold'>" + totalMoneyToDay + @"</span>
                                            <h6 class='text-uppercase text-muted mt-2 m-0 font-11'>Doanh thu hôm nay(" + currentDate + @")</h6>
                                        </div>
                                        <!--end col-->
                                    </div>
                                    <!-- end row -->
                                </div>
                                <!--end card-body-->
                            </div>
                            <!--end card-body-->
                        </div>
                        <!--end col-->
                        <div class='col-12 col-lg-6'>
                            <div class='card'>
                                <div class='card-body'>
                                    <div class='row align-items-center'>
                                        <div class='col text-center'>
                                            <span class='h5  fw-bold'>" + strStatistical.totalOrder + @"</span>
                                            <h6 class='text-uppercase text-muted mt-2 m-0 font-11'>Đơn hàng hôm nay("+ currentDate + @")</h6>
                                        </div>
                                        <!--end col-->
                                    </div>
                                    <!-- end row -->
                                </div>
                                <!--end card-body-->
                            </div>
                            <!--end card-body-->
                        </div>
                        <!--end col-->
                        
                    </div>
                    <!--end row-->
                    <div class='card'>
                        <div class='card-header'>
                            <div class='row align-items-center'>
                                <div class='col'>
                                    <h4 class='card-title'>Doanh thu tháng</h4>
                                </div>
                                <!--end col-->
                            </div>
                            <!--end row-->
                        </div>
                        <!--end card-header-->
                        <div class='card-body'>
                            <div class='row align-items-center'>
                                <div class='col-auto'>
                                    <i class='las la-file-invoice-dollar font-36 text-muted'></i>
                                </div>
                                <!--end col-->
                                <div class='col'>
                                    <div class='input-group'>
                                        <select class='form-select'>
                                            <option selected type='m' name='m'></option>
                                            " + monthList.ToString() + @"
                                           
                                        </select>
                                        <button class='btn btn-soft-primary btn-sm' type='button'><i class='las la-search'></i></button>
                                    </div>
                                </div>
                                <!--end col-->
                            </div>
                            <!--end row-->
                        </div>
                        <!--end card-body-->
                    </div>
                    <!--end card-->
                </div>
                <!-- end col-->
                <div class='col-lg-8'>
                    <div class='card'>
                        <div class='card-header'>
                            <div class='row align-items-center'>
                                <div class='col'>
                                    <h4 class='card-title'>Tình trạng doanh thu</h4>
                                </div>
                                <!--end col-->
                                <div class='col-auto'>
                                    <div class='dropdown'>
                                        <a href='#' class='btn btn-sm btn-outline-light dropdown-toggle' data-bs-toggle='dropdown' aria-haspopup='true' aria-expanded='false'>Tháng này<i class='las la-angle-down ms-1'></i>
                                        </a>
                                        <div class='dropdown-menu dropdown-menu-end'>
                                            <a class='dropdown-item' href='#'>Hôm nay</a>
                                            <a class='dropdown-item' href='#'>Tuần trước</a>
                                            <a class='dropdown-item' href='#'>Tháng trước</a>
                                            <a class='dropdown-item' href='#'>Năm trước</a>
                                        </div>
                                    </div>
                                </div>
                                <!--end col-->
                            </div>
                            <!--end row-->
                        </div>
                        <!--end card-header-->
                        <div class='card-body'>
                            <div class=''>
                                <div id='Revenu_Status' class='apex-charts'></div>
                            </div>
                        </div>
                        <!--end card-body-->
                    </div>
                    <!--end card-->
                </div>
                <!-- end col-->
            </div>
            <!--end row-->
            <!--end row-->
            <div class='row' style='width: 152%;'>
                <div class='col-lg-8'>
                    <div class='card'>
                        <div class='card-header'>
                            <div class='row align-items-center'>
                                <div class='col'>
                                    <h4 class='card-title'>Danh sách thống kê tháng " + m + @"</h4>
                                </div>
                                <!--end col-->
                            </div>
                            <!--end row-->
                        </div>
                        <!--end card-header-->
                        <div class='card-body'>
                            <div class='table-responsive'>
                                <table class='table mb-0'>
                                    <thead class='thead-light'>
                                        <tr>
                                            <th class='border-top-0'>Ngày</th>
                                            <th class='border-top-0'>Tổng hóa đơn</th>
                                            <th class='border-top-0'>Tổng tiền</th>
                                            <th class='border-top-0'>Chi phí</th>
                                            <th class='border-top-0'>Thu nhập</th>
                                        </tr>
                                        <!--end tr-->
                                    </thead>
                                    " + strStatisticalList.ToString() + @"
                                </table>
                                <!--end table-->
                            </div>
                            <!--end /div-->
                        </div>
                        <!--end card-body-->
                    </div>
                    <!--end card-->
                </div>
                <!--end col-->

            </div>
            <!--end row-->

        </div>";

            return html;
        }
    }
}