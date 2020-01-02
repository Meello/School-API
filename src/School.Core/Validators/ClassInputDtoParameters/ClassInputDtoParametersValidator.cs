using School.Core.Repositories;
using School.Core.Validators.NullOrZero;
using StoneCo.Buy4.School.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace School.Core.Validators.ClassInputDtoParameters
{
    public class ClassInputDtoParametersValidator : IClassInputDtoParametersValidator
    {
        private readonly IClassRepository _classRepository;
        private readonly ITeacherRepository _teacherRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly INullOrZeroValidator _nullOrZeroValidator;

        public ClassInputDtoParametersValidator(
            IClassRepository classRepository,
            ITeacherRepository teacherRepository,
            ICourseRepository courseRepository,
            INullOrZeroValidator nullOrZeroValidator)
        {
            this._classRepository = classRepository;
            this._teacherRepository = teacherRepository;
            this._courseRepository = courseRepository;
            this._nullOrZeroValidator = nullOrZeroValidator;
        }

        public void ClassId(int classId, OperationResponseBase response, string lineWithError)
        {
            if (!this._nullOrZeroValidator.Execute(classId, response, "Id"))
            {
                if (this._classRepository.ExistByClassId(classId) == true)
                {
                    response.AddError("025", $"{lineWithError} ClassId already exist.");
                }
            }
        }

        public void Teacher(string teacher, OperationResponseBase response, string lineWithError)
        {
            if (!this._nullOrZeroValidator.Execute(teacher, response, "Teacher"))
            {
                if (!this._teacherRepository.ExistByName(teacher))
                {
                    response.AddError("026", $"{lineWithError} Invalid teacher.");
                }
            }
        }

        public void Course(string course, OperationResponseBase response, string lineWithError)
        {
            if (!this._nullOrZeroValidator.Execute(course, response, "Course"))
            {
                if (!this._courseRepository.ExistByName(course))
                {
                    response.AddError("027", $"{lineWithError} Invalid course.");
                }
            }
        }

        public void Shift(string shift, OperationResponseBase response, string lineWithError)
        {
            if (!this._nullOrZeroValidator.Execute(shift, response,"Shift"))
            {
                if (!char.IsUpper(shift[0]))
                {
                    response.AddError("028", $"{lineWithError} First letter of shift must be in uppercase.");
                }
                else if (shift != "Manhã" && shift != "Tarde" && shift != "Noite")
                {
                    response.AddError("029", $"{lineWithError} Invalid Shift! Valid shifts: Manhã, Tarde, Noite");
                }
            }
        }

        public void Date(DateTime startDate, DateTime endDate, OperationResponseBase response, string lineWithError)
        {
            if (!this._nullOrZeroValidator.Execute(startDate, response, "StartDate") && !this._nullOrZeroValidator.Execute(endDate, response, "EndDate"))
            {
                if (startDate > endDate)
                {
                    response.AddError("030", $"{lineWithError} StartDate can't be bigger than EndDate");
                }
            }
        }

        public void Time(TimeSpan startTime, TimeSpan endTime, OperationResponseBase response, string lineWithError)
        {
            if (!this._nullOrZeroValidator.Execute(startTime, response, "StartTime") && !this._nullOrZeroValidator.Execute(endTime, response, "EndTime"))
            {
                StartTime(startTime, response, lineWithError);
                
                EndTime(endTime, response, lineWithError);

                if (startTime > endTime)
                {
                    response.AddError("031", $"{lineWithError} StartTime can't be bigger than EndTime");
                }
                else if (endTime - startTime > TimeSpan.FromHours(3))
                {
                    response.AddError("034", $"{lineWithError} Duration can't be bigger than 3h");
                }
            }
        }

        private void StartTime(TimeSpan startTime, OperationResponseBase response, string lineWithError)
        {
             if (startTime < TimeSpan.FromHours(8))
             {
                 response.AddError("032", $"{lineWithError} The course can't start before 8:00");
             }
        }

        private void EndTime(TimeSpan endTime, OperationResponseBase response, string lineWithError)
        {
            if (endTime < TimeSpan.FromHours(8))
            {
                response.AddError("033", $"{lineWithError} The course can't end after 22:00");
            }
        }
    }
}
