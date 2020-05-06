

using Commerce.SystemManagement.Core;

namespace Commerce.SystemManagement.ViewModel
{
    public class UserItemView
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public UserStatus Status { get; set; }
    }
}
