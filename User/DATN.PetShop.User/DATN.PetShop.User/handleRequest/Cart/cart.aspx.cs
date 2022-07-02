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

namespace DATN.PetShop.User.handleRequest.Cart
{
    public partial class cart : System.Web.UI.Page
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
            var apiUrl = Globals.addOrderAPI;

            var jsOrder = @"{ 
    '_id' :  '' , 
    'payment' : '', 
    'shipping' : {
        
    }, 
    'status' : '', 
    'subTotal' :   0 , 
    'productList' : [
        
    ]
}
";
            

            switch (type)
            {
                case "get":

                    break;
                case "post":
                    try
                    {
                        var lsProductGuid = new List<string>();
                        if (Session["ProductGuid"] != null)
                        {
                            lsProductGuid = Session["ProductGuid"] as List<string>;
                        }
                        else
                        {

                        }
                        lsProductGuid.Add(id);

                        Session["ProductGuid"] = lsProductGuid;


                        var order = JsonConvert.DeserializeObject<OrderModel>(jsOrder);

                        var lsprod = new List<ProductList>();

                        if (lsProductGuid != null && lsProductGuid.Count > 0)
                        {
                            foreach (var product in lsProductGuid)
                            {
                                var prod = new ProductList();
                                prod._id = product;
                                lsprod.Add(prod);
                            }
                        }
                        order.productList = lsprod;
                        var strPost = Restful.Post(baseUrl, apiUrl, order);
                        if (strPost != null && strPost != "")
                        {
                            Session["Order"] = strPost;
                            if (strPost != null)
                            {

                                var dicResult = new Dictionary<string, object> {
                            {"HttpStatusCode",200 },

                        };
                                result = JsonConvert.SerializeObject(dicResult);
                            }
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                    
                   
                    break;
                case "put":
                    
                    break;
                case "delete":
                    try
                    {
                        var lsProductGuid = new List<string>();
                        if (Session["ProductGuid"] != null)
                        {
                            lsProductGuid = Session["ProductGuid"] as List<string>;
                        }
                        else
                        {

                        }
                        lsProductGuid.Add(id);

                        Session["ProductGuid"] = lsProductGuid;


                        var order = JsonConvert.DeserializeObject<OrderModel>(jsOrder);

                        var lsprod = new List<ProductList>();

                        if (lsProductGuid != null && lsProductGuid.Count > 0)
                        {
                            var product = lsProductGuid.Where(x => !x.Equals(id)).ToList();

                        }
                        order.productList = lsprod;
                        var strPost = Restful.Post(baseUrl, apiUrl, order);
                        if (strPost != null && strPost != "")
                        {
                            Session["Order"] = strPost;
                            if (strPost != null)
                            {

                                var dicResult = new Dictionary<string, object> {
                            {"HttpStatusCode",200 },

                        };
                                result = JsonConvert.SerializeObject(dicResult);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                    
                    break;
            }

            Response.StatusCode = 200;
            Response.Write(result);
            Response.End();
        }
    }
}