using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OyonnBL.DTO
{
 public   class AdminDTO
    {
        public int Adminid { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool Remember_Me { get; set; }
        public string UserLoginErrorMassge { get; set; }
        public Nullable<System.DateTime> loginDate { get; set; }
        public Nullable<System.TimeSpan> login_time { get; set; }
        public string AdminName { get; set; }
    }
}
