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

        public static string productAPI = "api/Product/Admin";
       
        public static string productTop = "api/Product/TopProduct(4)";
        public static string userAPI = "api/User";
        public static string bestProductAPI = "api/Product/BestProduct";
        public static string serviceAPI = "api/Service";
        public static string categoryParentAPI = "api/Category/GetCategoryParent";
        public static string categoryAPI = "api/Category/GetCategoryByOderNo";
        public static string getOneProductAPI = "api/Product";
        public static string loginAPI = "api/User/SignIn";

        public static string serviceTop = "api/Service/TopService(3)";
    }
}
