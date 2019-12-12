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

        public IEnumerable<Teacher> Search(SearchTeacherRequest request)
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

            if (request.Data != null)
            {
                sql += @"WHERE
                    ";

                long lengthSql = sql.Length;

                if (request.Data.NameInitial != null)
                {
                    sql += @"LEFT(Name,1) = @NameInitial
                        ";
                }

                if(request.Data.Gender != null)
                {
                    if(lengthSql < sql.Length)
                    {
                        sql += @" AND ";
                        
                        lengthSql = sql.Length;
                    }

                    sql += $@"{nameof(request.Data.Gender)} IN('{string.Join("' , '", request.Data.Gender.ToArray())}')
                        ";
                }

                if (request.Data.LevelId != null)
                {
                    if (lengthSql < sql.Length)
                    {
                        sql += @" AND ";
                        
                        lengthSql = sql.Length;
                    }

                    sql += $@"{nameof(request.Data.LevelId)} IN('{string.Join("' , '", request.Data.LevelId.ToArray())}')
                        ";
                }

                if(request.Data.MinSalary != null && request.Data.MaxSalary == null)
                {
                    if(lengthSql < sql.Length)
                    {
                        sql += @" AND ";

                        lengthSql = sql.Length;
                    }

                    sql += $@"Salary > @MinSalary
                        ";
                }

                if (request.Data.MaxSalary != null && request.Data.MinSalary == null)
                {
                    if (lengthSql < sql.Length)
                    {
                        sql += @" AND ";

                        lengthSql = sql.Length;
                    }

                    sql += $@"Salary < @MaxSalary
                        ";
                }


                if (request.Data.MaxSalary != null && request.Data.MinSalary != null)
                {
                    if (lengthSql < sql.Length)
                    {
                        sql += @" AND ";

                        lengthSql = sql.Length;
                    }

                    sql += $@"Salary < @MaxSalary AND Salary > @MinSalary
                        ";
                }

                if (request.Data.MinAdmitionDate != null && request.Data.MaxAdmitionDate == null)
                {
                    if (lengthSql < sql.Length)
                    {
                        sql += @" AND ";

                        lengthSql = sql.Length;
                    }

                    sql += $@"AdmitionDate > @MinAdmitionDate
                        ";
                }

                if (request.Data.MaxAdmitionDate != null && request.Data.MinAdmitionDate == null)
                {
                    if (lengthSql < sql.Length)
                    {
                        sql += @" AND ";

                        lengthSql = sql.Length;
                    }

                    sql += $@"AdmitionDate < @MaxAdmitionDate
                        ";
                }


                if (request.Data.MaxAdmitionDate != null && request.Data.MinAdmitionDate != null)
                {
                    if (lengthSql < sql.Length)
                    {
                        sql += @" AND ";

                        lengthSql = sql.Length;
                    }

                    sql += $@"AdmitionDate < @MaxAdmitionDate AND AdmitionDate > @MinAdmitionDate
                        ";
                }
            }

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
    }
}
