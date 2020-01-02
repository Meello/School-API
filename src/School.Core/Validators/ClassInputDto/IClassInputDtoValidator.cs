using StoneCo.Buy4.School.Core.DTO;
using StoneCo.Buy4.School.DataContracts.Class.InsertClass;

namespace School.Core.Validators.SchoolClassCsvFile
{
    public interface IClassInputDtoValidator
    {
        void Execute(ClassInputDto classInputDto, InsertClassResponse response, int lineNumber);
    }
}
