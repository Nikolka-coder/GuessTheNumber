namespace SuperGuessTheNumber.Presentation.V1.Requests
{
    using System.ComponentModel.DataAnnotations;

    public class UserRegistrationRequest
    {
        [Required]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Invalid email")]
        public string Email { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 5, ErrorMessage = "Length of string must be from 5 until 60 symbols")]
        public string Nickname { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 5, ErrorMessage = "Length of string must be from 5 until 60 symbols")]
        public string Password { get; set; }
    }
}