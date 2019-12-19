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
    public class ServiceTypeProcess : ProcessComponent
    {
        public List<ServiceType> ToList()
        {
            var response = HttpGet<AllServiceTypesResponse>("api/servicetype/getAll", new Dictionary<string, object>(), MediaType.Json);
            return response.Result;
        }

        public void Add(ServiceType serviceType)
        {
            var request = new AddServiceTypeRequest();
            request.ServiceType = serviceType;
            var response = HttpPost<AddServiceTypeRequest>("api/servicetype/add", request, MediaType.Json);
        }

        public ServiceType Find(int id)
        {
            Dictionary<string, object> dir = new Dictionary<string, object>();
            dir.Add("Id", id);
            var response = HttpGet<GetServiceTypeResponse>("api/servicetype/getById", dir, MediaType.Json);
            return response.Result;
        }

        public void Update(ServiceType serviceType)
        {
            var request = new UpdateServiceTypeRequest();
            request.ServiceType = serviceType;
            var response = HttpPost<UpdateServiceTypeRequest>("api/servicetype/update", request, MediaType.Json);
        }

        public void Delete(int id)
        {
            var request = new DeleteServiceTypeRequest();
            request.Id = id;
            var response = HttpPost<DeleteServiceTypeRequest>("api/servicetype/delete", request, MediaType.Json);
        }
    }
}
