using System;
using System.Collections.Generic;
using System.Text;

namespace School.Core.Repositories
{
    public interface ILevelRepository
    {
        bool ExistByLevelId(char levelId);

        IEnumerable<char> ListAll();
    }
}
