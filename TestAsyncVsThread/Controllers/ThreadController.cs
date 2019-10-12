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
    public class ThreadController : ApiController
    {
        [HttpGet]
        public string Test()
        {
            try
            {
                // use sync call in another thread
                var task = Task.Factory.StartNew(() => new ApiService().Get(Urls.Jmeter), TaskCreationOptions.LongRunning);
                Task.WaitAll(task);
                return "Done";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}