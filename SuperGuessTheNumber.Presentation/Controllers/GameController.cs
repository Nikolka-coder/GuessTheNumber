namespace SuperGuessTheNumber.Presentation.Controllers
{
    using System;
    using System.Security.Claims;
    using AutoMapper;
    using GuessTheNumber.BLL.Interfaces;
    using GuessTheNumber.Core.Domain;
    using GuessTheNumber.Core.DTO;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using SuperGuessTheNumber.Presentation.Filters.CustomExceptionFilters;
    using SuperGuessTheNumber.Presentation.V1.Requests;

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class GameController : Controller
    {
        private readonly IGameService _gameService;
        private readonly IMapper _mapper;

        public GameController(IGameService gameService, IMapper mapper)
        {
            _gameService = gameService;
            _mapper = mapper;
        }

        [HttpGet("GetAllHistoryGames")]
        public IActionResult GetAllHistoryGames()
        {
            var games = _gameService.GetAllGames();
            return Ok(games);
        }

        [TypeFilter(typeof(CustomExceptionFilterAttribute))]
        [HttpGet("GetHistoryOfCurrentGame")]
        public IActionResult GetHistoryOfCurrentGame()
        {
            var listOfAttempt = _gameService.GetHistoryOfCurrentGame(ActiveGame.ActiveGameId);
            var historyModel = new HistoryModel
            {
                GameId = ActiveGame.ActiveGameId,
                DateTime = DateTime.Now,
                GameWinnerId = ActiveGame.GameWinnerId,
                GameWinnerName = ActiveGame.GameWinnerName,
                ListOfAttempts = listOfAttempt
            };
            return Ok(historyModel);
        }

        [TypeFilter(typeof(CustomExceptionFilterAttribute))]
        [HttpGet("CheckValue")]
        public IActionResult CheckValue([FromQuery] ValueRequest request)
        {
            var userId = ((ClaimsIdentity)User.Identity).FindFirst("Id").Value;
            var user = (ClaimsIdentity)User.Identity;
            var userName = user.FindFirst(ClaimTypes.Email).Value;
            var statusGameMessage = _gameService.CheckValue(request.Value, userId, userName);
            var gameModel = new GameModel
            {
                GameId = ActiveGame.ActiveGameId,
                PlayerId = userId,
                PlayerName = userName,
                DateTime = DateTime.Now,
                GameWinnerId = ActiveGame.GameWinnerId,
                GameWinnerName = ActiveGame.GameWinnerName,
                StatusGameMessage = statusGameMessage
            };

            if (ActiveGame.GameWinnerId != null)
            {
                _gameService.FinishGame();
            }

            return Ok(_mapper.Map<GameModel>(gameModel));
        }

        [HttpGet("StartGame")]
        public IActionResult StartGame([FromQuery] ValueRequest request)
        {
            var userId = ((ClaimsIdentity)User.Identity).FindFirst("Id").Value;
            var user = (ClaimsIdentity)User.Identity;
            var userName = user.FindFirst(ClaimTypes.Email).Value;
            _gameService.StartGame(userId, userName, request.Value);

            return Ok();
        }

        [HttpGet("FinishGame")]
        public IActionResult FinishResult()
        {
            var message = _gameService.FinishGame();
            return Ok(message);
        }
    }
}