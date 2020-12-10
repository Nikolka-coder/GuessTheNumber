namespace SuperGuessTheNumber.Presentation.Filters.CustomExceptionFilters
{
    using System.Net;
    using System.Threading.Tasks;
    using GuessTheNumber.Core.Enums;
    using GuessTheNumber.Core.ErrorMessages;
    using GuessTheNumber.Core.Errors;
    using GuessTheNumber.Core.Exceptions;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;

    public class CustomExceptionFilterAttribute : IAsyncExceptionFilter
    {
        public Task OnExceptionAsync(ExceptionContext context)
        {
            ApiError apiError = new ApiError();

            HttpResponse response = context.HttpContext.Response;

            if (context.Exception != null && context.Exception.GetType().IsSubclassOf(typeof(GuessTheNumberException)))
            {
                GuessTheNumberException exception = context.Exception as GuessTheNumberException;
                response.StatusCode = (int)HttpStatusCode.BadRequest;

                apiError.StatusCode = exception.Code;
                apiError.Message = exception.Message;
            }
            else
            {
                response.StatusCode = (int)HttpStatusCode.InternalServerError;

                apiError.StatusCode = (int)ExceptionEnums.Global.Base;
                apiError.Message = (context.Exception != null) ? context.Exception.Message : ErrorMessages.GuessTheNumberException;
            }

            context.Result = new BadRequestObjectResult(apiError);
            return Task.CompletedTask;
        }
    }
}