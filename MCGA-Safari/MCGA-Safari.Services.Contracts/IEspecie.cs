using MCGA_Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCGA_Safari.Services.Contracts
{
    public interface IEspecie
    {
        List<Species> ToList();
        Species Find(int id);
        Species Add(Species especie);
        Species Update(int id, Species especie);
        void Delete(int id);
    }
}
