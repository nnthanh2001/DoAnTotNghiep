using Entities.Login;
using Entities.MessageBox;
using Entities.Request;
using HttpClient_API;
using HttpClient_API.Core.Global;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ServiceModel.Channels;
using System.Web;

namespace DATN.PetShop.Admin.handleRequest.Authentication.signIn
{
    public partial class signIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var baseUrl = Globals.baseAPI;
            var apiUrl = Globals.loginAPI;

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

            var request = new RequestModel<LoginModel>();
            
            switch (type)
            {
                case "get":

                    break;
                case "post":
                    if (data != "false" && data != "")
                    {
                        var dataLogin = JsonConvert.DeserializeObject<LoginModel>(data);
                        var str = Restful.Post(baseUrl, apiUrl, dataLogin);
                        
                        if (str != null && str != "")
                        {
                            var transfer = JsonConvert.DeserializeObject<RequestModel<LoginModel>>(str);
                            request = transfer;
                            if (transfer != null)
                            {
                                if(request.HttpStatusCode == 200)
                                {
                                    Session["login"] = str;

                                    var dicResult = new Dictionary<string, object> {
                            {"HttpStatusCode",200 },
                            {"href","san-pham"} ,
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
                    else
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