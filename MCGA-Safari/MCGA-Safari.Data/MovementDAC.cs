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
    public class MovementDAC : DataAccessComponent, IRepository<Movement>
    {
        public Movement Create(Movement entity)
        {
            const string SQL_STATEMENT = "INSERT INTO Movimiento ([Fecha],[ClienteId],[TipoMovimientoId],[Valor]) " +
                "VALUES(@Fecha,@ClienteId,@TipoMovimientoId,@Valor); SELECT SCOPE_IDENTITY();";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Fecha", DbType.AnsiString, entity.Date);
                db.AddInParameter(cmd, "@ClienteId", DbType.AnsiString, entity.ClientId);
                db.AddInParameter(cmd, "@TipoMovimientoId", DbType.AnsiString, entity.MovementTypeId);
                db.AddInParameter(cmd, "@Valor", DbType.AnsiString, entity.Value);
                db.ExecuteScalar(cmd);
            }
            return entity;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Movement> Read()
        {
            throw new NotImplementedException();
        }

        public Movement ReadBy(int id)
        {
            throw new NotImplementedException();
        }

        public List<Movement> ReadyByFilters(Dictionary<string, string> filters)
        {
            string SQL_STATEMENT = "SELECT M.Id,[Fecha],[ClienteId],[TipoMovimientoId],[Valor], " +
                "C.Id as ClienteId, C.Nombre as ClienteNombre, C.Apellido as ClienteApellido, " +
                "C.FechaNacimiento as ClienteFechaNacimiento,C.Domicilio, C.Telefono as ClienteTelefono, " +
                "C.Email as ClienteEmail, C.Url, TM.Nombre as TipoMovimientoNombre, TM.Multiplicador " +
                "FROM Movimiento M inner join Cliente C on ClienteId = C.Id " +
                "inner join TipoMovimiento TM on TipoMovimientoId = TM.Id  WHERE ";
            List<Movement> movements = new List<Movement>();

            List<KeyValuePair<string, string>> values = filters.ToList();
            for (int i = 0; i < filters.Count; i++)
            {
                SQL_STATEMENT += values[i].Key + " = @" + values[i].Key;

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
                        movements.Add(LoadMovement(dr));
                    }
                }
            }
            return movements;
        }

        public void Update(Movement entity)
        {
            throw new NotImplementedException();
        }

        private Movement LoadMovement(IDataReader dr)
        {
            Movement movement = new Movement();
            movement.Id = GetDataValue<Int32>(dr, "Id");
            movement.Date = GetDataValue<DateTime>(dr, "Fecha");
            movement.Client = new Client{
                Id = GetDataValue<int>(dr, "ClienteId"),
                Name = GetDataValue<string>(dr, "ClienteNombre"),
                BirthDate = GetDataValue<DateTime>(dr, "ClienteFechaNacimiento"),
                Address = GetDataValue<string>(dr, "Domicilio"),
                LastName = GetDataValue<string>(dr, "ClienteApellido"),
                Email = GetDataValue<string>(dr, "ClienteEmail"),
                Phone = GetDataValue<string>(dr, "ClienteTelefono"),
                URL = GetDataValue<string>(dr, "URL")
            };
            movement.MovementType = new MovementType{
                Id = GetDataValue<Int32>(dr, "TipoMovimientoId"),
                Name = GetDataValue<string>(dr, "TipoMovimientoNombre"),
                Multiplier = GetDataValue<Int16>(dr, "Multiplicador")
        };
            movement.Value = Decimal.ToInt32(GetDataValue<Decimal>(dr, "Valor"));
            return movement;
        }
    }
}
