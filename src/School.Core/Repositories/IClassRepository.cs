using System;
using System.Collections.Generic;
using System.Text;

namespace School.Core.Repositories
{
    public interface IClassRepository
    {
        bool ExistByClassId(byte classId);
    }
}
