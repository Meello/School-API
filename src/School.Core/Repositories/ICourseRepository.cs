using System;
using System.Collections.Generic;
using System.Text;

namespace School.Core.Repositories
{
    public interface ICourseRepository
    {
        int GetCourseIdByName(string name);
    }
}
