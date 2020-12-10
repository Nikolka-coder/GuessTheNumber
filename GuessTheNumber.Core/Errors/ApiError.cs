namespace GuessTheNumber.Core.Errors
{
    using System.Collections.Generic;

    public class ApiError
    {
        public ApiError()
        {
            this.ValidationErrors = new List<ValidationError>();
        }

        public int StatusCode { get; set; }

        public string Message { get; set; }

        public IList<ValidationError> ValidationErrors { get; set; }
    }
}