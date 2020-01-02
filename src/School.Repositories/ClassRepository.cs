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

        public void Insert(List<Class> schoolClasses)
        {
            const string sql = @"InsertSchoolClass";

            using (SqlConnection sqlConnection = GetSqlConnection())
            {
                sqlConnection.Execute(sql, schoolClasses, commandType: CommandType.StoredProcedure);
            }
        }

        public void Insert(Class schoolClass)
        {
            const string sql = @"InsertSchoolClass";

            DynamicParameters parameters = new DynamicParameters();
            parameters.AddDynamicParams(new { 
                ClassId = schoolClass.ClassId,
                Local = schoolClass.Local,
                CourseId  = schoolClass.CourseId,
                TeacherId = schoolClass.TeacherId,
                Shift = schoolClass.Shift,
                StartDate = schoolClass.StartDate,
                EndDate = schoolClass.EndDate,
                StartTime = schoolClass.StartTime,
                EndTime = schoolClass.EndTime
            });

            using (SqlConnection sqlConnection = GetSqlConnection())
            {
                sqlConnection.Execute(sql, parameters, commandType : CommandType.StoredProcedure);
            }
        }

        public bool ExistByClassId(int classId)
        {
            const string sql = @"SELECT
                1
            FROM
                dbo.Class
            WHERE
                ClassId = @ClassId;";

            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("ClassId", classId, DbType.Int32);

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
