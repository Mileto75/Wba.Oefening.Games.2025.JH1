using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Wba.Oefening.Games.Core.Repositories;
using Wba.Oefening.Games.Web.ViewModels;

namespace Wba.Oefening.Games.Web.Controllers
{

    public class GamesController : Controller
    {
        private readonly GameRepository _gameRepository;

        public GamesController()
        {
            _gameRepository = new GameRepository();
        }

       
        public IActionResult Index()
        {
            //get the games from the gamerepository
            var games = _gameRepository.GetGames();
            //declare a viewmodel
            //put data in viewmodel
            var gamesIndexViewModel = new GamesIndexViewModel
            {
                Games = games.Select(g => new BaseViewModel
                { 
                    Id = g.Id,
                    Name = g.Title
                })
            };
            //pass the model to the view
            return View(gamesIndexViewModel);
        }

        
        public IActionResult ShowGame(int id)
        {
            //get the game from the Gamerepository
            var game = _gameRepository
                .GetGames()
                .FirstOrDefault(g => g.Id == id);
            //check if null => return NotFound()
            if(game == null)
            {
                return NotFound();
            }
            //create and fill the viewmodel
            var gamesShowGameViewModel
                = new GamesShowGameViewModel
                {
                    Id = game.Id,
                    Name = game.Title,
                    Developer = new BaseViewModel
                    {
                        Id = game.Developer.Id,
                        Name = game.Developer.Name
                    },
                    Rating = game.Rating
                };
            //pass to the view
            return View(gamesShowGameViewModel);
        }

    }
}