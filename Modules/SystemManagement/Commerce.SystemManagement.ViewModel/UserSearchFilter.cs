
using Commerce.SystemManagement.Core;

namespace Commerce.SystemManagement.ViewModel
{
    public class UserSearchFilter
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public UserStatus Status { get; set; }
    }
}
