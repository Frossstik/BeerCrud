using BeerCrud.Models;
using Microsoft.AspNetCore.Mvc;

namespace BeerCrud.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BeerController : ControllerBase
    {
        private List<Beer> beers = new List<Beer>();

        [HttpPost("/beer")]
        Beer PostBeer(string Name, string Sort, string Country, double Volume, double SpirtVolume )
        {
            Beer tempBeer = new Beer();
            tempBeer.Name = Name;
            tempBeer.Sort = Sort;
            tempBeer.Country = Country;
            tempBeer.Volume = Volume;
            tempBeer.SpirtVolume = SpirtVolume;
            beers.Add(tempBeer);
            return tempBeer;
        }

        [HttpGet("/beer")]
        IEnumerable<Beer> GetBeer()
        {
            return beers;
        }

        [HttpGet("/beer/{Id}")]
        Beer GetBeerById(int Id)
        {
            Beer tempBeer = null;
            foreach (var b in beers)
            {
                if (b.Id == Id)
                {
                    tempBeer = b;
                }
            }
            return tempBeer;
        }
    }
}