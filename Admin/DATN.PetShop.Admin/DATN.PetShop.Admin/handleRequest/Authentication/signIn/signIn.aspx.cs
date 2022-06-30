using Entities.Login;
using HttpClient_API;
using HttpClient_API.Core.Global;
using Newtonsoft.Json;
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
            switch (type)
            {
                case "get":

                    break;
                case "post":
                    var login = JsonConvert.DeserializeObject<LoginModel>(data);
                    var str = Restful.Post(baseUrl, apiUrl, login);
                    if (str != null && str != "")
                    {
                        if (str != null)
                        {
                            Session["login"] = str;
                            var dicResult = new Dictionary<string, object> {
                            {"HttpStatusCode",200 },
                            {"href","san-pham"}
                        };
                            result = JsonConvert.SerializeObject(dicResult);

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