using System.ComponentModel.DataAnnotations;

namespace ITI_MVC_Demo.Models
{
    public class Department
    {
        public int Id { get; set; }
        [Display(Name ="Department Name")]
        //[DataType(DataType.EmailAddress)]  byshof l type mn hna l awl lw ml2sh by5od type l property
        public string Name { get; set; } = null!;
        public string ManagerName { get; set; } = null!;

        public virtual List<Employee>? Employees { get; set; }
    }
}
