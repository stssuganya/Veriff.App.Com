using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using VeriffApi.com.Utilities;
using VeriffApi.Core.Models;

namespace VeriffApi.com.Controllers
{
    public class VeriffApiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        #region Create Session
        [HttpPost]
        public VeriffResponse CreateSession(verification verification)
        {
            VeriffResponse veriffResponse = new VeriffResponse();
            try
            {
                if (verification!=null)
                {
                    string ApiKey = Convert.ToString(Utility.GetAppSettings("ApiKey"));
                    var apiRequest = JsonConvert.SerializeObject(verification);
                    var client = new HttpClient();
                    var request = new HttpRequestMessage(HttpMethod.Post, "/v1/sessions/");
                    request.Headers.Add("X-AUTH-CLIENT", ApiKey);
                    var content = new StringContent(apiRequest, null, "application/json");
                    request.Content = content;
                    var response =  client.SendAsync(request);
                    //response.EnsureSuccessStatusCode();
                    //Console.WriteLine( await response.Content.ReadAsStringAsync());

                    
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return veriffResponse;
        }
        #endregion


        #region Get Veriff Web Request Response
        private Object GetVeriffWebRequestResponse(string requestJson)
        {
            Object payment = null;
            if (!string.IsNullOrWhiteSpace(requestJson))
            {
                string veriffURL = Utility.GetAppSettings(Constants.VeriffUrl);

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(veriffURL);

                byte[] bytes;
                bytes = System.Text.Encoding.ASCII.GetBytes(requestJson);
                request.ContentType = "application/json";
                request.ContentLength = bytes.Length;
                request.Method = "POST";
                Stream requestStream = request.GetRequestStream();
                requestStream.Write(bytes, 0, bytes.Length);
                requestStream.Close();
                HttpWebResponse response = null;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

                try
                {

                    response = (HttpWebResponse)request.GetResponse();
                }
                catch (WebException we)
                {
                    //HttpWebResponse errorResponse = we.Response as HttpWebResponse;
                    //if (errorResponse.StatusCode == HttpStatusCode.NotFound)
                    //{
                    //    //
                    //    payment = new payment();
                    //    ((payment)payment).Error = new Error()
                    //    {
                    //        ErrorMessage = (int)HttpStatusCode.NotFound + " Not Found"
                    //    };
                    //}
                }
                catch (Exception ex)
                {
                    if (ex != null && !string.IsNullOrWhiteSpace(ex.Message))
                    {
                       
                    }
                }

                //if (response != null && response.StatusCode == HttpStatusCode.OK)
                //{
                //    Stream responseStream = response.GetResponseStream();
                //    string responseStr = new StreamReader(responseStream).ReadToEnd();
                //    payment = DeSerialize(responseStr, typeof(payment));
                //}
            }
            return payment;
        }
        #endregion
    }
}
