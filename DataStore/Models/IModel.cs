using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStore.Models
{
    public interface IModel
    {
        bool Success { get; }
        System.Exception Exception { get; }
    }
}
