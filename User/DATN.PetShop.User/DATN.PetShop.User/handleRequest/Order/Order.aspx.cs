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

namespace DATN.PetShop.User.handleRequest.Order
{
    public partial class Order : System.Web.UI.Page
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
            var apiUrl = Globals.createOrderAPI;

            
            switch (type)
            {
                case "get":

                    break;
                case "post":

                    if (Session["Order"] != null)
                    {
                        var strorder = Session["Order"].ToString();

                        var order = JsonConvert.DeserializeObject<OrderModel>(strorder);
                        
                        var strPost = Restful.Post(baseUrl, apiUrl, order);
                        if (strPost != null && strPost != "")
                        {
                            if (strPost != null)
                            {

                                var dicResult = new Dictionary<string, object> {
                            {"HttpStatusCode",200 },
                            {"href","thanh-toan" }
                        };
                                result = JsonConvert.SerializeObject(dicResult);
                                Session["Order"] = null;
                            }
                        }
                    }
                    else
                    {
                        var dicResult = new Dictionary<string, object> {
                            {"HttpStatusCode",400 },
                            {"message",""}
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