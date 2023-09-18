using System.ComponentModel.DataAnnotations;

namespace Roles_Trainning_application.Models
{
    public class UserRole
    {
        [Required]
        public string RoleName { get; set; }
    }
}
