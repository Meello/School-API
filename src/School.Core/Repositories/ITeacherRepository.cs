using School.Core.Models;
using StoneCo.Buy4.School.DataContracts.UpdateTeacher;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.Core.Repositories
{
    public interface ITeacherRepository
    {
        //Interface define o contrato
        Teacher Get(long id);

        List<Teacher> ListAll();

        Teacher Insert(Teacher teacher);

        Teacher Update(UpdateTeacherRequestData teacher);

        Teacher Delete(long id);
    }
}