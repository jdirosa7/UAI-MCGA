using MCGA_Safari.Data;
using MCGA_Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCGA_Safari.Business
{
    public class RoomComponent
    {
        RoomDAC dac = new RoomDAC();

        public Room Add(Room Room)
        {
            Room result = default(Room);
            
            result = dac.Create(Room);
            return result;
        }

        public void Update(Room Room)
        {
            dac.Update(Room);
        }

        public void Delete(int id)
        {
            dac.Delete(id);
        }

        public Room Find(int id)
        {
            return dac.ReadBy(id);
        }

        public List<Room> ToList()
        {
            List<Room> result = default(List<Room>);

            result = dac.Read();
            return result;
        }
    }
}
