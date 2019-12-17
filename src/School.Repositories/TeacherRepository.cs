using Dapper;
using Microsoft.Extensions.Configuration;
using School.Core.Models;
using School.Core.Repositories;
using StoneCo.Buy4.School.DataContracts;
using StoneCo.Buy4.School.DataContracts.DeleteTeacher;
using StoneCo.Buy4.School.DataContracts.SearchTeacher;
using StoneCo.Buy4.School.DataContracts.InsertTeacher;
using StoneCo.Buy4.School.DataContracts.UpdateTeacher;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using School.Core.Filters;

namespace School.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly string _connectionString;

        public TeacherRepository(string connectionString)
        {
            this._connectionString = connectionString;
        }

        public Teacher Get(long cpf)
        {
            const string sql = @"
                SELECT 
	                TeacherId,
	                Name,
	                Gender,
	                LevelId,
	                Salary,
	                AdmitionDate
                FROM 
	                dbo.Teacher
                WHERE
	                TeacherId = @Cpf";

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("Cpf", cpf, DbType.Int64);

            using (SqlConnection sqlConnection = GetSqlConnection())
            {
                return sqlConnection.QuerySingleOrDefault<Teacher>(sql, parameters);
            }
        }

        public PagedResult<Teacher> ListPagedByFilter(TeacherFilter filter, int pageNumber, int pageSize)
        {
            //Usar o var para passar o parâmetro implicitamente
            //var parameters = new DynamicParameters();
            DynamicParameters parameters = new DynamicParameters();
            parameters.AddDynamicParams(new { Filter = filter, PageNumber = pageNumber, PageSize = pageSize });

            StringBuilder queryCount = new StringBuilder(@"Select 
                COUNT(TeacherId)
            FROM 
                dbo.Teacher
            ");

            StringBuilder sqlString = new StringBuilder(@"
                SELECT 
                    TeacherId,
                    Name,
                    Gender,
                    LevelId,
                    Salary,
                    AdmitionDate
                FROM 
                    dbo.Teacher
                ");

            if(filter != null)
            {
                queryCount.Append("@DynamicFilter");
                ApplyFilter(queryCount, filter, parameters);
                
                sqlString.Append("@DynamicFilter");
                ApplyFilter(sqlString, filter, parameters);
            }

            sqlString.Append(@"ORDER BY TeacherId
                    OFFSET (@PageNumber - 1)*@PageSize  ROWS
                    FETCH NEXT @PageSize ROWS ONLY");

            using (SqlConnection sqlConnection = GetSqlConnection())
            {
                return PagedResult<Teacher>.Create(sqlConnection.QueryMultiple(sqlString.ToString(), parameters).Read<Teacher>(), sqlConnection.QueryMultiple(queryCount.ToString(), parameters).ReadFirst<long>());
            }
        }

        public IEnumerable<Teacher> ListAll()
        {
            const string sql = @"
                SELECT 
	                TeacherId,
	                Name,
	                Gender,
	                LevelId,
	                Salary,
	                AdmitionDate
                FROM 
	                dbo.Teacher";

            using (SqlConnection sqlConnection = GetSqlConnection())
            {
                return sqlConnection.Query<Teacher>(sql);
            }
        }

        public void Delete(long cpf)
        {
            const string sqlDelete = @"
                DELETE
                FROM 
                	dbo.Teacher
                WHERE
                	TeacherId = @Cpf";

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("Cpf", cpf, DbType.Int64);

            using (SqlConnection sqlConnection = GetSqlConnection())
            {
                sqlConnection.Execute(sqlDelete, parameters);
            }
        }

        public void Insert(Teacher teacherToInsert)
        {
            const string sql = @"
                INSERT INTO dbo.Teacher
                (
                	TeacherId,
                	Name,
                	Gender,
                	LevelId,
                	Salary,
                	AdmitionDate
                )
                VALUES
                (
                	@TeacherId,
                	@Name,
                	@Gender,
                	@LevelId,
                	@Salary,
                	@AdmitionDate
                )
            ";
            
            DynamicParameters parameters = new DynamicParameters();
            parameters.AddDynamicParams(new
            {
                TeacherId = teacherToInsert.TeacherId,
                Name = teacherToInsert.Name,
                Gender = teacherToInsert.Gender,
                LevelId = teacherToInsert.LevelId,
                Salary = teacherToInsert.Salary,
                AdmitionDate = teacherToInsert.AdmitionDate
            });
            
            using (SqlConnection sqlConnection = GetSqlConnection())
            {
                sqlConnection.Execute(sql, parameters);
            }
        }
        
        public void Update(Teacher requestData)
        {
            const string sqlUpdate = @"
                UPDATE dbo.Teacher
                SET Name = @Name,
                    Gender = @Gender,
                    LevelId = @LevelId,
                    Salary = @Salary,
                    AdmitionDate = @AdmitionDate
                WHERE TeacherId = @TeacherId";

            DynamicParameters parameters = new DynamicParameters();
            parameters.AddDynamicParams(new
            {
                TeacherId = requestData.TeacherId,
                Name = requestData.Name,
                Gender = requestData.Gender,
                LevelId = requestData.LevelId,
                Salary = requestData.Salary,
                AdmitionDate = requestData.AdmitionDate
            });

            using (SqlConnection sqlConnection = GetSqlConnection())
            {
                sqlConnection.Execute(sqlUpdate, parameters);
            }
        }

        private void ApplyFilter(StringBuilder sql, TeacherFilter filter, DynamicParameters parameters)
        {
            var conditions = new List<string>();

            if (!string.IsNullOrWhiteSpace(filter.Name))
            {
                //Vai dar ruim, só pesquisar
                conditions.Add("Name LIKE @Name");
                parameters.Add("Name", filter.Name + "%", DbType.String);
            }

            if(filter.Genders?.Any() == true)
            {
                //Pode passar direto o parâmetro, dapper já ajusta dentro do parênteses
                conditions.Add("Gender IN @Genders");
                parameters.Add("Genders", filter.Genders);
            }

            if (filter.LevelIds?.Any() == true)
            {
                conditions.Add("LevelId IN @LevelIds");
                parameters.Add("LevelIds", filter.LevelIds);
            }

            if (filter.MinSalary.HasValue && filter.MaxSalary.HasValue)
            {
                conditions.Add("Salary BETWEEN @MinSalary AND @MaxSalary");
                parameters.Add("MinSalary", filter.MinSalary, DbType.Decimal);
                parameters.Add("MaxSalary", filter.MaxSalary, DbType.Decimal);
            }
            //XOR --> apenas um é verdadeiro (^)
            else if (filter.MinSalary.HasValue ^ filter.MaxSalary.HasValue)
            {
                if(filter.MinSalary.HasValue)
                {
                    conditions.Add("Salary >= @MinSalary");
                    parameters.Add("MinSalary", filter.MinSalary, DbType.Decimal);
                }
                else
                {
                    conditions.Add("Salary <= @MaxSalary");
                    parameters.Add("MaxSalary", filter.MaxSalary, DbType.Decimal);
                }
            }

            if (filter.MinAdmitionDate.HasValue && filter.MaxAdmitionDate.HasValue)
            {
                conditions.Add("AdmitionDate BETWEEN @MinAdmitionDate AND @MaxAdmitionDate");
                parameters.Add("MinAdmitionDate", filter.MinAdmitionDate, DbType.DateTime2);
                parameters.Add("MaxAdmitionDate", filter.MaxAdmitionDate, DbType.DateTime2);
            }
            else if (filter.MinAdmitionDate.HasValue ^ filter.MaxAdmitionDate.HasValue)
            {
                if (filter.MinAdmitionDate.HasValue)
                {
                    conditions.Add("AdmitionDate >= @MinAdmitionDate");
                    parameters.Add("MinAdmitionDate", filter.MinAdmitionDate, DbType.DateTime2);
                }
                else
                {
                    conditions.Add("AdmitionDate <= @MaxAdmitionDate");
                    parameters.Add("MaxAdmitionDate", filter.MaxAdmitionDate, DbType.DateTime2);
                }
            }

            string dynamicFilter = conditions.Any() ? $"WHERE {string.Join(" AND ", conditions)}" : "";

            sql.Replace("@DynamicFilter", dynamicFilter);
        }

        public bool ExistByTeacherId(long teacherId)
        {
            const string sql = @"SELECT
                1
            FROM
                dbo.Teacher
            WHERE
                TeacherId = @teacherId";

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("teacherId", teacherId, DbType.Int64);

            using (SqlConnection sqlConnection = GetSqlConnection())
            {
                return sqlConnection.ExecuteScalar<bool>(sql, parameters);
            }
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

        public IEnumerable<char> ValidLevelIds()
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
