using Microsoft.AspNetCore.Mvc;
using School.Core.Operations.Subscription.EnrolledStudents;
using School.Core.Operations.Subscription.GetSubscriptions;
using School.Core.Operations.Subscription.InsertSubscription;
using School.Core.Operations.Subscription.SubscriptionInformations;
using StoneCo.Buy4.School.DataContracts.InformationsSubscription;
using StoneCo.Buy4.School.DataContracts.Subscription;
using StoneCo.Buy4.School.DataContracts.Subscription.EnrolledStudents;
using StoneCo.Buy4.School.DataContracts.Subscription.GetSubscriptions;
using StoneCo.Buy4.School.DataContracts.Subscription.InsertSubscription;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.Application.Controllers
{
    [Route("api/v1/subscriptions")]

    public class SubscriptionController : ControllerBase
    {
        private readonly ISubscriptionInformations _subscriptionInformation;
        private readonly IEnrolledStudents _enrolledStudents;
        private readonly IInsertSubscription _insertSubscription;
        private readonly IGetSubscriptions _getSubscriptions;

        public SubscriptionController(
            ISubscriptionInformations informationSubscription, 
            IEnrolledStudents enrolledStudents,
            IInsertSubscription insertSubscription,
            IGetSubscriptions getSubscriptions)
        {
            this._subscriptionInformation = informationSubscription;
            this._enrolledStudents = enrolledStudents;
            this._insertSubscription = insertSubscription;
            this._getSubscriptions = getSubscriptions;
        }

        [HttpGet]
        public ActionResult<GetSubscriptionsResponse> Get()
        {
            GetSubscriptionsRequest request = new GetSubscriptionsRequest();
            GetSubscriptionsResponse response = this._getSubscriptions.Process(request);

            return response;
        }

        [HttpPost]
        public ActionResult<InsertSubscriptionResponse> Insert([FromBody]SubscriptionRequestData requestData)
        {
            InsertSubscriptionRequest request = new InsertSubscriptionRequest(requestData);
            InsertSubscriptionResponse response = this._insertSubscription.Process(request);

            if(!response.Success)
            {
                return BadRequest(response);
            }

            return response;
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
        public ActionResult<EnrolledStudentResponse> EnrolledStudents()
        {
            EnrolledStudentRequest request = new EnrolledStudentRequest();
            EnrolledStudentResponse response = this._enrolledStudents.Process(request);

            if (!response.Success)
            {
                return NotFound(response);
            }

            return Ok(response);
        }
    }
}
