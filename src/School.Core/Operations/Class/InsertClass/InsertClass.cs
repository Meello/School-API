using School.Core.Mapping;
using School.Core.Models;
using School.Core.Operations.Class.ClassCSVReader;
using School.Core.Repositories;
using School.Core.Validators.SchoolClassCsvFile;
using StoneCo.Buy4.School.Core.DTO;
using StoneCo.Buy4.School.DataContracts.Class.InsertClass;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace School.Core.Operations.Class.InsertClass
{
    public class InsertClass : OperationBase<InsertClassRequest, InsertClassResponse>, IInsertClass
    {
        private ICollection<ClassInputDto> classInputDtos;

        private readonly IClassCsvReader _classInputFile;
        private readonly ISchoolMappingResolver _mappingResolver;
        private readonly IClassRepository _classRepository;
        private readonly IClassInputDtoValidator _validator;

        public InsertClass(
            IClassCsvReader classInputFile, 
            ISchoolMappingResolver mappingResolver,
            IClassRepository classRepository,
            IClassInputDtoValidator validator)
        {
            this._classInputFile = classInputFile;
            this._mappingResolver = mappingResolver;
            this._classRepository = classRepository;
            this._validator = validator;
        }

        protected override InsertClassResponse ProcessOperation(InsertClassRequest request)
        {
            InsertClassResponse response = new InsertClassResponse();

            List<Models.Class> schoolClassList = this._mappingResolver.BuildFrom(classInputDtos);

            this._classRepository.Insert(schoolClassList);

            return response;
        }

        protected override InsertClassResponse ValidateOperation(InsertClassRequest request)
        {
            InsertClassResponse response = new InsertClassResponse();
            
            if(request.File.Length <= 0)
            {
                response.AddError("024","File can't be empty.");

                return response;
            }

            classInputDtos = this._classInputFile.Execute(request.File);

            int countLine = 1;

            foreach(ClassInputDto classInputDto in classInputDtos)
            {
                this._validator.Execute(classInputDto, response, countLine);

                countLine += 1;
            }

            return response;
        }
    }
}
