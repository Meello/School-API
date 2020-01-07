using School.Core.Repositories;
using School.Core.Validators.ValidateTeacherParameters;
using StoneCo.Buy4.School.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace School.Core.Validators.TeacherFilterParameters
{
    public class TeacherFilterParametersValidator : ITeacherFilterParametersValidator
    {
        private readonly ITeacherParametersValidator _parametersValidator;
        private readonly ILevelRepository _levelRepository;

        public TeacherFilterParametersValidator(
            ITeacherParametersValidator parametersValidator,
            ILevelRepository levelRepository)
        {
            this._parametersValidator = parametersValidator;
            this._levelRepository = levelRepository;
        }

        public void ValidateGenders(List<char> genders, OperationResponseBase response)
        {
            if (genders.Count > 0)
            {
                List<char> validGenders = new List<char> { 'M', 'F' };
                List<char> invalidGenders = genders.Except(validGenders).ToList();

                if (invalidGenders.Count > 0)
                {
                    response.AddError("017", $"Error in levelIds. Invalid values: {string.Join(", ", invalidGenders)}.");
                }
            }
        }

        public void ValidateLevelIds(List<char> levelIds, OperationResponseBase response)
        {
            if (levelIds.Count > 0)
            {
                List<char> validLevels = this._levelRepository.ListAll().ToList();

                List<char> invalidLevels = levelIds.Except(validLevels).ToList();

                if (invalidLevels.Count > 0)
                {
                    response.AddError("017", $"Error in levelIds. Invalid values: {string.Join(", ", invalidLevels)}.");
                }
            }
        }

        public void ValidateAdmitionDate(DateTime? minAdmitionDate, DateTime? maxAdmitionDate, OperationResponseBase response)
        {
            if (minAdmitionDate != null && maxAdmitionDate != null)
            {
                this._parametersValidator.ValidateAdmitionDate(minAdmitionDate, response, nameof(minAdmitionDate));

                this._parametersValidator.ValidateAdmitionDate(maxAdmitionDate, response, nameof(maxAdmitionDate));
                
                if (maxAdmitionDate < minAdmitionDate)
                {
                    response.AddError("019", $"{nameof(maxAdmitionDate)} can't be bigger than {nameof(minAdmitionDate)}");
                }
            }
            else if (minAdmitionDate != null ^ maxAdmitionDate != null)
            {
                if (minAdmitionDate != null)
                {
                    this._parametersValidator.ValidateAdmitionDate(minAdmitionDate, response, nameof(minAdmitionDate));
                }
                else if (maxAdmitionDate != null)
                {
                    this._parametersValidator.ValidateAdmitionDate(maxAdmitionDate, response, nameof(maxAdmitionDate));
                }
            }
        }

        public void ValidateSalary(decimal? minSalary, decimal? maxSalary, OperationResponseBase response)
        {
            if (minSalary != null && maxSalary != null)
            {
                this._parametersValidator.ValidateSalary(minSalary, response, nameof(minSalary));

                this._parametersValidator.ValidateSalary(maxSalary, response, nameof(maxSalary));
                
                if (maxSalary < minSalary)
                {
                    response.AddError("019", $"{nameof(maxSalary)} can't be bigger than {nameof(minSalary)}");
                }
            }
            else if (minSalary != null ^ maxSalary != null)
            {
                if (maxSalary != null)
                {
                    this._parametersValidator.ValidateSalary(minSalary, response, nameof(minSalary));
                }
                else if (maxSalary != null)
                {
                    this._parametersValidator.ValidateSalary(maxSalary, response, nameof(maxSalary));
                }
            }
        }
    }
}
