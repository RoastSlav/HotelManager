using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelManager.ViewModels
{
    public class EditRoleViewModel
    {
        public EditRoleViewModel()
        {
            Users = new List<string>();
        }
        public string Id { get; set; }

        [Required(ErrorMessage = "Името е задължително")]
        public string RoleName { get; set; }

        public List<string> Users { set; get; }
    }
}
