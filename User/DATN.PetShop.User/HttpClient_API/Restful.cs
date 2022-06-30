using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HttpClient_API
{
    public class Restful
    {
        public static async Task<TEntity> Get<TEntity>(string baseUrl, string apiUrl) where TEntity : new()
        {
            var response = new TEntity();
            if (baseUrl != null && baseUrl != "")
            {
                if (apiUrl != null && apiUrl != "")
                {
                    using (var client = new HttpClient())
                    {

                        client.BaseAddress = new Uri(baseUrl);
                        client.Timeout = TimeSpan.FromSeconds(10000);
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        var request = client.GetAsync(apiUrl);
                        if (request.Status == TaskStatus.WaitingForActivation)
                        {
                            Thread.Sleep(500);
                        }
                        var title = "";
                        var message = "";
                        var flag = true;
                        var maxLoop = 10;
                        var loop = 0;
                        while (flag)
                        {
                            if (request.Status == TaskStatus.RanToCompletion)
                            {
                                flag = false;
                                if (request.Result.StatusCode == System.Net.HttpStatusCode.OK)
                                {
                                    var result = request.Result.EnsureSuccessStatusCode();
                                    if (result.StatusCode == System.Net.HttpStatusCode.OK)
                                    {
                                        var json = result.Content.ReadAsStringAsync().Result;
                                        if (json != null && json != "")
                                        {
                                            response = JsonConvert.DeserializeObject<TEntity>(json);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                title = request.Status.ToString();
                                var statusCode = (int)request.Status;
                                switch ((int)request.Status)
                                {
                                    case 0:
                                        message = "The task has been initialized but has not yet been scheduled.";
                                        break;
                                    case 1:
                                        message = "The task is waiting to be activated and scheduled internally by the .NET Framework infrastructure.";
                                        break;
                                    case 2:
                                        message = "The task has been scheduled for execution but has not yet begun executing.";
                                        break;
                                    case 3:
                                        message = "The task is running but has not yet completed.";
                                        break;
                                    case 4:
                                        message = "The task has finished executing and is implicitly waiting for attached child tasks to complete.";
                                        break;
                                    case 6:
                                        message = "The task acknowledged cancellation by throwing an OperationCanceledException " +
                                        "with its own CancellationToken while the token was in signaled state, or the task's CancellationToken " +
                                        "was already signaled before the task started executing.For more information, see Task Cancellation.";
                                        break;
                                    case 7:
                                        message = "The task completed due to an unhandled exception.";
                                        break;
                                    default:
                                        break;
                                }


                                //if (request.Status == TaskStatus.Canceled)
                                //{
                                //    flag = false;
                                //    break;
                                //}
                                loop++;
                                if (loop >= maxLoop)
                                {
                                    flag = false;
                                }
                                else
                                {
                                    Thread.Sleep(500);
                                }
                            }
                        }
                    }
                }
            }
            return response;
        }
        public static string Post<TEntity>(string baseUrl, string apiUrl, TEntity entity, bool isSerialize = true) where TEntity : new()
        {
            var response = "";
            if (baseUrl != null && baseUrl != "")
            {
                if (apiUrl != null && apiUrl != "")
                {
                    using (var client = new HttpClient())
                    {

                        client.BaseAddress = new Uri(baseUrl);
                        client.Timeout = TimeSpan.FromSeconds(10000);
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));



                        var request = client.PostAsJsonAsync(apiUrl, entity);


                        if (request.Result.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            var result = request.Result.EnsureSuccessStatusCode();
                            if (result.StatusCode == System.Net.HttpStatusCode.OK)
                            {
                                var json = result.Content.ReadAsStringAsync().Result;
                                response = json;
                            }
                        }
                        //else
                        //{
                        //    var result = request.Result.EnsureSuccessStatusCode();
                        //    if (result.StatusCode == System.Net.HttpStatusCode.NotFound)
                        //    {
                        //        var err = result.Content.ReadAsStringAsync().Result;
                        //        response = err;
                        //    }
                        //}
                    }
                }
            }
            return response;
        }
        //public async Task<TEntity> Post<TEntity>(string baseUrl, string apiUrl, TEntity entity, bool isSerialize = true)
        //{
        //    var response = "";
        //    if (baseUrl != null && baseUrl != "")
        //    {
        //        if (apiUrl != null && apiUrl != "")
        //        {
        //            using (var client = new HttpClient())
        //            {

        //                client.BaseAddress = new Uri(baseUrl);
        //                client.Timeout = TimeSpan.FromSeconds(10000);
        //                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

        //                Task<HttpResponseMessage> request;
        //                if (isSerialize)
        //                {
        //                    var data = JsonConvert.SerializeObject(entity);
        //                    var doc = new StringContent(data, Encoding.UTF8, "application/json");
        //                    request = client.PostAsync(apiUrl, doc);
        //                }
        //                else
        //                {
        //                    request = client.PostAsJsonAsync(apiUrl, entity);
        //                }
        //                if (request.Status == TaskStatus.WaitingForActivation)
        //                {
        //                    Thread.Sleep(500);
        //                }

        //                var title = "";
        //                var message = "";
        //                var flag = true;
        //                var maxLoop = 10;
        //                var loop = 0;
        //                while (flag)
        //                {
        //                    if (request.Status == TaskStatus.RanToCompletion)
        //                    {
        //                        flag = false;
        //                        if (request.Result.StatusCode == System.Net.HttpStatusCode.OK)
        //                        {
        //                            var result = request.Result.EnsureSuccessStatusCode();
        //                            if (result.StatusCode == System.Net.HttpStatusCode.OK)
        //                            {
        //                                var json = result.Content.ReadAsStringAsync().Result;
        //                                if (json != null && json != "")
        //                                {
        //                                    var model = JsonConvert.SerializeObject<TEntity>(json);
        //                                    response.Model = model;
        //                                    response.HttpStatusCode = 200;
        //                                }
        //                            }
        //                            else
        //                            {
        //                                response.HttpStatusCode = (int)result.StatusCode;
        //                                response.Message = result.Content.ReadAsStringAsync().Result;
        //                            }
        //                        }
        //                        else
        //                        {
        //                            var content = request.Result.Content.ReadAsStringAsync().Result;
        //                            if (content != null && content != "")
        //                            {
        //                                response = ConvertHelper.Deserialize<ResponseModel<TEntity>>(content);
        //                                if (response.Model == null && response.Message == null)
        //                                {
        //                                    response.HttpStatusCode = (int)request.Result.StatusCode;
        //                                    response.Message = content;
        //                                }
        //                            }
        //                            else
        //                            {
        //                                response.HttpStatusCode = (int)request.Result.StatusCode;
        //                                response.Message = request.Result.Content.ReadAsStringAsync().Result;
        //                            }
        //                        }
        //                    }
        //                    else
        //                    {
        //                        title = request.Status.ToString();
        //                        var statusCode = (int)request.Status;
        //                        switch ((int)request.Status)
        //                        {
        //                            case 0:
        //                                message = "The task has been initialized but has not yet been scheduled.";
        //                                break;
        //                            case 1:
        //                                message = "The task is waiting to be activated and scheduled internally by the .NET Framework infrastructure.";
        //                                break;
        //                            case 2:
        //                                message = "The task has been scheduled for execution but has not yet begun executing.";
        //                                break;
        //                            case 3:
        //                                message = "The task is running but has not yet completed.";
        //                                break;
        //                            case 4:
        //                                message = "The task has finished executing and is implicitly waiting for attached child tasks to complete.";
        //                                break;
        //                            case 6:
        //                                message = "The task acknowledged cancellation by throwing an OperationCanceledException " +
        //                                "with its own CancellationToken while the token was in signaled state, or the task's CancellationToken " +
        //                                "was already signaled before the task started executing.For more information, see Task Cancellation.";
        //                                break;
        //                            case 7:
        //                                message = "The task completed due to an unhandled exception.";
        //                                break;
        //                            default:
        //                                break;
        //                        }
        //                        response.Title = title;
        //                        response.HttpStatusCode = statusCode;
        //                        response.Message = message;

        //                        //if (request.Status == TaskStatus.Canceled)
        //                        //{
        //                        //    flag = false;
        //                        //    break;
        //                        //}
        //                        loop++;
        //                        if (loop >= maxLoop)
        //                        {
        //                            flag = false;
        //                        }
        //                        else
        //                        {
        //                            Thread.Sleep(500);
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    return response;
        //}

        public static string Put<TEntity>(string baseUrl, string apiUrl, TEntity entity, bool isSerialize = true)
        {
            var response = "";
            if (baseUrl != null && baseUrl != "")
            {
                if (apiUrl != null && apiUrl != "")
                {
                    using (var client = new HttpClient())
                    {

                        client.BaseAddress = new Uri(baseUrl);
                        client.Timeout = TimeSpan.FromSeconds(10000);
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));


                        var request = client.PutAsJsonAsync(apiUrl, entity);


                        if (request.Result.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            var result = request.Result.EnsureSuccessStatusCode();
                            if (result.StatusCode == System.Net.HttpStatusCode.OK)
                            {
                                var json = result.Content.ReadAsStringAsync().Result;
                                response = json;
                            }
                            else
                            {
                            }
                        }
                        else
                        {

                        }
                    }
                }
            }
            return response;
        }

        public static string Delete<TEntity>(string baseUrl, string apiUrl)
        {
            var response = "";
            if (baseUrl != null && baseUrl != "")
            {
                if (apiUrl != null && apiUrl != "")
                {
                    using (var client = new HttpClient())
                    {

                        client.BaseAddress = new Uri(baseUrl);
                        client.Timeout = TimeSpan.FromSeconds(10000);
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));


                        var request = client.DeleteAsync(apiUrl);



                        if (request.Result.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            var result = request.Result.EnsureSuccessStatusCode();
                            if (result.StatusCode == System.Net.HttpStatusCode.OK)
                            {
                                var json = result.Content.ReadAsStringAsync().Result;
                                response = json;
                            }
                            else
                            {
                                //response.HttpStatusCode = (int)result.StatusCode;
                                //response.Message = result.Content.ReadAsStringAsync().Result;
                            }
                        }
                        //else
                        //{
                        //    var content = request.Result.Content.ReadAsStringAsync().Result;
                        //    if (content != null && content != "")
                        //    {
                        //        response = ConvertHelper.Deserialize<ResponseModel<TEntity>>(content);
                        //        if (response.Model == null && response.Message == null)
                        //        {
                        //            response.HttpStatusCode = (int)request.Result.StatusCode;
                        //            response.Message = content;
                        //        }
                        //    }
                        //    else
                        //    {
                        //        response.HttpStatusCode = (int)request.Result.StatusCode;
                        //        response.Message = request.Result.Content.ReadAsStringAsync().Result;
                        //    }
                        //}
                    }
                }

            }
            return response;
        }



        //public async Task<TEntity> PostEntity<TEntity>(string baseUrl, string apiUrl, object entity, bool isSerialize = true) where TEntity : new()
        //{
        //    var response = new ResponseModel<TEntity>();
        //    if (baseUrl != null && baseUrl != "")
        //    {
        //        if (apiUrl != null && apiUrl != "")
        //        {
        //            using (var client = new HttpClient())
        //            {
        //                if (token != null && token != "")
        //                {
        //                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        //                }
        //                var culture = GlobalsParameter._language;
        //                if (culture != null && culture != "")
        //                {
        //                    client.DefaultRequestHeaders.Add("culture", culture);
        //                }
        //                client.BaseAddress = new Uri(baseUrl);
        //                client.Timeout = TimeSpan.FromSeconds(10000);
        //                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        //                cancellationTokenSource.CancelAfter(10000);
        //                Task<HttpResponseMessage> request;
        //                if (isSerialize)
        //                {
        //                    var data = ConvertHelper.Serialize(entity);
        //                    var doc = new StringContent(data, Encoding.UTF8, "application/json");
        //                    request = client.PostAsync(apiUrl, doc);
        //                }
        //                else
        //                {
        //                    request = client.PostAsJsonAsync(apiUrl, entity);
        //                }
        //                if (request.Status == TaskStatus.WaitingForActivation)
        //                {
        //                    Thread.Sleep(500);
        //                }

        //                var title = "";
        //                var message = "";
        //                var flag = true;
        //                var maxLoop = 10;
        //                var loop = 0;
        //                while (flag)
        //                {
        //                    if (request.Status == TaskStatus.RanToCompletion)
        //                    {
        //                        flag = false;
        //                        if (request.Result.StatusCode == System.Net.HttpStatusCode.OK)
        //                        {
        //                            var result = request.Result.EnsureSuccessStatusCode();
        //                            if (result.StatusCode == System.Net.HttpStatusCode.OK)
        //                            {
        //                                var json = result.Content.ReadAsStringAsync().Result;
        //                                if (json != null && json != "")
        //                                {
        //                                    var model = ConvertHelper.Deserialize<TEntity>(json);
        //                                    response.Model = model;
        //                                    response.HttpStatusCode = 200;
        //                                }
        //                            }
        //                            else
        //                            {
        //                                response.HttpStatusCode = (int)result.StatusCode;
        //                                response.Message = result.Content.ReadAsStringAsync().Result;
        //                            }
        //                        }
        //                        else
        //                        {
        //                            var content = request.Result.Content.ReadAsStringAsync().Result;
        //                            if (content != null && content != "")
        //                            {
        //                                response = ConvertHelper.Deserialize<ResponseModel<TEntity>>(content);
        //                                if (response.Model == null && response.Message == null)
        //                                {
        //                                    response.HttpStatusCode = (int)request.Result.StatusCode;
        //                                    response.Message = content;
        //                                }
        //                            }
        //                            else
        //                            {
        //                                response.HttpStatusCode = (int)request.Result.StatusCode;
        //                                response.Message = request.Result.Content.ReadAsStringAsync().Result;
        //                            }
        //                        }
        //                    }
        //                    else
        //                    {
        //                        title = request.Status.ToString();
        //                        var statusCode = (int)request.Status;
        //                        switch ((int)request.Status)
        //                        {
        //                            case 0:
        //                                message = "The task has been initialized but has not yet been scheduled.";
        //                                break;
        //                            case 1:
        //                                message = "The task is waiting to be activated and scheduled internally by the .NET Framework infrastructure.";
        //                                break;
        //                            case 2:
        //                                message = "The task has been scheduled for execution but has not yet begun executing.";
        //                                break;
        //                            case 3:
        //                                message = "The task is running but has not yet completed.";
        //                                break;
        //                            case 4:
        //                                message = "The task has finished executing and is implicitly waiting for attached child tasks to complete.";
        //                                break;
        //                            case 6:
        //                                message = "The task acknowledged cancellation by throwing an OperationCanceledException " +
        //                                "with its own CancellationToken while the token was in signaled state, or the task's CancellationToken " +
        //                                "was already signaled before the task started executing.For more information, see Task Cancellation.";
        //                                break;
        //                            case 7:
        //                                message = "The task completed due to an unhandled exception.";
        //                                break;
        //                            default:
        //                                break;
        //                        }
        //                        response.Title = title;
        //                        response.HttpStatusCode = statusCode;
        //                        response.Message = message;

        //                        //if (request.Status == TaskStatus.Canceled)
        //                        //{
        //                        //    flag = false;
        //                        //    break;
        //                        //}
        //                        loop++;
        //                        if (loop >= maxLoop)
        //                        {
        //                            flag = false;
        //                        }
        //                        else
        //                        {
        //                            Thread.Sleep(500);
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    return response;
        //}


    }

}

