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
    [RoutePrefix("api/movement")]
    public class MovementServiceHttp : ApiController
    {
        [HttpPost]
        [Route("Add")]
        public AddMovementResponse Add(AddMovementRequest request)
        {
            try
            {
                var response = new AddMovementResponse();
                var bc = new MovementComponent();
                response.Result = bc.Add(request.Movement);
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
        [Route("getByClient")]
        public ClientMovementResponse GetByClient(int id)
        {
            try
            {
                var response = new ClientMovementResponse();
                var bc = new MovementComponent();
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
    }
}
