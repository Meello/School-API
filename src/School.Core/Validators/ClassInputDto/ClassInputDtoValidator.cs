using School.Core.Repositories;
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
        private readonly IClassRepository _classRepository;
        private readonly ITeacherRepository _teacherRepository;
        private readonly ICourseRepository _courseRepository;

        public ClassInputDtoValidator(
            IClassRepository classRepository,
            ITeacherRepository teacherRepository,
            ICourseRepository courseRepository)
        {
            this._classRepository = classRepository;
            this._teacherRepository = teacherRepository;
            this._courseRepository = courseRepository;
        }

        public void Execute(ClassInputDto classInputDto, InsertClassResponse response, int lineNumber)
        {
            string lineError = $"Line {lineNumber} =>";

            if(classInputDto == null)
            {
                response.AddError("001",$"Line {lineNumber} can't be null.");
            }
            else
            {
                if(this._classRepository.ExistByClassId(classInputDto.Id) == true)
                {
                    response.AddError("025",$"{lineError} ClassId already exist.");
                }

                if(this._teacherRepository.GetTeacherIdByName(classInputDto.Teacher) == 0)
                {
                    response.AddError("026",$"{lineError} Invalid teacher.");
                }

                if (this._courseRepository.GetCourseIdByName(classInputDto.Course) == 0)
                {
                    response.AddError("027", $"{lineError} Invalid course.");
                }

                if (!char.IsUpper(classInputDto.Shift[0]))
                {
                    response.AddError("028",$"{lineError} First letter of shift must be in uppercase.");
                }
                else if(classInputDto.Shift == "Manhã" || classInputDto.Shift == "Tarde" || classInputDto.Shift == "Noite")
                {
                    response.AddError("029",$"{lineError} Invalid Shift! Valid shifts: Manhã, Tarde, Noite");
                }

                if(classInputDto.StartDate > classInputDto.EndDate)
                {
                    response.AddError("030",$"{lineError} StartDate can't be bigger than EndDate");
                }

                if (classInputDto.StartTime > classInputDto.EndTime)
                {
                    response.AddError("031", $"{lineError} StartTime can't be bigger than EndTime");
                }

                if (classInputDto.EndTime - classInputDto.StartTime > TimeSpan.FromHours(3))
                {
                    response.AddError("",$"{lineError} Duration can't be bigger than 3h");
                }

                if(classInputDto.EndTime > TimeSpan.FromHours(22))
                {
                    response.AddError("",$"{lineError} The course can't end after 22:00");
                }

                if (classInputDto.StartTime < TimeSpan.FromHours(8))
                {
                    response.AddError("", $"{lineError} The course can't start before 8:00");
                }
            }
        }
    }
}
