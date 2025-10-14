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

        public DevelopersController()
        {
            //initialize service classes
            _developerRepository = new DeveloperRepository();
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
            //get the games
            //create and fill the model
            //pass to the view
            return Content("I should make a view + view model for this!");
        }

        public IActionResult Games(int id)
        {
            //show all the games of one developer
            return View();
        }

    }
}