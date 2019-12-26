using School.Core.Mapping;
using School.Core.Models;
using StoneCo.Buy4.School.DataContracts.Class.InsertClass;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace School.Core.Operations.Class.ClassCSVReader
{
    public class ClassCsvReader : IClassCsvReader
    {
        private readonly ISchoolMappingResolver _mappingResolver;

        public ClassCsvReader(ISchoolMappingResolver mappingResolver)
        {
            this._mappingResolver = mappingResolver;
        }

        public IEnumerable<ClassCsvFile> Execute(InsertClassRequestData requestData)
        {
            List<ClassCsvFile> classCsvFiles = new List<ClassCsvFile>();

            StreamReader reader = new StreamReader($@"{requestData.FileAddress}",Encoding.UTF8,true);
            reader.ReadLine().Skip(1);

            while (true)
            {
                string line = reader.ReadLine();

                if (line == null) break;

                string[] separetedLine = line.Split(';');

                ClassCsvFile classCsvFile = this._mappingResolver.BuildFrom(separetedLine);

                classCsvFiles.Add(classCsvFile);
            }

            return classCsvFiles;
        }
    }
}
