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
            string sql = @"
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

            using (SqlConnection sqlConnection = new SqlConnection(this._connectionString)) 
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
            @DynamicFilter");

            //Tentar chamar ApplyFilter antes e depois da query para retornar os dados paginados
            ApplyFilter(queryCount, filter, parameters);

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
                @DynamicFilter
                ");

            ApplyFilter(sqlString, filter, parameters);

            sqlString.Append(@"ORDER BY TeacherId
                    OFFSET (@PageNumber - 1)*@PageSize  ROWS
                    FETCH NEXT @PageSize ROWS ONLY");

            using (SqlConnection sqlConnection = new SqlConnection(this._connectionString))
            {
                return PagedResult<Teacher>.Create(sqlConnection.QueryMultiple(sqlString.ToString(), parameters).Read<Teacher>(), sqlConnection.QueryMultiple(queryCount.ToString(), parameters).ReadFirst<long>());
            }
        }

        public IEnumerable<Teacher> ListAll()
        {
            string sql = @"
                SELECT 
	                TeacherId,
	                Name,
	                Gender,
	                LevelId,
	                Salary,
	                AdmitionDate
                FROM 
	                dbo.Teacher";

            using (SqlConnection sqlConnection = new SqlConnection(this._connectionString))
            {
                return sqlConnection.Query<Teacher>(sql);
            }
        }

        public void Delete(long cpf)
        {
            string sqlDelete = @"
                DELETE
                FROM 
                	dbo.Teacher
                WHERE
                	TeacherId = @Cpf";

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("Cpf", cpf, DbType.Int64);

            using (SqlConnection sqlConnection = new SqlConnection(this._connectionString))
            {
                sqlConnection.Execute(sqlDelete, parameters);
            }
        }

        public void Insert(Teacher teacherToInsert)
        {
            string sql = @"
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

            parameters.AddDynamicParams(teacherToInsert);
            
            using (SqlConnection sqlConnection = new SqlConnection(this._connectionString)) 
            {
                sqlConnection.Execute(sql, parameters);
            }
        }
        
        public void Update(Teacher requestData)
        {
            string sqlUpdate = @"
                UPDATE dbo.Teacher
                SET Name = @Name,
                    Gender = @Gender,
                    LevelId = @LevelId,
                    Salary = @Salary,
                    AdmitionDate = @AdmitionDate
                WHERE TeacherId = @TeacherId";

            DynamicParameters parameters = new DynamicParameters();
            parameters.AddDynamicParams(requestData);

            using (SqlConnection sqlConnection = new SqlConnection(this._connectionString))
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
                conditions.Add("Name LIKE @Name + '%'");
                parameters.Add("Name", filter.Name, DbType.String);
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
                parameters.Add("MinAdmitionDate", filter.MinAdmitionDate, DbType.DateTime);
                parameters.Add("MaxAdmitionDate", filter.MaxAdmitionDate, DbType.DateTime);
            }
            else if (filter.MinAdmitionDate.HasValue ^ filter.MaxAdmitionDate.HasValue)
            {
                if (filter.MinAdmitionDate.HasValue)
                {
                    conditions.Add("AdmitionDate >= @MinAdmitionDate");
                    parameters.Add("MinAdmitionDate", filter.MinAdmitionDate, DbType.DateTime);
                }
                else
                {
                    conditions.Add("AdmitionDate <= @MaxAdmitionDate");
                    parameters.Add("MaxAdmitionDate", filter.MaxAdmitionDate, DbType.DateTime);
                }
            }

            string dynamicFilter = conditions.Any() ? $"WHERE {string.Join(" AND ", conditions)}" : "";

            sql.Replace("@DynamicFilter", dynamicFilter);
        }

        public bool ExistByTeacherId(long teacherId)
        {
            string sql = @"SELECT
                1
            FROM
                dbo.Teacher
            WHERE
                TeacherId = @teacherId";

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("teacherId", teacherId, DbType.Int64);

            using (SqlConnection sqlConnection = new SqlConnection(this._connectionString))
            {
                return sqlConnection.ExecuteScalar<bool>(sql, parameters);
            }
        }

        /*
        private SqlConnection GetSqlConnection()
        {
            //COLOCAR TODA A LÓGICA DO SQLCONNECTION AQUI
            //Tentar extrair um método se tiver repetições
            //Não precisa abrir a conexão se estiver usando o dapper
            return new SqlConnection(this._connectionString);
        }
        */
    }
}
