namespace GuessTheNumber.DAL.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using GuessTheNumber.DAL.Data;
    using GuessTheNumber.DAL.Entities;
    using GuessTheNumber.DAL.Interfaces;
    using Microsoft.EntityFrameworkCore;

    public class GameRepository : IGameRepository
    {
        private readonly DataContext _db;

        public GameRepository(DataContext db)
        {
            _db = db;
        }

        public int Create(Game item)
        {
            ICollection<Attempt> attempt = new List<Attempt>();
            item.Attempts = attempt;
            _db.Games.Add(item);
            _db.SaveChanges();
            return item.GameId;
        }

        public Game Get(int id) => _db.Games.Find(id);

        public void AddAttempt(int gameId, int value, string userId, string userName)
        {
            var item = _db.Games.Find(gameId);
            _db.Entry(item).Collection(game => game.Attempts).Load();
            var attempt = new Attempt { GameId = gameId, Value = value, Time = DateTime.Now, UserId = userId, UserName = userName };
            item.Attempts.Add(attempt);
            _db.SaveChanges();
        }

        public ICollection<Game> GetAll()
        {
            return _db.Games.Include(x => x.Attempts).Where(x => x.GameWinnerId != null).ToList();
        }

        public ICollection<Attempt> GetAttempts(int gameId)
        {
            var att = Get(gameId);
            _db.Entry(att).Collection(game => game.Attempts).Load();
            return att.Attempts.ToList();
        }
    }
}