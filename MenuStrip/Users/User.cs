namespace MenuStrip.Users
{
    public class User : IUser
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public IDictionary<string, int> Configs { get; set; } = new Dictionary<string, int>();
    }
}
