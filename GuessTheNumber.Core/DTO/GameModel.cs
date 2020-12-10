namespace GuessTheNumber.Core.DTO
{
    using System;
    using System.Collections.Generic;

    public class GameModel
    {
        public int GameId { get; set; }

        public string PlayerId { get; set; }

        public string PlayerName { get; set; }

        public string GameWinnerId { get; set; }

        public string GameWinnerName { get; set; }

        public DateTime DateTime { get; set; }

        public string StatusGameMessage { get; set; }
    }
}