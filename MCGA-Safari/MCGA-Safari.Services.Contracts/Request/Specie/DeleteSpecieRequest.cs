using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MCGA_Safari.Services.Contracts.Request
{    
    [DataContract]
    public partial class DeleteSpecieRequest
    {
        [DataMember]
        public int Id { get; set; }
    }
}
