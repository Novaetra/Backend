using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Runtime.Validation;

namespace Novaetra.Backend.Users.Dto
{
    public class GetUserInput : ICustomValidate
    {
        [Required]
        public string SearchString { get; set; }

        public void AddValidationErrors(List<ValidationResult> results)
        {
            if (string.IsNullOrWhiteSpace(SearchString))
            {
                results.Add(new ValidationResult(nameof(SearchString) + " cannot be empty!", new[] { nameof(SearchString) }));
            }
        }
    }
}
