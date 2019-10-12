using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject_DataAccess
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_GetData()
        {
            string connectionString = @"Data Source=10.1.1.1;Initial Catalog=DB;User ID=Tester;Password=Tester;Application Name=DataAccess.NET Test";

            string userName = "Tester";
            string sql = "PROC_GET_USER_DATA";
            var inParameters = new System.Collections.Generic.List<System.Data.SqlClient.SqlParameter>() { new System.Data.SqlClient.SqlParameter("@UserWinName", userName) };
            var da = new DataAccess.DataAccess(connectionInfo:connectionString);
            var result = da.Data(sql, inParameters);

            Assert.IsNotNull(result.Result);
        }

        [TestMethod]
        public void Test_FailData()
        {
            string connectionString = @"Data Source=10.1.1.1;Initial Catalog=DB;User ID=Tester;Password=Tester;Application Name=DataAccess.NET Test";

            string userName = "Tester";
            string sql = "PROC_GET_USER_DATA";
            var inParameters = new System.Collections.Generic.List<System.Data.SqlClient.SqlParameter>() { new System.Data.SqlClient.SqlParameter("@UserWinName", userName) };
            var da = new DataAccess.DataAccess(connectionInfo: connectionString);
            var result = da.Data(sql, inParameters);

            Assert.IsNotNull(result.Exception) ;
        }

        [TestMethod]
        public async Task Test_GetData_Async()
        {
            string connectionString = @"Data Source=10.1.1.1;Initial Catalog=DB;User ID=Tester;Password=Tester;Application Name=DataAccess.NET Test";

            string userName = "Tester";
            string sql = "PROC_GET_USER_DATA";
            var inParameters = new System.Collections.Generic.List<System.Data.SqlClient.SqlParameter>() { new System.Data.SqlClient.SqlParameter("@UserWinName", userName) };
            var da = new DataAccess.DataAccess(connectionInfo: connectionString);
            var result = await da.DataAsync(sql, inParameters);

            Assert.IsNotNull(result.Result);
        }

        [TestMethod]
        public void Test_Execute()
        {
            string connectionString = @"Data Source=10.1.1.1;Initial Catalog=DB;User ID=Tester;Password=Tester;Application Name=DataAccess.NET Test";

            string userName = "Tester";
            string sql = "PROC_GET_USER_DATA";
            var inParameters = new System.Collections.Generic.List<System.Data.SqlClient.SqlParameter>() { new System.Data.SqlClient.SqlParameter("@UserWinName", userName) };
            var da = new DataAccess.DataAccess(connectionInfo: connectionString);
            var result = da.Execute(sql, inParameters);

            Assert.IsNotNull(result.Result);
        }

        [TestMethod]
        public void Test_GetUserInfo()
        {
            string connectionString = @"Data Source=10.1.1.1;Initial Catalog=DB;User ID=Tester;Password=Tester;Application Name=DataAccess.NET Test";

            string userName = "Tester";
            string sql = "PROC_GET_USER_DATA";
            var inParameters = new System.Collections.Generic.List<System.Data.SqlClient.SqlParameter>() { new System.Data.SqlClient.SqlParameter("@UserWinName", userName) };
            var da = new DataAccess.DataAccess(connectionInfo: connectionString);
            var result = da.Data(sql, inParameters);

            Assert.IsNotNull(result.Result);
        }
    }
}
