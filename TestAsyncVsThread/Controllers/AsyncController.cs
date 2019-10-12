using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using TestAsyncVsThread.Services;

namespace TestAsyncVsThread.Controllers
{
    public class AsyncController : ApiController
    {
        [HttpGet]
        public async Task<string> Test()
        {
            try
            {
                // use async call
                var service = new ApiService();
                var statusCode = await service.GetAsync(Urls.Jmeter);
                return statusCode.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}