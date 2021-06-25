using QSpace.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace QSpace.API.Controllers
{
    
    //[Route("api/[controller]/[action]")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class BaseController :Controller
    {
        protected string UserId = "";
        protected APIResponseViewModel GetResponse(object data = null, string message = "Done")
        {
            var result = new APIResponseViewModel()
            {
                Status = true,
                Message = message,
                Data = data
            };
            return result;
        }
        protected APIResponseViewModel GetExceptionResponse(string message)
        {
            var result = new APIResponseViewModel()
            {
                Status = false,
                Message = message,
                Data = null
            };
            return result;
        }
        
    }
}
