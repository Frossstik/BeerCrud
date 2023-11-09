namespace BeerCrud.Models
{
    public class Beer
    {
        private static int IdCounter = 0;
        public Beer()
        {
            IdCounter++;
            Id = IdCounter;
        }
        public int Id { get; private set; }
        public string Name { get; set; }

        public string Sort { get; set; }

        public string Country { get; set; }

        public double Volume { get; set; }

        public double SpirtVolume { get; set; }
    }
}
