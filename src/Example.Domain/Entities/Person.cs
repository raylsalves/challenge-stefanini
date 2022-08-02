using Stefanini.Challenge.Domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stefanini.Challenge.Domain.Entities
{
    public class Person : BaseEntity
    {
        public int CityId { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public int Age { get; set; }
        public City City { get; set; }
    }
}
