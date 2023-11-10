using BeerCrud.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BeerCrud.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class BeerController : ControllerBase
    {
        private int _id = 0;

        private List<Beer> beers = new List<Beer>();

        public BeerController()
        {
            PostBeer(new Beer
            {
                Name = "Балтика 7",
                Sort = "Светлый лагер",
                Country = "Россия",
                Volume = 450,
                SpirtVolume = 5.4,
                Price = 57
            });
            PostBeer(new Beer
            {
                Name = "Corona Extra",
                Sort = "Светлый лагер",
                Country = "Мексика",
                Volume = 355,
                SpirtVolume = 4.5,
                Price = 134.99
            });
            PostBeer(new Beer
            {
                Name = "Guinness",
                Sort = "Стаут",
                Country = "Ирландия",
                Volume = 440,
                SpirtVolume = 4.1,
                Price = 223
            });
            PostBeer(new Beer
            {
                Name = "Krusovice",
                Sort = "Темный лагер",
                Country = "Чехия",
                Volume = 430,
                SpirtVolume = 4.1,
                Price = 85
            });
            /*
            PostBeer("Corona Extra", "Светлый лагер", "Мексика", 355, 4.5, 134.99);
            PostBeer("Guinness", "Стаут", "Ирландия", 440, 4.1, 223);
            PostBeer("Krusovice", "Темный лагер", "Чехия", 430, 4.1, 85);
            */
        }


        [HttpGet("/beer/{id}")]
        public Beer GetBeerById(int id)
        {
            return beers.Find(b => b.Id == id);
        }

        [HttpGet("/beer")]
        public IEnumerable<Beer> GetBeer()
        {
            return beers;
        }

        [HttpPut("/beer/{id}")]
        public Beer UpdateBeer(int id, Beer beer)
        {
            beers.RemoveAt(id);
            beers.Add(beer);
            return beer;
        }

        [HttpDelete("/beer")]
        public void DeleteAllBeer()
        {
            beers.Clear();
        }

        [HttpDelete("/beer/{id}")]
        public void DeleteBeer(int id)
        {
            beers.RemoveAll(b => b.Id == id);
        }

        [HttpPost("/beer")]
        public Beer PostBeer(Beer beer)
        {
            _id++;
            beer.Id = _id;
            beers.Add(beer);
            return beer;
        }
    }
}