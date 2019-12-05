using System;
using System.Collections.Generic;
using System.Text;

namespace School.Core.Models
{
    public static class ModelConstants
    {
        public static class Teacher
        {
            public const int NameMaxLength = 32;

            public const decimal MinSalary = 1000;

            public const decimal MaxSalary = 10000;

            public const int MaxTeachersPerPage = 100;
        }

    }
}
