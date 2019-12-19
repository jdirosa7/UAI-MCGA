using MCGA_Safari.Entities;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCGA_Safari.Data
{
    public class PriceDAC : DataAccessComponent, IRepository<Price>
    {
        public Price Create(Price Price)
        {
            const string SQL_STATEMENT = "INSERT INTO Precio ([TipoServicioId],[FechaDesde],[FechaHasta],[Valor]) " +
                "VALUES(@TipoServicioId,@FechaDesde,@FechaHasta,@Valor);" +
                " SELECT SCOPE_IDENTITY();";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@TipoServicioId", DbType.Int32, Price.ServiceTypeId);
                db.AddInParameter(cmd, "@FechaDesde", DbType.DateTime, Price.FromDate);
                db.AddInParameter(cmd, "@FechaHasta", DbType.DateTime, Price.ToDate);
                db.AddInParameter(cmd, "@Valor", DbType.Decimal, Price.Value);
                db.ExecuteScalar(cmd);
            }
            return Price;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Price> Read()
        {
            throw new NotImplementedException();
        }

        public Price ReadBy(int id)
        {
            throw new NotImplementedException();
        }

        public Price ReadByFilters(Dictionary<string, string> filters)
        {
            string SQL_STATEMENT = "SELECT [TipoServicioId],[FechaDesde],[FechaHasta],[Valor] FROM Precio WHERE ";
            Price price = null;

            List<KeyValuePair<string, string>> values = filters.ToList();
            for (int i = 0; i < filters.Count; i++)
            {
                if (values[i].Key == "FechaDesde")
                {
                    SQL_STATEMENT += values[i].Key + " <= '" + values[i].Value + "'";
                }
                else{
                    if(values[i].Key == "FechaHasta")
                    {
                        SQL_STATEMENT += values[i].Key + " >= '" + values[i].Value + "'";
                    }
                    else
                    {
                        SQL_STATEMENT += values[i].Key + " = " + values[i].Value;
                    }
                }

                if (i + 1 != filters.Count)
                    SQL_STATEMENT += " AND ";

            }

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                for (int i = 0; i < filters.Count; i++)
                {
                    var isTypeInt = values[i].Value.GetType().Equals(typeof(int));
                    db.AddInParameter(cmd, "@" + values[i].Key, isTypeInt ? DbType.Int32 : DbType.AnsiString, values[i].Value);

                }

                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        price = LoadPrice(dr);
                    }
                }
            }
            return price;
        }

        public List<Price> ReadyByFilters(Dictionary<string, string> filters)
        {
            throw new NotImplementedException();
        }

        public void Update(Price entity)
        {
            throw new NotImplementedException();
        }

        private Price LoadPrice(IDataReader dr)
        {
            Price price = new Price();
            price.ServiceTypeId = GetDataValue<Int32>(dr, "TipoServicioId");
            price.FromDate = GetDataValue<DateTime>(dr, "FechaDesde");
            price.ToDate = GetDataValue<DateTime>(dr, "FechaHasta");
            price.Value = Decimal.ToInt32(GetDataValue<Decimal>(dr, "Valor"));
            return price;
        }
    }
}
