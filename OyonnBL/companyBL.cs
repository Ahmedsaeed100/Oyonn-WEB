using OyonnBL.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OyonnBL
{
 public   class companyBL
    {
        oyonnEntities DB = new oyonnEntities();



        //M@@@@companyDataLoad
        public List<companyDTO> CompanyDataLoad()
        {
            var result = DB.companies.Select(ev => new companyDTO()
            {
                company_id = ev.company_id,
                company_name_ar = ev.company_name_ar,
                company_name_en = ev.company_name_en,
                company_img = Generic.PicturePathRelative + ev.company_img,
                company_phone = ev.company_phone,
                company_address = ev.company_address,
                company_mobile = ev.company_mobile,
            }).ToList();
            return result;
        }

        //M@@@@companyDataLoadByID
        public List<companyDTO> CompanyDataLoadByID(Int64 company_id)
        {
            var result = DB.companies.Where(u => u.company_id == company_id).Select(ev => new companyDTO()
            {
                company_id = ev.company_id,
                company_name_ar = ev.company_name_ar,
                company_name_en = ev.company_name_en,
                company_img = Generic.PicturePathRelative + ev.company_img,
                company_phone = ev.company_phone,
                company_address = ev.company_address,
                company_mobile = ev.company_mobile,
            }).ToList();
            return result;
        }
        //M@@@ CompanyDateSave
        public int CompanyDataSave(companyDTO result)
        {
            company companies = AutoMapper.Mapper.Map<companyDTO, company>(result);

            try
            {
                DB.companies.Add(companies);
                DB.SaveChanges();

                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }



        //M@@@@companyDelete
        public int companyDelete(int? id)
        {
            try
            {
                company result = DB.companies.Find(id);
                DB.companies.Remove(result);
                DB.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }


        }

        //m@@companyUpdate
        public int companyUpdate(companyDTO companies)
        {
            company CO = AutoMapper.Mapper.Map<companyDTO, company>(companies);
            try
            {
                company c = DB.companies.Find(CO.company_id);
                c.company_name_ar = CO.company_name_ar;
                c.company_name_en = CO.company_name_en;
                c.company_address = CO.company_address;
                c.company_phone = CO.company_phone;
                c.company_mobile = CO.company_mobile;




                if (CO.company_img != "0")
                {
                    c.company_img = CO.company_img;
                }
                DB.Entry(c).State = EntityState.Modified;
                DB.SaveChanges();
                return 1;
            }
            catch (Exception)
            {

                return 0;
            }


        }
    }
}
