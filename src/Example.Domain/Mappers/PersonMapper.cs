using AutoMapper;
using Stefanini.Challenge.Domain.Dtos.Request.Person;
using Stefanini.Challenge.Domain.Dtos.Response.Person;
using Stefanini.Challenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stefanini.Challenge.Domain.Mappers
{
    public class PersonMapper : Profile
    {

        public PersonMapper()
        {
            CreateMap<Person, PersonResponse>();
            CreateMap<CreatePersonRequest, Person>();
            CreateMap<Person, CreatePersonResponse>();
            CreateMap<Person, UpdatePersonResponse>();
            CreateMap<UpdatePersonRequest, Person>();
            CreateMap<Person, DeletePersonResponse>();
        }

    }
}
