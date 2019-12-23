using School.Core.Repositories;
using StoneCo.Buy4.School.DataContracts.Subscription.EnrolledStudents;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.Core.Operations.Subscription.EnrolledStudents
{
    public class EnrolledStudents : OperationBase<EnrolledStudentsRequest, EnrolledStudentsResponse>, IEnrolledStudents
    {
        private readonly ISubscriptionRepository _subscriptionRepository;

        public EnrolledStudents(ISubscriptionRepository subscriptionRepository)
        {
            this._subscriptionRepository = subscriptionRepository;
        }

        protected override EnrolledStudentsResponse ProcessOperation(EnrolledStudentsRequest request)
        {
            EnrolledStudentsResponse response = new EnrolledStudentsResponse();

            response.Data = this._subscriptionRepository.EnrolledStudentsView();

            return response;
        }

        protected override EnrolledStudentsResponse ValidateOperation(EnrolledStudentsRequest request)
        {
            return new EnrolledStudentsResponse();
        }
    }
}
