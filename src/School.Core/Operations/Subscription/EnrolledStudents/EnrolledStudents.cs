using School.Core.Mapping;
using School.Core.Repositories;
using StoneCo.Buy4.School.Core.DTO;
using StoneCo.Buy4.School.DataContracts.Subscription.EnrolledStudents;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.Core.Operations.Subscription.EnrolledStudents
{
    public class EnrolledStudents : OperationBase<EnrolledStudentRequest, EnrolledStudentResponse>, IEnrolledStudents
    {
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly ISchoolMappingResolver _mappingResolver;

        public EnrolledStudents(ISubscriptionRepository subscriptionRepository, ISchoolMappingResolver mappingResolver)
        {
            this._subscriptionRepository = subscriptionRepository;
            this._mappingResolver = mappingResolver;
        }

        protected override EnrolledStudentResponse ProcessOperation(EnrolledStudentRequest request)
        {
            EnrolledStudentResponse response = new EnrolledStudentResponse();
            
            IEnumerable<EnrolledStudentData> enrolledStudents = this._subscriptionRepository.EnrolledStudents();

            List<EnrolledStudentResponseData> responseDatas = this._mappingResolver.BuildFrom(enrolledStudents);

            response.Data = responseDatas;

            return response;
        }

        protected override EnrolledStudentResponse ValidateOperation(EnrolledStudentRequest request)
        {
            return new EnrolledStudentResponse();
        }
    }
}
