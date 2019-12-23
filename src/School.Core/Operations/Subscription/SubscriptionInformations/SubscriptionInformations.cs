using School.Core.Mapping;
using School.Core.Repositories;
using StoneCo.Buy4.School.Core.DTO;
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
        private readonly ISchoolMappingResolver _mappingResolver;

        public SubscriptionInformations(ISubscriptionRepository classRepository, ISchoolMappingResolver mappingResolver)
        {
            this._classRepository = classRepository;
            this._mappingResolver = mappingResolver;
        }

        protected override SubscriptionInformationsResponse ProcessOperation(SubscriptionInformationsRequest request)
        {
            SubscriptionInformationsResponse response = new SubscriptionInformationsResponse();

            IEnumerable<SubscriptionInformationData> informations = this._classRepository.SubscriptionInformations();

            List<InformationResponseData> responseDatas = this._mappingResolver.BuildFrom(informations);

            response.Data = responseDatas;

            return response;
        }

        protected override SubscriptionInformationsResponse ValidateOperation(SubscriptionInformationsRequest request)
        {
            return new SubscriptionInformationsResponse();
        }
    }
}
