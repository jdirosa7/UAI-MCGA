using MCGA_Safari.Entities;
using MCGA_Safari.Services.Contracts.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCGA_Safari.UI.Process
{
    public class MovementTypeProcess : ProcessComponent
    {
        public MovementType Find(string name)
        {
            Dictionary<string, object> dir = new Dictionary<string, object>();
            dir.Add("Name", name);
            var response = HttpGet<GetMovementTypeResponse>("api/movementtype/GetByName", dir, MediaType.Json);
            return response.Result;
        }
    }
}
