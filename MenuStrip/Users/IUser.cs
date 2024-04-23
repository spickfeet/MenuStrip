namespace MenuStrip.Users
{
    public interface IUser
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public IDictionary<string, int> Configs { get; set; }
    }
}
