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

namespace DATN.PetShop.Admin.handleRequest.Product.Product
{
    public partial class product : System.Web.UI.Page
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
            var apiUrl = Globals.productAPI;
            switch (type)
            {
                case "get":

                    break;
                case "post":
                    var addProduct = JsonConvert.DeserializeObject<ProductBaseModel>(data);
                    var strPost = Restful.Post(baseUrl, apiUrl, addProduct);
                    if (strPost != null && strPost != "")
                    {
                        if (strPost != null)
                        {

                            var dicResult = new Dictionary<string, object> {
                            {"HttpStatusCode",200 },
                            {"href","san-pham"}
                        };
                            result = JsonConvert.SerializeObject(dicResult);
                        }
                    }
                    break;
                case "put":
                    var editProduct = JsonConvert.DeserializeObject<ProductBaseModel>(data);
                    var strPut = Restful.Put(baseUrl, apiUrl + "/" + id, editProduct);
                    if (strPut != null && strPut != "")
                    {
                        if (strPut != null)
                        {
                            var dicResult = new Dictionary<string, object> {
                            {"HttpStatusCode",200 },
                            {"href","san-pham"}
                        };
                            result = JsonConvert.SerializeObject(dicResult);
                        }
                    }
                    break;
                case "delete":
                    var strDelete = Restful.Delete<ProductBaseModel>(baseUrl, apiUrl + "/" + id);
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

            Response.StatusCode = 200;
            Response.Write(result);
            Response.End();
        }
    }
}