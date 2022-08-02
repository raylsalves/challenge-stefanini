using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stefanini.Challenge.Domain.Dtos.Response
{
    public abstract class BaseResponse
    {

        public bool Success { get; set; } = true;
        public object? Error { get; set; } = null;

    }
}
