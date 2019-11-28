using School.Core.Mapping;
using School.Core.Models;
using School.Core.Repositories;
using StoneCo.Buy4.School.DataContracts;
using StoneCo.Buy4.School.DataContracts.InsertTeacher;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.Core.Operations.InsertTeacher
{
    public class InsertTeacher : IInsertTeacher
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly ISchoolMappingResolver _mappingResolver;

        public InsertTeacher(ITeacherRepository teacherRepository, ISchoolMappingResolver mappingResolver)
        {
            this._teacherRepository = teacherRepository;
            this._mappingResolver = mappingResolver;
        }

        public InsertTeacherResponse ProcessOperation(InsertTeacherRequest request)
        {
            //InsertTeacherResponse response = new InsertTeacherResponse();

            Teacher teacher = this._mappingResolver.BuildFrom(request.Data);

            InsertTeacherResponse response = ValidateOperation(teacher);
            
            this._teacherRepository.Insert(teacher);

            InsertTeacherResponse responseIfExist = ValidateInsert(teacher);

            if (response.Success == false)
            {
                return response;
            }

            if (request == null)
            {
                response.Success = false;
                return response;
            }

            response.Data = this._mappingResolver.BuildFrom(teacher);
            response.Success = true;

            return response;
        }

        //Fui tentar melhor, achei um erro e não consegui verificar se o id já existe dentro da outra verificação
        private InsertTeacherResponse ValidateInsert(Teacher teacher)
        {
            InsertTeacherResponse response = new InsertTeacherResponse
            {
                Errors = new List<OperationError>()
            };

            if (teacher.Id == -1)
            {
                response.Errors.Add(new OperationError("014", "Operation can't be done. Id already exist"));
                return response;
            }

            response.Success = true;
            return response;
            
        }
    private InsertTeacherResponse ValidateOperation(Teacher teacher)
        {
            InsertTeacherResponse response = new InsertTeacherResponse
            {
                Errors = new List<OperationError>()
            };

            if (teacher == null)
            {
                response.Errors.Add(new OperationError("001", "Request can't be null"));
                return response;
            }

            if (teacher.Id == 0)
            {
                response.Errors.Add(new OperationError("002", "Id can't be null"));
            }

            if (teacher.Name == null)
            {
                response.Errors.Add(new OperationError("009", "Name can't be null"));
            }
            else
            {
                if (teacher.Name.Length > 32)
                {
                    response.Errors.Add(new OperationError("004", "Name lenght don't supported! Limit: 32 caracters"));
                }
            }

            if(teacher.Gender == '\u0000')
            {
                response.Errors.Add(new OperationError("010", "Gender can't be null"));
            }
            else
            { 
                if (teacher.Gender != 'F' && teacher.Gender != 'M')
                {
                    response.Errors.Add(new OperationError("005", "Invalid Gender! Choose M or F"));
                }          
            }

            if(teacher.Level == '\u0000')
            {
                response.Errors.Add(new OperationError("011", "Level can't be null"));
            }
            else
            {
                if (teacher.Level != 'J' && teacher.Level != 'P' && teacher.Level != 'S')
                {
                    response.Errors.Add(new OperationError("006", "Invalid Level! Choose J or P or S"));
                }
            }

            if(teacher.Salary == decimal.Zero)
            {
                response.Errors.Add(new OperationError("012", "Salary can't be null"));
            }
            else
            {
                if (teacher.Salary < 1000 || teacher.Salary > 10000)
                {
                    response.Errors.Add(new OperationError("007", "Value don't accepted! Choose some value betewwn 1000 and 10000"));
                }
            }

            if (teacher.AdmitionDate == DateTime.MinValue)
            {
                response.Errors.Add(new OperationError("013", "AdmitionDate can't be null"));
            }
            else
            {
                if (teacher.AdmitionDate > DateTime.Today)
                {
                    response.Errors.Add(new OperationError("008", "Admition date can't be bigger than today"));
                }
            }

            if (response.Errors.Count == 0)
            {
                response.Success = true;
            }

            return response;
        }
    }
}
