using CarStore.Bll.DTOs;
using CarStore.Bll.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarStore.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpPost]
        public async Task Create(CarDto carDto)
        {
            await _carService.AddAsync(carDto);
        }

        [HttpGet]
        public async Task<IEnumerable<CarDto>> Get()
        {
            return await _carService.GetAsync();
        }

        [HttpGet("{id}")]
        public async Task<CarDto> Get(int id)
        {
            return await _carService.GetAsync(id);
        }

        [HttpPut]
        public async Task Update(CarDto carDto)
        {
            await _carService.UpdateAsync(carDto);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _carService.RemoveAsync(id);
        }
    }
}
