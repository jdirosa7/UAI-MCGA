using MCGA_Safari.Data;
using MCGA_Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCGA_Safari.Business
{
    public class MovementTypeComponent
    {
        public MovementType Add(MovementType movementType)
        {
            MovementType result = default(MovementType);
            var dac = new MovementTypeDAC();

            result = dac.Create(movementType);
            return result;
        }

        public void Update(MovementType movementType)
        {
            var dac = new MovementTypeDAC();
            dac.Update(movementType);
        }

        public void Delete(int id)
        {
            var dac = new MovementTypeDAC();
            dac.Delete(id);
        }

        public List<MovementType> ToList()
        {
            List<MovementType> result = default(List<MovementType>);

            var dac = new MovementTypeDAC();
            result = dac.Read();
            return result;
        }

        public MovementType GetByName(string name)
        {
            MovementType result = default(MovementType);

            var dac = new MovementTypeDAC();
            result = dac.ReadBy(name);
            return result;
        }
    }
}
