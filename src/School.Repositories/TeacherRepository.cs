using Dapper;
using Microsoft.Extensions.Configuration;
using School.Core.Models;
using School.Core.Repositories;
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
        private readonly IConfiguration _configuration;

        public TeacherRepository(IConfiguration configuration)
        {
            this._configuration = configuration;
        }
        
        public string GetConnectionString()
        {
            var connection = _configuration.GetConnectionString("SchoolConnection");
            return connection;
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

            using (SqlConnection sqlConnection = new SqlConnection(this.GetConnectionString()))
            {
                sqlConnection.Open();

                return sqlConnection.Query<Teacher>(sql);
            }
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

            //Para passar um parâmetro na query
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("Cpf", cpf, DbType.Int64);

            using (SqlConnection sqlConnection = new SqlConnection(this.GetConnectionString()))
            {
                sqlConnection.Open();

                return sqlConnection.QuerySingleOrDefault<Teacher>(sql,parameters);
            }
        }
        public Teacher Insert(Teacher teacherToInsert)
        {
            return null;
            //_teachers.Add(teacherToInsert);

            //return teacherToInsert;
        }

        public Teacher Delete(long cpf)
        {
            /*for (int i = 0; i < _teachers.Count; i++)
            {
                if (_teachers[i].TeacherId == cpf)
                {
                    Teacher teacher = _teachers.ElementAt(i);
                    _teachers.Remove(teacher);
                    return teacher;
                }
            }*/

            return null;
        }

        

        public Teacher Update(UpdateTeacherRequestData requestData)
        {
            /*if (_teachers.Find(x => x.TeacherId == requestData.CPF) == null)
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
            return null;
        }
    }
}
