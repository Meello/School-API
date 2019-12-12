using System;
using System.Collections.Generic;
using System.Text;
using School.Core.Querys.SearchConditions.SearchConditionsPerParameter;
using StoneCo.Buy4.School.DataContracts.SearchTeacher;

namespace School.Core.Querys.SearchConditions
{
    public class SearchConditions : ISearchConditions
    {
        private readonly ISearchConditionsPerParameter _conditionsPerParameter;

        public SearchConditions(ISearchConditionsPerParameter conditionsPerParameter)
        {
            this._conditionsPerParameter = conditionsPerParameter;
        }

        public string SqlStringSearchConditions(SearchTeacherRequestData requestData)
        {
            string sqlStringSearchConditions = null;
            
            if (requestData != null)
            {
                sqlStringSearchConditions = @"WHERE
                    ";

                long lengthSqlString = sqlStringSearchConditions.Length;

                //Add search by name initial
                sqlStringSearchConditions += this._conditionsPerParameter.SqlStringSearchConditionsName(requestData.NameInitial, nameof(requestData.NameInitial));

                //Add "AND" if search by name initial where added
                lengthSqlString = this._conditionsPerParameter.SqlStringLength(sqlStringSearchConditions, lengthSqlString);

                //Add search by gender
                sqlStringSearchConditions += this._conditionsPerParameter.SqlStringSearchConditionsList(requestData.Gender, nameof(requestData.Gender));
                
                //Add "AND" if search by gender where added
                lengthSqlString = this._conditionsPerParameter.SqlStringLength(sqlStringSearchConditions, lengthSqlString);
                
                //Add search by levelId
                sqlStringSearchConditions += this._conditionsPerParameter.SqlStringSearchConditionsList(requestData.LevelId, nameof(requestData.LevelId));

                //Add "AND" if search by levelId where added
                lengthSqlString = this._conditionsPerParameter.SqlStringLength(sqlStringSearchConditions, lengthSqlString);

                //Add search by salary
                sqlStringSearchConditions += this._conditionsPerParameter.SqlStringSearchConditionsInterval(requestData.MinSalary, nameof(requestData.MinSalary), requestData.MaxSalary, nameof(requestData.MaxSalary),"Salary");

                //Add "AND" if search by salary where added
                lengthSqlString = this._conditionsPerParameter.SqlStringLength(sqlStringSearchConditions, lengthSqlString);

                //Add search by AdmitionDate
                sqlStringSearchConditions += this._conditionsPerParameter.SqlStringSearchConditionsInterval(requestData.MinAdmitionDate, nameof(requestData.MinAdmitionDate), requestData.MaxAdmitionDate, nameof(requestData.MaxAdmitionDate), "AdmitionDate");

                /*
                if (requestData.NameInitial != null)
                {
                    sqlStringSearchConditions += @"LEFT(Name,1) = @NameInitial
                        ";
                }

                if (requestData.Gender != null)
                {
                    if (lengthSqlString < sqlStringSearchConditions.Length)
                    {
                        sqlStringSearchConditions += @" AND ";

                        lengthSqlString = sqlStringSearchConditions.Length;
                    }

                    sqlStringSearchConditions += $@"{nameof(requestData.Gender)} IN('{string.Join("','", requestData.Gender.ToArray())}')
                        ";
                }

                if (requestData.LevelId != null)
                {
                    if (lengthSqlString < sqlStringSearchConditions.Length)
                    {
                        sqlStringSearchConditions += @" AND ";

                        lengthSqlString = sqlStringSearchConditions.Length;
                    }

                    sqlStringSearchConditions += $@"{nameof(requestData.LevelId)} IN('{string.Join("','", requestData.LevelId.ToArray())}')
                        ";
                }

                if (requestData.MinSalary != null && requestData.MaxSalary == null)
                {
                    if (lengthSqlString < sqlStringSearchConditions.Length)
                    {
                        sqlStringSearchConditions += @" AND ";

                        lengthSqlString = sqlStringSearchConditions.Length;
                    }

                    sqlStringSearchConditions += $@"Salary > @MinSalary
                        ";
                }

                if (requestData.MaxSalary != null && requestData.MinSalary == null)
                {
                    if (lengthSqlString < sqlStringSearchConditions.Length)
                    {
                        sqlStringSearchConditions += @" AND ";

                        lengthSqlString = sqlStringSearchConditions.Length;
                    }

                    sqlStringSearchConditions += $@"Salary < @MaxSalary
                        ";
                }


                if (requestData.MaxSalary != null && requestData.MinSalary != null)
                {
                    if (lengthSqlString < sqlStringSearchConditions.Length)
                    {
                        sqlStringSearchConditions += @" AND ";

                        lengthSqlString = sqlStringSearchConditions.Length;
                    }

                    sqlStringSearchConditions += $@"Salary < @MaxSalary AND Salary > @MinSalary
                        ";
                }

                if (requestData.MinAdmitionDate != null && requestData.MaxAdmitionDate == null)
                {
                    if (lengthSqlString < sqlStringSearchConditions.Length)
                    {
                        sqlStringSearchConditions += @" AND ";

                        lengthSqlString = sqlStringSearchConditions.Length;
                    }

                    sqlStringSearchConditions += $@"AdmitionDate > @MinAdmitionDate
                        ";
                }

                if (requestData.MaxAdmitionDate != null && requestData.MinAdmitionDate == null)
                {
                    if (lengthSqlString < sqlStringSearchConditions.Length)
                    {
                        sqlStringSearchConditions += @" AND ";

                        lengthSqlString = sqlStringSearchConditions.Length;
                    }

                    sqlStringSearchConditions += $@"AdmitionDate < @MaxAdmitionDate
                        ";
                }


                if (requestData.MaxAdmitionDate != null && requestData.MinAdmitionDate != null)
                {
                    if (lengthSqlString < sqlStringSearchConditions.Length)
                    {
                        sqlStringSearchConditions += @" AND ";

                        lengthSqlString = sqlStringSearchConditions.Length;
                    }

                    sqlStringSearchConditions += $@"AdmitionDate < @MaxAdmitionDate AND AdmitionDate > @MinAdmitionDate
                        ";
                }
                */
            }

            return sqlStringSearchConditions;
        }
    }
}
