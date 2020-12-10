namespace SuperGuessTheNumber.Presentation.Services
{
    using System.Threading.Tasks;
    using SuperGuessTheNumber.Core.Domain;

    public interface IIdentityService
    {
        Task<AuthenticationResult> RegisterAsync(string email, string password);

        Task<AuthenticationResult> LoginAsync(string email, string password);
    }
}