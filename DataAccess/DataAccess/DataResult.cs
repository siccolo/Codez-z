using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DataResult:Result.IResult<System.Data.DataTable>
    {
        public bool Success { get; private set; }
        public System.Data.DataTable Result { get; private set; }

        public System.Exception Exception { get; private set; }

        public DataResult(System.Exception exception)
        {
            Success = false;
            Exception = exception;
        }

        public DataResult(System.Data.DataTable result)
        {
            Success = true;
            Exception = null;
            Result = result;
        }

    }


    public class ExecuteResult : Result.IResult<IEnumerable<System.Data.SqlClient.SqlParameter>>
    {
        public bool Success { get; private set; }
        public IEnumerable<System.Data.SqlClient.SqlParameter> Result { get; private set; }

        public System.Exception Exception { get; private set; }

        public ExecuteResult(System.Exception exception)
        {
            Success = false;
            Exception = exception;
        }

        public ExecuteResult(IEnumerable<System.Data.SqlClient.SqlParameter> result)
        {
            Success = false;
            Exception = null;
            Result = result;
        }

    }
}
