using HttpClient_API.Core.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DATN.PetShop.Admin.site.products.services
{
    public partial class addService : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var Route = HttpContext.Current.Request.RequestContext.RouteData;
            if (Route.Route == null) return;
            var request = Route.Values;
            if (!Page.IsPostBack)
            {
                var handle = request["handle"] != null && request["handle"].ToString() != ""
                ? request["handle"].ToString().ToLower().Trim()
                : "";
                var id = request["_id"] != null && request["_id"].ToString() != ""
               ? request["_id"].ToString().ToLower().Trim()
               : "";

                //var getService = GetDataEditService(id);
                //main.InnerHtml = getService;
            }
        }
        public string GetDataEditService(string id)
        {
            var baseUrl = Globals.baseAPI;
            var apiUser = Globals.editServiceAPI + "/" + id;


            var strListStatus = new StringBuilder();

            var html = @"";


            return html;
        }
    }
}