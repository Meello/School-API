using School.Core.Repositories;
using StoneCo.Buy4.School.DataContracts.InformationsSubscription;
using StoneCo.Buy4.School.DataContracts.Subscription.InformationsSubscription;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace School.Core.Operations.Subscription.SubscriptionInformations
{
    public class SubscriptionInformations : OperationBase<SubscriptionInformationsRequest, SubscriptionInformationsResponse>, ISubscriptionInformations
    {
        private readonly ISubscriptionRepository _classRepository;

        public SubscriptionInformations(ISubscriptionRepository classRepository)
        {
            this._classRepository = classRepository;
        }

        protected override SubscriptionInformationsResponse ProcessOperation(SubscriptionInformationsRequest request)
        {
            SubscriptionInformationsResponse response = new SubscriptionInformationsResponse();

            response.Data = this._classRepository.InformationsView().ToList();

            return response;
        }

        protected override SubscriptionInformationsResponse ValidateOperation(SubscriptionInformationsRequest request)
        {
            return new SubscriptionInformationsResponse();
        }
    }
}
