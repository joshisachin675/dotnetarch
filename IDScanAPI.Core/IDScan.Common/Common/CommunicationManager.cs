
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Common
{
    public class CommunicationManager
    {
        private static readonly HttpClient client = new HttpClient();

        /// <summary>
        /// Post Request
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="url"></param>
        /// <param name="obj"></param>
        /// <param name="header">Send header param like api key</param>
        /// <returns></returns>
        public static HttpResponseMessage Post<T1>(string url, T1 obj ,List<KeyValuePair<string, string>> header)
        {
            if (string.IsNullOrEmpty(url) || obj == null)
            {
                throw new ArgumentNullException();
            }          
            string json = JsonConvert.SerializeObject(obj);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            foreach (KeyValuePair<string,string> item in header)
            {
                content.Headers.Add(item.Key, item.Value);                
            }
            return client.PostAsync(url, content).Result;
        }


        /// <summary>
        /// Post Request
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <param name="url"></param>
        /// <param name="obj"></param>
        /// <param name="header">Send header param like api key</param>
        /// <returns></returns>
        public static bool PostAsync<T1>(string url, T1 obj , List<KeyValuePair<string,string>> header)
        {
            if (string.IsNullOrEmpty(url) || obj == null)
            {
                throw new ArgumentNullException();
            }
            string json = JsonConvert.SerializeObject(obj);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponseMessage = client.PostAsync(url, content).Result;
            foreach (var item in header)
            {
                content.Headers.Add(item.Key , item.Value);
            }
            var result = httpResponseMessage.Content.ReadAsStringAsync().Result;
            return true;

        }
    }
}