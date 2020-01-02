using School.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.Core.Repositories
{
    public interface IClassRepository
    {
        void Insert(Class schoolClass);

        void Insert(List<Class> schoolClasses);

        bool ExistByClassId(int classId);
    }
}
