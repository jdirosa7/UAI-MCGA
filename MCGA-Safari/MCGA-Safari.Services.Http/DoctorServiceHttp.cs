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
    [RoutePrefix("api/doctor")]
    public class DoctorServiceHttp : ApiController
    {
        [HttpPost]
        [Route("add")]
        public AddDoctorResponse add(AddDoctorRequest request)
        {
            try
            {
                var response = new AddDoctorResponse();
                var bc = new DoctorComponent();
                response.Result = bc.Add(request.Doctor);
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
        [Route("getAll")]
        public AllDoctorsResponse getAll()
        {
            try
            {
                var response = new AllDoctorsResponse();
                var bc = new DoctorComponent();
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
        [Route("getById")]
        public GetDoctorResponse getById(int id)
        {
            try
            {
                var response = new GetDoctorResponse();
                var bc = new DoctorComponent();
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
        [Route("update")]
        public void delete(UpdateDoctorRequest request)
        {
            try
            {
                var response = new UpdateDoctorResponse();
                var bc = new DoctorComponent();
                bc.Update(request.Doctor);
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
        [Route("delete")]
        public void delete(DeleteDoctorRequest request)
        {
            try
            {
                var response = new DeleteDoctorResponse();
                var bc = new DoctorComponent();
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
