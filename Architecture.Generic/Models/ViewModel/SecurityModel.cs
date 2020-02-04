using Architecture.Generic.Infrastructure;
using Architecture.Generic.Resources;
using System.ComponentModel.DataAnnotations;

namespace Architecture.Generic.Models.ViewModel
{
    public class LoginModel
    {
        [Required(ErrorMessageResourceName = "EmailRequired", ErrorMessageResourceType = typeof(Resource))]
        [RegularExpression(Constants.RegxEmail, ErrorMessageResourceName = "EmailInvalid", ErrorMessageResourceType = typeof(Resource))]
        public string Email { get; set; }

        [Required(ErrorMessageResourceName = "PasswordRequired", ErrorMessageResourceType = typeof(Resource))]
        public string Password { get; set; }
    }
}
