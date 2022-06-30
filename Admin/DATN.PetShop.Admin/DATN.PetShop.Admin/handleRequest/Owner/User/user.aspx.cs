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

namespace DATN.PetShop.Admin.handleRequest.Owner.User
{
    public partial class user : System.Web.UI.Page
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
            var apiUrl = Globals.userAPI;
            switch (type)
            {
                case "get":

                    break;
                case "post":

                    if (data != null)
                    {
                        var addUser = JsonConvert.DeserializeObject<UserBaseModel>(data);
                        var str = Restful.Post(baseUrl, apiUrl, addUser);
                        if (str != null && str != "")
                        {
                            if (str != null)
                            {

                                var dicResult = new Dictionary<string, object> {
                            {"HttpStatusCode",200 },
                            {"href","nhan-vien"}
                        };
                                result = JsonConvert.SerializeObject(dicResult);
                            }
                        }
                    }

                    break;
                case "put":
                    var editUser = JsonConvert.DeserializeObject<UserBaseModel>(data);
                    var strPut = Restful.Put(baseUrl, apiUrl + "/" + id, editUser);
                    if (strPut != null && strPut != "")
                    {
                        if (strPut != null)
                        {
                            var dicResult = new Dictionary<string, object> {
                            {"HttpStatusCode",200 },
                            {"href","nhan-vien"}
                        };
                            result = JsonConvert.SerializeObject(dicResult);
                        }
                    }
                    break;
                case "delete":
                    var strDelete = Restful.Delete<UserBaseModel>(baseUrl, apiUrl + "/" + id);
                    if (strDelete != null && strDelete != "")
                    {
                        if (strDelete != null)
                        {

                            var dicResult = new Dictionary<string, object> {
                            {"HttpStatusCode",200 },
                            {"href","nhan-vien"}
                        };
                            result = JsonConvert.SerializeObject(dicResult);
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