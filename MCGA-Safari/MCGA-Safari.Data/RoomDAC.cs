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
    public class RoomDAC : DataAccessComponent, IRepository<Room>
    {
        public Room Create(Room Room)
        {
            const string SQL_STATEMENT = "INSERT INTO Sala ([Nombre],[TipoSala]) VALUES(@Nombre,@TipoSala);" +
                " SELECT SCOPE_IDENTITY();";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Nombre", DbType.AnsiString, Room.Name);
                db.AddInParameter(cmd, "@TipoSala", DbType.AnsiString, Room.RoomType);
                Room.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }
            return Room;
        }

        public List<Room> Read()
        {
            const string SQL_STATEMENT = "SELECT [Id], [Nombre], [TipoSala] FROM Sala ";

            List<Room> result = new List<Room>();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        Room Room = LoadRoom(dr);
                        result.Add(Room);
                    }
                }
            }
            return result;
        }

        public Room ReadBy(int id)
        {
            const string SQL_STATEMENT = "SELECT [Id], [Nombre], [TipoSala] FROM Sala WHERE [Id]=@Id ";
            Room Room = null;

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        Room = LoadRoom(dr);
                    }
                }
            }
            return Room;
        }

        public void Update(Room Room)
        {
            const string SQL_STATEMENT = "UPDATE Sala SET [Nombre]= @Nombre, [TipoSala]=@TipoSala WHERE [Id]= @Id ";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Nombre", DbType.AnsiString, Room.Name);
                db.AddInParameter(cmd, "@TipoSala", DbType.AnsiString, Room.RoomType);
                db.AddInParameter(cmd, "@Id", DbType.Int32, Room.Id);
                db.ExecuteNonQuery(cmd);
            }
        }

        public void Delete(int id)
        {
            const string SQL_STATEMENT = "DELETE Sala WHERE [Id]= @Id ";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        private Room LoadRoom(IDataReader dr)
        {
            Room Room = new Room();
            Room.Id = GetDataValue<int>(dr, "Id");
            Room.Name = GetDataValue<string>(dr, "Nombre");
            Room.RoomType = GetDataValue<string>(dr, "TipoSala");
            return Room;
        }

        public List<Room> ReadyByFilters(Dictionary<string, string> filters)
        {
            throw new NotImplementedException();
        }
    }
}
