using System;
using System.Collections.Generic;
using System.Text;

namespace StoneCo.Buy4.School.DataContracts.DeleteTeacher
{
    public class DeleteTeacherRequest
    {
        public DeleteTeacherRequest(long cpf)
        {
            this.CPF = cpf;
        }

        public long CPF { get; }
    }
}
