using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Veriff.Core.Model;
using VeriffApi.TBS.Com.Utilities;

namespace VeriffApi.TBS.Com.Controllers
{
    //[ApiController]
    //[Route("controller")]
    public class VeriffApiController : BaseAPIController
    {

        #region Create Session
        [HttpPost]
        public bool CreateSession(VerificationData verification)
        {
            VeriffResponse veriffResponse = new VeriffResponse();
            verification ver = new verification();
            ver.callback = "https://veriff.me";
            ver.person = new person();
            ver.person.firstName = "John";
            ver.person.lastName = "Smith";
            ver.person.dateOfBirth = "1990-06-21";
            ver.person.gender = "M";
            ver.document = new document();
            ver.document.type = "DRIVERS_LICENSE";
            ver.document.country = "US";
            ver.vendorData = "Span Test";
          
            bool isSaved = true;
            try
            {
                if (verification != null)
                {
                    string ApiKey = Convert.ToString(Utility.GetAppSettings("ApiKey"));
                    string basesiteUrl = Convert.ToString(Utility.GetAppSettings("VeriffUrl"));
                    var apiRequest = JsonConvert.SerializeObject(ver);
                    var client = new HttpClient();
                    var request = new HttpRequestMessage(HttpMethod.Post, basesiteUrl + "v1/sessions/");
                    request.Headers.Add("X-AUTH-CLIENT", ApiKey);
                    var content = new StringContent(apiRequest, null, "application/json");
                    request.Content = content;
                    var response = client.SendAsync(request);
                    //response.EnsureSuccessStatusCode();
                    //Console.WriteLine( await response.Content.ReadAsStringAsync());

                    //var client = new HttpClient();
                    //var request = new HttpRequestMessage(HttpMethod.Post, basesiteUrl+"v1/sessions/");
                    //request.Headers.Add("X-AUTH-CLIENT", ApiKey);
                    //var content = new StringContent("{\n    \"verification\": {\n        \"callback\": \"https://veriff.me\",\n        \"person\": {\n            \"firstName\": \"John\",\n            \"lastName\": \"Smith\",\n            \"dateOfBirth\": \"1990-06-21\",\n            \"gender\": \"M\"\n        },\n        \"document\": {\n            \"type\": \"DRIVERS_LICENSE\",\n            \"country\": \"US\"\n        },\n        \"vendorData\": \"Postman test\"\n    }\n}", null, "application/json");
                    //request.Content = content;
                    //var response =  client.SendAsync(request);
                    //response.EnsureSuccessStatusCode();
                    //Console.WriteLine(await response.Content.ReadAsStringAsync());



                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return isSaved;
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
