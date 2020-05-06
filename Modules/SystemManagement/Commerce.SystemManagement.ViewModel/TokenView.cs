using System;

namespace Commerce.SystemManagement.ViewModel
{
    public class TokenView
    {
        public long Id { get; set; }
        public Guid TokenId { get; set; }
        public string UserName { get; set; }
        public long UserID { get; set; }
        public DateTime? ExpireDate { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
