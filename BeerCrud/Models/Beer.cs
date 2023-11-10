namespace BeerCrud.Models
{
    public class Beer
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public string Sort { get; set; }

        public string Country { get; set; }

        public double Volume { get; set; } //.мл

        public double SpirtVolume { get; set; }//%

        public double Price { get; set; }
    }
}
