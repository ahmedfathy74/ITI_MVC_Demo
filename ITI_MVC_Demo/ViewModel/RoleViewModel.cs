using System.ComponentModel.DataAnnotations;

namespace ITI_MVC_Demo.ViewModel
{
    public class RoleViewModel
    {
        [Required]
        public string RoleName { get; set; }
    }
}
