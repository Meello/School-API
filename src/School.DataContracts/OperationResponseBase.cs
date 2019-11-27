using System;
using System.Collections.Generic;
using System.Text;

namespace StoneCo.Buy4.School.DataContracts
{
    public class OperationResponseBase
    {
        public bool Success { get; set; }

        public List<OperationError> Errors { get; set; }

        public object Data { get; set; }
    }
}
