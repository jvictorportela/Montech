using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Montech.Communication.Responses;
using Montech.Exceptions;
using Montech.Exceptions.ExceptionBase;
using System.Net;

namespace Montech.API.Filters;

public class ExceptionFilters : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is MontechException)
            HandleProjectException(context);
        else
            ThrowUnknowException(context);
    }

    private void HandleProjectException(ExceptionContext context)
    {
        if (context.Exception is InvalidLoginException)
        {
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            context.Result = new UnauthorizedObjectResult(new ResponseErrorJson(context.Exception.Message));
        }

        else if (context.Exception is ErrorOnValidationException)
        {
            var exception = context.Exception as ErrorOnValidationException;

            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            context.Result = new BadRequestObjectResult(new ResponseErrorJson(exception!.ErrorMessages));
        }
    }

    private void ThrowUnknowException(ExceptionContext context)
    {
        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        context.Result = new ObjectResult(new ResponseErrorJson(ResourceMessagesExcpetions.UNKNOW_ERROR));
    }
}
