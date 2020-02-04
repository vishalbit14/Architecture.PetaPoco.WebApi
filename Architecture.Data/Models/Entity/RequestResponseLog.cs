using Architecture.Data.Infrastructure.Attributes;
using PetaPoco;
using System;

namespace Architecture.Data.Models.Entity
{
    [TableName("RequestResponseLog")]
    [PrimaryKey("RequestResponseLogID")]
    [Sort("RequestResponseLogID", "DESC")]
    public class RequestResponseLog
    {
        public long RequestResponseLogID { get; set; }
        public long RefRequestResponseLogID { get; set; }
        public long UserId { get; set; }
        public string Url { get; set; }
        public string Type { get; set; }
        public string Headers { get; set; }
        public string Data { get; set; }
        [SetValueOnAdd((int)SetValueOnAddAttribute.SetValueEnum.CurrentTime)]
        public DateTime CreatedDate { get; set; }
    }
}
