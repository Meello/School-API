using School.Core.Repositories;
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

        public SubscriptionValidator(ISubscriptionRepository subscriptionRepository)
        {
            this._subscriptionRepository = subscriptionRepository;
        }

        public InsertSubscriptionResponse ValidateSubscription(SubscriptionRequestData requestData)
        {
            InsertSubscriptionResponse response = new InsertSubscriptionResponse();

            if(!this.IsNullOrZero(requestData.StudentId, response, nameof(requestData.StudentId)))
            {
                if (!this._subscriptionRepository.ExistByStudentId(requestData.ClassId))
                {
                    response.AddError("023", "StudentId don't exist");
                }
            }

            if(!this.IsNullOrZero(requestData.ClassId, response, nameof(requestData.ClassId)))
            {
                if (!this._subscriptionRepository.ExistByClassId(requestData.ClassId))
                {
                    response.AddError("022", "ClassId don't exist");
                }
            }

            return response;
        }

        public bool IsNullOrZero(long? num, InsertSubscriptionResponse response, string fieldname)
        {
            if(num == 0 || num == null)
            {
                response.AddError("002", $"{fieldname} can't be null or zero");

                return true;
            }

            return false;
        }

        public bool IsNullOrZero(int? num, InsertSubscriptionResponse response, string fieldname)
        {
            if (num == 0 || num == null)
            {
                response.AddError("002", $"{fieldname} can't be null or zero");

                return true;
            }

            return false;
        }
    }
}
