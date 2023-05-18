namespace LIstUserApp.Model
{
    public class User
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Birthday { get; set; }
        public string Image { get; set; }
        public int Id { get; set; }

        public User(string firstName, string secondName, string birthday, string image, int id)
        {
            FirstName = firstName;
            SecondName = secondName;
            Birthday = birthday;
            Image = image;
            Id = id;
        }
    }
}
