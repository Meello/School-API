using Dapper;
using School.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace School.Repositories
{
    public class ClassRepository : IClassRepository
    {
        private readonly string _connectionString;

        public ClassRepository(string connectionString)
        {
            this._connectionString = connectionString;
        }

        public bool ExistByClassId(byte classId)
        {
            const string sql = @"SELECT
                1
            FROM
                dbo.Class
            WHERE
                ClassId = @ClassId;";

            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("ClassId",classId,DbType.Byte);

            using (SqlConnection sqlConnection = this.GetSqlConnection())
            {
                bool exist = sqlConnection.ExecuteScalar<bool>(sql,parameter);

                return exist;
            }
        }

        private SqlConnection GetSqlConnection()
        {
            return new SqlConnection(this._connectionString);
        }
    }
}
