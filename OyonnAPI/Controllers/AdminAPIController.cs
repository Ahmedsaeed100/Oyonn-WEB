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
    [RoutePrefix("api/AdminAPI")]
    public class AdminAPIController : ApiController
    {
        AdminBL BL = new AdminBL();
        [HttpPost]
        [Route("AdminLogin")]
        [ActionName("AdminLogin")]
        public HttpResponseMessage AdminLogin(AdminDTO USER)
        {
            try
            {

                var result = BL.AdminLogin(USER);
                if (result != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, result);
                }
                else
                    return Request.CreateResponse(HttpStatusCode.NotFound);



            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
