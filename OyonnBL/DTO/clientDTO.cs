using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OyonnBL.DTO
{
  public  class clientDTO
    {
        public int client_id { get; set; }
        public Nullable<byte> client_status_id { get; set; }
        public string client_name { get; set; }
        public string client_mobile { get; set; }
        public string client_location { get; set; }
        public Nullable<System.DateTime> client_registration_date { get; set; }

        public virtual client_statusDTO client_status { get; set; }
        public virtual ICollection<client_shopDTO> client_shop { get; set; }


    }
}
