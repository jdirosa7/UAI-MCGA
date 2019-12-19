using MCGA_Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCGA_Safari.Services.Contracts
{
    public interface IServiceType
    {
        List<ServiceType> ToList();
        ServiceType Find(int id);
        ServiceType Add(ServiceType ServiceType);
        ServiceType Update(int id, ServiceType ServiceType);
        void Delete(int id);
    }
}
