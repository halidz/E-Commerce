namespace Commerce.Core
{
    public class CurrentUser : ICurrentUser
    {
        public string UserName { get  ; set ; }
        public string FullName { get; set; }

        public CurrentUser()
        {
            UserName = "h.cifci";
            FullName = "M.Halid ÇİFCİ";
        }
    }
}
