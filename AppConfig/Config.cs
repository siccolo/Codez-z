using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppConfig
{
    public interface IConfig
    {
         string ConnectionInfo { get; set; }
        string UserName { get; set; }
    }

    public class Config:IConfig
    {
        public string ConnectionInfo { get; set; }
        public string UserName { get; set; }
    }
}
