using System;
using System.Collections.Generic;
using System.Text;

namespace School.Core.Repositories
{
    public interface ICourseRepository
    {
        bool ExistByName(string name);

        int GetCourseIdByName(string name);
    }
}
