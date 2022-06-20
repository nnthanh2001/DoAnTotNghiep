using Entities.Login;
using Entities.Product;
using HttpClient_API;
using HttpClient_API.Core.Global;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DATN.PetShop.Admin.handleRequest.Product.EditProduct
{
    public partial class EditProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            //   var Route = HttpContext.Current.Request.RequestContext.RouteData;
            //   if (Route.Route == null) return;
            //   var request = Route.Values;
            //   var rq = request["request"] != null && request["request"].ToString() != ""
            //      ? request["request"].ToString().ToLower().Trim()
            //      : "";
            //   var id = request["_id"] != null && request["_id"].ToString() != ""
            //  ? request["_id"].ToString()
            //  : "";
            //   var data = request["data"] != null && request["data"].ToString() != ""
            //? request["data"].ToString()
            //: "";
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
            var apiUrl = Globals.productAPI + "/" + id;
            switch (type)
            {
                case "get":

                    break;
                case "post":

                    break;
                case "put":
                    var editProduct = JsonConvert.DeserializeObject<ProductModel>(data);
                    var str = Restful.Put(baseUrl, apiUrl, editProduct);
                    if (str != null && str != "")
                    {
                        if (str != null)
                        {

                            var dicResult = new Dictionary<string, object> {
                            {"HttpStatusCode",200 },
                        };
                            result = JsonConvert.SerializeObject(dicResult);
                        }
                    }
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