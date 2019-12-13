using System;
using System.Collections.Generic;
using System.Text;

namespace School.Core.Querys.SearchConditions.SearchConditionsPerParameter
{
    public interface ISearchConditionsPerParameter
    {
        string SqlStringSearchConditionsList(List<char?> charList, string fieldname);

        string SqlStringSearchConditionsInterval(Object min, string minName, Object max, string maxName, string fieldToSearch);

        string SqlStringSearchConditionsName(string name, string fieldName);

        string SqlStringLength(string sqlString, long sqlStringLength);
    }
}
