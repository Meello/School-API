using StoneCo.Buy4.School.DataContracts.Subscription.EnrolledStudents;
using StoneCo.Buy4.School.DataContracts.Subscription.InformationsSubscription;
using StoneCo.Buy4.School.DataContracts.Subscription;
using System;
using System.Collections.Generic;
using System.Text;
using StoneCo.Buy4.School.Core.DTO;

namespace School.Core.Repositories
{
    public interface ISubscriptionRepository
    {
        IEnumerable<SubscriptionResponseData> ListAll();

        void InsertSubscription(SubscriptionRequestData requestData);

        IEnumerable<SubscriptionInformationData> SubscriptionInformations();

        IEnumerable<EnrolledStudentData> EnrolledStudents();
    }
}
