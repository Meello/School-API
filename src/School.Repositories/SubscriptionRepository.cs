using Dapper;
using School.Core.Repositories;
using StoneCo.Buy4.School.DataContracts.Subscription.EnrolledStudents;
using StoneCo.Buy4.School.DataContracts.Subscription.InformationsSubscription;
using StoneCo.Buy4.School.DataContracts.Subscription;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using StoneCo.Buy4.School.Core.DTO;

namespace School.Repositories
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly string _connectionString;

        public SubscriptionRepository(string connectionString)
        {
            this._connectionString = connectionString;
        }

        public IEnumerable<SubscriptionResponseData> ListAll()
        {
            const string sql = @"SELECT
                StudentId,
                ClassId
            FROM
                dbo.Subscription";

            using (SqlConnection sqlConnection = GetSqlConnection())
            {
                IEnumerable<SubscriptionResponseData> subscriptions = sqlConnection.Query<SubscriptionResponseData>(sql);

                return subscriptions;
            }
        }

        public void InsertSubscription(SubscriptionRequestData requestData)
        {
            const string sql = @"INSERT INTO dbo.Subscription
            (
                StudentId,
                ClassId
            )
            VALUES
            (
                @StudentId,
                @ClassId
            )";

            DynamicParameters parameters = new DynamicParameters();
            parameters.AddDynamicParams(
                new { 
                    StudentId = requestData.StudentId, 
                    ClassId = requestData.ClassId 
                });

            using (SqlConnection sqlConnection = GetSqlConnection())
            {
                sqlConnection.Execute(sql, parameters);
            }
        }

        public IEnumerable<SubscriptionInformationData> SubscriptionInformations()
        {
            const string sql = @"SELECT 
                ClassId,
                Course,
                InformationArea,
                Local,
                Profile,
                StartDate,
                StartTime,
                Student,
                Teacher
            FROM
                SubscriptionsInformations";

            using (SqlConnection sqlConnection = GetSqlConnection())
            {
                List<SubscriptionInformationData> informationView = sqlConnection.Query<SubscriptionInformationData>(sql).ToList();

                return informationView;
            }
        }

        public IEnumerable<EnrolledStudentData> EnrolledStudents()
        {
            const string sql = @"SELECT
                CourseId,
                Course,
                EnrolledStudents 
            FROM
                Enrolled_Students";

            using (SqlConnection sqlConnection = GetSqlConnection())
            {
                List<EnrolledStudentData> enrolledStudents = sqlConnection.Query<EnrolledStudentData>(sql).ToList();

                return enrolledStudents;
            }
        }

        private SqlConnection GetSqlConnection()
        {
            return new SqlConnection(this._connectionString);
        }
    }
}
