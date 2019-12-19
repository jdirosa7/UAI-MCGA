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
    public class MovementProcess : ProcessComponent
    {
        public void Add(Movement Movement)
        {
            var request = new AddMovementRequest();
            request.Movement = Movement;
            var response = HttpPost<AddMovementRequest>("api/movement/add", request, MediaType.Json);
        }

        public List<Movement> GetMovementsByClient(int id)
        {
            Dictionary<string, object> dir = new Dictionary<string, object>();
            dir.Add("id", id);
            var response = HttpGet<ClientMovementResponse>("api/movement/getByClient", dir, MediaType.Json);
            return response.Result;
        }
    }
}
