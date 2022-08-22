using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PhucNPH.MockProject.Domain.Constants;
using PhucNPH.MockProject.Domain.Ulitilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PhucNPH.MockProject.Domain.Filters
{
    public class CustomExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception.InnerException != null && 
                context.Exception.InnerException.Message.Contains(ValidationConstants.ExceptionType.DuplicatedUsername))
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;

                context.Result = new JsonResult
                    (new ResponseResult((int)HttpStatusCode.UnprocessableEntity, 
                    $"Username existed. Please chooose another username"));

                base.OnException(context);
            }
            else
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                context.Result = new JsonResult
                    (new ResponseResult((int)HttpStatusCode.InternalServerError, 
                    $"Unidentified Error: {context.Exception.Message}. Please contact administator."));

            }

            base.OnException(context);

        }
    }
}
