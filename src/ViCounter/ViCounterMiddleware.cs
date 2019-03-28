using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace ViCounter
{
    public class ViCounterMiddleware
    {
        private readonly RequestDelegate _requestDelegate;
        //        private readonly ViCounter 

        public ViCounterMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }

        public async Task Invoke(HttpContext context)
        {
            var visitorId = context.Request.Cookies["VisitorId"];

            if (visitorId == null)
            {
                visitorId = Guid.NewGuid().ToString();
                //don the necessary staffs here to save the count by one
                context.Response.Cookies.Append("VisitorId", visitorId, new CookieOptions()
                {
                    Path = "/",
                    HttpOnly = true,
                    //Secure = false,
                    Expires = DateTime.Now.AddMonths(1)
                });
            }
            CounterProcessor.Visit(visitorId);

            await _requestDelegate(context);
        }
    }
}
