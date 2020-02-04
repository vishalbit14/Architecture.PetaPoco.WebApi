using Architecture.Generic.Resources;
using System.ComponentModel.DataAnnotations;

namespace Architecture.Generic.Models.ViewModel
{
    public class SearchUserModel
    {
        public string SearchText { get; set; }
    }

    public class UserModel
    {
        public long UserId { get; set; }
        public int UserRoleId { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resource))]
        public string Email { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resource))]
        public string FirstName { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resource))]
        public string LastName { get; set; }

        public string Gender { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string AboutMe { get; set; }

        public bool IsActive { get; set; }

        public string FullName => $"{FirstName} {LastName}";
    }

    public class UserListModel : UserModel
    {
        public int Row { get; set; }
        public int Count { get; set; }
    }
}
