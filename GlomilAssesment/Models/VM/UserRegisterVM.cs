using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlomilAssesment.Models.VM
{
    public class UserRegisterVM
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public DateTime BornYear { get; private set; }
    }
}
