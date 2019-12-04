using School.Core.Models;
using StoneCo.Buy4.School.DataContracts.DeleteTeacher;
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

        IEnumerable<Models.Teacher> ListAll();

        void Insert(Models.Teacher teacher);

        void Update(Teacher teacher);

        void Delete(long cpf);
    }
}