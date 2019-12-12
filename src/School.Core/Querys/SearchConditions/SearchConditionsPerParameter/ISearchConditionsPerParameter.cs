using System;
using System.Collections.Generic;
using System.Text;

namespace School.Core.Querys.SearchConditions.SearchConditionsPerParameter
{
    public interface ISearchConditionsPerParameter
    {
        string SqlStringSearchConditionsList(List<char?> charList, string fieldname);
        string SqlStringSearchConditionsList(List<char?> charList, string fieldname, string sqlString, long sqlStringLength);

        string SqlStringSearchConditionsInterval(Object min, string minName, Object max, string maxName, string fieldToSearch);
        string SqlStringSearchConditionsInterval(Object min, string minName, Object max, string maxName, string fieldToSearch, string sqlString, long sqlStringLength);

        //ESSE JEITO TA ERRADO (OS OUTROS TAMBEM)
        string SqlStringSearchConditionsName(string name, string fieldName);
        //ESSE É O JEITO CERTO(OS OUTROS TAMBEM)
        string SqlStringSearchConditionsName(string name, string fieldName, string sqlString, long sqlStringLength);

        long SqlStringLength(string sqlString, long sqlStringLength);
    }
}
