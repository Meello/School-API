using School.Core.Mapping;
using School.Core.Models;
using StoneCo.Buy4.School.DataContracts.Class.InsertClass;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace School.Core.Operations.Class.ClassCSVReader
{
    public class SchoolClassCsvReader : ISchoolClassCsvReader
    {
        public List<string> Execute(InsertClassRequestData requestData)
        {
            List<string> schoolClassFileLines = new List<string>();

            StreamReader reader = new StreamReader($@"{requestData.FullFilePath}",Encoding.UTF8,true);
            reader.ReadLine().Skip(1);

            while (true)
            {
                string line = reader.ReadLine();

                if (line == null) break;

                schoolClassFileLines.Add(line);
            }

            //Voltar para como era, construir o objeto aqui mesmo

            return schoolClassFileLines;
        }
    }
}
