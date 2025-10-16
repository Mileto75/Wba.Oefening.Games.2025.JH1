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
    public class DevelopersController : Controller
    {
        private readonly DeveloperRepository _developerRepository;
        private readonly GameRepository _gameRepository;

        public DevelopersController()
        {
            //initialize service classes
            _developerRepository = new DeveloperRepository();
            _gameRepository = new GameRepository();
        }

       
        public IActionResult Index()
        {
            //get the developers
            //var developers = _developerRepository.GetDevelopers();
            //create and fill the model
            var developerIndexViewModel = new DevelopersIndexViewModel
            {
                Developers = _developerRepository.GetDevelopers().Select
                (d => new BaseViewModel
                {
                    Id = d.Id,
                    Name = d.Name
                })
            };
            //pass to the view
            return View(developerIndexViewModel);
        }

      
        public IActionResult ShowDeveloper(int id)
        {
            //get the developer
            var developer = _developerRepository
                .GetDevelopers()
                .FirstOrDefault(d => d.Id == id);
            //get the games
            var games = _gameRepository
                .GetGames()
                .Where(g => g.Developer.Id == id);
            //create and fill the model
            var developersShowDevelopersViewModel
                = new DevelopersShowDeveloperViewModel
                {
                    Id = developer.Id,
                    Name = developer.Name,
                    Games = games.Select(g =>
                    new BaseViewModel
                    {
                        Id = g.Id,
                        Name = g.Title
                    })
                };
            //pass to the view
            return View(developersShowDevelopersViewModel);
        }
        public IActionResult Games(int id)
        {
            //show all the games of one developer
            //check if developer exists!(Noah method)
            var developer = _developerRepository
                .GetDevelopers()
                .FirstOrDefault(d => d.Id == id);
            if (developer == null)
            {
                return NotFound();
            }
            //if (_developerRepository.GetDevelopers().Any(d => d.Id == id) == false)
            //{
            //    return NotFound();
            //}
            //get the games of the developerId
            var games = _gameRepository
                .GetGames()
                .Where(g => g.Developer.Id == id);
            //create the model
            //fill the model
            var developersGamesViewModel = new DevelopersGamesViewModel
            {
                Games = games.Select(g => new BaseViewModel
                {
                    Id = g.Id,
                    Name = g.Title,
                    Image = g.Image
                }),
                Developer = developer.Name
            };
            //pass to the view
            return View(developersGamesViewModel);
        }

    }
}