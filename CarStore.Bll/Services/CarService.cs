using AutoMapper;
using CarStore.Bll.DTOs;
using CarStore.Bll.Services.Interfaces;
using CarStore.Dal.Entities;
using CarStore.Dal.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarStore.Bll.Services
{
    public class CarService : ICarService
    {
        private readonly IMapper _mapper;
        private readonly ICarRepository _carRepository;

        public CarService(IMapper mapper, ICarRepository carRepository)
        {
            _mapper = mapper;
            _carRepository = carRepository;
        }

        public async Task AddAsync(CarDto dto)
        {
            var entity = _mapper.Map<Car>(dto);
            await _carRepository.AddAsync(entity);
        }

        public async Task<CarDto> GetAsync(int id)
        {
            var entity = await _carRepository.GetAsync(id);
            var dto = _mapper.Map<CarDto>(entity);

            return dto;
        }

        public async Task<IEnumerable<CarDto>> GetAsync()
        {
            var entities = await _carRepository.GetAsync();
            var dtos = _mapper.Map<IEnumerable<CarDto>>(entities);

            return dtos;
        }

        public async Task UpdateAsync(CarDto dto)
        {
            var entity = await _carRepository.GetAsync(dto.Id);
            entity.Marka = dto.Marka;

            await _carRepository.UpdateAsync(entity);
        }

        public async Task RemoveAsync(int id)
        {
            var entity = await _carRepository.GetAsync(id);
            if (entity == null)
            {
                return;
            }

            await _carRepository.RemoveAsync(id);
        }
    }
}
