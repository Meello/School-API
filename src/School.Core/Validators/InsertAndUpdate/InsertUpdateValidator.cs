using School.Core.Repositories;
using School.Core.ValidatorsTeacher;
using StoneCo.Buy4.School.DataContracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.Core.Validators.InsertAndUpdate
{
    public class InsertUpdateValidator<TResponse> : IInsertAndUpdateValidator<TResponse>
        where TResponse : OperationResponseBase, new()
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly ITeacherValidator _teacherValidator;

        public InsertUpdateValidator(ITeacherRepository teacherRepository, ITeacherValidator validator)
        {
            this._teacherRepository = teacherRepository;
            this._teacherValidator = validator;
        }

        public TResponse ValidateInsertAndUpdate(TeacherRequestData requestData)
        {
            TResponse response = new TResponse();

            if (requestData == null)
            {
                response.AddError("001", "Request can't be null");

                return response;
            }

            if (this._teacherRepository.ExistByTeacherId(requestData.TeacherId) == false)
            {
                response.Errors.Add(new OperationError("003", $"{nameof(requestData.TeacherId)} not found"));

                return response;
            }

            if (this._teacherValidator.ValidateTeacher(requestData, response) == false)
            {
                return response;
            }

            return response;
        }
    }
}
