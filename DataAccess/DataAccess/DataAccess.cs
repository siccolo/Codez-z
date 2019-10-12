using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DataAccess: IDataAccess
    {
        private readonly string _connectionInfo = String.Empty;
        public DataAccess(AppConfig.IConfig config)
        {
            _connectionInfo = config.ConnectionInfo;
        }

        //public Result.IResult<System.Data.DataTable> Data(string commandSQL, IEnumerable<System.Data.SqlClient.SqlParameter> listParameter)
        public Result.IResult<System.Data.DataTable> Data(string commandSQL, IEnumerable<System.Data.SqlClient.SqlParameter> listParameter)
        {
            System.Data.DataTable dt = new System.Data.DataTable("data");

            using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(_connectionInfo))
            {
                try
                {
                    connection.Open();
                }
                catch (InvalidOperationException exOp)
                {
                    return new DataResult(exOp);
                }
                catch (System.Data.SqlClient.SqlException exSQL)
                {
                    return new DataResult(exSQL);
                }
                //
                using (System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand(commandSQL, connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    if (listParameter != null && listParameter.Any())
                    {
                        command.Parameters.AddRange(listParameter.Where(p => p != null).ToArray());
                    }
                    //
                    using (System.Data.SqlClient.SqlDataAdapter sqlAdapter = new System.Data.SqlClient.SqlDataAdapter(command))
                    {
                        sqlAdapter.Fill(dt);
                    }
                    //
                    command.Parameters.Clear();
                }
                //
                connection.Close();
            }

            return new DataResult(dt);
        }

        public async Task<Result.IResult<System.Data.DataTable>> DataAsync(string commandSQL, IEnumerable<System.Data.SqlClient.SqlParameter> listParameter)
        {
            System.Data.DataTable dt = new System.Data.DataTable("data");

            using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(_connectionInfo))
            {
                try
                {
                    await connection.OpenAsync().ConfigureAwait(false);
                }
                catch (InvalidOperationException exOp)
                {
                    return new DataResult(exOp);
                }
                catch (System.Data.SqlClient.SqlException exSQL)
                {
                    return new DataResult(exSQL);
                }
                //
                using (System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand(commandSQL, connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    if (listParameter != null && listParameter.Any())
                    {
                        command.Parameters.AddRange(listParameter.Where(p => p != null).ToArray());
                    }
                    //
                    using (var r = await command.ExecuteReaderAsync(System.Data.CommandBehavior.SequentialAccess).ConfigureAwait(false))
                    {
                        dt.Load(r);
                    }
                    //
                    command.Parameters.Clear();
                }
                //
                connection.Close();
            }

            return new DataResult(dt);
        }

        public Result.IResult<IEnumerable<System.Data.SqlClient.SqlParameter>> Execute(string commandSQL, IEnumerable<System.Data.SqlClient.SqlParameter> listParameter)
        {
            System.Data.SqlClient.SqlParameter[] listOutputParameter = new System.Data.SqlClient.SqlParameter[] { };

            using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(_connectionInfo))
            {
                try
                {
                    connection.Open();
                }
                catch (InvalidOperationException exOp)
                {
                    return new ExecuteResult(exOp);
                }
                catch (System.Data.SqlClient.SqlException exSQL)
                {
                    return new ExecuteResult(exSQL);
                }
                catch (Exception ex)
                {
                    return new ExecuteResult(ex);
                }
                //
                using (System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand(commandSQL, connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    if (listParameter != null && listParameter.Any())
                    {
                        command.Parameters.AddRange(listParameter.Where(p => p != null).ToArray());
                    }
                    //
                    //command.ExecuteNonQuery();
                    try
                    {
                        command.ExecuteNonQuery();
                        if (command.Parameters.Cast<System.Data.SqlClient.SqlParameter>().Any(c => c.Direction == System.Data.ParameterDirection.Output))
                        {
                            listOutputParameter = command.Parameters.Cast<System.Data.SqlClient.SqlParameter>().Where(c => c.Direction == System.Data.ParameterDirection.Output).ToArray();
                        }
                    }
                    catch (Exception ex)
                    {
                        return new ExecuteResult(ex);
                    }
                    command.Parameters.Clear();
                }
                //
                connection.Close();
            }

            return new ExecuteResult(listOutputParameter);
        }
    }
}
