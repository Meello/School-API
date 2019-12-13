using System;
using System.Collections.Generic;
using System.Text;

//NÃO ESTÁ SENDO USADA
namespace School.Core.Querys.SearchConditions.SearchConditionsPerParameter
{
    public class SearchConditionsPerParameter : ISearchConditionsPerParameter
    {
        public string SqlStringSearchConditionsList(List<char?> charList, string fieldname)
        {
            return $@"{fieldname} IN('{string.Join("','", charList.ToArray())}')
                ";
        }

        public string SqlStringSearchConditionsInterval(Object min, string minFieldName, Object max, string maxFieldName, string fieldToSearch)
        {
            //Está certo fazer assim para que seja permitido somente datetime e decimal?
            if (min.GetType().ToString() != "DateTime" && max.GetType().ToString() != "DateTime")
            {
                if (min.GetType().ToString() != "decimal" && max.GetType().ToString() != "decimal")
                {
                    throw new Exception("Invalid format! Valid formats: DateTime and decimal");
                }
            }
                
            if (min != null && max == null)
            {
                return $@"{fieldToSearch} > @{minFieldName}
                    ";
            }

            if (max != null && min == null)
            {
                return $@"{fieldToSearch} < @{maxFieldName}
                    ";
            }

            if (max != null && min != null)
            {
                return $@"{fieldToSearch} < @{maxFieldName} AND {fieldToSearch} > @{minFieldName}
                    ";
            }

            return null;
        }

        public string SqlStringSearchConditionsName(string name, string fieldName)
        {
            if (name != null)
            {
                return $@"LEFT(Name,1) = @{fieldName}
                    ";
            }

            return null;
        }

        public string SqlStringLength(string sqlString, long sqlStringLength)
        {
            if (sqlStringLength < sqlString.Length)
            {
                return @" AND ";
            }
            
            return null;
        }
    }
}
