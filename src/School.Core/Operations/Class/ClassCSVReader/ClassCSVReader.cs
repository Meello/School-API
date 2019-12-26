using StoneCo.Buy4.School.DataContracts.Class.InsertClass;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace School.Core.Operations.Class.ClassCSVReader
{
    public class ClassCSVReader : IClassCSVReader
    {
        public IEnumerable<Models.Class> Read(InsertClassRequestData requestData)
        {
            string line = "";
            string[] separetedLine = null;
            StreamReader reader = new StreamReader($@"{requestData.FileAddress}");

            while (true)
            {
                line = reader.ReadLine();
                if (line == null) break;
                separetedLine = line.Split(';');
            }

            return null;
        }
    }
}
