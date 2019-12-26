using StoneCo.Buy4.School.DataContracts.Class.InsertClass;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.Core.Operations.Class.ClassCSVReader
{
    public interface IClassCSVReader
    {
        IEnumerable<Models.Class> Read(InsertClassRequestData requestData);
    }
}
