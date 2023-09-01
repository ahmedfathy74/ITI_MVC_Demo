using System.ComponentModel.DataAnnotations;

namespace ITI_MVC_Demo.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool isPersisite { get; set; }
    }
}
