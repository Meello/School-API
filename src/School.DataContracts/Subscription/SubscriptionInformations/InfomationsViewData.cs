using System;
using System.Collections.Generic;
using System.Text;

namespace StoneCo.Buy4.School.DataContracts.Subscription.InformationsSubscription
{
    public class InfomationsViewData
    {
        public string Student { get; }

        public string Course { get; }

        public string InformationArea { get; }
        
        public string Local { get; }

        public string StartDate { get; }

        public string StartTime { get; }
        
        public string Teacher { get; }
        
        public string Profile { get; }

        public byte ClassId { get; }
    }
}
