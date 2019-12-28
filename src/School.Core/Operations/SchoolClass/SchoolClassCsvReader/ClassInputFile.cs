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
    public class ClassInputFile : IClassInputFile
    {
        private readonly ISchoolMappingResolver _mappingResolver;

        public ClassInputFile(ISchoolMappingResolver mappingResolver)
        {
            this._mappingResolver = mappingResolver;
        }

        public List<ClassInputDto> Execute(Stream file)
        {
            List<ClassInputDto> classInputDtos = new List<ClassInputDto>();

            StreamReader reader = new StreamReader($@"{file.FullFilePath}",Encoding.UTF8,true);
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
