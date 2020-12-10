namespace GuessTheNumber.DAL.Interfaces
{
    using System.Collections.Generic;
    using GuessTheNumber.DAL.Entities;

    public interface IGameRepository
    {
        ICollection<Game> GetAll();

        Game Get(int id);

        int Create(Game item);

        void AddAttempt(int gameId, int value, string userId, string userName);

        ICollection<Attempt> GetAttempts(int gameId);
    }
}