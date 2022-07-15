using DATN.PetShop.User.Models;
using Entities.Order;
using HttpClient_API;
using HttpClient_API.Core.Global;
using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
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
                        if(dataShipping.paymentType ==1 )
                        {
                            order.payment = "Thanh toán sau khi nhận hàng";
                        }
                        else
                        {
                            order.payment = "Thanh toán trực tuyến";
                        }
                        Session["Order"] = order;

                        var strPost = Restful.Post(baseUrl, apiUrl, order);

                        switch (dataShipping.paymentType)
                        {
                            case 1:
                                if (strPost != null && strPost != "")
                                {
                                    
                                    Session["Order"] = strPost;
                                    var dicResult = new Dictionary<string, object> {
                                    {"HttpStatusCode",200 },
                                    {"href","thanh-toan" },
                                };
                                    result = JsonConvert.SerializeObject(dicResult);
                                }

                                break;
                            case 2:

                                var dataOrder = JsonConvert.DeserializeObject<OrderModel>(strPost);
                                
                                //Get Config Info
                                string vnp_Returnurl = ConfigurationManager.AppSettings["vnp_Returnurl"]; //URL nhan ket qua tra ve 
                                string vnp_Url = ConfigurationManager.AppSettings["vnp_Url"]; //URL thanh toan cua VNPAY 
                                string vnp_TmnCode = ConfigurationManager.AppSettings["vnp_TmnCode"]; //Ma website
                                string vnp_HashSecret = ConfigurationManager.AppSettings["vnp_HashSecret"]; //Chuoi bi mat

                                //Get payment input
                                OrderInfo orderInfo = new OrderInfo();
                                //Save order to db
                                orderInfo.OrderId = dataOrder.orderID; // Giả lập mã giao dịch hệ thống merchant gửi sang VNPAY
                                orderInfo.Amount = dataOrder.subTotal; // Giả lập số tiền thanh toán hệ thống merchant gửi sang VNPAY 100,000 VND
                                orderInfo.Status = "Đang chờ thanh toán"; //0: Trạng thái thanh toán "chờ thanh toán" hoặc "Pending"
                                orderInfo.OrderDesc = "";
                                orderInfo.CreatedDate = DateTime.Now;
                                string locale = "vn";
                                //Build URL for VNPAY
                                VnPayLibrary vnpay = new VnPayLibrary();

                                vnpay.AddRequestData("vnp_Version", VnPayLibrary.VERSION);
                                vnpay.AddRequestData("vnp_Command", "pay");
                                vnpay.AddRequestData("vnp_TmnCode", vnp_TmnCode);
                                vnpay.AddRequestData("vnp_Amount", (orderInfo.Amount * 100).ToString()); //Số tiền thanh toán. Số tiền không mang các ký tự phân tách thập phân, phần nghìn, ký tự tiền tệ. Để gửi số tiền thanh toán là 100,000 VND (một trăm nghìn VNĐ) thì merchant cần nhân thêm 100 lần (khử phần thập phân), sau đó gửi sang VNPAY là: 10000000
                                //if (cboBankCode.SelectedItem != null && !string.IsNullOrEmpty(cboBankCode.SelectedItem.Value))
                                //{
                                    vnpay.AddRequestData("vnp_BankCode", "VNBANK");
                                //}
                                vnpay.AddRequestData("vnp_CreateDate", orderInfo.CreatedDate.ToString("yyyyMMddHHmmss"));
                                vnpay.AddRequestData("vnp_CurrCode", "VND");
                                vnpay.AddRequestData("vnp_IpAddr", Utils.GetIpAddress());
                                if (!string.IsNullOrEmpty(locale))
                                {
                                    vnpay.AddRequestData("vnp_Locale", locale);
                                }
                                else
                                {
                                    vnpay.AddRequestData("vnp_Locale", "vn");
                                }
                                vnpay.AddRequestData("vnp_OrderInfo", "Thanh toan don hang:" + orderInfo.OrderId);
                                vnpay.AddRequestData("vnp_OrderType", "topup"); //default value: other
                                vnpay.AddRequestData("vnp_ReturnUrl", vnp_Returnurl);
                                vnpay.AddRequestData("vnp_TxnRef", orderInfo.OrderId.ToString()); // Mã tham chiếu của giao dịch tại hệ thống của merchant. Mã này là duy nhất dùng để phân biệt các đơn hàng gửi sang VNPAY. Không được trùng lặp trong ngày

                                ////Add Params of 2.1.0 Version
                                //vnpay.AddRequestData("vnp_ExpireDate", txtExpire.Text);
                                ////Billing
                                //vnpay.AddRequestData("vnp_Bill_Mobile", txt_billing_mobile.Text.Trim());
                                //vnpay.AddRequestData("vnp_Bill_Email", txt_billing_email.Text.Trim());
                                //var fullName = txt_billing_fullname.Text.Trim();
                                //if (!String.IsNullOrEmpty(fullName))
                                //{
                                //    var indexof = fullName.IndexOf(' ');
                                //    vnpay.AddRequestData("vnp_Bill_FirstName", fullName.Substring(0, indexof));
                                //    vnpay.AddRequestData("vnp_Bill_LastName", fullName.Substring(indexof + 1, fullName.Length - indexof - 1));
                                //}
                                //vnpay.AddRequestData("vnp_Bill_Address", txt_inv_addr1.Text.Trim());
                                //vnpay.AddRequestData("vnp_Bill_City", txt_bill_city.Text.Trim());
                                //vnpay.AddRequestData("vnp_Bill_Country", txt_bill_country.Text.Trim());
                                //vnpay.AddRequestData("vnp_Bill_State", "");

                                //// Invoice

                                //vnpay.AddRequestData("vnp_Inv_Phone", txt_inv_mobile.Text.Trim());
                                //vnpay.AddRequestData("vnp_Inv_Email", txt_inv_email.Text.Trim());
                                //vnpay.AddRequestData("vnp_Inv_Customer", txt_inv_customer.Text.Trim());
                                //vnpay.AddRequestData("vnp_Inv_Address", txt_inv_addr1.Text.Trim());
                                //vnpay.AddRequestData("vnp_Inv_Company", txt_inv_company.Text);
                                //vnpay.AddRequestData("vnp_Inv_Taxcode", txt_inv_taxcode.Text);
                                //vnpay.AddRequestData("vnp_Inv_Type", cbo_inv_type.SelectedItem.Value);

                                string paymentUrl = vnpay.CreateRequestUrl(vnp_Url, vnp_HashSecret);
                                //log.InfoFormat("VNPAY URL: {0}", paymentUrl);
                                //Response.Redirect(paymentUrl);

                                if (strPost != null && strPost != "")
                                {
                                    Session["Order"] = strPost;
                                    var dicResult = new Dictionary<string, object> {
                                    {"HttpStatusCode",200 },
                                    {"href",paymentUrl },
                                };
                                    result = JsonConvert.SerializeObject(dicResult);
                                }
                                break;

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