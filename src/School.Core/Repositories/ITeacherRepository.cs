using School.Core.Models;
using StoneCo.Buy4.School.DataContracts.DeleteTeacher;
using StoneCo.Buy4.School.DataContracts.FilterTeacher;
using StoneCo.Buy4.School.DataContracts.GetTeacherPerPage;
using StoneCo.Buy4.School.DataContracts.InsertTeacher;
using StoneCo.Buy4.School.DataContracts.UpdateTeacher;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.Core.Repositories
{
    public interface ITeacherRepository
    {
        //Interface define o contrato
        Teacher Get(long cpf);

        List<Teacher> Search(SearchTeacherRequestData requestData);

        IEnumerable<Teacher> ListAll();

        List<Teacher> GetPerPage(GetTeachersPerPageRequestData requestData);

        void Insert(Teacher teacher);

        void Update(Teacher teacher);

        void Delete(long cpf);
    }
}