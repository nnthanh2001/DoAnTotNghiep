using DATN.PetShop.User.Models;
using Entities.Order;
using Entities.Request;
using Entities.User;
using HttpClient_API;
using HttpClient_API.Core.Global;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DATN.PetShop.User.site.Payment
{
    public partial class paymentReturn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)

        {
            var baseUrl = Globals.baseAPI;
            var apiUrl = Globals.createOrderAPI;

            string returnContent = string.Empty;
            if (Request.QueryString.Count > 0)
            {
                string vnp_HashSecret = ConfigurationManager.AppSettings["vnp_HashSecret"]; //Secret key
                var vnpayData = Request.QueryString;
                VnPayLibrary vnpay = new VnPayLibrary();
                foreach (string s in vnpayData)
                {
                    //get all querystring data
                    if (!string.IsNullOrEmpty(s) && s.StartsWith("vnp_"))
                    {
                        vnpay.AddResponseData(s, vnpayData[s]);
                    }
                }
                //Lay danh sach tham so tra ve tu VNPAY
                //vnp_TxnRef: Ma don hang merchant gui VNPAY tai command=pay    
                //vnp_TransactionNo: Ma GD tai he thong VNPAY
                //vnp_ResponseCode:Response code from VNPAY: 00: Thanh cong, Khac 00: Xem tai lieu
                //vnp_SecureHash: HmacSHA512 cua du lieu tra ve

                var strorder = Session["Order"].ToString();
                var dataOrder = JsonConvert.DeserializeObject<OrderModel>(strorder);

                var strCustomer = Session["login"].ToString();
                var request = JsonConvert.DeserializeObject<RequestModel<UserModel>>(strCustomer);

                



                long orderId = Convert.ToInt64(vnpay.GetResponseData("vnp_TxnRef"));
                long vnp_Amount = Convert.ToInt64(vnpay.GetResponseData("vnp_Amount")) / 100;
                long vnpayTranId = Convert.ToInt64(vnpay.GetResponseData("vnp_TransactionNo"));
                string vnp_ResponseCode = vnpay.GetResponseData("vnp_ResponseCode");
                string vnp_TransactionStatus = vnpay.GetResponseData("vnp_TransactionStatus");
                String vnp_SecureHash = Request.QueryString["vnp_SecureHash"];
                bool checkSignature = vnpay.ValidateSignature(vnp_SecureHash, vnp_HashSecret);
                if (checkSignature)
                {
                    //Cap nhat ket qua GD
                    //Yeu cau: Truy van vao CSDL cua  Merchant => lay ra duoc OrderInfo
                    //Giả sử OrderInfo lấy ra được như giả lập bên dưới
                    OrderInfo order = new OrderInfo();//get from DB
                    order.OrderId = dataOrder.orderID;
                    order.Amount = dataOrder.subTotal;
                    order.PaymentTranId = vnpayTranId;
                    order.Status = "0"; //0: Cho thanh toan,1: da thanh toan,2: GD loi
                    //Kiem tra tinh trang Order
                    if (order != null)
                    {
                        if (order.Amount == vnp_Amount)
                        {
                            if (order.Status == "0")
                            {
                                if (vnp_ResponseCode == "00" && vnp_TransactionStatus == "00")
                                {
                                    //Thanh toan thanh cong
                                    //log.InfoFormat("Thanh toan thanh cong, OrderId={0}, VNPAY TranId={1}", orderId,
                                    //    vnpayTranId);

                                    order.Status = "1";
                                    //var strPost = Restful.Post(baseUrl, apiUrl, dataOrder);
                                    //if (strPost != null && strPost != "")
                                    //{
                                    //    if (strPost != null)
                                    //    {

                                    //        Session["Order"] = null;
                                    //        Session["ProductGuid"] = null;

                                    //    }
                                    //}
                                    Response.Redirect("https://localhost:44382/thanh-toan");
                                }
                                else
                                {
                                    //Thanh toan khong thanh cong. Ma loi: vnp_ResponseCode
                                    //  displayMsg.InnerText = "Có lỗi xảy ra trong quá trình xử lý.Mã lỗi: " + vnp_ResponseCode;
                                    //log.InfoFormat("Thanh toan loi, OrderId={0}, VNPAY TranId={1},ResponseCode={2}",
                                    //    orderId,
                                    //    vnpayTranId, vnp_ResponseCode);
                                    var dicResult = new Dictionary<string, object> {
                            {"HttpStatusCode",400 },
                            {"message","Có lỗi xảy ra trong quá trình xử lý"}
                        };
                                    returnContent = JsonConvert.SerializeObject(dicResult);
                                    dataOrder.status = "Đang xác nhận";
                                    order.Status = "2";
                                }

                                //Thêm code Thực hiện cập nhật vào Database 
                                //Update Database

                                returnContent = "{\"RspCode\":\"00\",\"Message\":\"Confirm Success\"}";
                            }
                            else
                            {
                                returnContent = "{\"RspCode\":\"02\",\"Message\":\"Order already confirmed\"}";
                            }
                        }
                        else
                        {
                            returnContent = "{\"RspCode\":\"04\",\"Message\":\"invalid amount\"}";
                        }
                    }
                    else
                    {
                        returnContent = "{\"RspCode\":\"01\",\"Message\":\"Order not found\"}";
                    }
                }
                else
                {
                    //log.InfoFormat("Invalid signature, InputData={0}", Request.RawUrl);
                    returnContent = "{\"RspCode\":\"97\",\"Message\":\"Invalid signature\"}";
                }
            }
            else
            {
                returnContent = "{\"RspCode\":\"99\",\"Message\":\"Input data required\"}";
            }


            Response.ClearContent();
            Response.Write(returnContent);
            Response.End();
        }
    }
}