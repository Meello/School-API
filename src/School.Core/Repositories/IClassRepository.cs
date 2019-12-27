using School.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.Core.Repositories
{
    public interface IClassRepository
    {
        void Insert(SchoolClass schoolClass);

        void Insert(List<SchoolClass> schoolClasses);

        bool ExistByClassId(byte classId);
    }
}
