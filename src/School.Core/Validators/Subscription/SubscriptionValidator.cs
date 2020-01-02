using School.Core.Repositories;
using School.Core.Validators.NullOrZero;
using StoneCo.Buy4.School.DataContracts.Subscription;
using StoneCo.Buy4.School.DataContracts.Subscription.InsertSubscription;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.Core.Validators.Subscription
{
    public class SubscriptionValidator : ISubscriptionValidator
    {
        private readonly INullOrZeroValidator _validator;
        private readonly IStudentRepository _studentRepository;
        private readonly IClassRepository _classRepository;

        public SubscriptionValidator(
            INullOrZeroValidator nullOrZeroValidator,
            IStudentRepository studentRepository,
            IClassRepository classRepository)
        {
            this._validator = nullOrZeroValidator;
            this._studentRepository = studentRepository;
            this._classRepository = classRepository;
        }

        public InsertSubscriptionResponse ValidateSubscription(SubscriptionRequestData requestData)
        {
            InsertSubscriptionResponse response = new InsertSubscriptionResponse();

            if(!this._validator.Execute(requestData.StudentId, response, nameof(requestData.StudentId)))
            {
                if (!this._studentRepository.ExistByStudentId(requestData.StudentId))
                {
                    response.AddError("023", "StudentId don't exist");
                }
            }

            if(!this._validator.Execute(requestData.ClassId, response, nameof(requestData.ClassId)))
            {
                if (!this._classRepository.ExistByClassId(requestData.ClassId))
                {
                    response.AddError("022", "ClassId don't exist");
                }
            }

            return response;
        }
    }
}
