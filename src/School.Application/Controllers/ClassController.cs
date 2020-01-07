using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.Core.Operations.Class.InsertClass;
using StoneCo.Buy4.School.DataContracts.Class.InsertClass;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace School.Application.Controllers
{
    [Route("api/v1/classes")]

    public class ClassController : ControllerBase
    {
        private readonly IInsertClass _insertClass;

        public ClassController(
            IInsertClass insertClass)
        {
            this._insertClass = insertClass;
        }

        [HttpPost]
        public ActionResult<InsertClassResponse> Insert(IFormFile file)
        {
            InsertClassRequest request = new InsertClassRequest(file.OpenReadStream());
            InsertClassResponse response = this._insertClass.Process(request);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}
