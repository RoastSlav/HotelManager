using System.ComponentModel.DataAnnotations;

namespace HotelManager.ViewModels
{
    public class CreateRoleViewModel
    {
        [Required]
        public string RoleName { get; set; }
    }
}
