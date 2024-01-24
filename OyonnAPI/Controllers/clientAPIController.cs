using OyonnBL;
using OyonnBL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OyonnAPI.Controllers
{
    [RoutePrefix("api/clientAPI")]
    public class clientAPIController : ApiController
    {
        clientBL BL = new clientBL();
        [HttpPost]
        [Route("updateclient_status")]
        [ActionName("updateclient_status")]
        public HttpResponseMessage updateclient_status(clientDTO CL)
        {
            try
            {
                if (ModelState.IsValid)
                {


                    var result = BL.updateclient_status(CL);
                    if (result != 0)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                    else
                        return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }

            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }


        [HttpGet]
        [Route("clientDataLoad")]
        public List<clientDTO> clientDataLoad()
        {
            return BL.clientDataLoad();
        }
        [HttpGet]
        [Route("client_statusDataLoad")]
        public List<client_statusDTO> client_statusDataLoad()
        {
            return BL.client_statusDataLoad();
        }
        [HttpGet]
        [Route("clientDataLoadbyclient_status_id/{client_status_id?}")]
        public List<clientDTO> clientDataLoadbyclient_status_id(int client_status_id)
        {

            return BL.clientDataLoadbyclient_status_id(client_status_id);
        }

        [HttpGet]
        [Route("client_shopDataLoad/{client_id?}")]
        public List<client_shopDTO> client_shopDataLoad(int client_id)
        {

            return BL.client_shopDataLoad(client_id);
        }
    }
}
