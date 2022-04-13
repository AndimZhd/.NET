namespace MVCTest.Models
{
    public class UserCollection
    {
        private List<User> users;

        UserCollection(List<User> users)
        {
            this.users = users;
        }
        UserCollection() { users = new List<User>(); }

        public void addAUser(User user)
        {
            users.Add(user);
        }
    }
}
