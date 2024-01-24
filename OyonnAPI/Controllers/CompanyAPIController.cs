
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

namespace oyonnAPI.Controllers
{
    [RoutePrefix("api/CompanyAPI")]
    public class CompanyAPIController : ApiController
    {
        companyBL BL = new companyBL();

        [HttpGet]
        [Route("CompanyDataLoad")]
        public List<companyDTO> CompanyDataLoad()
        {
            return BL.CompanyDataLoad();
        }
        [HttpGet]
        [Route("CompanyDataLoadByID/{company_id?}")]
        public List<companyDTO> CompanyDataLoadByID(Int64 company_id)
        {

            return BL.CompanyDataLoadByID(company_id);
        }


       



        [HttpPost]
        [Route("companyDelete")]

        public HttpResponseMessage companyDelete([FromBody]int? id)
        {
            try
            {
                var result = BL.companyDelete(id);
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
        [Route("Postcompany")]
        [ActionName("Postcompany")]
        public HttpResponseMessage Postcompany(companyDTO News)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    string path = null;
                    if (News.company_img != "0")
                    {
                        string res = News.company_img.Substring(News.company_img.IndexOf(',') + 1);
                        string id1 = Guid.NewGuid().ToString();
                        id1 = id1 + ".png";

                        byte[] ret = Convert.FromBase64String(res);

                        path = HttpContext.Current.Server.MapPath("~/IMG/PicturesCompany/").ToString() + id1;
                        File.WriteAllBytes(path, ret);


                        News.company_img = id1;

                    }
                    var result = BL.CompanyDataSave(News);
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

        [Route("companyUpdate")]
        [ActionName("companyUpdate")]
        public HttpResponseMessage companyUpdate(companyDTO News)
        {
            try
            {
                if (ModelState.IsValid)
                {


                    string path = null;
                    if (News.company_img != "0")
                    {
                        string res = News.company_img.Substring(News.company_img.IndexOf(',') + 1);
                        string id1 = Guid.NewGuid().ToString();
                        id1 = id1 + ".png";

                        byte[] ret = Convert.FromBase64String(res);

                        path = HttpContext.Current.Server.MapPath("~/IMG/PicturesCompany/").ToString() + id1;
                        File.WriteAllBytes(path, ret);


                        News.company_img = id1;

                    }
                    var result = BL.companyUpdate(News);
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
