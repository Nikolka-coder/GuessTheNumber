namespace GuessTheNumber.Core.DTO
{
    using System;
    using System.Collections.Generic;

    public class HistoryModel
    {
        public int GameId { get; set; }

        public string GameWinnerId { get; set; }

        public string GameWinnerName { get; set; }

        public DateTime DateTime { get; set; }

        public IEnumerable<ListOfAttempt> ListOfAttempts { get; set; }
    }
}