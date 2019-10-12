using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IDataAccess
    {
        Result.IResult<System.Data.DataTable> Data(string sql, IEnumerable<System.Data.SqlClient.SqlParameter> inList);

        Task<Result.IResult<System.Data.DataTable>> DataAsync(string sql, IEnumerable<System.Data.SqlClient.SqlParameter> inList);

        Result.IResult<IEnumerable<System.Data.SqlClient.SqlParameter>> Execute(string sql, IEnumerable<System.Data.SqlClient.SqlParameter> inList);
    }
}
