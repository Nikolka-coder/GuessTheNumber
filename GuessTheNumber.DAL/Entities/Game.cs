namespace GuessTheNumber.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Identity;

    public class Game
    {
        [Key]
        public int GameId { get; set; }

        public string GameOwnerId { get; set; }

        public IdentityUser GameOwnerUser { get; set; }

        public string GameOwnerName { get; set; }

        public string GameWinnerId { get; set; }

        public IdentityUser GameWinnerUser { get; set; }

        public string GameWinnerName { get; set; }

        public DateTime GameDate { get; set; }

        public int SecretValue { get; set; }

       // public ICollection<IdentityUser> Players { get; set; }
        public virtual ICollection<Attempt> Attempts { get; set; }
    }
}