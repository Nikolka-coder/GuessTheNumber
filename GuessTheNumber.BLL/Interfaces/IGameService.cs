namespace GuessTheNumber.BLL.Interfaces
{
    using System.Collections.Generic;
    using GuessTheNumber.Core.DTO;

    public interface IGameService
    {
        int StartGame(string playerId, string playerName, int secretValue);

        string CheckValue(int value, string playerId, string playerName);

        ICollection<ListOfAttempt> GetHistoryOfCurrentGame(int gameId);

        ICollection<AllGamesHistoryModel> GetAllGames();

        string FinishGame();
    }
}