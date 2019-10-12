using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStore
{
    public class DataStoreManagemer: IDataStore
    {
        DataAccess.IDataAccess _DataAccess;

        public DataStoreManagemer(DataAccess.IDataAccess dataAccess)
        {
            _DataAccess = dataAccess;
        }

        public async Task<Models.UserInfoModel> UserInfo(string userName)
        {
            string sql = "PROC_GET_USER_DATA";
            var inParameters = new System.Collections.Generic.List<System.Data.SqlClient.SqlParameter>() { new System.Data.SqlClient.SqlParameter("@UserWinName", userName) };
            var result = await _DataAccess.DataAsync(sql, inParameters).ConfigureAwait(false);
            if (result.Success)
            {
                System.Data.DataTable dt = (System.Data.DataTable)result.Result;
                if (dt.Rows.Count > 0)
                {
                    return new Models.UserInfoModel(dt.Rows[0]);
                }
                else
                {
                    return new Models.UserInfoModel();
                }
            }
            else
            {
                return new Models.UserInfoModel(result.Exception);
            }
        }
    }
}
