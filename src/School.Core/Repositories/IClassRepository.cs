using School.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.Core.Repositories
{
    public interface IClassRepository
    {
        void Insert(Class @class);

        bool ExistByClassId(byte classId);
    }
}
