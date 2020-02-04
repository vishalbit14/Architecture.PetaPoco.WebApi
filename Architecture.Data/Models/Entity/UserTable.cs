using Architecture.Data.Infrastructure.Attributes;
using PetaPoco;

namespace Architecture.Data.Models.Entity
{
    [TableName("Users")]
    [PrimaryKey("UserId")]
    [Sort("UserId", "ASC")]
    public class UserTable : BaseEntity
    {
        public long UserId { get; set; }
        public int UserRoleId { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
    }
}
