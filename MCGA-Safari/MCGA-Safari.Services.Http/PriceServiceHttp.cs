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
    [RoutePrefix("api/price")]
    public class PriceServiceHttp : ApiController
    {
        [HttpPost]
        [Route("Add")]
        public AddPriceResponse Add(AddPriceRequest request)
        {
            try
            {
                var response = new AddPriceResponse();
                var bc = new PriceComponent();
                response.Result = bc.Add(request.Price);
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
        [Route("GetByFilters")]
        public GetPriceResponse GetById(int id, DateTime date)
        {
            try
            {
                var response = new GetPriceResponse();
                var bc = new PriceComponent();
                response.Result = bc.Find(id, date);
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
