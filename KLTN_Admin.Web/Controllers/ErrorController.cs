using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace KLTN_Admin.Web.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error")]
        [AllowAnonymous]
        public IActionResult Error()
        {
            var exDetail = HttpContext.Features.Get<IExceptionHandlerPathFeature>().Error;
            return View(exDetail.Message);
        }

        [Route("Error/{statusCode}")]
        [AllowAnonymous]
        public IActionResult Status(int statusCode)
        {
            string message;
            switch (statusCode)
            {
                case 400: 
                    message = "Bad request";
                    break;
                case 401: 
                    message = "Un athorize";
                    break;
                default:
                    message = string.Empty;
                    break;
            };

            return View();
        }
    }
}
