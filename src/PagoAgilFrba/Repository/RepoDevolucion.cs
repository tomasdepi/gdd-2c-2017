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

            if (devolucion.tipoEntidad.Equals("Factura"))
                this.devolucionFactura(devolucion.idEntidad);

            if (devolucion.tipoEntidad.Equals("Rendicion"))
                this.devolucionRendicion(devolucion.idEntidad);

        }

        private void devolucionFactura(int numFactura)
        {
            var query = "UPDATE PIZZA.Factura SET fact_pagada = 0 WHERE fact_numero = @numFactura";

            this.Command = new SqlCommand(query, this.Connector);
            this.Command.Parameters.Add("@numFactura", SqlDbType.Int).Value = numFactura;

            this.Connector.Open();
            this.Command.ExecuteNonQuery();
            this.Connector.Close();
        }

        private void devolucionRendicion(int idRendicion)
        {
            var query = "UPDATE PIZZA.Rendicion SET rend_devuelta = 1 WHERE rend_id = @idRendicion";

            this.Command = new SqlCommand(query, this.Connector);
            this.Command.Parameters.Add("@idRendicion", SqlDbType.Int).Value = idRendicion;

            this.Connector.Open();
            this.Command.ExecuteNonQuery();
            this.Connector.Close();

            query = "DELETE FROM PIZZA.Factura_por_rendicion WHERE factRend_rendicion = @idRendicion";

            this.Command = new SqlCommand(query, this.Connector);
            this.Command.Parameters.Add("@idRendicion", SqlDbType.Int).Value = idRendicion;

            this.Connector.Open();
            this.Command.ExecuteNonQuery();
            this.Connector.Close();
        }


    }
}
