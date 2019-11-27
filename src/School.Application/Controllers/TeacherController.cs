using Microsoft.AspNetCore.Mvc;
using School.Core.Models;
using School.Core.Operations.DeleteTeacher;
using School.Core.Operations.GetTeacher;
using School.Core.Operations.GetTeachers;
using School.Core.Operations.InsertTeacher;
using School.Core.Operations.UpdateTeacher;
using StoneCo.Buy4.School.DataContracts.DeleteTeacher;
using StoneCo.Buy4.School.DataContracts.GetTeacher;
using StoneCo.Buy4.School.DataContracts.GetTeachers;
using StoneCo.Buy4.School.DataContracts.InsertTeacher;
using StoneCo.Buy4.School.DataContracts.UpdateTeacher;
using System;

namespace School.Application.Controllers
{
    [Route("api/teachers")]
    //sempre plural o nome de rota --> boas praticas API REST
    //[ApiController] evitar de usar --> customizar as mensagens de erro
    public class TeacherController : ControllerBase

    {
        private readonly IGetTeacher _getTeacher;
        private readonly IGetTeachers _getTeachers;
        private readonly IDeleteTeacher _deleteTeacher;
        private readonly IUpdateTeacher _updateTeacher;
        private readonly IInsertTeacher _insertTeacher;

        //Criando lista, deve colocar no plural
        //sempre que precisar de alguma dependência, acrescentar no construtor

        public TeacherController(
            IGetTeacher getTeacher,
            IGetTeachers getTeachers,
            IDeleteTeacher deleteTeacher,
            IUpdateTeacher updateTeacher,
            IInsertTeacher insertTeacher)
        {
            this._getTeacher = getTeacher;
            this._getTeachers = getTeachers;
            this._deleteTeacher = deleteTeacher;
            this._updateTeacher = updateTeacher;
            this._insertTeacher = insertTeacher;
        }

        [HttpGet("{id}")]
        public ActionResult<GetTeacherResponse> Get(long id)
        {
            GetTeacherRequest request = new GetTeacherRequest(id);
            GetTeacherResponse response = this._getTeacher.ProcessOperation(request);

            if(response == null)
            {
                return NotFound();
            }

            return Ok(response);
            //Aparece o status 200 e retorna o dado
        }

        [HttpGet]
        public ActionResult<GetTeachersResponse> Get()
        {
            GetTeachersResponse response = this._getTeachers.ProcessOperation();

            return Ok(response);
            //Aparece o status 200 e retorna o dado
        }
        //Não precisa do return notfound quando não tem dados, porque a lista pode estar vazia
        //salvo exceções, exemplo erro 500, internal error

        [HttpDelete("{id}")]
        public ActionResult<DeleteTeacherResponse> Delete(long id)
        {
            DeleteTeacherRequest request = new DeleteTeacherRequest(id);
            DeleteTeacherResponse response = this._deleteTeacher.ProcessOperation(request);

            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpPut]
        public ActionResult<UpdateTeacherResponse> Update(long id, string name, char gender, char levelId, decimal salary, DateTime admitionDate)
        {
            //não consegui pegar todo o teacher
            UpdateTeacherRequest request = new UpdateTeacherRequest(id, name, gender, levelId, salary, admitionDate);
            UpdateTeacherResponse response = this._updateTeacher.ProcessOperation(request);

            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpPost]
        public ActionResult<InsertTeacherResponse> Insert([FromBody]TeacherRequestData requestData)
        { 
            InsertTeacherRequest request = new InsertTeacherRequest(requestData);
            InsertTeacherResponse response = this._insertTeacher.ProcessOperation(request);

            if(response.Success == false)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
            
    }
}