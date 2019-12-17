using Microsoft.AspNetCore.Mvc;
using School.Core.Operations.DeleteTeacher;
using School.Core.Operations.SearchTeacher;
using School.Core.Operations.GetTeacher;
using School.Core.Operations.GetTeachers;
using School.Core.Operations.InsertTeacher;
using School.Core.Operations.UpdateTeacher;
using StoneCo.Buy4.School.DataContracts.DeleteTeacher;
using StoneCo.Buy4.School.DataContracts.SearchTeacher;
using StoneCo.Buy4.School.DataContracts.GetTeacher;
using StoneCo.Buy4.School.DataContracts.GetTeachers;
using StoneCo.Buy4.School.DataContracts.InsertTeacher;
using StoneCo.Buy4.School.DataContracts.UpdateTeacher;
using StoneCo.Buy4.School.DataContracts;

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
        private readonly ISearchTeacher _searchTeacher;

        //Criando lista, deve colocar no plural
        //sempre que precisar de alguma dependência, acrescentar no construtor

        public TeacherController(
            IGetTeacher getTeacher,
            IGetTeachers getTeachers,
            IDeleteTeacher deleteTeacher,
            IUpdateTeacher updateTeacher,
            IInsertTeacher insertTeacher,
            ISearchTeacher searchTeacher)
        {
            this._getTeacher = getTeacher;
            this._getTeachers = getTeachers;
            this._deleteTeacher = deleteTeacher;
            this._updateTeacher = updateTeacher;
            this._insertTeacher = insertTeacher;
            this._searchTeacher = searchTeacher;
        }

        [HttpGet("{cpf}")]
        public ActionResult<GetTeacherResponse> Get(long cpf)
        {
            GetTeacherRequest request = new GetTeacherRequest(cpf);
            GetTeacherResponse response = this._getTeacher.Process(request);

            if (response.Data == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpPost("search")]
        public ActionResult<SearchTeacherResponse> Search([FromBody]RequestFilter requestFilter, int pageNumber, int pageSize)
        {
            SearchTeacherRequest request = new SearchTeacherRequest(requestFilter, pageNumber, pageSize);
            SearchTeacherResponse response = this._searchTeacher.Process(request);

            if (response.Data == null)
            {
                return NotFound(response);
            }

            if (response.Success == false)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet]
        public ActionResult<GetTeachersResponse> Get()
        {
            GetTeachersResponse response = this._getTeachers.Process();

            return Ok(response);
            //Aparece o status 200 e retorna o dado
            //Não precisa do return notfound quando não tem dados, porque a lista pode estar vazia
            //salvo exceções, exemplo erro 500, internal error
        }

        [HttpDelete("{cpf}")]
        public ActionResult<DeleteTeacherResponse> Delete(long cpf)
        {
            DeleteTeacherRequest request = new DeleteTeacherRequest(cpf);
            DeleteTeacherResponse response = this._deleteTeacher.Process(request);

            if (response.Success == false)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpPost]
        public ActionResult<InsertTeacherResponse> Insert([FromBody]TeacherRequestData requestData)
        { 
            InsertTeacherRequest request = new InsertTeacherRequest(requestData);
            InsertTeacherResponse response = this._insertTeacher.Process(request);

            if(response.Success == false)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
       
        [HttpPut]
        public ActionResult<UpdateTeacherResponse> Update([FromBody]TeacherRequestData requestData)
        {
            UpdateTeacherRequest request = new UpdateTeacherRequest(requestData);
            UpdateTeacherResponse response = this._updateTeacher.Process(request);

            if (response.Success == false)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}