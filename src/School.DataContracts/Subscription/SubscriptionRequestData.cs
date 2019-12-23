using System;
using System.Collections.Generic;
using System.Text;

namespace StoneCo.Buy4.School.DataContracts.Subscription
{
    public class SubscriptionRequestData
    {
        public long StudentId { get; set; }

        public byte ClassId { get; set; }
    }
}
