using CarStore.Bll.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarStore.Bll.Services.Interfaces
{
    public interface ICarService
    {
        Task<IEnumerable<CarDto>> GetAsync();
        Task<CarDto> GetAsync(int id);
        Task AddAsync(CarDto dto);
        Task UpdateAsync(CarDto dto);
        Task RemoveAsync(int id);
    }
}
