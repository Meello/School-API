using School.Core.Models;
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

        Teacher Update(long id, string name, char? gender, char? levelId, decimal? salary, DateTime? admitionDate);

        Teacher Delete(long id);
    }
}