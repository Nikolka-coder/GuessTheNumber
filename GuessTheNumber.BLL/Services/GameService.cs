namespace GuessTheNumber.BLL.Services
{
    using System;
    using System.Collections.Generic;
    using AutoMapper;
    using GuessTheNumber.BLL.Interfaces;
    using GuessTheNumber.Core.Domain;
    using GuessTheNumber.Core.DTO;
    using GuessTheNumber.Core.Exceptions;
    using GuessTheNumber.DAL.Entities;
    using GuessTheNumber.DAL.Interfaces;

    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;
        private readonly IMapper _mapper;

        public GameService(
            IGameRepository gameRepository,
            IMapper mapper)
        {
            _gameRepository = gameRepository;
            _mapper = mapper;
        }

        public string CheckValue(int value, string playerId, string playerName)
        {
            var secretValue = ActiveGame.SecretValue;
            string statusGameMessage;
            if (value == secretValue)
            {
                string gameWinnerId = playerId;
                string gameWinnerName = playerName;
                var game = _gameRepository.Get(ActiveGame.ActiveGameId);
                game.GameWinnerId = gameWinnerId;
                game.GameWinnerName = gameWinnerName;
                ActiveGame.GameWinnerId = gameWinnerId;
                ActiveGame.GameWinnerName = gameWinnerName;
                InitializationAttempt(value, playerId, playerName);
                statusGameMessage = $"{gameWinnerName}! Congratulation! Your number is right!";
                return statusGameMessage;
            }

            if (value > secretValue)
            {
                InitializationAttempt(value, playerId, playerName);
                statusGameMessage = $"Your number is {value}.You must enter a lower value";
                return statusGameMessage;
            }
            else
            {
                InitializationAttempt(value, playerId, playerName);
                statusGameMessage = $"Your number is {value}.You must enter a larger value";
                return statusGameMessage;
            }
        }

        public ICollection<ListOfAttempt> GetHistoryOfCurrentGame(int gameId)
        {
            if (gameId == 0)
            {
                throw new GuessTheNumberAllGamesAlreadyFinishedException();
            }

            var attempts = _gameRepository.GetAttempts(gameId);
            return _mapper.Map<List<ListOfAttempt>>(attempts);
        }

        public ICollection<AllGamesHistoryModel> GetAllGames()
        {
            var games = _gameRepository.GetAll();
           return _mapper.Map<List<AllGamesHistoryModel>>(games);
        }

        public int StartGame(string playerId, string playerName, int secretValue)
        {
            string gameOwnerId = playerId;
            string gameOwnerName = playerName;
            InitializationGame(gameOwnerId, gameOwnerName, secretValue);
            return secretValue;
        }

        public string FinishGame()
        {
            ActiveGame.ActiveGameId = 0;

            string message = "Game Over!";
            return message;
        }

        private int InitializationGame(string gameOwnerId, string gameOwnerName, int secretValue)
        {
            var gameId = _gameRepository.Create(new Game
            {
                GameDate = DateTime.Now,
                GameOwnerId = gameOwnerId,
                GameOwnerName = gameOwnerName,
                SecretValue = secretValue
            });
            ActiveGame.SecretValue = secretValue;
            ActiveGame.ActiveGameId = gameId;
            return ActiveGame.ActiveGameId;
        }

        private void InitializationAttempt(int value, string userId, string userName)
        {
            var gameId = ActiveGame.ActiveGameId;
            if (gameId == 0)
            {
                throw new GuessTheNumberAllGamesAlreadyFinishedException();
            }

            _gameRepository.AddAttempt(gameId, value, userId, userName);
        }
    }
}