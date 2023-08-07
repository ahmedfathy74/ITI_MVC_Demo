using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITI_MVC_Demo.Models
{
    //public class Employee
    //{
    //    public int Id { get; set; }
    //    [Required(ErrorMessage ="Name Required ")]
    //    [MaxLength(25,ErrorMessage ="Name Must be less than 25 Char")]
    //    [MinLength(3, ErrorMessage = "Name Must be More than 2 Char")]
    //    //[UniqueName (Msg ="My Msg")] //server side only
    //    [Remote(action:"TestUnique",controller: "Employee",AdditionalFields = "Id,Address", ErrorMessage ="Name Already Exist")] //call client side using ajax Performance better than attruibute
    //    public string Name { get; set; } = null!;
    //    public int Salary { get; set; }
    //    [RegularExpression(@"w\{1,}\.(jpg|png)",ErrorMessage ="image must be jpj or png")]
    //    public string? Address { get; set; }
    //    public string Image { get; set; } = null!;
    //    [ForeignKey("department")] // we decalre here that the Dept_id is a foreign key based on ref obj from Department
    //    [Display(Name ="Department Name")]
    //    public int Dept_Id { get; set; }
    //    // we use virtual here to reuse instance from department and not created new one for every emp 
    //    public virtual Department? department { get; set; }
    //}

    public partial class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Salary { get; set; }
        public string? Address { get; set; }
        public string Image { get; set; } = null!;
        [ForeignKey("department")] // we decalre here that the Dept_id is a foreign key based on ref obj from Department
        public int Dept_Id { get; set; }
        // we use virtual here to reuse instance from department and not created new one for every emp 
        public virtual Department? department { get; set; }
    }
}
