using System;

namespace Architecture.Generic.Models.ViewModel
{
    public class LoginTokenModel
    {
        public long LoginTokenId { get; set; }
        public long UserId { get; set; }
        public string Token { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
