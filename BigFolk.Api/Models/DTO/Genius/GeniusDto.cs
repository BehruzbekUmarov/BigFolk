﻿using BigFolk.Api.Models.Domain;

namespace BigFolk.Api.Models.DTO.Genius
{
    public class GeniusDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? ImageUrl { get; set; }

        public List<Domain.Car> Cars { get; set; } = new List<Domain.Car>();
        public List<Domain.SmartHouse> SmartHouses { get; set; } = new List<Domain.SmartHouse>();
        public List<Company> Companies { get; set; } = new List<Company>();
        public List<Habit> Habits { get; set; } = new List<Habit>();
        public List<Portfolio> Portfolios { get; set; } = new List<Portfolio>();
    }
}