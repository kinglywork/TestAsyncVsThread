﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace TestAsyncVsThread.Services
{
    public class ApiService
    {
        public async Task GetAsync(string url)
        {
            var handler = new HttpClientHandler() {UseCookies = false};
            var client = new HttpClient(handler);
            var message = new HttpRequestMessage(HttpMethod.Get, url);
//            message.Headers.Add("Cookie", cookie);
            var response = await client.SendAsync(message);
        }

        public void Get(string url)
        {
            var handler = new HttpClientHandler() {UseCookies = false};
            var client = new HttpClient(handler);
            var message = new HttpRequestMessage(HttpMethod.Get, url);
//            message.Headers.Add("Cookie", cookie);
            var response = client.SendAsync(message).Result;
        }
    }
}