namespace GuessTheNumber.Core.DTO
{
    using System;
    using System.Collections.Generic;

    public class AllGamesHistoryModel
    {
        public int GameId { get; set; }

        public string GameOwnerName { get; set; }

        public string GameWinnerName { get; set; }

        public DateTime GameDate { get; set; }

        public int SecretValue { get; set; }

        //public bool IsCurrentGameUser { get; set; }
        public IEnumerable<ListOfAttempt> ListOfAttempts { get; set; }
    }
}