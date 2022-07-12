using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpClient_API.Core.Global
{
    public class Globals
    {
        public static string baseAPI = "https://localhost:44309";
        public static string userAPI = "api/User";
       
        public static string loginAPI = "api/User/SignInCustomer";
        public static string orderAPI = "api/Cart";
        public static string addOrderAPI = "api/Cart/AddOrder";
        public static string createOrderAPI = "api/Order";

        public static string cartAPI = "api/Cart";

        public static string homePageAPI = "api/Home";
        public static string productPageAPI = "api/Product/Client/ProductPage";
        public static string productDetailPage = "api/Product/Client/ProductDetailPage";
        public static string getOneProductAPI = "api/Product";

        public static string listProductAPI = "/api/Product/Admin";
        public static string getOrderByCustomerAPI = "/api/Order/GetOrderByCustomer";

        public static string orderDetailAPI = "api/Order/GetOrderByID";
    }
}
