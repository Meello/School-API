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

        public bool ExistByName(string name)
        {
            const string sql = @"SELECT
                1
            FROM
                dbo.Course
            WHERE
                Name = @Name";

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("Name", name, DbType.String);

            using (SqlConnection sqlConnection = GetSqlConnection())
            {
                bool exist = sqlConnection.ExecuteScalar<bool>(sql, parameters);

                return exist;
            }
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
            parameters.Add("Name", name, DbType.String);

            using (SqlConnection sqlConnection = GetSqlConnection())
            {
                int courseId = sqlConnection.ExecuteScalar<int>(sql, parameters);

                return courseId;
            }
        }

        private SqlConnection GetSqlConnection()
        {
            return new SqlConnection(this._connectionString);
        }
    }
}
