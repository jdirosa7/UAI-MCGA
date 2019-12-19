using MCGA_Safari.Business;
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
    [RoutePrefix("api/movementtype")]
    public class MovementTypeServiceHttp : ApiController
    {
        [HttpGet]
        [Route("GetByName")]
        public GetMovementTypeResponse GetById(string name)
        {
            try
            {
                var response = new GetMovementTypeResponse();
                var bc = new MovementTypeComponent();
                response.Result = bc.GetByName(name);
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
