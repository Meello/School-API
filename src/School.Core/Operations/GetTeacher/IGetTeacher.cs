using StoneCo.Buy4.School.DataContracts.GetTeacher;

namespace School.Core.Operations.GetTeacher
{
    public interface IGetTeacher
    {
        GetTeacherResponse Process(GetTeacherRequest request);
    }
}