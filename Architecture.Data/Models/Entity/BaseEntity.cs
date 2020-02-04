using Architecture.Data.Infrastructure.Attributes;

namespace Architecture.Data.Models.Entity
{
    public class BaseEntity
    {
        [SetValueOnAdd((int)SetValueOnAddAttribute.SetValueEnum.CurrentTime)]
        public long CreatedDate { get; set; }

        [SetValueOnAdd((int)SetValueOnAddAttribute.SetValueEnum.CurrentTime)]
        [SetValueOnUpdate((int)SetValueOnAddAttribute.SetValueEnum.CurrentTime)]
        public long ModifiedDate { get; set; }
    }
}
