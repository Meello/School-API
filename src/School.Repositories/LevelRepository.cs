using Dapper;
using School.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace School.Repositories
{
    public class LevelRepository : ILevelRepository
    {
        private readonly string _connectionString;

        public LevelRepository(string connectionString)
        {
            this._connectionString = connectionString;
        }

        public bool ExistByLevelId(char levelId)
        {
            const string sql = @"SELECT 
                1
            FROM
                dbo.Level
            WHERE
                LevelId = @levelId";

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("levelId", levelId, DbType.String);

            using (SqlConnection sqlConnection = GetSqlConnection())
            {
                return sqlConnection.ExecuteScalar<bool>(sql, parameters);
            }
        }

        public IEnumerable<char> ListAll()
        {
            const string sql = @"SELECT 
                LevelId
            FROM
                dbo.Level";

            using (SqlConnection sqlConnection = GetSqlConnection())
            {
                return sqlConnection.Query<char>(sql);
            }
        }

        private SqlConnection GetSqlConnection()
        {
            return new SqlConnection(this._connectionString);
        }
    }
}
