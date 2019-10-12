using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStore.Models
{
    public class Model:IModel
    {
        public bool Success { get; private set; }
        public System.Exception Exception { get; private set; }

        public Model()
        {
            Success = false;
            Exception = new System.ArgumentException("no info given");
        }

        public Model(System.Exception exception)
        {
            Success = false;
            Exception = exception;
        }

        /*
        public object Clone()
        {
            return this.MemberwiseClone();
        }
        */

        public Model(IModel info)
        {
            Init(info);
        }
        
        public virtual void Init(IModel info)
        {
            throw new System.NotImplementedException();
        }
    }
}
