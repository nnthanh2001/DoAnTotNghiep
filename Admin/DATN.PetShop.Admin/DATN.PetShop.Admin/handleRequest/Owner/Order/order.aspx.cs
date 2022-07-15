using Entities.Order;
using HttpClient_API;
using HttpClient_API.Core.Global;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DATN.PetShop.Admin.handleRequest.Owner.Order
{
    public partial class order : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var result = "";
            var type = Request["type"] != null && Request["type"].ToString() != ""
                 ? Request["type"].ToString().ToLower().Trim()
                 : "";
            var rq = Request["request"] != null && Request["request"].ToString() != ""
               ? Request["request"].ToString().ToLower().Trim()
               : "";
            var id = Request["_id"] != null && Request["_id"].ToString() != ""
           ? Request["_id"].ToString()
           : "";
            var data = Request["data"] != null && Request["data"].ToString() != ""
         ? Request["data"].ToString()
         : "";
            var baseUrl = Globals.baseAPI;
            var apiUrl = Globals.orderDetailAPI;
            var updateStatusOrderApi = Globals.updateOrderAPI ;
            switch (type)
            {
                case "get":
                    var orderDetail = Restful.Get<OrderModel>(baseUrl, apiUrl + "/" + id).Result;
                    if (orderDetail != null)
                    {
                       
                            var dicResult = new Dictionary<string, object> {
                            {"HttpStatusCode",200 },
                            {"href","chi-tiet-don-hang/{_id}"}
                        };
                            result = JsonConvert.SerializeObject(dicResult);
                        
                    }
                    break;
                case "post":
                    
                    var updateStatus = Restful.Get<Object>(baseUrl, updateStatusOrderApi + "?_id=" + id).Result;
                    if (updateStatus != null)
                    {

                        var dicResult = new Dictionary<string, object> {
                            {"HttpStatusCode",200 },
                            {"href","don-hang"}
                        };
                        result = JsonConvert.SerializeObject(dicResult);

                    }
                    break;
                    
                case "put":

                    break;
                case "delete":
                   
                   
                    break;
            }
                
            Response.StatusCode = 200;
            Response.Write(result);
            Response.End();
        }
    }
}