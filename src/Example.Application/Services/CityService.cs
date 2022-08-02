using AutoMapper;
using Microsoft.Extensions.Logging;
using Stefanini.Challenge.Application.Common;
using Stefanini.Challenge.Application.Services.Interfaces;
using Stefanini.Challenge.Domain.Dtos.Request.City;
using Stefanini.Challenge.Domain.Dtos.Response.City;
using Stefanini.Challenge.Domain.Entities;
using Stefanini.Challenge.Infra.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stefanini.Challenge.Application.Services
{
    public class CityService : BaseService<CityService>, ICityService
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<City> _cityRepository;

        public CityService(ILogger<CityService> logger, IMapper mapper, IGenericRepository<City> cityRepository) : base(logger)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        public async Task<CreateCityResponse> CreateAsync(CreateCityRequest request)
        {
            if (request == null)
                throw new ArgumentException("Request empty!");

            City city = _mapper.Map<City>(request);

            await _cityRepository.CreateAsync(city);

            return _mapper.Map<CreateCityResponse>(city);
        }

        public async Task<ICollection<CityResponse>> GetAllAsync()
        {
            IEnumerable<City> cities = await _cityRepository.GetAllAsync();
            return _mapper.Map<ICollection<CityResponse>>(cities);
        }

        public async Task<CityResponse> GetAsync(int id)
        {
            City? city = await _cityRepository.GetAsync(id);
            return _mapper.Map<CityResponse>(city);
        }

        public async Task<UpdateCityResponse> UpdateAsync(int id, UpdateCityRequest request)
        {
            if (request == null)
                throw new ArgumentException("Request empty!");

            City? city = await _cityRepository.GetAsync(id);

            if (city != null)
            {
                city.Name = request.Name;
                city.UF = request.UF;
                await _cityRepository.UpdateAsync(city);
            }

            return _mapper.Map<UpdateCityResponse>(city);
        }

        public async Task<DeleteCityResponse> DeleteAsync(int id)
        {
            City? city = await _cityRepository.GetAsync(id);

            if (city != null) 
                await _cityRepository.DeleteAsync(city);

            return _mapper.Map<DeleteCityResponse>(city);
        }
    }
}
