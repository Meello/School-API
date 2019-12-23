using Microsoft.AspNetCore.Mvc;
using School.Core.Operations.Subscription.EnrolledStudents;
using School.Core.Operations.Subscription.SubscriptionInformations;
using StoneCo.Buy4.School.DataContracts.InformationsSubscription;
using StoneCo.Buy4.School.DataContracts.Subscription.EnrolledStudents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.Application.Controllers
{
    [Route("api/subscriptions")]

    public class SubscriptionController : ControllerBase
    {
        private readonly ISubscriptionInformations _subscriptionInformation;
        private readonly IEnrolledStudents _enrolledStudents;

        public SubscriptionController(ISubscriptionInformations informationSubscription, IEnrolledStudents enrolledStudents)
        {
            this._subscriptionInformation = informationSubscription;
            this._enrolledStudents = enrolledStudents;
        }

        [HttpPost("informations")]
        public ActionResult<SubscriptionInformationsResponse> Informations()
        {
            SubscriptionInformationsRequest request = new SubscriptionInformationsRequest();
            SubscriptionInformationsResponse response = this._subscriptionInformation.Process(request);

            if(!response.Success)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpPost("enrolled_students")]
        public ActionResult<EnrolledStudentsResponse> EnrolledStudents()
        {
            EnrolledStudentsRequest request = new EnrolledStudentsRequest();
            EnrolledStudentsResponse response = this._enrolledStudents.Process(request);

            if (!response.Success)
            {
                return NotFound(response);
            }

            return Ok(response);
        }
    }
}
