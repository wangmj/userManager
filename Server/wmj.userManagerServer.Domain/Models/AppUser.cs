namespace wmj.userManagerServer.Domain.Models
{
    public class AppUser : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Age { get; set; }
        public string Phone { get; set; }
        public string Remark { get; set; }
        public string Avator { get; set; }
        public string Email { get; set; }
        public string IsAdmin { get; set; }
    }
}
