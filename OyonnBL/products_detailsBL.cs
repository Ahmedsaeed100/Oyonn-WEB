using OyonnBL.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OyonnBL
{

 public   class products_detailsBL
    {
        oyonnEntities DB = new oyonnEntities();



        //M@@@@products_detailsDataLoad
        public List<products_detailsDTO> product_detailsDataLoad()
        {
            var result = DB.products_details.Select(ev => new products_detailsDTO()
            {
                product_details_id = ev.product_details_id,
                product_id = ev.product_id,
                product_name_ar = ev.product_name_ar,
                product_name_en = ev.product_name_en,
                product_img = Generic.product_imgPathRelative + ev.product_img,
                product_quantity = ev.product_quantity,
                product_price = ev.product_price,
                product = new productDTO { product_name_ar = (ev.product != null ? ev.product.product_name_ar : "") },
            }).ToList();
            return result;
        }

        //M@@@@product_detailsDataLoadByID
        public List<products_detailsDTO> product_detailsDataLoadByID(Int64 product_details_id)
        {
            var result = DB.products_details.Where(u => u.product_details_id == product_details_id).Select(ev => new products_detailsDTO()
            {
                product_details_id = ev.product_details_id,
                product_id = ev.product_id,
                product_name_ar = ev.product_name_ar,
                product_name_en = ev.product_name_en,
                product_img = Generic.product_imgPathRelative + ev.product_img,
                product_quantity = ev.product_quantity,
                product_price = ev.product_price,
                product = new productDTO { product_name_ar = (ev.product != null ? ev.product.product_name_ar : "") },
            }).ToList();
            return result;
        }
        //M@@@ products_detailsDateSave
        public int products_detailsDataSave(products_detailsDTO result)
        {
            products_details products_details = AutoMapper.Mapper.Map<products_detailsDTO, products_details>(result);

            try
            {
                DB.products_details.Add(products_details);
                DB.SaveChanges();

                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }



        //M@@@@products_detailsDelete
        public int products_detailsDelete(int? id)
        {
            try
            {
                products_details result = DB.products_details.Find(id);
                DB.products_details.Remove(result);
                DB.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }


        }

        //m@@products_detailsUpdate
        public int products_detailsUpdate(products_detailsDTO products_details)
        {
            products_details CO = AutoMapper.Mapper.Map<products_detailsDTO, products_details>(products_details);
            try
            {
                products_details c = DB.products_details.Find(CO.product_details_id);
                c.product_id = CO.product_id;
                c.product_name_ar = CO.product_name_ar;
                c.product_name_en = CO.product_name_en;
                c.product_quantity = CO.product_quantity;
                c.product_price = CO.product_price;




                if (CO.product_img != "0")
                {
                    c.product_img = CO.product_img;
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
