using School.Core.Repositories;
using School.Core.Validators.ClassInputDtoParameters;
using School.Core.Validators.NullOrZero;
using StoneCo.Buy4.School.Core.DTO;
using StoneCo.Buy4.School.DataContracts.Class.InsertClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace School.Core.Validators.SchoolClassCsvFile
{
    public class ClassInputDtoValidator : IClassInputDtoValidator
    {
        private readonly IClassInputDtoParametersValidator _parametersValidator;
        private readonly IClassRepository _classRepository;
        private readonly ITeacherRepository _teacherRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly INullOrZeroValidator _nullOrZeroValidator;

        public ClassInputDtoValidator(
            IClassInputDtoParametersValidator parametersValidator,
            IClassRepository classRepository,
            ITeacherRepository teacherRepository,
            ICourseRepository courseRepository,
            INullOrZeroValidator nullOrZeroValidator)
        {
            this._parametersValidator = parametersValidator;
            this._classRepository = classRepository;
            this._teacherRepository = teacherRepository;
            this._courseRepository = courseRepository;
            this._nullOrZeroValidator = nullOrZeroValidator;
        }

        public void Execute(ClassInputDto classInputDto, InsertClassResponse response, int lineNumber)
        {
            string lineWithError = $"Line {lineNumber} =>";

            if (classInputDto == null)
            {
                response.AddError("001", $"Line {lineNumber} can't be null.");
            }
            else
            {
                this._parametersValidator.ClassId(classInputDto.Id, response, lineWithError);

                this._parametersValidator.Teacher(classInputDto.Teacher, response, lineWithError);

                this._parametersValidator.Course(classInputDto.Course, response, lineWithError);

                this._parametersValidator.Shift(classInputDto.Shift, response, lineWithError);

                this._parametersValidator.Date(classInputDto.StartDate, classInputDto.EndDate, response, lineWithError);

                this._parametersValidator.Time(classInputDto.StartTime, classInputDto.EndTime, response, lineWithError);
            }
        }
    }
}
