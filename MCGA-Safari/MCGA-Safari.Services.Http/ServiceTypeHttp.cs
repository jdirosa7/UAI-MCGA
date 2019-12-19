using MCGA_Safari.Business;
using MCGA_Safari.Services.Contracts.Request;
using MCGA_Safari.Services.Contracts.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace MCGA_Safari.Services.Http
{
    [RoutePrefix("api/servicetype")]
    public class ServiceTypeHttp : ApiController
    {
        [HttpPost]
        [Route("Add")]
        public AddServiceTypeResponse Add(AddServiceTypeRequest request)
        {
            try
            {
                var response = new AddServiceTypeResponse();
                var bc = new ServiceTypeComponent();
                response.Result = bc.Add(request.ServiceType);
                return response;
            }
            catch (Exception ex)
            {
                var httpError = new HttpResponseMessage()
                {
                    StatusCode = (HttpStatusCode)422,
                    ReasonPhrase = ex.Message
                };
                throw new HttpResponseException(httpError);
            }
        }

        [HttpGet]
        [Route("GetAll")]
        public AllServiceTypesResponse GetAll()
        {
            try
            {
                var response = new AllServiceTypesResponse();
                var bc = new ServiceTypeComponent();
                response.Result = bc.ToList();

                return response;

            }
            catch (Exception ex)
            {
                var httpError = new HttpResponseMessage()
                {
                    StatusCode = (HttpStatusCode)422,
                    ReasonPhrase = ex.Message
                };
                throw new HttpResponseException(httpError);
            }
        }

        [HttpGet]
        [Route("GetById")]
        public GetServiceTypeResponse GetById(int id)
        {
            try
            {
                var response = new GetServiceTypeResponse();
                var bc = new ServiceTypeComponent();
                response.Result = bc.Find(id);
                return response;
            }
            catch (Exception ex)
            {
                var httpError = new HttpResponseMessage()
                {
                    StatusCode = (HttpStatusCode)422,
                    ReasonPhrase = ex.Message
                };
                throw new HttpResponseException(httpError);
            }
        }

        [HttpPost]
        [Route("Update")]
        public void Update(UpdateServiceTypeRequest request)
        {
            try
            {
                var response = new UpdateServiceTypeResponse();
                var bc = new ServiceTypeComponent();
                bc.Update(request.ServiceType);
            }
            catch (Exception ex)
            {
                var httpError = new HttpResponseMessage()
                {
                    StatusCode = (HttpStatusCode)422,
                    ReasonPhrase = ex.Message
                };
                throw new HttpResponseException(httpError);
            }
        }

        [HttpPost]
        [Route("Delete")]
        public void Delete(DeleteServiceTypeRequest request)
        {
            try
            {
                var response = new DeleteServiceTypeResponse();
                var bc = new ServiceTypeComponent();
                bc.Delete(request.Id);
            }
            catch (Exception ex)
            {
                var httpError = new HttpResponseMessage()
                {
                    StatusCode = (HttpStatusCode)422,
                    ReasonPhrase = ex.Message
                };
                throw new HttpResponseException(httpError);
            }
        }
    }
}
