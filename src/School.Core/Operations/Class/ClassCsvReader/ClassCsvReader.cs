using School.Core.Mapping;
using School.Core.Models;
using StoneCo.Buy4.School.Core.DTO;
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

        public ICollection<ClassInputDto> Execute(Stream file)
        {
            ICollection<ClassInputDto> classInputDtos = new List<ClassInputDto>();

            StreamReader reader = new StreamReader(file, true);
            reader.ReadLine().Skip(1);

            while (true)
            {
                string line = reader.ReadLine();

                if (line == null) break;

                classInputDtos.Add(this._mappingResolver.BuildFrom(line));
            }

            return classInputDtos;
        }
    }
}
