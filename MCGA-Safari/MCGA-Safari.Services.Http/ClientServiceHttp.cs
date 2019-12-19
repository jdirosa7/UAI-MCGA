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
    [RoutePrefix("api/client")]
    public class ClientServiceHttp : ApiController
    {
        [HttpPost]
        [Route("add")]
        public AddClientResponse add(AddClientRequest request)
        {
            try
            {
                var response = new AddClientResponse();
                var bc = new ClientComponent();
                response.Result = bc.Add(request.Client);
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
        public AllClientsResponse getAll()
        {
            try
            {
                var response = new AllClientsResponse();
                var bc = new ClientComponent();
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
        public GetClientResponse getById(int id)
        {
            try
            {
                var response = new GetClientResponse();
                var bc = new ClientComponent();
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
        public void delete(UpdateClientRequest request)
        {
            try
            {
                var response = new UpdateClientResponse();
                var bc = new ClientComponent();
                bc.Update(request.Client);
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
        public void delete(DeleteClientRequest request)
        {
            try
            {
                var response = new DeleteClientResponse();
                var bc = new ClientComponent();
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
