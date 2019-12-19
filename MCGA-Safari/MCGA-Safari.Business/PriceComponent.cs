using MCGA_Safari.Data;
using MCGA_Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCGA_Safari.Business
{
    public class PriceComponent
    {
        public Price Add(Price price)
        {
            Price result = default(Price);
            var priceDAC = new PriceDAC();

            result = priceDAC.Create(price);
            return result;
        }

        public void Update(Price price)
        {
            var priceDAC = new PriceDAC();
            priceDAC.Update(price);
        }

        public void Delete(int id)
        {
            var priceDAC = new PriceDAC();
            priceDAC.Delete(id);
        }

        public List<Price> ToList()
        {
            List<Price> result = default(List<Price>);

            var priceDAC = new PriceDAC();
            result = priceDAC.Read();
            return result;
        }

        public Price Find(int id, DateTime date)
        {
            Price result = default(Price);
            var dac = new PriceDAC();

            Dictionary<string, string> filters = new Dictionary<string, string>();
            filters.Add("TipoServicioId", id.ToString());
            filters.Add("FechaDesde", date.ToString());
            filters.Add("FechaHasta", date.ToString());

            result = dac.ReadByFilters(filters);
            return result;
        }
    }
}
