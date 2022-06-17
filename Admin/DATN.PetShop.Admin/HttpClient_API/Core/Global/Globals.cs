﻿using System;
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

        public static string listProductAPI = "/api/Product/Admin";
        public static string editProductAPI = "api/Product/EditProduct";
        public static string addProductAPI = "api/Product/AddProduct";
        public static string productAPI = "/api/Product";
        

        public static string userAPI = "api/User";
        public static string editUserAPI = "api/User/EditUser";

        public static string serviceAPI = "api/Service";
        public static string editServiceAPI = "api/Service/EditService";

        public static string categoryAPI = "api/Category/GetCategoryByOderNo";
       

        
        
    }
}
