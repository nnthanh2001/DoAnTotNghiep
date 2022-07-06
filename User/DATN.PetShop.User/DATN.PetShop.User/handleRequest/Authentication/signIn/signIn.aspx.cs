using Entities.login;
using Entities.Request;
using Entities.User;
using HttpClient_API;
using HttpClient_API.Core.Global;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DATN.PetShop.User.handleRequest.Authentication.signIn
{
    public partial class signIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var baseUrl = Globals.baseAPI;
            var apiLoginUrl = Globals.loginAPI;
            var apiRegisterUrl = Globals.userAPI;
            var response = new RequestModel<UserModel> { HttpStatusCode = 400 };


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
            var result = "";
            var request = new RequestModel<LoginModel>();
            switch (type)
            {
                case "get":
                    Session["login"] = null;

                    var dicResult = new Dictionary<string, object> {
                            {"HttpStatusCode",200 },
                            {"href","trang-chu"} ,
                                    };
                    result = JsonConvert.SerializeObject(dicResult);
                    break;
                case "post":
                    if (rq == "signin")
                    {
                        if (data != "false" && data != "")
                        {
                            var dataLogin = JsonConvert.DeserializeObject<LoginModel>(data);
                            var str = Restful.Post(baseUrl, apiLoginUrl, dataLogin);

                            if (str != null && str != "")
                            {
                                var transfer = JsonConvert.DeserializeObject<RequestModel<LoginModel>>(str);
                                request = transfer;
                                if (transfer != null)
                                {
                                    if (request.HttpStatusCode == 200)
                                    {
                                        Session["login"] = str;

                                         dicResult = new Dictionary<string, object> {
                            {"HttpStatusCode",200 },
                            {"href","gio-hang"} ,
                            {"message","Đăng nhập thành công!"}
                                    };
                                        result = JsonConvert.SerializeObject(dicResult);
                                    }
                                    else
                                    {
                                        request.HttpStatusCode = 200;
                                        result = JsonConvert.SerializeObject(request);
                                    }
                                }
                            }
                        }


                    }
                    else
                    {
                        if (data != "false")
                        {
                            var register = JsonConvert.DeserializeObject<UserModel>(data);
                            var strRegister = Restful.Post(baseUrl, apiRegisterUrl, register);
                            if (strRegister != null && strRegister != "")
                            {

                                Session["register"] = strRegister;
                                 dicResult = new Dictionary<string, object> {
                                    {"HttpStatusCode",200 },
                                    {"href","dang-nhap"},
                                    { "message","Đăng ký thành công!, Mời bạn qua phần đăng nhập để vào tài khoản của mình"}
                                };
                                result = JsonConvert.SerializeObject(dicResult);


                            }
                        }
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