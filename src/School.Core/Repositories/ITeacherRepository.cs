using School.Core.Filters;
using School.Core.Models;
using StoneCo.Buy4.School.DataContracts.SearchTeacher;
using System.Collections.Generic;

namespace School.Core.Repositories
{
    public interface ITeacherRepository
    {
        //Interface define o contrato
        Teacher Get(long cpf);

        PagedResult<Teacher> ListPagedByFilter(TeacherFilter filter, int pageNumber, int pageSize);

        IEnumerable<Teacher> ListAll();

        void Insert(List<Teacher> teacher);

        void Update(Teacher teacher);

        void Delete(long cpf);

        bool ExistByTeacherId(long teacherId);

        long GetTeacherIdByName(string name);
    }
}