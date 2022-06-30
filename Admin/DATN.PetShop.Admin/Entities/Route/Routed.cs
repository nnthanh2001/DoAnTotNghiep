using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Routing;

namespace Entities.Route
{
    public class Routed
    {
        public static async void Register(RouteCollection routes)
        {
            routes.RouteExistingFiles = true;
            routes.MapPageRoute("dashboard", "thong-ke-doanh-thu", "~/site/dashboard/dashboard.aspx", false);

            routes.MapPageRoute("invoices", "hoa-don", "~/site/invoices/invoice.aspx", false);

            routes.MapPageRoute("login", "dang-nhap", "~/site/login/login.aspx", false);

            routes.MapPageRoute("product", "san-pham", "~/site/product/product.aspx", false);
            routes.MapPageRoute("editProduct", "san-pham/{handle}-{_id}", "~/site/product/editProduct.aspx", false);
            routes.MapPageRoute("addProduct", "them-moi-san-pham", "~/site/product/addProduct.aspx", false);

            routes.MapPageRoute("customer", "khach-hang", "~/site/user/listCustomer.aspx", false);
            routes.MapPageRoute("user", "nhan-vien", "~/site/user/listUser.aspx", false);
            routes.MapPageRoute("editUser", "nhan-vien/{handle}-{_id}", "~/site/user/editUser.aspx", false);
            routes.MapPageRoute("addUser", "them-moi-nhan-vien", "~/site/user/addUser.aspx", false);

            routes.MapPageRoute("service", "dich-vu", "~/site/service/service.aspx", false);
            routes.MapPageRoute("editService", "dich-vu/{handle}-{_id}", "~/site/service/editService.aspx", false);
        

            



            routes.MapPageRoute("home language", "{language}", "~/site/home/home.aspx", false);
        }
    }
}
