
using OyonnBL;
using OyonnBL.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OyonnBL
{
 public class productBL
    {
        oyonnEntities DB = new oyonnEntities();



        //M@@@@productDataLoad
        public List<productDTO> productDataLoad()
        {
            var result = DB.products.Select(ev => new productDTO()
            {
                product_id = ev.product_id,
                company_id = ev.company_id,
                product_name_ar = ev.product_name_ar,
                product_name_en = ev.product_name_en,

                company = new companyDTO { company_name_ar = (ev.company != null ? ev.company.company_name_ar : "") },
            }).ToList();
            return result;
        }

        //M@@@@productDataLoadByID
        public List<productDTO> productDataLoadByID(Int64 product_id)
        {
            var result = DB.products.Where(u => u.product_id == product_id).Select(ev => new productDTO()
            {
                product_id = ev.product_id,
                company_id = ev.company_id,
                product_name_ar = ev.product_name_ar,
                product_name_en = ev.product_name_en,

                company = new companyDTO { company_name_ar = (ev.company != null ? ev.company.company_name_ar : "") },
            }).ToList();
            return result;
        }
        //M@@@ productDateSave
        public int productDataSave(productDTO result)
        {
            product prod= AutoMapper.Mapper.Map<productDTO, product>(result);

            try
            {
                DB.products.Add(prod);
                DB.SaveChanges();

                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }



        //M@@@@productsDelete
        public int productsDelete(int? id)
        {
            try
            {
                product result = DB.products.Find(id);
                DB.products.Remove(result);
                DB.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }


        }

        //m@@productsUpdate
        public int productsUpdate(productDTO products)
        {
            product CO = AutoMapper.Mapper.Map<productDTO, product>(products);
            try
            {
                product c = DB.products.Find(CO.product_id);
                c.product_name_ar = CO.product_name_ar;
                c.product_name_en = CO.product_name_en;
                c.company_id = CO.company_id;
              
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
