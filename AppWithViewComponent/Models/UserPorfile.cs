namespace AppWithViewComponent
{
    public class UserPorfile
    {
        public string Fullname { get; private set; }
        public string Address { get; private set; }

        public UserPorfile(string fullname, string address)
        {
            this.Fullname = fullname;
            this.Address = address;
        }
    }
}
