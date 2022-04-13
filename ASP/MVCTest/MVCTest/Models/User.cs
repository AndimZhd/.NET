namespace MVCTest.Models
{
    public class User
    {
        private string id { set; get; }
        private string email { set; get; }
        private string registrationDate { set; get; }
        private string lastEntryDate { set; get; }
        private string status { set; get; }

        public User(string id, string email, string registrationDate, string lastEntryDate, string status)
        {
            this.id = id;
            this.email = email;
            this.registrationDate = registrationDate;
            this.lastEntryDate = lastEntryDate;
            this.status = status;
        }


    }
}
