using Microsoft.AspNetCore.Mvc;
using School.Core.Operations.Class.InsertClass;
using StoneCo.Buy4.School.DataContracts.Class.InsertClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.Application.Controllers
{
    [Route("api/classes")]

    public class ClassController : ControllerBase
    {
        private readonly IInsertClass _insertClass;

        public ClassController(
            IInsertClass insertClass)
        {
            this._insertClass = insertClass;
        }

        [HttpPost]
        public ActionResult<InsertClassResponse> Insert([FromBody] InsertClassRequestData requestData)
        {
            InsertClassRequest request = new InsertClassRequest(requestData);
            InsertClassResponse response = this._insertClass.Process(request);

            if(!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}
