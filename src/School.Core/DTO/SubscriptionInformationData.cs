using System;
using System.Collections.Generic;
using System.Text;

namespace StoneCo.Buy4.School.Core.DTO
{
    public class SubscriptionInformationData
    {
        public string Student { get; }

        public string Course { get; }

        public string InformationArea { get; }
        
        public string Local { get; }

        public DateTime StartDate { get; }

        public TimeSpan StartTime { get; }
        
        public string Teacher { get; }
        
        public string Profile { get; }

        public byte ClassId { get; }
    }
}
