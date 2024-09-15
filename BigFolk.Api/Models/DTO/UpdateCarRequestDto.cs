﻿namespace BigFolk.Api.Models.DTO
{
    public class UpdateCarRequestDto
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string State { get; set; }
        public string? ImageUrl { get; set; } = string.Empty;
        public Guid GeniusId { get; set; }
    }
}
