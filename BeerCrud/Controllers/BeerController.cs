using BeerCrud.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BeerCrud.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BeerController : ControllerBase
    {
        private int _id = 0;

        private List<Beer> beers = new List<Beer>();

        public BeerController()
        {
            PostBeer("Балтика 7", "Светлый лагер", "Россия", 450, 5.4, 57);
            PostBeer("Corona Extra", "Светлый лагер", "Мексика", 355, 4.5, 134.99);
            PostBeer("Guinness", "Стаут", "Ирландия", 440, 4.1, 223);
            PostBeer("Krusovice", "Темный лагер", "Чехия", 430, 4.1, 85);
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
        public Beer UpdateBeer(int id, string name, string sort, string country, double volume, double spirtVolume, double price)
        {
            beers.RemoveAt(id);
            Beer beer = new Beer {Id = id, Name = name, Sort = sort, Country = country, Volume = volume, SpirtVolume = spirtVolume, Price = price };
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
        public Beer PostBeer(string name, string sort, string country, double volume, double spirtVolume, double price)
        {
            _id++;
            Beer beer = new Beer {Id = _id, Name = name, Sort = sort, Country = country, Volume = volume, SpirtVolume = spirtVolume, Price = price };
            beers.Add(beer);
            return beer;
        }
    }
}