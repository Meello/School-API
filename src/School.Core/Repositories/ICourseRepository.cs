using System;
using System.Collections.Generic;
using System.Text;

namespace School.Core.Repositories
{
    public interface ICourseRepository
    {
        long GetCourseIdByName(string name);
    }
}
