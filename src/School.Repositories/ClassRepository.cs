using Dapper;
using School.Core.Models;
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

        public void Insert(Class @class)
        {
            const string sql = @"SET IDENTITY_INSERT dbo.Class ON
            INSERT INTO dbo.Class
            (
                Local
                CourseId 
                TeacherId
                Shift
                StartDate
                EndDate
                StartTime
                EndTime
            )
            VALUES
            (
                @Local
                @CourseId 
                @TeacherId
                @Shift
                @StartDate
                @EndDate
                @StartTime
                @EndTime
            )";

            DynamicParameters parameters = new DynamicParameters();
            parameters.AddDynamicParams(new { 
                //ClassId = @class.ClassId,
                Local = @class.Local,
                CourseId  = @class.CourseId,
                TeacherId = @class.TeacherId,
                Shift = @class.Shift,
                StartDate = @class.StartDate,
                EndDate = @class.EndDate,
                StartTime = @class.StartTime,
                EndTime = @class.EndTime
            });

            using (SqlConnection sqlConnection = GetSqlConnection())
            {
                sqlConnection.Execute(sql, parameters);
            }
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
            parameter.Add("ClassId", classId, DbType.Byte);

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
