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
    [RoutePrefix("api/patient")]
    public class PatientServiceHttp : ApiController
    {
        [HttpPost]
        [Route("add")]
        public AddPatientResponse add(AddPatientRequest request)
        {
            try
            {
                var response = new AddPatientResponse();
                var bc = new PatientComponent();
                response.Result = bc.Add(request.Patient);
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
        public AllPatientsResponse getAll()
        {
            try
            {
                var response = new AllPatientsResponse();
                var bc = new PatientComponent();
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
        public GetPatientResponse getById(int id)
        {
            try
            {
                var response = new GetPatientResponse();
                var bc = new PatientComponent();
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

        [HttpGet]
        [Route("getByClientId")]
        public GetClientPetsResponse getByClientId(int id)
        {
            try
            {
                var response = new GetClientPetsResponse();
                var bc = new ClientComponent();
                response.Result = bc.GetClientPets(id);
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
        public void delete(UpdatePatientRequest request)
        {
            try
            {
                var response = new UpdatePatientResponse();
                var bc = new PatientComponent();
                bc.Update(request.Patient);
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
        public void delete(DeletePatientRequest request)
        {
            try
            {
                var response = new DeletePatientResponse();
                var bc = new PatientComponent();
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
