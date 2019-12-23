using System;
using System.Collections.Generic;
using System.Text;

namespace StoneCo.Buy4.School.DataContracts.Subscription.InsertSubscription
{
    public class InsertSubscriptionRequest : OperationRequestBase
    {
        public InsertSubscriptionRequest(SubscriptionRequestData requestData )
        {
            Data = requestData;
        }

        public SubscriptionRequestData Data { get; set; }
    }
}
