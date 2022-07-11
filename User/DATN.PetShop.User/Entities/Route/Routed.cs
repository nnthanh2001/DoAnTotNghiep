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
            routes.MapPageRoute("home", "trang-chu", "~/site/home/home.aspx", false);
            routes.MapPageRoute("product", "san-pham", "~/site/products/productPage.aspx", false);
            routes.MapPageRoute("productFilter", "san-pham/{handle}-{_id}", "~/site/products/productPage.aspx", false);
            routes.MapPageRoute("allProduct", "san-pham/", "~/site/products/productPage.aspx", false);
            routes.MapPageRoute("productDetail", "chi-tiet-san-pham/{handle}-{_id}-{categoryID}", "~/site/products/productDetail.aspx", false);
            routes.MapPageRoute("contact", "lien-he", "~/site/contact/contactUs.aspx", false);
            routes.MapPageRoute("aboutus", "thong-tin", "~/site/aboutUs/aboutUs.aspx", false);
            routes.MapPageRoute("service", "dich-vu", "~/site/service/service.aspx", false);
            routes.MapPageRoute("tips", "huong-dan-cham-soc", "~/site/blog/blog_master.aspx", false);
            routes.MapPageRoute("checkout", "thanh-toan", "~/site/checkout/checkout.aspx", false);
            routes.MapPageRoute("login", "dang-nhap", "~/site/login/login.aspx", false);
            routes.MapPageRoute("cart", "gio-hang", "~/site/cart/cart.aspx", false);
            routes.MapPageRoute("serviceDetail", "dich-vu/chi-tiet-dich-vu", "~/site/service/service_Detail.aspx", false);
            routes.MapPageRoute("account", "{handle}-{_id}", "~/site/account/account.aspx", false);
            routes.MapPageRoute("thankyou", "cam-on", "~/site/orderComplete/orderComplete.aspx", false);




            routes.MapPageRoute("home language", "{language}", "~/site/home/home.aspx", false);
        }
    }
}
