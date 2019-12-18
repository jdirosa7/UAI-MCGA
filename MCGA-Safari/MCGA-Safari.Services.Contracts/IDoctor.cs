using MCGA_Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCGA_Safari.Services.Contracts
{
    public interface IDoctor
    {
        List<Doctor> ToList();
        Doctor Find(int id);
        Doctor Add(Doctor doctor);
        Doctor Update(Doctor doctor);
        void Delete(int id);
    }
}
