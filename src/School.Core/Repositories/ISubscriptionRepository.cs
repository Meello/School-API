using StoneCo.Buy4.School.DataContracts.Subscription.EnrolledStudents;
using StoneCo.Buy4.School.DataContracts.Subscription.InformationsSubscription;
using StoneCo.Buy4.School.DataContracts.Subscription;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.Core.Repositories
{
    public interface ISubscriptionRepository
    {
        IEnumerable<SubscriptionResponseData> ListAll();

        void InsertSubscription(SubscriptionRequestData requestData);

        IEnumerable<InfomationsViewData> InformationsView();

        IEnumerable<EnrolledStudentsViewData> EnrolledStudentsView();

        bool ExistByClassId(byte classId);

        bool ExistByStudentId(long studentId);
    }
}
