using System.ComponentModel.DataAnnotations;

namespace ITI_MVC_Demo.Models
{
    public class UniqueNameAttribute : ValidationAttribute
    {
        public string Msg { get; set; }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            //db
            string name = value.ToString();
            // validationContext.GetType()
            //Employee empObj  = validationContext.ObjectInstance as Employee;
            ITIEntity context = new ITIEntity();
            Employee smp = context.Employees.FirstOrDefault(e => e.Name == name);
            if (smp == null)
            {
                //unique
                return ValidationResult.Success;
            }
            return new ValidationResult("Name is already Exist");
        }
    }
}
