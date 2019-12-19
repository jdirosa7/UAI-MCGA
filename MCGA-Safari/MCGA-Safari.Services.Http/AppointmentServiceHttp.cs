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
    [RoutePrefix("api/appointment")]
    public class AppointmentServiceHttp : ApiController
    {
        [HttpPost]
        [Route("add")]
        public AddAppointmentResponse add(AddAppointmentRequest request)
        {
            try
            {
                var response = new AddAppointmentResponse();
                var bc = new AppointmentComponent();
                response.Result = bc.Add(request.Appointment);
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
        public AllAppointmentsResponse getAll()
        {
            try
            {
                var response = new AllAppointmentsResponse();
                var bc = new AppointmentComponent();
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
        public GetAppointmentResponse getById(int id)
        {
            try
            {
                var response = new GetAppointmentResponse();
                var bc = new AppointmentComponent();
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
        public void delete(UpdateAppointmentRequest request)
        {
            try
            {
                var response = new UpdateAppointmentResponse();
                var bc = new AppointmentComponent();
                bc.Update(request.Appointment);
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
        public void delete(DeleteAppointmentRequest request)
        {
            try
            {
                var response = new DeleteAppointmentResponse();
                var bc = new AppointmentComponent();
                bc.Delete(request.Appointment);
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
