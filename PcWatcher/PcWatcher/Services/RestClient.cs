using PcWatcher.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using PcWatcher.Models;
using Newtonsoft.Json;

namespace PcWatcher.Services
{
    public class RestClient : IRestClient
    {
       public  HttpClient httpClient = new HttpClient();
        string IP = "";
        
    
        public async Task<string> CloseWatcher(Commands commands, string address)
        {
            StringContent content = new StringContent("Tom");
            // определяем данные запроса
             var request = new HttpRequestMessage(HttpMethod.Post, IP);
            // установка отправляемого содержимого
            request.Content = content;
            // отправляем запрос
             var response = await httpClient.SendAsync(request);
            // получаем ответ
            string responseText = await response.Content.ReadAsStringAsync();
            return responseText;

        }

        public async Task<string> SendMessage(Commands commands, string address)
        {
            IP = address;
            try
            {
                var json = JsonConvert.SerializeObject(commands, Formatting.Indented);
                StringContent content = new StringContent(json);
                // определяем данные запроса
                var request = new HttpRequestMessage(HttpMethod.Post, IP);
                // установка отправляемого содержимого
                request.Content = content;
                // отправляем запрос
                var response = await httpClient.SendAsync(request);
                // получаем ответ
                string responseText = await response.Content.ReadAsStringAsync();
                return responseText;
            }
            catch(Exception e)
            {
                return e.Message;
            }
         
        }

        public async Task<string> SetTime(Commands commands, string address)
        {
            IP = address;
            try
            {
                var json = JsonConvert.SerializeObject(commands, Formatting.Indented);
                StringContent content = new StringContent(json);
                // определяем данные запроса
                var request = new HttpRequestMessage(HttpMethod.Post, IP);
                // установка отправляемого содержимого
                request.Content = content;
                // отправляем запрос
                var response = await httpClient.SendAsync(request);
                // получаем ответ
                string responseText = await response.Content.ReadAsStringAsync();
                return responseText;
            }
            catch(Exception e)
            {
                return e.Message;
            }
           
        }

        public async  Task<string> ShutDown(Commands commands, string address)
        {
            throw new NotImplementedException();
        }
    }
}
