using StoneCo.Buy4.School.DataContracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.Core.Validators.Page
{
    public interface IPageValidator
    {
        void ValidatePage(long pageSize, long pageNumber, long maxElements, OperationResponseBase response);
    }
}
