using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.Repository
{
    public class RepoDevolucion : Repo
    {
        public void altaDevolucion(Entities.Devolucion devolucion)
        {
            var query = "INSERT INTO PIZZA.Devolucion(dev_tipoEntidad, dev_fecha, dev_motivo, dev_entidad)";
            query += "VALUES (@tipoEntidad, @fecha, @motivo, @idEntidad)";

            this.Command = new SqlCommand(query, this.Connector);

            this.Command.Parameters.Add("@tipoEntidad", SqlDbType.VarChar).Value = devolucion.tipoEntidad;
            this.Command.Parameters.Add("@fecha", SqlDbType.Date).Value = devolucion.fecha;
            this.Command.Parameters.Add("@motivo", SqlDbType.VarChar).Value = devolucion.motivo;
            this.Command.Parameters.Add("@idEntidad", SqlDbType.Int).Value = devolucion.idEntidad;

            this.Connector.Open();
            this.Command.ExecuteNonQuery();
            this.Connector.Close();
        }
    }
}
