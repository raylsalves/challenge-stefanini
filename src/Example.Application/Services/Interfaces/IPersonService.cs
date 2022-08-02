using Stefanini.Challenge.Domain.Dtos.Request.Person;
using Stefanini.Challenge.Domain.Dtos.Response.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stefanini.Challenge.Application.Services.Interfaces
{
    public interface IPersonService
    {
        Task<ICollection<PersonResponse>> GetAllAsync();
        Task<CreatePersonResponse> CreateAsync(CreatePersonRequest request);
        Task<UpdatePersonResponse> UpdateAsync(int id, UpdatePersonRequest request);
        Task<PersonResponse> GetAsync(int id);
        Task<DeletePersonResponse> DeleteAsync(int id);
    }
}
