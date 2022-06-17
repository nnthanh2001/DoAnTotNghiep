using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace TestApi
{
    public class Class1
    {
        public class staff
        {
            public int staffID { get; set; }
            public string staffName { get; set; }
            public string role { get; set; }
            public string email { get; set; }
            public string address { get; set; }
            public string phone { get; set; }
            public string status { get; set; }
        }
        public string get()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44309/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method
                HttpResponseMessage response =  client.GetAsync("api/Product").Result;
                if (response.IsSuccessStatusCode)
                {
                    var staff =  response.Content.ReadAsStringAsync().Result;
                }
                else
                {
                    Console.WriteLine("Internal server Error");
                }
            }
            return default(string);
        }
    }
}
