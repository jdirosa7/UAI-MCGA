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
    public class MovementTypeDAC : DataAccessComponent, IRepository<MovementType>
    {
        public MovementType Create(MovementType entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<MovementType> Read()
        {
            throw new NotImplementedException();
        }

        public MovementType ReadBy(int id)
        {
            throw new NotImplementedException();
        }

        public MovementType ReadBy(string name)
        {
            const string SQL_STATEMENT = "SELECT [Id], [Nombre], [Multiplicador] FROM TipoMovimiento " +
                "WHERE [Nombre]=@Nombre ";
            MovementType movementType = null;

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Nombre", DbType.String, name);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        movementType = LoadMovementType(dr);
                    }
                }
            }
            return movementType;
        }

        public List<MovementType> ReadyByFilters(Dictionary<string, string> filters)
        {
            throw new NotImplementedException();
        }

        public void Update(MovementType entity)
        {
            throw new NotImplementedException();
        }

        private MovementType LoadMovementType(IDataReader dr)
        {
            MovementType movementType = new MovementType();
            movementType.Id = GetDataValue<Int32>(dr, "Id");
            movementType.Name = GetDataValue<string>(dr, "Nombre");
            movementType.Multiplier = GetDataValue<Int16>(dr, "Multiplicador");
            return movementType;
        }
    }
}
