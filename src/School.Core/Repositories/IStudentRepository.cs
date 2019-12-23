using System;
using System.Collections.Generic;
using System.Text;

namespace School.Core.Repositories
{
    public interface IStudentRepository
    {
        bool ExistByStudentId(long studentId);
    }
}
