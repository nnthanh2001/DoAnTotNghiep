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
                        //else
                        //{
                        //    lsProductGuid = new List<string>();
                        //    lsProductGuid = Session["ProductGuid"] as List<string>;
                        //}
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

                        var dataShipping = JsonConvert.DeserializeObject<Shipping>(data);

                        order.shipping = dataShipping;
                        order.productList = lsprod;

                        //Session["Order"] = order;

                        var strPost = Restful.Post(baseUrl, apiUrl, order);

                        //if (strPost != null && strPost != "")
                        {
                            Session["Order"] = strPost;
                            //Response.Redirect(Page.Request.Path);
                            //Response.Redirect(Request.RawUrl, true);
                            //var dicResult = new Dictionary<string, object> {
                            //        {"HttpStatusCode",200 },
                            //        {"href","thanh-toan" }

                            //    };
                            //result = JsonConvert.SerializeObject(dicResult);
                        }
                        
                    }
                    catch (Exception ex)
                    {

                    }


                    break;
                case "put":

                    break;
                case "delete":
                    if (rq == "deleteitem")
                    {
                        try
                        {
                            var lsProductGuid = new List<string>();
                            if (Session["ProductGuid"] != null)
                            {
                                lsProductGuid = Session["ProductGuid"] as List<string>;
                            }

                            var order = JsonConvert.DeserializeObject<OrderModel>(jsOrder);

                            var lsprod = new List<ProductList>();
                            if (lsProductGuid != null && lsProductGuid.Count > 0)
                            {
                                lsProductGuid = lsProductGuid.Where(x => !x.Equals(id)).ToList();
                                foreach (var product in lsProductGuid)
                                {
                                    var prod = new ProductList();
                                    prod._id = product;
                                    lsprod.Add(prod);
                                }

                            }
                            order.productList = lsprod;
                            Session["ProductGuid"] = lsProductGuid;

                            var strPost = Restful.Post(baseUrl, apiUrl, order);
                            if (strPost != null && strPost != "")
                            {
                                Session["Order"] = strPost;
                                if (strPost != null)
                                {

                                    var dicResult = new Dictionary<string, object> {
                            {"HttpStatusCode",200 },
                            {"href","gio-hang" }

                        };
                                    result = JsonConvert.SerializeObject(dicResult);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            throw;
                        }
                    }
                    else
                    {
                        if (rq == "deleteall")
                        {
                            var order = JsonConvert.DeserializeObject<OrderModel>(jsOrder);
                            var lsprod = new List<ProductList>();

                            Session["ProductGuid"] = null;
                            var strPost = Restful.Post(baseUrl, apiUrl, order);
                            if (strPost != null && strPost != "")
                            {
                                Session["Order"] = strPost;
                                if (strPost != null)
                                {

                                    var dicResult = new Dictionary<string, object> {
                            {"HttpStatusCode",200 },
                            {"href","gio-hang" }

                        };
                                    result = JsonConvert.SerializeObject(dicResult);
                                }
                            }



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