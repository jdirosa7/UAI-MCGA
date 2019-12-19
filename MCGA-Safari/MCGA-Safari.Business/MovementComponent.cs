using MCGA_Safari.Data;
using MCGA_Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCGA_Safari.Business
{
    public class MovementComponent
    {
        public Movement Add(Movement movement)
        {
            Movement result = default(Movement);
            var dac = new MovementDAC();

            result = dac.Create(movement);
            return result;
        }

        public void Update(Movement movement)
        {
            var dac = new MovementDAC();
            dac.Update(movement);
        }

        public void Delete(int id)
        {
            var dac = new MovementDAC();
            dac.Delete(id);
        }

        public List<Movement> ToList()
        {
            List<Movement> result = default(List<Movement>);

            var dac = new MovementDAC();
            result = dac.Read();
            return result;
        }

        public List<Movement> Find(int id)
        {
            List<Movement> result = default(List<Movement>);

            Dictionary<string, string> filters = new Dictionary<string, string>();
            filters.Add("ClienteId", id.ToString());          
            
            var dac = new MovementDAC();
            result = dac.ReadyByFilters(filters);
            return result;
        }
    }
}
