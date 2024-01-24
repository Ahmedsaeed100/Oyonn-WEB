
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
    [RoutePrefix("api/products_detailsAPI")]
    public class products_detailsAPIController : ApiController
    {
        products_detailsBL BL = new products_detailsBL();

        [HttpGet]
        [Route("product_detailsDataLoad")]
        public List<products_detailsDTO> product_detailsDataLoad()
        {
            return BL.product_detailsDataLoad();
        }
        [HttpGet]
        [Route("product_detailsDataLoadByID/{product_details_id?}")]
        public List<products_detailsDTO> product_detailsDataLoadByID(Int64 product_details_id)
        {

            return BL.product_detailsDataLoadByID(product_details_id);
        }



        [HttpPost]
        [Route("products_detailsDelete")]

        public HttpResponseMessage products_detailsDelete([FromBody]int? id)
        {
            try
            {
                var result = BL.products_detailsDelete(id);
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
        [Route("Postproducts_details")]
        [ActionName("Postproducts_details")]
        public HttpResponseMessage Postproducts_details(products_detailsDTO News)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    string path = null;
                    if (News.product_img != "0")
                    {
                        string res = News.product_img.Substring(News.product_img.IndexOf(',') + 1);
                        string id1 = Guid.NewGuid().ToString();
                        id1 = id1 + ".png";

                        byte[] ret = Convert.FromBase64String(res);

                        path = HttpContext.Current.Server.MapPath("~/IMG/Pic_Product/").ToString() + id1;
                        File.WriteAllBytes(path, ret);


                        News.product_img = id1;

                    }
                    var result = BL.products_detailsDataSave(News);
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

        [Route("products_detailsUpdate")]
        [ActionName("products_detailsUpdate")]
        public HttpResponseMessage products_detailsUpdate(products_detailsDTO News)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    string path = null;
                    if (News.product_img != "0")
                    {
                        string res = News.product_img.Substring(News.product_img.IndexOf(',') + 1);
                        string id1 = Guid.NewGuid().ToString();
                        id1 = id1 + ".png";

                        byte[] ret = Convert.FromBase64String(res);

                        path = HttpContext.Current.Server.MapPath("~/IMG/Pic_Product/").ToString() + id1;
                        File.WriteAllBytes(path, ret);


                        News.product_img = id1;

                    }
                    var result = BL.products_detailsUpdate(News);
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
