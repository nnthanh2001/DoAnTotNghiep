using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
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
                        else
                        {
                            var result = request.Result.EnsureSuccessStatusCode();
                            if (result.StatusCode == System.Net.HttpStatusCode.NotFound)
                            {
                                var err = result.Content.ReadAsStringAsync().Result;
                                response = err;
                            }
                        }
                    }
                }
            }
            return response;
        }
    }

}
