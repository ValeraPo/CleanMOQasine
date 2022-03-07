using CleanMOQasine.API.Models;
using System.ComponentModel.DataAnnotations;

namespace CleanMOQasine.API.Validation
{
    public class IsEndTimeMoreThanStartTimeAttribute : CompareAttribute
    {
        public IsEndTimeMoreThanStartTimeAttribute(string otherProperty) : base(otherProperty)
        {

        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var checkeded = validationContext.ObjectInstance as WorkingTimeInsertInputModel;
            if (String.Compare(checkeded.StartTime, checkeded.EndTime) <= 0)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult(ErrorMessage = "Время начала рабочего дня не может быть больше или равно времени окончания.");
            }
        }

        public override bool Match(object? obj)
        {
            return base.Match(obj);
        }
    }
}
