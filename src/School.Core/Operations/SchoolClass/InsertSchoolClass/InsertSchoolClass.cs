using School.Core.Mapping;
using School.Core.Models;
using School.Core.Operations.Class.ClassCSVReader;
using School.Core.Repositories;
using StoneCo.Buy4.School.Core.DTO;
using StoneCo.Buy4.School.DataContracts.Class.InsertClass;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace School.Core.Operations.Class.InsertClass
{
    public class InsertSchoolClass : OperationBase<InsertClassRequest, InsertClassResponse>, IInsertSchoolClass
    {
        private ICollection<ClassInputDto> classInputDtos;

        private readonly ISchoolClassCsvReader _classCsvReader;
        private readonly ISchoolMappingResolver _mapperResolver;
        private readonly IClassRepository _classRepository;

        public InsertSchoolClass(
            ISchoolClassCsvReader classCsvReader, 
            ISchoolMappingResolver mapperResolver,
            IClassRepository classRepository)
        {
            this._classCsvReader = classCsvReader;
            this._mapperResolver = mapperResolver;
            this._classRepository = classRepository;
        }

        protected override InsertClassResponse ProcessOperation(InsertClassRequest request)
        {
            InsertClassResponse response = new InsertClassResponse();

            //List<string> schoolClassFileLines = this._classCsvReader.Execute(request.File);
            
            //List<SchoolClass> schoolClassList = this._mapperResolver.BuildFrom(schoolClassFileLines);

            //this._classRepository.Insert(schoolClassList);

            return response;
        }

        protected override InsertClassResponse ValidateOperation(InsertClassRequest request)
        {
            classInputDtos = 

            InsertClassResponse response = new InsertClassResponse();

            List<string> schoolClassFileLines = new List<string>();

            StreamReader reader = new StreamReader(request.File,true);
            reader.ReadLine().Skip(1);

            while (true)
            {
                string line = reader.ReadLine();

                if (line == null) break;

                schoolClassFileLines.Add(line);
            }

            //if (request.File.FullFilePath.IndexOfAny(Path.GetInvalidPathChars()) != -1)
            //{
            //    response.AddError("024", "File path have invalid characters.");

            //    return response;
            //}

            //if (!File.Exists(request.File.FullFilePath))
            //{
            //    response.AddError("025","File don't exist or can't be find.");
            //}


            //IEnumerable<SchoolClass> schoolClasses = this._classCsvReader.Execute(request.Data);

            return response;
        }
    }
}
