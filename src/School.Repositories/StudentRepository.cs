using Dapper;
using School.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace School.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly string _connectionString;

        public StudentRepository(string connectionString)
        {
            this._connectionString = connectionString;
        }

        public bool ExistByStudentId(long StudentId)
        {
            const string sql = @"SELECT
                1
            FROM
                dbo.Student
            WHERE
                StudentId = @StudentId;";

            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("StudentId", StudentId, DbType.Int64);

            using (SqlConnection sqlConnection = GetSqlConnection())
            {
                bool exist = sqlConnection.ExecuteScalar<bool>(sql, parameter);

                return exist;
            }
        }

        private SqlConnection GetSqlConnection()
        {
            return new SqlConnection(this._connectionString);
        }
    }
}
