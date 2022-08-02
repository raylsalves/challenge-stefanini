using Stefanini.Challenge.Domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stefanini.Challenge.Domain.Entities
{
    public class City : BaseEntity
    {
        public City()
        {
            
        }
        public string Name { get; set; }
        public string UF { get; set; }
        public ICollection<Person> Persons { get; set; }

    }
}
