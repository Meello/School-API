using School.Core.Filters;
using School.Core.Models;
using StoneCo.Buy4.School.Core.DTO;
using StoneCo.Buy4.School.DataContracts;
using StoneCo.Buy4.School.DataContracts.SearchTeacher;
using StoneCo.Buy4.School.DataContracts.Subscription.EnrolledStudents;
using StoneCo.Buy4.School.DataContracts.Subscription.InformationsSubscription;
using System.Collections.Generic;

namespace School.Core.Mapping
{
    public interface ISchoolMappingResolver
    {
        TeacherResponseData BuildFrom(Teacher teacher);

        Teacher BuildFrom(TeacherRequestData requestData);

        List<Teacher> BuildFrom(IEnumerable<TeacherRequestData> requestDatas);

        List<TeacherResponseData> BuildFrom(IEnumerable<Teacher> teacher);

        TeacherFilter BuildFrom(RequestFilter requestFilter);

        EnrolledStudentResponseData BuildFrom(EnrolledStudentData enrolledStudent);

        List<EnrolledStudentResponseData> BuildFrom(IEnumerable<EnrolledStudentData> enrolledStudents);

        InformationResponseData BuildFrom(SubscriptionInformationData subscriptionInformation);

        List<InformationResponseData> BuildFrom(IEnumerable<SubscriptionInformationData> subscriptionInformation);
    }
}
