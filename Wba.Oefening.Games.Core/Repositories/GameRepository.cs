using System.Collections.Generic;
using System.Linq;
using Wba.Oefening.Games.Core.Entities;

namespace Wba.Oefening.Games.Core.Repositories
{
    public class GameRepository
    {
        public IEnumerable<Game> GetGames()
        {
            DeveloperRepository developerRepository = new DeveloperRepository();
            return new List<Game>
            {
                new Game
                {
                    Id = 1,
                    Title = "Wolfenstein Colossus",
                    Rating = 1,
                    Developer =
                        developerRepository.GetDevelopers().
                            First(d => d.Id == 1),
                    Image = "game1.jpg"
                },
                new Game
                {
                    Id = 2,
                    Title ="FIFA 2020",
                    Rating = 2,
                    Developer =
                        developerRepository.GetDevelopers().
                            First(d => d.Id == 2),
                    Image = "game2.jpg"
                },
                new Game
                {
                    Id = 3,
                    Title ="Elder Scrolls V: Skyrim",
                    Rating = 5,
                    Developer =
                        developerRepository.GetDevelopers().
                            First(d => d.Id == 3),
                    Image = "game3.jpg"
                },
                new Game
                {
                    Id = 4,
                    Title ="Fallout 4",
                    Rating = 3,
                    Developer =
                        developerRepository.GetDevelopers().
                            First(d => d.Id == 3),
                    Image = "game4.jpg"
                }
            };
        }
    }
}
