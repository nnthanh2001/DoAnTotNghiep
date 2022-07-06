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

namespace DATN.PetShop.User.handleRequest.Product
{
    public partial class ProductFilter : System.Web.UI.Page
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
            var apiUrl = Globals.productPageAPI + "?id=" + id;

            

            switch (type)
            {
                case "get":
                    
                    var product = Restful.Get<ProductPage>(baseUrl, apiUrl).Result;
                    if (product != null)
                    {
                        var dicResult = new Dictionary<string, object> {
                            {"HttpStatusCode",200 },
                            {"href","san-pham"},
                            {"_id",id }
                        };
                        result = JsonConvert.SerializeObject(dicResult);
                    }
                    break;
                case "post":

                    break;
                case "put":

                    break;
                case "delete":
                    var strDelete = Restful.Delete<ProductPage>(baseUrl, apiUrl + "/" + id);
                    if (strDelete != null && strDelete != "")
                    {
                        if (strDelete != null)
                        {

                            var dicResult = new Dictionary<string, object> {
                            {"HttpStatusCode",200 },
                            {"href","san-pham"}
                        };
                            result = JsonConvert.SerializeObject(dicResult);
                        }
                    }
                    break;
            }


        }
    }

}