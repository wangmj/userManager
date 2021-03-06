﻿namespace wmj.userManagerServer.Domain.Models
{
    public class AppUser : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Pwd { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
        public string Remark { get; set; }
        public string Avator { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
    }
}
