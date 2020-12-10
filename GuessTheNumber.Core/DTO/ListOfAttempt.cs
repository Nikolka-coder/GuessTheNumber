namespace GuessTheNumber.Core.DTO
{
    using System;

    public class ListOfAttempt
    {
        public int GameId { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }

        public int Value { get; set; }

        public DateTime Time { get; set; }
    }
}