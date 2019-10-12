using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Result
{
    public interface IResult<T>
    {
        bool Success { get; }
        T Result { get; }

        System.Exception Exception { get; }
    }
}
