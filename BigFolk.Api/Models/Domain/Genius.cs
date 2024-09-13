namespace BigFolk.Api.Models.Domain
{
    public class Genius
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? ImageUrl { get; set; }

        public ICollection<Car> Cars { get; set; } = new List<Car>();
        public ICollection<SmartHouse> SmartHouses { get; set; } = new List<SmartHouse>();
        public ICollection<Company> Companies { get; set; } = new List<Company>();
        public ICollection<Habit> Habits { get; set; } = new List<Habit>();
        public List<Portfolio> Portfolios { get; set; } = new List<Portfolio>();
    }
}
