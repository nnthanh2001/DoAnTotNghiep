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
            switch (type)
            {
                case "get":

                    break;
                case "post":
                    if (rq == "signin")
                    {
                        if (data != "false")
                        {

                            var login = JsonConvert.DeserializeObject<LoginModel>(data);
                            var strLogin = Restful.Post(baseUrl, apiLoginUrl, login);
                            var user = JsonConvert.DeserializeObject<RequestModel<UserModel>>(strLogin);
                            if(user.HttpStatusCode == 200)
                            {
                                Session["login"] = strLogin;
                                var dicResult = new Dictionary<string, object> {
                            {"HttpStatusCode",200 },
                            {"href","tai-khoan/{_id}"}
                        };
                                result = JsonConvert.SerializeObject(dicResult);
                            }
                           
                            else
                            {
                                var dicResult = new Dictionary<string, object> {
                            {"HttpStatusCode",400 },
                            {"message","Tài khoản không tồn tại vui lòng nhập lại!"}
                        };
                                result = JsonConvert.SerializeObject(dicResult);
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
                                if (strRegister != null)
                                {
                                    Session["register"] = strRegister;
                                    var dicResult = new Dictionary<string, object> {
                            {"HttpStatusCode",200 },
                            {"href","dang-nhap"}
                        };
                                    result = JsonConvert.SerializeObject(dicResult);

                                }
                            }
                            else
                            {

                            }
                        }
                    }


                    break;
                case "put":

                    break;
                case "delete":

                    break;
            }


            Response.StatusCode = response.HttpStatusCode;
            Response.Write(result);
            Response.End();
        }
    }
}