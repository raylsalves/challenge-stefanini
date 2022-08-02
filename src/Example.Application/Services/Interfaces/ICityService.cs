using Stefanini.Challenge.Domain.Dtos.Request.City;
using Stefanini.Challenge.Domain.Dtos.Response.City;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stefanini.Challenge.Application.Services.Interfaces
{
    public interface ICityService
    {
        Task<ICollection<CityResponse>> GetAllAsync();
        Task<CreateCityResponse> CreateAsync(CreateCityRequest request);
        Task<UpdateCityResponse> UpdateAsync(int id, UpdateCityRequest request);
        Task<CityResponse> GetAsync(int id);
        Task<DeleteCityResponse> DeleteAsync(int id);
    }
}
