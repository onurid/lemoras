namespace Lemoras.Remora.Admin.Business.UserModel
{
    public class UpdateUserContract
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Passwd { get; set; }
        public string Email { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public bool Active { get; set; }
    }
}
