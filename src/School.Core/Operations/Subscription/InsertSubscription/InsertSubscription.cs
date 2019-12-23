using School.Core.Repositories;
using School.Core.Validators.Subscription;
using StoneCo.Buy4.School.DataContracts.Subscription.InsertSubscription;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.Core.Operations.Subscription.InsertSubscription
{
    public class InsertSubscription : OperationBase<InsertSubscriptionRequest, InsertSubscriptionResponse>, IInsertSubscription
    {
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly ISubscriptionValidator _validator;

        public InsertSubscription(ISubscriptionRepository subscriptionRepository, ISubscriptionValidator validator)
        {
            this._subscriptionRepository = subscriptionRepository;
            this._validator = validator;
        }

        protected override InsertSubscriptionResponse ProcessOperation(InsertSubscriptionRequest request)
        {
            InsertSubscriptionResponse response = new InsertSubscriptionResponse();

            this._subscriptionRepository.InsertSubscription(request.Data);

            return response;
        }

        protected override InsertSubscriptionResponse ValidateOperation(InsertSubscriptionRequest request)
        {
            InsertSubscriptionResponse response = this._validator.ValidateSubscription(request.Data);

            return response;
        }
    }
}
