using OyonnBL.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OyonnBL
{
    public class clientBL
    {
        oyonnEntities DB = new oyonnEntities();

        //client data loade
        public List<clientDTO> clientDataLoad()
        {
            var result = DB.clients.OrderByDescending(u => u.client_id).Select(cl => new clientDTO() {
                client_id = cl.client_id,
                client_status_id = cl.client_status_id,
                client_name = cl.client_name,
                client_mobile = cl.client_mobile,
                client_location = cl.client_location,
                client_registration_date = cl.client_registration_date,
                client_status = new client_statusDTO { client_status1 = (cl.client_status != null ? cl.client_status.client_status1 : "") },
                client_shop = cl.client_shop.Select(ch => new client_shopDTO() {
                    shop_id = ch.shop_id,
                    client_id = ch.client_id,
                    shop_img = Generic.pic_shopPathRelative + ch.shop_img,
                    area_id = ch.area_id,
                    city_id = ch.city_id,
                    shop_phone = ch.shop_phone,
                    shop_address = ch.shop_address,
                    Shop_mobile = ch.Shop_mobile,
                    shop_Name = ch.shop_Name,
                  
        area = new areaDTO { area_name = (ch.area != null ? ch.area.area_name : "") },
                    city = new cityDTO { city_name = (ch.city != null ? ch.city.city_name : "") },
                }).ToList(),


            }).ToList();

            return result;
        }

        public List<clientDTO> clientDataLoadbyclient_status_id(int client_status_id)
        {
            var result = DB.clients.Where(x => x.client_status_id == client_status_id).Select(cl => new clientDTO()
            {
                client_id = cl.client_id,
                client_status_id = cl.client_status_id,
                client_name = cl.client_name,
                client_mobile = cl.client_mobile,
                client_location = cl.client_location,
                client_registration_date = cl.client_registration_date,
                client_status = new client_statusDTO { client_status1 = (cl.client_status != null ? cl.client_status.client_status1 : "") },
                client_shop = cl.client_shop.Select(ch => new client_shopDTO()
                {
                    shop_id = ch.shop_id,
                    client_id = ch.client_id,
                    shop_img = Generic.pic_shopPathRelative + ch.shop_img,
                    area_id = ch.area_id,
                    city_id = ch.city_id,
                    shop_phone = ch.shop_phone,
                    shop_address = ch.shop_address,
                    Shop_mobile = ch.Shop_mobile,
                    shop_Name = ch.shop_Name,
                    area = new areaDTO { area_name = (ch.area != null ? ch.area.area_name : "") },
                    city = new cityDTO { city_name = (ch.city != null ? ch.city.city_name : "") },
                }).ToList(),


            }).ToList();

            return result;
        }

        public int updateclient_status(clientDTO result)
        {
            client CO = AutoMapper.Mapper.Map<clientDTO, client>(result);
            try
            {
                client c = DB.clients.Find(CO.client_id);
                c.client_status_id = CO.client_status_id;
                DB.Entry(c).State = EntityState.Modified;
                DB.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
                throw;
            }
        }


        public List<client_statusDTO> client_statusDataLoad()
        {
            var result = DB.client_status.Select(ev => new client_statusDTO()
            {
                client_status_id = ev.client_status_id,
                client_status1 = ev.client_status1,

            }).ToList();
            return result;
        }



        public List<client_shopDTO> client_shopDataLoad(int client_id)
        {
            var result = DB.client_shop.Where(u => u.client_id== client_id).Select(ch => new client_shopDTO()
            {
                
                    shop_id = ch.shop_id,
                    client_id = ch.client_id,
                    shop_img = Generic.pic_shopPathRelative + ch.shop_img,
                    area_id = ch.area_id,
                    city_id = ch.city_id,
                    shop_phone = ch.shop_phone,
                    shop_address = ch.shop_address,
                    Shop_mobile = ch.Shop_mobile,
                    shop_Name = ch.shop_Name,

                    area = new areaDTO { area_name = (ch.area != null ? ch.area.area_name : "") },
                    city = new cityDTO { city_name = (ch.city != null ? ch.city.city_name : "") },
               


            }).ToList();

            return result;
        }
    }
}
