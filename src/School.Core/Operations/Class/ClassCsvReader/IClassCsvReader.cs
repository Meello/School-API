using School.Core.Models;
using StoneCo.Buy4.School.Core.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace School.Core.Operations.Class.ClassCSVReader
{
    public interface IClassCsvReader
    {
        ICollection<ClassInputDto> Execute(Stream file);
    }
}
