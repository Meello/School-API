using System;
using System.Collections.Generic;
using System.Text;
using School.Core.Querys.SearchConditions.SearchConditionsPerParameter;
using StoneCo.Buy4.School.DataContracts.SearchTeacher;

namespace School.Core.Querys.SearchConditions
{
    public class SearchConditions : ISearchConditions
    {
        public string SqlStringSearchConditions(SearchTeacherRequestData requestData)
        {
            string sqlString = null;
            int count = 0;

            if (requestData != null)
            {
                sqlString = @"WHERE
                    ";

                long lengthSqlString = sqlString.Length;

                if (requestData.NameInitial != null)
                {
                    sqlString += $@"LEFT(Name,1) = @{nameof(requestData.NameInitial)}
                        ";
                    count += 1;
                }

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

            if(count == 0)
            {
                return null;
            }

            return sqlString;
        }
    }
}
