using School.Core.Models;
using StoneCo.Buy4.School.DataContracts.Class.InsertClass;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.Core.Operations.Class.ClassCSVReader
{
    public interface ISchoolClassCsvReader
    {
        List<string> Execute(InsertClassRequestData requestData);
    }
}
