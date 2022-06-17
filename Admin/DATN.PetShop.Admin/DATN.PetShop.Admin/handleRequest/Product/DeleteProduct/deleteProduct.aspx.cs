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

namespace DATN.PetShop.Admin.handleRequest.Product.DeleteProduct
{
    public partial class DeleteProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var baseUrl = Globals.baseAPI;
            var apiUrl = Globals.productAPI;
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
           
            switch (type)
            {
                case "get":
                   
                    break;
                case "post":
                    
                    break;
                case "put":

                    break;
                case "delete":
                    var str = Restful.Delete<ProductModel>(baseUrl, apiUrl);
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
            }

            Response.StatusCode = 200;
            Response.Write(result);
            Response.End();

        }
    }
}