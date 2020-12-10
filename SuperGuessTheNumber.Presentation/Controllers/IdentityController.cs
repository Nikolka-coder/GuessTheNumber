namespace SuperGuessTheNumber.Presentation.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using SuperGuessTheNumber.Presentation.ActionFilters;
    using SuperGuessTheNumber.Presentation.Filters.CustomExceptionFilters;
    using SuperGuessTheNumber.Presentation.Services;
    using SuperGuessTheNumber.Presentation.V1.Requests;
    using SuperGuessTheNumber.Presentation.V1.Responces;
    using SuperGuessTheNumber.Presentation.V1.Routes;

    public class IdentityController : Controller
    {
        private readonly IIdentityService _identityService;

        public IdentityController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

       // [ServiceFilter(typeof(ValidateModelAttribute))]
        [TypeFilter(typeof(CustomExceptionFilterAttribute))]
        [HttpPost(ApiRoutes.Identity.Register)]
        public async Task<IActionResult> Register([FromBody] UserRegistrationRequest request)
        {
            var authResponse = await _identityService.RegisterAsync(request.Email, request.Password);

            return Ok(new AuthSuccessResponse
            {
                Token = authResponse.Token,
            });
        }

        [ServiceFilter(typeof(ValidateModelAttribute))]
        [TypeFilter(typeof(CustomExceptionFilterAttribute))]
        [HttpPost(ApiRoutes.Identity.Login)]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest request)
        {
            var authResponse = await _identityService.LoginAsync(request.Email, request.Password);

            return Ok(new AuthSuccessResponse
            {
                Token = authResponse.Token,
            });
        }
    }
}