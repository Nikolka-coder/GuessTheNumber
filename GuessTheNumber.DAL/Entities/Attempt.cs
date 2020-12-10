namespace GuessTheNumber.DAL.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Identity;

    public class Attempt
    {
        [Key]
        public int AttemptId { get; set; }

        public int GameId { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }

        public Game Game { get; set; }

        public IdentityUser User { get; set; }

        public int Value { get; set; }

        public DateTime Time { get; set; }
    }
}