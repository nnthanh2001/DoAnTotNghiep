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

        public static string loginAPI = "api/User/SignIn";
        public static string handleAPI = "/api/Handle/Request";

        public static string listProductAPI = "/api/Product/Admin";
        public static string editProductAPI = "api/Product/EditProduct";
        public static string addProductAPI = "api/Product/AddProduct";
        public static string productAPI = "/api/Product";
        

        public static string userAPI = "api/User";
        public static string customerAPI = "api/User/GetCustomer";
        public static string editUserAPI = "api/User/EditUser";
        public static string addUserAPI = "api/User/AddUser";

        public static string serviceAPI = "api/Service";
        public static string editServiceAPI = "api/Service/EditService";

        public static string categoryAPI = "api/Category/GetCategoryByOderNo";

        public static string orderAPI = "api/Order/GetOrder";
        public static string orderDetailAPI = "api/Order/GetOrderByID";


        public static string statisticalAPI = "api/Statistical";
        public static string statisticalAPI2 = "api/Statistical/GetStatisticalByMonth";
        

        
        
    }
}
