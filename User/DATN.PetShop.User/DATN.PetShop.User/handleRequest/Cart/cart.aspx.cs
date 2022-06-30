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
    '_id' :  '62ba6559e7af45147fe9b74e' , 
    'payment' : 'Thanh toán online', 
    'shipping' : {
        'userName' : 'Nguyễn Như Thành', 
        'phone' :   769899125 , 
        'email' : 'nguyentrungnghia1999@gmail.com', 
        'addressDelivery' : 'B601 Chung cư Hoàng Quân, Trần Quang Diệu, Vĩnh Hải, Thành phố Nha Trang, Khánh Hòa', 
        'userId' : '62849a20c42f05a9c62bbd89'
    }, 
    'status' : 'Đã nhận hàng', 
    'subTotal' :   0 , 
    'productList' : [
        
    ]
}
";
            
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
            
            if(lsProductGuid!=null && lsProductGuid.Count > 0)
            {
                foreach (var product in lsProductGuid)
                {
                    var prod = new ProductList();
                    prod._id = product;
                    lsprod.Add(prod);
                }
            }
            order.productList = lsprod;
            

            switch (type)
            {
                case "get":

                    break;
                case "post":

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

                    break;
                case "put":
                    
                    break;
                case "delete":
                    var strDelete = Restful.Delete<OrderModel>(baseUrl, apiUrl);
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

            //Response.StatusCode = 200;
            //Response.Write(result);
            //Response.End();
        }
    }
}