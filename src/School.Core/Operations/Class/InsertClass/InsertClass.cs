using School.Core.Models;
using School.Core.Operations.Class.ClassCSVReader;
using StoneCo.Buy4.School.DataContracts.Class.InsertClass;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.Core.Operations.Class.InsertClass
{
    public class InsertClass : OperationBase<InsertClassRequest, InsertClassResponse>, IInsertClass
    {
        private readonly IClassCsvReader _classCsvReader;

        public InsertClass(IClassCsvReader classCsvReader)
        {
            this._classCsvReader = classCsvReader;
        }

        protected override InsertClassResponse ProcessOperation(InsertClassRequest request)
        {
            throw new NotImplementedException();
        }

        protected override InsertClassResponse ValidateOperation(InsertClassRequest request)
        {
            InsertClassResponse response = new InsertClassResponse();

            IEnumerable<ClassCsvFile> classCsvFiles = this._classCsvReader.Execute(request.Data);

            //COMPARAR O ARQUIVO COM OS DADOS QUE PRECISAM EXISTIR PARA INSERIR
            //VALIDAR O CLASS

            return response;
        }
    }
}
