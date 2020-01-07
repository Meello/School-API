using School.Core.Models;
using StoneCo.Buy4.School.DataContracts;
using System;
using System.Collections.Generic;
using System.Text;
using School.Core.ValidatorsTeacher;
using School.Core.Validators.ValidateTeacherParameters;
using StoneCo.Buy4.School.DataContracts.InsertTeacher;
using School.Core.Validators.NullOrZero;

namespace School.Core.ValidatorsTeacher
{
    public class TeacherValidator : ITeacherValidator
    {
        private readonly ITeacherParametersValidator _validator;
        private readonly IIsNullOrZeroValidator _nullOrZeroValidator;

        public TeacherValidator(
            ITeacherParametersValidator validator,
            IIsNullOrZeroValidator nullOrZeroValidator
            )
        {
            this._validator = validator;
            this._nullOrZeroValidator = nullOrZeroValidator;
        }

        public void ValidateTeacher(Teacher teacher, OperationResponseBase response)
        {
            if(teacher == null)
            {
                response.AddError("001", "Request can't be null");

                return;
            }

            this._validator.ValidateTeacherId(teacher.TeacherId, response);
            
            this._validator.ValidateName(teacher.Name, response);
            
            this._validator.ValidateGender(teacher.Gender, response);
            
            this._validator.ValidateLevel(teacher.LevelId, response);
            
            this._validator.ValidateSalary(teacher.Salary, response, nameof(teacher.Salary));
            
            this._validator.ValidateAdmitionDate(teacher.AdmitionDate, response, nameof(teacher.AdmitionDate));
        }
    }
}