using BigFolk.Api.Models.Domain;
using BigFolk.Api.Models.DTO;
using BigFolk.Api.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BigFolk.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarRepository _carRepository;

        public CarController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var carDomain = await _carRepository.GetAllAsync();

            if(carDomain == null) return NotFound();

            var carDto = new List<CarDto>();
            foreach (var car in carDomain)
            {
                carDto.Add(new CarDto
                {
                    Id = car.Id,
                    Name = car.Name,
                    Type = car.Type,
                    State = car.State,
                    ImageUrl = car.ImageUrl,
                    CreatedOn = car.CreatedOn,
                    GeniusId = car.GeniusId,
                });
            }

            return Ok(carDto);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var carDomain = await _carRepository.GetByIdAsync(id);

            if(carDomain == null) return NotFound();

            var carDto = new CarDto
            {
                Id = carDomain.Id,
                Name = carDomain.Name,
                Type = carDomain.Type,
                State = carDomain.State,
                ImageUrl = carDomain.ImageUrl,
                CreatedOn = carDomain.CreatedOn,
                GeniusId = carDomain.GeniusId,
            };

            return Ok(carDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddCarRequestDto requestDto)
        {
            var carDomain = new Car()
            {
                Name = requestDto.Name,
                ImageUrl = requestDto.ImageUrl,
                State = requestDto.State,
                GeniusId= requestDto.GeniusId,
                Type = requestDto.Type,
            };

            carDomain = await _carRepository.CreateAsync(carDomain);
            if(carDomain == null) return NotFound();

            var carDto = new CarDto()
            {
                Id = carDomain.Id,
                Name = carDomain.Name,
                Type = carDomain.Type,
                State = carDomain.State,
                ImageUrl = carDomain.ImageUrl,
                CreatedOn = carDomain.CreatedOn,
                GeniusId = requestDto.GeniusId
            };

            return CreatedAtAction(nameof(GetById), new { id = carDto.Id }, carDto);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateCarRequestDto requestDto)
        {
            var carDomain = new Car()
            {
                Name = requestDto.Name,
                ImageUrl = requestDto.ImageUrl,
                State = requestDto.State,
                Type = requestDto.Type,
                GeniusId = requestDto.GeniusId
            };

            carDomain = await _carRepository.UpdateAsync(id, carDomain);
            if(carDomain == null) return NotFound();

            var carDto = new CarDto()
            {
                Id = carDomain.Id,
                Name = carDomain.Name,
                Type = carDomain.Type,
                State = carDomain.State,
                ImageUrl = carDomain.ImageUrl,
                CreatedOn = carDomain.CreatedOn,
                GeniusId = requestDto.GeniusId
            };

            return Ok(carDto);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var carDomain = await _carRepository.DeleteAsync(id);
            if(carDomain == null) return NotFound();

            var carDto = new CarDto()
            {
                Id = carDomain.Id,
                Name = carDomain.Name,
                Type = carDomain.Type,
                State = carDomain.State,
                ImageUrl = carDomain.ImageUrl,
                CreatedOn = carDomain.CreatedOn,
                GeniusId = carDomain.GeniusId
            };

            return Ok(carDto);
        }
    }
}
