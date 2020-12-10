namespace SuperGuessTheNumber.Presentation.V1.Responces
{
    using System.Collections.Generic;

    public class AuthFailedResponse
    {
        public IEnumerable<string> Errors { get; set; }
    }
}