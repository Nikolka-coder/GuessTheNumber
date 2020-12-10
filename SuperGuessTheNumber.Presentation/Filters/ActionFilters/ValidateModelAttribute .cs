namespace SuperGuessTheNumber.Presentation.ActionFilters
{
    using System.Linq;
    using System.Threading.Tasks;
    using GuessTheNumber.Core.Exceptions;
    using Microsoft.AspNetCore.Mvc.Filters;

    public class ValidateModelAttribute : IAsyncActionFilter
    {
        public Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var errorsInModelState = context.ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(x => x.ErrorMessage)).ToArray();

                throw new GuessTheNumberModelIsNotValidException();
            }

            return next();
        }
    }
}