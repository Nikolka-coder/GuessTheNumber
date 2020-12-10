namespace GuessTheNumber.Core.Domain
{
    using System.Collections.Generic;
    using GuessTheNumber.DAL.Entities;

    public static class ActiveGame
    {
        public static int ActiveGameId { get; set; }

        public static int SecretValue { get; set; }

        public static string GameWinnerId { get; set; }

        public static string GameWinnerName { get; set; }

       // public static ICollection<Attempt> Attempts { get; set; }
    }
}