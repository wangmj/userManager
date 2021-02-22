using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wmj.userManagerServer.Domain.ViewModels
{
    public class AppUserAdd
    {
        public string Name { get; set; }
        public string Pwd { get; set; }
       
        public int Age { get; set; }
        
        public string Phone { get; set; }
        public string Remark { get; set; }
        public string Avator { get; set; }
        public string Email { get; set; }
    }
}
