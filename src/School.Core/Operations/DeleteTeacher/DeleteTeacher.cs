using School.Core.Mapping;
using School.Core.Models;
using School.Core.Repositories;
using School.Core.Validators.IdValidator;
using StoneCo.Buy4.School.DataContracts.DeleteTeacher;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.Core.Operations.DeleteTeacher
{
    //NÃO PODE ESQUECER DE IMPLEMENTAR O CONTRATO
    public class DeleteTeacher : IDeleteTeacher
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly IDataBaseValidator _dataBaseValidator;

        public DeleteTeacher(ITeacherRepository teacherRepository, IDataBaseValidator dataBaseValidator)
        {
            this._teacherRepository = teacherRepository;
            this._dataBaseValidator = dataBaseValidator;
        }

        public DeleteTeacherResponse ProcessOperation(DeleteTeacherRequest request)
        {
            DeleteTeacherResponse response = new DeleteTeacherResponse();

            if (this._dataBaseValidator.ValidateIdExist(request.CPF) == false)
            {
                response.Success = false;
                return response;
            }

            this._teacherRepository.Delete(request.CPF);

            response.Success = true;

            return response;
        }
    }
}
