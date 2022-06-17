using HttpClient_API.Core.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DATN.PetShop.User.handleRequest.ProductDetail
{
    public partial class ProductDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var baseUrl = Globals.baseAPI;
            var apiProductDetail = Globals.getOneProductAPI;

           

        }
    }
}