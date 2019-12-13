using Dapper;
using Microsoft.Extensions.Configuration;
using School.Core.Models;
using School.Core.Repositories;
using StoneCo.Buy4.School.DataContracts;
using StoneCo.Buy4.School.DataContracts.DeleteTeacher;
using StoneCo.Buy4.School.DataContracts.SearchTeacher;
using StoneCo.Buy4.School.DataContracts.GetTeacherPerPage;
using StoneCo.Buy4.School.DataContracts.InsertTeacher;
using StoneCo.Buy4.School.DataContracts.UpdateTeacher;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using School.Core.Querys.SearchConditions;
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
            //Quando tem a mais, não tem problema
            //Quando tem a menos, a coluna que a aplicação faz referência pode ter sido deletada e a aplicação vai quebrar
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

            //Para passar um parâmetro na query
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("Cpf", cpf, DbType.Int64);

            using (SqlConnection sqlConnection = new SqlConnection(this._connectionString)) 
            {
                sqlConnection.Open();

                return sqlConnection.QuerySingleOrDefault<Teacher>(sql, parameters);
            }
        }

        public IEnumerable<Teacher> GetPerPage(long pageNumber, long teachersPerPage)
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
                ORDER BY TeacherId
                	OFFSET (@Page - 1)*@PageSize ROWS 
                	FETCH NEXT @PageSize ROWS ONLY";

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@PageSize", teachersPerPage, DbType.Int64);
            parameters.Add("@Page", pageNumber, DbType.Int64);

            using (SqlConnection sqlConnection = new SqlConnection(this._connectionString))
            {
                sqlConnection.Open();

                return sqlConnection.Query<Teacher>(sql, parameters);
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
                ";

            sql += sqlWhereConditions;

            sql += @"ORDER BY TeacherId
                    OFFSET (@PageNumber - 1)*@PageSize  ROWS
                    FETCH NEXT @PageSize ROWS ONLY";


            using (SqlConnection sqlConnection = GetSqlConnection())
            {
                sqlConnection.Query<Teacher>(sql, parameters);
            }

        }

        private SqlConnection GetSqlConnection()
        {
            //COLOCAR TODA A LÓGICA DO SQLCONNECTION AQUI
            //Tentar extrair um método se tiver repetições
            //Não precisa abrir a conexão se estiver usando o dapper
            return new SqlConnection(this._connectionString);
        }

        public IEnumerable<Teacher> Search(SearchTeacherRequest request, string sqlWhereConditions)
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
                ";

            sql += sqlWhereConditions;

            sql += @"ORDER BY TeacherId
                    OFFSET (@PageNumber - 1)*@PageSize  ROWS
                    FETCH NEXT @PageSize ROWS ONLY";

            DynamicParameters parameters = new DynamicParameters();
            parameters.AddDynamicParams(request.Data);
            parameters.Add("PageNumber", request.PageNumber, DbType.Int64);
            parameters.Add("PageSize", request.PageSize, DbType.Int64);

            using (SqlConnection sqlConnection = new SqlConnection(this._connectionString))
            {
                sqlConnection.Open();

                return sqlConnection.Query<Teacher>(sql, parameters);
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
                sqlConnection.Open();

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
                sqlConnection.Open();

                sqlConnection.QuerySingleOrDefault<Teacher>(sqlDelete, parameters);
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
                sqlConnection.Open();
                
                sqlConnection.Query(sql, parameters);
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
                sqlConnection.Open();
                
                sqlConnection.QueryFirstOrDefault(sqlUpdate, parameters);
            }
        }

        private void ApplyFilter(StringBuilder sql, TeacherFilter filter, DynamicParameters parameters)
        {
            var conditions = new List<string>();

            if (!string.IsNullOrWhiteSpace(filter.Name))
            {
                //VAi dar ruim, só pesquisar
                conditions.Add("Name LIKE @Name%");
                parameters.Add("Name", filter.Name, DbType.String);
            }

            if(filter.Genders?.Any() == true)
            {
                //Pode passar direto o parâmetro, dapper já ajusta dentro do parênteses
                conditions.Add("Gender IN @Genders");
                parameters.Add("Genders", filter.Genders);
            }

            if(filter.MinSalary.HasValue && filter.MaxSalary.HasValue)
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

            string dynamicFilter = conditions.Any() ? $"WHERE {string.Join(" AND ", conditions)}" : "";

            sql.Replace("@DynamicFilter", dynamicFilter);


                if (requestData.Gender != null)
            {
                if (lengthSqlString < sqlString.Length)
                {
                    sqlString += @" AND ";

                    lengthSqlString = sqlString.Length;
                }

                sqlString += $@"{nameof(requestData.Gender)} IN('{string.Join("','", requestData.Gender.ToArray())}')
                        ";

                count += 1;
            }

            if (requestData.LevelId != null)
            {
                if (lengthSqlString < sqlString.Length)
                {
                    sqlString += @" AND ";

                    lengthSqlString = sqlString.Length;
                }

                sqlString += $@"{nameof(requestData.LevelId)} IN('{string.Join("','", requestData.LevelId.ToArray())}')
                        ";

                count += 1;
            }

            if (requestData.MinSalary != null && requestData.MaxSalary == null)
            {
                if (lengthSqlString < sqlString.Length)
                {
                    sqlString += @" AND ";

                    lengthSqlString = sqlString.Length;
                }

                sqlString += $@"Salary >= @{nameof(requestData.MinSalary)}
                        ";

                count += 1;
            }

            if (requestData.MaxSalary != null && requestData.MinSalary == null)
            {
                if (lengthSqlString < sqlString.Length)
                {
                    sqlString += @" AND ";

                    lengthSqlString = sqlString.Length;
                }

                sqlString += $@"Salary <= @{nameof(requestData.MaxSalary)}
                        ";

                count += 1;
            }


            if (requestData.MaxSalary != null && requestData.MinSalary != null)
            {
                if (lengthSqlString < sqlString.Length)
                {
                    sqlString += @" AND ";

                    lengthSqlString = sqlString.Length;
                }

                sqlString += $@"Salary >= @{nameof(requestData.MinSalary)} AND Salary <= @{nameof(requestData.MaxSalary)}
                        ";

                count += 1;
            }

            if (requestData.MinAdmitionDate != null && requestData.MaxAdmitionDate == null)
            {
                if (lengthSqlString < sqlString.Length)
                {
                    sqlString += @" AND ";

                    lengthSqlString = sqlString.Length;
                }

                sqlString += $@"AdmitionDate >= @{nameof(requestData.MinAdmitionDate)}
                        ";

                count += 1;
            }

            if (requestData.MaxAdmitionDate != null && requestData.MinAdmitionDate == null)
            {
                if (lengthSqlString < sqlString.Length)
                {
                    sqlString += @" AND ";

                    lengthSqlString = sqlString.Length;
                }

                sqlString += $@"AdmitionDate <= @{nameof(requestData.MaxAdmitionDate)}
                        ";

                count += 1;
            }

            if (requestData.MaxAdmitionDate != null && requestData.MinAdmitionDate != null)
            {
                if (lengthSqlString < sqlString.Length)
                {
                    sqlString += @" AND ";

                    lengthSqlString = sqlString.Length;
                }

                sqlString += $@"AdmitionDate >= @{nameof(requestData.MinAdmitionDate)} AND Salary <= @{nameof(requestData.MaxAdmitionDate)}
                        ";

                count += 1;
            }
        }
    }
    }
}
