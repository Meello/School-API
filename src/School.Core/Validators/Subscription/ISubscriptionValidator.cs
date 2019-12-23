using StoneCo.Buy4.School.DataContracts.Subscription;
using StoneCo.Buy4.School.DataContracts.Subscription.InsertSubscription;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.Core.Validators.Subscription 
{
    public interface ISubscriptionValidator
    {
        InsertSubscriptionResponse ValidateSubscription(SubscriptionRequestData requestData);

        bool IsNullOrZero(long? num, InsertSubscriptionResponse response, string fieldname);

        bool IsNullOrZero(int? num, InsertSubscriptionResponse response, string fieldname);
    }
}
