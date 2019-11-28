using System;
using System.Collections.Generic;
using System.Text;
using School.Core.Mapping;
using School.Core.Models;
using School.Core.Repositories;
using StoneCo.Buy4.School.DataContracts;
using StoneCo.Buy4.School.DataContracts.UpdateTeacher;

namespace School.Core.Operations.UpdateTeacher
{
    public class UpdateTeacher : IUpdateTeacher
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly ISchoolMappingResolver _mappingResolver;

        public UpdateTeacher(ITeacherRepository teacherRepository, ISchoolMappingResolver mappingResolver)
        {
            this._teacherRepository = teacherRepository;
            this._mappingResolver = mappingResolver;
        }

        public UpdateTeacherResponse ProcessOperation(UpdateTeacherRequest request)
        {
            UpdateTeacherRequestData teacher = this._mappingResolver.BuildFrom(request.Data);

            //O objeto para ser passado para o BuildFrom deve ser o que recebe o repositório
            //Tomar cuidado para não enviar a requisição
            Teacher updatedTeacher = this._teacherRepository.Update(teacher);

            UpdateTeacherResponse response = ValidateRequestOperation(updatedTeacher);

            if (response.Success == false)
            {
                return response;
            }

            if (request == null)
            {
                response.Success = false;
                return response;
            }

            response.Data = this._mappingResolver.BuildFrom(updatedTeacher);

            response.Success = true;

            return response;
        }

        private UpdateTeacherResponse ValidateRequestOperation(Teacher teacher)
        {
            UpdateTeacherResponse response = new UpdateTeacherResponse
            {
                Errors = new List<OperationError>()
            };

            if (teacher == null)
            {
                response.Errors.Add(new OperationError("003", "Id not found"));
                return response;
            }

            //Quando o if(teacher.Id ==0) estava em cima, deu erro
            if (teacher.Id == 0)
            {
                response.Errors.Add(new OperationError("002", "Id can't be null"));
                return response;
            }

            if (teacher.Name.Length > 32)
            {
                response.Errors.Add(new OperationError("004", "Name lenght don't supported! Limit: 32 caracters"));
            }

            if (teacher.Gender != null)
            {
                if (teacher.Gender != 'F' && teacher.Gender != 'M')
                {
                    response.Errors.Add(new OperationError("005", "Invalid Gender! Choose M or F"));
                }
            }

            if (teacher.Level != null)
            {
                if (teacher.Level != 'J' && teacher.Level != 'P' && teacher.Level != 'S')
                {
                    response.Errors.Add(new OperationError("006", "Invalid Level! Choose J or P or S"));
                }
            }

            if (teacher.Salary != null)
            {
                if (teacher.Salary < 1000 || teacher.Salary > 10000)
                {
                    response.Errors.Add(new OperationError("007", "Value don't accepted! Choose some value betewwn 1000 and 10000"));
                }
            }

            if (teacher.AdmitionDate != null)
            {
                if (teacher.AdmitionDate > DateTime.Today)
                {
                    response.Errors.Add(new OperationError("008", "Admition date can't be bigger than today"));
                }
            }

            if(response.Errors.Count == 0)
            {
                response.Success = true;
            }

            return response;
        }
    }
}
