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
    public partial class costDetail : System.Web.UI.Page
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

                var costList = DataCostDetail(id);
                main.InnerHtml = costList;
            }
           
        }
        public string DataCostDetail(string id)
        {

            var baseUrl = Globals.baseAPI;
            var apiUrl = Globals.statisticalAPI + "/" + id;

            var strStatistical = Restful.Get<StatisticalModel>(baseUrl, apiUrl).Result;
            var value = new StringBuilder();
            if(strStatistical.costList.Count > 0)
            {
                foreach (var cost in strStatistical.costList)
                {
                    string price = String.Format("{0:0,00₫}", cost.costPrice);
                    var str = @"<tr>
                                            <td>" + cost.costID + @"</a></td>
                                            <td>" + cost.costName + @"</td>
                                            <td>" + price + @"</td>
                                            
                                        </tr>";
                    value.Append(str);
                }
            }    
           

            var html = @"<div class='topbar'>
        <!-- Navbar -->
        <nav class='navbar-custom' id='navbar-custom'>
            <ul class='list-unstyled topbar-nav mb-0'>
                <li>
                    <button class='nav-link button-menu-mobile nav-icon' id='togglemenu'>
                        <i class='ti ti-menu-2'></i>
                    </button>
                </li>
                <li class='hide-phone app-search'>
                    <form role='k' action='' method='get'>
                        <input type='k' name='k' class='form-control top-search mb-0' placeholder='Tìm kiếm...'>
                        <button type='submit'><i class='ti ti-search'></i></button>
                    </form>
                </li>
            </ul>
        </nav>
        <!-- end navbar-->
    </div>



<div class='container-fluid'>
            <div class='row'>
                <div class='col-sm-12'>
                    <div class='page-title-box'>
                        <div class='float-end'>
                           <ol class='breadcrumb'>
                                <li class='breadcrumb-item'><a href='#'>Pet Shop</a>
                                </li>
                                <!--end nav-item-->
                                <li class='breadcrumb-item'><a href='don-hang'>Thống kê doanh thu</a>
                                </li>
                                <!--end nav-item-->
                                <li class='breadcrumb-item active'>Chi tiết chi phí</li>
                            </ol>
                        </div>
                        <h4 class='page-title'>Danh sách chi phí</h4>
                    </div>
                </div>
            </div>
            <div class='row'>
                <div class='col-12'>
                    <div class='card'>
                        <div class='card-header'>
                            <h4 class='card-title'>Thông tin chi phí</h4>
                        </div>
                        <div class='card-body'>
                            <div class='table-responsive'>
                                <table class='table' id='datatable_1'>
                                    <thead class='thead-light'>
                                        <tr>
                                            <th>ID</th>
                                            <th>Tên chi phí</th>
                                            <th>Giá</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        " + value.ToString() + @"
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>";



            return html;
        }


    }
}