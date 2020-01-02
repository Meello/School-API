using Dapper;
using School.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace School.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly string _connectionString;

        public CourseRepository(string connectionString)
        {
            this._connectionString = connectionString;
        }

        public int GetCourseIdByName(string name)
        {
            const string sql = @"SELECT
                CourseId
            FROM
                dbo.Course
            WHERE
                Name = @Name";

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("Name", name, DbType.Int64);

            using (SqlConnection sqlConnection = GetSqlConnection())
            {
                return sqlConnection.ExecuteScalar<int>(sql, parameters);
            }
        }

        private SqlConnection GetSqlConnection()
        {
            return new SqlConnection(this._connectionString);
        }
    }
}
