using School.Core.Repositories;
using StoneCo.Buy4.School.DataContracts.Subscription;
using StoneCo.Buy4.School.DataContracts.Subscription.GetSubscriptions;
using System.Collections.Generic;
using System.Linq;

namespace School.Core.Operations.Subscription.GetSubscriptions
{
    public class GetSubscriptions : OperationBase<GetSubscriptionsRequest, GetSubscriptionsResponse>, IGetSubscriptions
    {
        private readonly ISubscriptionRepository _subscriptionRepository;

        public GetSubscriptions(ISubscriptionRepository subscriptionRepository)
        {
            this._subscriptionRepository = subscriptionRepository;
        }

        protected override GetSubscriptionsResponse ProcessOperation(GetSubscriptionsRequest request)
        {
            GetSubscriptionsResponse response = new GetSubscriptionsResponse();

            List<SubscriptionResponseData> subscriptions = this._subscriptionRepository.ListAll().ToList();

            response.Data = subscriptions;

            return response;
        }

        protected override GetSubscriptionsResponse ValidateOperation(GetSubscriptionsRequest request)
        {
            return new GetSubscriptionsResponse();
        }
    }
}
