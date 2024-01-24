using AutoMapper;
using OyonnBL;
using OyonnBL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
 public  class AutoMapperConfiguration
    {
        public static void Initialize()
        {
            Mapper.Initialize((config) =>
            {

                config.CreateMap<companyDTO, company>().ReverseMap();
                config.CreateMap<productDTO, product>().ReverseMap();
                config.CreateMap<products_detailsDTO, products_details>().ReverseMap();
                config.CreateMap<clientDTO, client>().ReverseMap();
                config.CreateMap<orderDTO, order>().ReverseMap();
               
                
            });
        }
    }
}
