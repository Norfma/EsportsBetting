namespace ASP_Front.Infrastructure
{
    public class SessionUser
    {
        public int UserID { get; set; }
        public string UserName { get; set; }

        public SessionUser(int userID, string userName)
        {
            UserID = userID;
            UserName = userName;
        }
    }
}