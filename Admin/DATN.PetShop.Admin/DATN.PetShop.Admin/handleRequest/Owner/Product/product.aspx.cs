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
            var searchProductApiUrl = Globals.listProductAPI + "?k=" + id;
            switch (type)
            {
                case "get":
                    var strProduct = Restful.Get<List<ProductModel>>(baseUrl, searchProductApiUrl).Result;
                    if (strProduct != null)
                    {
                        foreach (var product in strProduct)
                        {
                            string price = String.Format("{0:0,00₫}", product.price);
                            var strProductList = @" <tr>
                <td>" + product.productID + @"</td>
                <td>
                     <img src='" + product.image + @"' alt='' height='40' class='me-2'>
                     <p class='d-inline-block align-middle mb-0'>
                     <a href='/san-pham/" + product.productHandle + @"-" + product._id + @"' class='d-inline-block align-middle mb-0 product-name'>" + product.productName + @"</a>
                     <br>
                     </p>
                </td>
                <td>" + product.petTypeName + @"</td>
                <td>" + product.categoryName + @"</td>
                <td><div class='line-clamp'>" + product.description + @" </div></td>
                <td>" + product.quantity + @"</td>
                <td>" + price + @"</td>
                <td>" + product.statusName + @"</td>
                <td><a href='/san-pham/" + product.productHandle + @"-" + product._id + @"'><i class='las la-pen text-secondary font-16'></i></a> 
                <a type='button'><i class='las la-trash-alt text-secondary font-16' jsaction='deleteProductButton' value='" + product._id + @"'></i></a></td>
                </tr>";

                            
                        }
                    }
                   

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