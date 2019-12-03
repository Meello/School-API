using Dapper;
using Microsoft.Extensions.Configuration;
using School.Core.Models;
using School.Core.Repositories;
using StoneCo.Buy4.School.DataContracts;
using StoneCo.Buy4.School.DataContracts.DeleteTeacher;
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

        //Criar novo ListAll para ser paginável e poder aplicar filtro
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

                return sqlConnection.QuerySingleOrDefault<Teacher>(sql,parameters);
            }
        }
        public Teacher Insert(Teacher teacherToInsert, InsertTeacherResponse response)
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

            //parameters.AddDynamicParams --> para adicionar varios parametros
            parameters.Add("TeacherId", teacherToInsert.TeacherId, DbType.Int64);
            parameters.Add("Name", teacherToInsert.Name, DbType.String);
            parameters.Add("Gender", teacherToInsert.Gender, DbType.String);
            parameters.Add("LevelId", teacherToInsert.LevelId, DbType.String);
            parameters.Add("Salary", teacherToInsert.Salary, DbType.Decimal);
            parameters.Add("AdmitionDate", teacherToInsert.AdmitionDate, DbType.Date);

            using (SqlConnection sqlConnection = new SqlConnection(this._connectionString)) 
            {
                sqlConnection.Open();

                //Tirar o response daqui, fazer outro método para procurar se existe

                try 
                { 
                    sqlConnection.Query<Teacher>(sql, parameters);
                }
                catch (Exception ex)
                {
                    response.Errors.Add(new OperationError("010", ex.Message.ToString()));
                }
                finally
                {
                    sqlConnection.Close();
                }
                
                return teacherToInsert;
            }
        }

        public Teacher Delete(long cpf, DeleteTeacherResponse response)
        {
            //delete pode ser void
            //usar metodo existe no select
            string sqlGetTeacher = @"
                SELECT 
	                1
                FROM 
	                dbo.Teacher
                WHERE
	                TeacherId = @Cpf";

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

                return sqlConnection.QuerySingleOrDefault<Teacher>(sqlGetTeacher, parameters);
            }
        }

        public Teacher Update(UpdateTeacherRequestData requestData, UpdateTeacherResponse response)
        {
            string sqlGetTeacher = @"
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

            string sqlUpdate = @"
                UPDATE dbo.Teacher
                SET Name = @Name,
                    Gender = @Gender,
                    LevelId = @LevelId,
                    Salary = @Salary,
                    AdmitionDate = @AdmitionDate
                WHERE TeacherId = @TeacherId";

            DynamicParameters parameters = new DynamicParameters(requestData as UpdateTeacherRequestData);
            parameters.Add("TeacherId", requestData.CPF, DbType.Int64);
            parameters.Add("Name", requestData.Name, DbType.String);
            parameters.Add("Gender", requestData.Gender, DbType.String);
            parameters.Add("LevelId", requestData.Level, DbType.String);
            parameters.Add("Salary", requestData.Salary, DbType.Decimal);
            parameters.Add("AdmitionDate", requestData.AdmitionDate, DbType.Date);

            using (SqlConnection sqlConnection = new SqlConnection(this._connectionString))
            {
                sqlConnection.Open();
                //não precisa fazer assim, using já fecha a conexão
                try
                {
                    sqlConnection.Query<Teacher>(sqlUpdate, parameters);
                }
                catch (Exception ex)
                {
                    response.Errors.Add(new OperationError("009", ex.Message.ToString()));
                }
                finally
                {
                    sqlConnection.Close();
                }

                return sqlConnection.QuerySingleOrDefault<Teacher>(sqlGetTeacher, parameters);
            }

            /*
            if (_teachers.Find(x => x.TeacherId == requestData.CPF) == null)
            {
                return null;
            }
            
            for (int i = 0; i < _teachers.Count; i++)
            {
                if (_teachers[i].TeacherId == requestData.CPF)
                {
                    _teachers[i].AdmitionDate = requestData.AdmitionDate.Value;
                    _teachers[i].Gender = requestData.Gender.Value;
                    _teachers[i].LevelId = requestData.Level.Value;
                    _teachers[i].Name = requestData.Name;
                    _teachers[i].Salary = requestData.Salary.Value;
                }
            }

            return _teachers.Find(x => x.TeacherId == requestData.CPF);*/

        }
    }
}
