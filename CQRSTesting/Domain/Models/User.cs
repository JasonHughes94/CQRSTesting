namespace CQRSTesting.Domain.Models
{
    public class User
    {
        public User(int id, string userName, string[] roles)
        {
            Id = id;
            UserName = userName;
            Roles = roles;
        }

        public void UpdateUser(string userName, string[] roles)
        {
            UserName = userName;
            UpdateRoles(roles);
        }

        public void UpdateRoles(string[] roles)
        {
            Roles = roles;
        }

        public int Id { get; private set; }
        public string UserName { get; private set; }
        public string[] Roles { get; private set; }
    }
}