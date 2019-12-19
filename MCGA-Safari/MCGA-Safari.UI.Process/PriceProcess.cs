using MCGA_Safari.Entities;
using MCGA_Safari.Services.Contracts.Request;
using MCGA_Safari.Services.Contracts.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCGA_Safari.UI.Process
{
    public class PriceProcess : ProcessComponent
    {
        public void Add(Price Price)
        {
            var request = new AddPriceRequest();
            request.Price = Price;
            var response = HttpPost<AddPriceRequest>("api/Price/add", request, MediaType.Json);
        }

        public Price Find(int id, DateTime date)
        {
            Dictionary<string, object> dir = new Dictionary<string, object>();
            dir.Add("id", id);
            dir.Add("date", date);
            var response = HttpGet<GetPriceResponse>("api/price/getByFilters", dir, MediaType.Json);
            return response.Result;
        }
    }
}
