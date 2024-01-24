
using OyonnBL;
using OyonnBL.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace OyonnAPI.Controllers
{
    [RoutePrefix("api/productsAPI")]
    public class productsAPIController : ApiController
    {
        productBL BL = new productBL();

        [HttpGet]
        [Route("productDataLoad")]
        public List<productDTO> productDataLoad()
        {
            return BL.productDataLoad();
        }
        [HttpGet]
        [Route("productDataLoadByID/{product_id?}")]
        public List<productDTO> productDataLoadByID(Int64 product_id)
        {

            return BL.productDataLoadByID(product_id);
        }






        [HttpPost]
        [Route("productsDelete")]

        public HttpResponseMessage productsDelete([FromBody]int? id)
        {
            try
            {
                var result = BL.productsDelete(id);
                if (result != 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPost]
        [Route("PostproductDataSave")]
        [ActionName("PostproductDataSave")]
        public HttpResponseMessage PostproductDataSave(productDTO News)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    
                    var result = BL.productDataSave(News);
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

        [Route("productsUpdate")]
        [ActionName("productsUpdate")]
        public HttpResponseMessage productsUpdate(productDTO pro)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    
                    var result = BL.productsUpdate(pro);
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
    }
}
