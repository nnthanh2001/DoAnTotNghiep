using Entities.login;
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
            var apiUrl = Globals.loginAPI;




            //   var Route = HttpContext.Current.Request.RequestContext.RouteData;
            //   if (Route.Route == null) return;
            //   var request = Route.Values;
            //   var rq = request["request"] != null && request["request"].ToString() != ""
            //      ? request["request"].ToString().ToLower().Trim()
            //      : "";
            //   var id = request["_id"] != null && request["_id"].ToString() != ""
            //  ? request["_id"].ToString()
            //  : "";
            //   var data = request["data"] != null && request["data"].ToString() != ""
            //? request["data"].ToString()
            //: "";
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
                            {"href","site/home/home.aspx"}
                        };
                            result = JsonConvert.SerializeObject(dicResult);
                            //Response.Redirect("~/site/product/product.aspx");   
                            //Response.End();
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

            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Inserted Successfully')", true);
            //Response.Write("<script>alert('Đăng nhập sai')</script>");
            Response.End();
        }
    }
}