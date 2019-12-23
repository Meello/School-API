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
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly IIsNullOrZeroValidator _validator;

        public SubscriptionValidator(ISubscriptionRepository subscriptionRepository, IIsNullOrZeroValidator nullOrZeroValidator)
        {
            this._subscriptionRepository = subscriptionRepository;
            this._validator = nullOrZeroValidator;
        }

        public InsertSubscriptionResponse ValidateSubscription(SubscriptionRequestData requestData)
        {
            InsertSubscriptionResponse response = new InsertSubscriptionResponse();

            if(!this._validator.IsNullOrZero(requestData.StudentId, response, nameof(requestData.StudentId)))
            {
                if (!this._subscriptionRepository.ExistByStudentId(requestData.StudentId))
                {
                    response.AddError("023", "StudentId don't exist");
                }
            }

            if(!this._validator.IsNullOrZero(requestData.ClassId, response, nameof(requestData.ClassId)))
            {
                if (!this._subscriptionRepository.ExistByClassId(requestData.ClassId))
                {
                    response.AddError("022", "ClassId don't exist");
                }
            }

            return response;
        }
    }
}
