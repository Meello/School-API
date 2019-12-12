using School.Core.Models;
using StoneCo.Buy4.School.DataContracts.SearchTeacher;
using System.Collections.Generic;

namespace School.Core.Repositories
{
    public interface ITeacherRepository
    {
        //Interface define o contrato
        Teacher Get(long cpf);

        IEnumerable<Teacher> Search(SearchTeacherRequest request, string sqlWhereConditions);

        IEnumerable<Teacher> ListAll();

        IEnumerable<Teacher> GetPerPage(long pageNumber, long teachersPerPage);

        void Insert(Teacher teacher);

        void Update(Teacher teacher);

        void Delete(long cpf);
    }
}