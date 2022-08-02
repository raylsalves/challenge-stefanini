using AutoMapper;
using Stefanini.Challenge.Domain.Dtos.Request.City;
using Stefanini.Challenge.Domain.Dtos.Response.City;
using Stefanini.Challenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stefanini.Challenge.Domain.Mappers
{
    public class CityMapper : Profile
    {
        public CityMapper()
        {
            CreateMap<City,CityResponse>();
            CreateMap<CreateCityRequest, City>();
            CreateMap<City, CreateCityResponse>();
            CreateMap<City, UpdateCityResponse>();
            CreateMap<UpdateCityRequest, City>();
            CreateMap<City, DeleteCityResponse>();
        }

    }
}
