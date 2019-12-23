using School.Core.Mapping;
using School.Core.Models;
using School.Core.Repositories;
using StoneCo.Buy4.School.DataContracts.DeleteTeacher;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.Core.Operations.DeleteTeacher
{
    //NÃO PODE ESQUECER DE IMPLEMENTAR O CONTRATO
    public class DeleteTeacher : OperationBase<DeleteTeacherRequest, DeleteTeacherResponse>, IDeleteTeacher
    {
        private readonly ITeacherRepository _teacherRepository;

        public DeleteTeacher(ITeacherRepository teacherRepository)
        {
            this._teacherRepository = teacherRepository;
        }

        protected override DeleteTeacherResponse ProcessOperation(DeleteTeacherRequest request)
        {
            DeleteTeacherResponse response = new DeleteTeacherResponse();

            this._teacherRepository.Delete(request.TeacherId);

            return response;
        }

        protected override DeleteTeacherResponse ValidateOperation(DeleteTeacherRequest request)
        {
            DeleteTeacherResponse response = new DeleteTeacherResponse();

            if (this._teacherRepository.ExistByTeacherId(request.TeacherId) == false)
            {
                response.AddError("003", $"{nameof(request.TeacherId)} not found");
            }

            return response;
        }
    }
}
