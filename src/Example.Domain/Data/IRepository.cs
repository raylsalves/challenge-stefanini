using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stefanini.Challenge.Domain.Data
{
    public interface IRepository<T>
    {

        public IUnitOfWork UnitOfWork { get; }

    }
}
