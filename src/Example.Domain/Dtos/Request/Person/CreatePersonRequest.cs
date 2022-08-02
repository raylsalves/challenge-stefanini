using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stefanini.Challenge.Domain.Dtos.Request.Person
{
    public class CreatePersonRequest
    {
        public string Name { get; set; }
        public string CPF { get; set; }
        public int Age { get; set; }
        public int CityId { get; set; }
    }
}
