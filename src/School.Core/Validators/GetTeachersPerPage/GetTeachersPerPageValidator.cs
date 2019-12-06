using Dapper;
using School.Core.Models;
using StoneCo.Buy4.School.DataContracts;
using StoneCo.Buy4.School.DataContracts.GetTeacherPerPage;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace School.Core.Validators.GetTeachersPerPage
{
    public class GetTeachersPerPageValidator : IGetTeachersPerPageValidator
    {
        private readonly string _connectionString;

        public GetTeachersPerPageValidator(string connectionString)
        {
            this._connectionString = connectionString;
        }
        
        public void NumberOfElementsValiator(long pageNumber, long elementsPerPage, GetTeachersPerPageResponse response)
        {
            string sql = @"
                SELECT 
                    COUNT(TeacherId)
                FROM
                    dbo.Teacher";

            long maxTeachers;

            using (SqlConnection sqlConnection = new SqlConnection(this._connectionString))
            {
                sqlConnection.Open();

                maxTeachers = sqlConnection.QueryFirstOrDefault<long>(sql);
            }

            if (elementsPerPage > ModelConstants.Teacher.MaxTeachersPerPage)
            {
                response.Errors.Add(new OperationError("015", "Number of teachers exceded the limit"));
            }

            if (elementsPerPage * pageNumber > maxTeachers)
            {
                response.Errors.Add(new OperationError("016", "Values can't be find! Incorrect search local"));
            }

            if (response.Errors.Count == 0)
            {
                response.Success = true;
            }
        }
    }
}
