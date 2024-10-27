using System;
using System.Net.Http;

namespace WindowsService1.Services
{
    public static class ApiClientFactory
    {
        public static HttpClient CreateClient(string baseAddress)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(baseAddress);
            return client;
        }
    }
}