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

        IEnumerable<Teacher> ListAll();

        Teacher Insert(Teacher teacher, InsertTeacherResponse response);

        Teacher Update(UpdateTeacherRequestData teacher, UpdateTeacherResponse response);

        Teacher Delete(long cpf, DeleteTeacherResponse response);
    }
}