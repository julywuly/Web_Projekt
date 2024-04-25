namespace ProjektWeb.Models
{

    public class User
    {
        public int UserId { get; set; }
        public string Firstname { get; set; } = "";

        public string Lastname { get; set; } = "";

        public string Hobbies { get; set; } = "";

        public DateTime Birthdate { get; set; }

    }
}
