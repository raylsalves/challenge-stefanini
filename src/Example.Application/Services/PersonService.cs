using AutoMapper;
using Microsoft.Extensions.Logging;
using Stefanini.Challenge.Application.Common;
using Stefanini.Challenge.Application.Services.Interfaces;
using Stefanini.Challenge.Domain.Dtos.Request.Person;
using Stefanini.Challenge.Domain.Dtos.Response.Person;
using Stefanini.Challenge.Domain.Entities;
using Stefanini.Challenge.Infra.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stefanini.Challenge.Application.Services
{
    public class PersonService : BaseService<PersonService>, IPersonService
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Person> _personRepository;

        public PersonService(ILogger<PersonService> logger, IMapper mapper, IGenericRepository<Person> personRepository) : base(logger)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public async Task<CreatePersonResponse> CreateAsync(CreatePersonRequest request)
        {
            if (request == null)
                throw new ArgumentException("Request empty!");

            Person person = _mapper.Map<Person>(request);

            await _personRepository.CreateAsync(person);

            return _mapper.Map<CreatePersonResponse>(person);
        }

        public async Task<ICollection<PersonResponse>> GetAllAsync()
        {
            IEnumerable<Person> persons = await _personRepository.GetAllAsync();
            return _mapper.Map<ICollection<PersonResponse>>(persons);
        }

        public async Task<PersonResponse> GetAsync(int id)
        {
            Person? person = await _personRepository.GetAsync(id);
            return _mapper.Map<PersonResponse>(person);
        }

        public async Task<UpdatePersonResponse> UpdateAsync(int id, UpdatePersonRequest request)
        {
            if (request == null)
                throw new ArgumentException("Request empty!");

            Person? person = await _personRepository.GetAsync(id);

            if (person != null)
            {
                person.Name = request.Name;
                person.CPF = request.CPF;
                person.Age = request.Age;
                person.CityId = request.CityId;
                await _personRepository.UpdateAsync(person);
            }

            return _mapper.Map<UpdatePersonResponse>(person);
        }

        public async Task<DeletePersonResponse> DeleteAsync(int id)
        {
            Person? person = await _personRepository.GetAsync(id);

            if (person != null)
                await _personRepository.DeleteAsync(person);

            return _mapper.Map<DeletePersonResponse>(person);
        }

    }
}
