using System;
using System.Collections.Generic;
using System.Text;

namespace StoneCo.Buy4.School.DataContracts.GetTeacher
{
    public class GetTeacherRequest : OperationRequestBase
    {
        public GetTeacherRequest(long cpf)
        {
            this.CPF = cpf;
        }

        public long CPF{ get; }
    }
}
