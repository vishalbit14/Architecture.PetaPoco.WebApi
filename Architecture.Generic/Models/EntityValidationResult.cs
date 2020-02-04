using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InspiralThoughtsAPI.Models.ApiModel
{
    public class EntityValidationResult
    {
        public IList<ValidationResult> Errors { get; private set; }

        public bool HasError
        {
            get { return Errors.Count > 0; }
        }

        public EntityValidationResult(IList<ValidationResult> errors = null)
        {
            Errors = errors ?? new List<ValidationResult>();
        }
    }
}