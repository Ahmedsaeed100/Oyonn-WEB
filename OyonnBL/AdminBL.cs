using OyonnBL.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OyonnBL
{
  public  class AdminBL
    {
        oyonnEntities DB = new oyonnEntities();
        public AdminDTO AdminLogin(AdminDTO USER)
        {

            var result = DB.Admins.Where(S => S.UserName == USER.UserName && S.Password == USER.Password).Select(ST => new AdminDTO()
            {
                Adminid = ST.Adminid,
                AdminName = ST.AdminName,


            }).FirstOrDefault();
            Admin CO = AutoMapper.Mapper.Map<AdminDTO, Admin>(result);
            try
            {
                Admin c = DB.Admins.Find(CO.Adminid);
                c.loginDate = DateTime.Now;
              
                DB.Entry(c).State = EntityState.Modified;
                DB.SaveChanges();
                
            }
            catch (Exception EX)
            {

               
            }

            return result;

        }
    }
}
