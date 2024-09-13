﻿using BigFolk.Api.Data;
using BigFolk.Api.Models.Domain;
using BigFolk.Api.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BigFolk.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeniusController : ControllerBase
    {
        private readonly BigFolkDbContext _dbContext;
        public GeniusController(BigFolkDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var geniusDomain = _dbContext.Geniuses.ToList();

            if(geniusDomain ==  null) return NotFound();

            var geniusDto = new List<GeniusDto>();
            foreach(var genius in geniusDomain)
            {
                geniusDto.Add(new GeniusDto()
                {
                    Id = genius.Id,
                    Name = genius.Name,
                    ImageUrl = genius.ImageUrl,
                    Cars = genius.Cars,
                    Companies = genius.Companies,
                    SmartHouses = genius.SmartHouses,
                    Habits = genius.Habits,
                    Portfolios = genius.Portfolios
                });
            }

            return Ok(geniusDto);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var geniusDomain = _dbContext.Geniuses.FirstOrDefault(x => x.Id == id);

            if(geniusDomain == null) return NotFound();

            var geniusDto = new GeniusDto
            {
                Id = geniusDomain.Id,
                Name = geniusDomain.Name,
                ImageUrl = geniusDomain.ImageUrl,
                Cars = geniusDomain.Cars,
                SmartHouses = geniusDomain.SmartHouses,
                Companies = geniusDomain.Companies,
                Habits = geniusDomain.Habits,
                Portfolios = geniusDomain.Portfolios
            };

            return Ok(geniusDto);
        }

        [HttpPost]
        public IActionResult Create([FromBody] AddGeniusRequestDto requestDto)
        {
            var geniusDomain = new Genius()
            {
                Name = requestDto.Name,
                ImageUrl = requestDto.ImageUrl
            };

            _dbContext.Add(geniusDomain);
            _dbContext.SaveChanges();

            var geniusDto = new GeniusDto
            {
                Id = geniusDomain.Id,
                Name = geniusDomain.Name,
                ImageUrl = geniusDomain.ImageUrl
            };

            return CreatedAtAction(nameof(GetById), new { id = geniusDto.Id }, geniusDto);   
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public IActionResult Update([FromRoute] Guid id, UpdateGeniusRequestDto requestDto)
        {
            var geniusDomain = _dbContext.Geniuses.FirstOrDefault(x => x.Id == id);
            if (geniusDomain == null) return NotFound();

            geniusDomain.Name = requestDto.Name;
            geniusDomain.ImageUrl = requestDto.ImageUrl;

            _dbContext.SaveChanges();

            var geniusDto = new GeniusDto 
            {
                Id = geniusDomain.Id,
                Name = geniusDomain.Name,
                ImageUrl= geniusDomain.ImageUrl
            };

            return Ok(geniusDto);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            var geniusDomain = _dbContext.Geniuses.FirstOrDefault(x =>x.Id == id);  

            if(geniusDomain == null) return NotFound();

            _dbContext.Remove(geniusDomain);
            _dbContext.SaveChanges();

            var geniusDto = new GeniusDto
            {
                Id = geniusDomain.Id,
                Name = geniusDomain.Name,
                ImageUrl = geniusDomain.ImageUrl
            };

            return Ok(geniusDto);
        }
    }
}
