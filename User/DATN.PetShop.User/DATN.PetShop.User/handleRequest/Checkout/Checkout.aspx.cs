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

namespace DATN.PetShop.User.handleRequest.Checkout
{
    public partial class Checkout : System.Web.UI.Page
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


            var a = @"<ul>
                                        <li class='single - shopping - cart'>
                                               < div class='row'>
                                            <div class='shopping-cart-img'>
                                                <a href = '/chi-tiet-san-pham/thuc-an-cho-me-o-gold-6299776bacfa1169c32c9255-0' >
                                                    < img alt='' src='https://www.petmart.vn/wp-content/uploads/2019/04/pate-cho-cho-vi-thit-bo-iris-one-care-beef100g.jpg'></a>
                                            </div>
                                            <div class='shopping-cart-title' style='width: 300px;'>
                                                <h4><a href = '/chi-tiet-san-pham/thuc-an-cho-me-o-gold-6299776bacfa1169c32c9255-0' > Pate cho chó vị thịt bò IRIS One Care Beef</a></h4>
                                                <h6>Số lượng: 1</h6>
                                                <span>176,000₫</span>
                                            </div>
                                           </div>
                                        </li>
                                    </ul>";


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

                        Session["Order"] = order;

                        var strPost = Restful.Post(baseUrl, apiUrl, order);

                        if (strPost != null && strPost != "")
                        {
                            Session["Order"] = strPost;
                            var dicResult = new Dictionary<string, object> {
                                    {"HttpStatusCode",200 },
                                    //{"href","thanh-toan" },
                                    {"href","http://localhost:16262/" },


                                };


                            result = JsonConvert.SerializeObject(dicResult);
                        }

                    }
                    catch (Exception ex)
                    {

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