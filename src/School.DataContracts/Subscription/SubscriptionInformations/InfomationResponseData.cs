using System;
using System.Collections.Generic;
using System.Text;

namespace StoneCo.Buy4.School.DataContracts.Subscription.InformationsSubscription
{
    public class InformationResponseData
    {
        public string Student { get; set; }

        public string Course { get; set; }

        public string InformationArea { get; set; }
        
        public string Local { get; set; }

        public string StartDate { get; set; }

        public string StartTime { get; set; }
        
        public string Teacher { get; set; }
        
        public string Profile { get; set; }

        public byte ClassId { get; set; }
    }
}
