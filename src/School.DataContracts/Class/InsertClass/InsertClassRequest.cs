using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace StoneCo.Buy4.School.DataContracts.Class.InsertClass
{
    public class InsertClassRequest : OperationRequestBase
    {
        public InsertClassRequest(Stream file)
        {
            File = file;
        }

        public Stream File { get; }
    }
}
