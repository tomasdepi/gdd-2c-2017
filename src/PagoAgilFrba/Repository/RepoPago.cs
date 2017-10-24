using PagoAgilFrba.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.Repository
{
    public class RepoPago : Repo
    {

        public void altaPago(Pago pago)
        {
            var query = "INSERT INTO PIZZA.Pago (pago_cliente, pago_importeTotal, pago_sucursal, pago_fecha, pago_formaPago)";
            query += " VALUES (@cliente, @importe, @sucursal, @fecha, @formaPago)";

            this.Command = new SqlCommand(query, this.Connector);

            this.Command.Parameters.Add("@cliente", SqlDbType.Int).Value = pago.cliente;
            this.Command.Parameters.Add("@importe", SqlDbType.Int).Value = pago.importeTotal;
            this.Command.Parameters.Add("@sucursal", SqlDbType.Int).Value = pago.sucursal;
            this.Command.Parameters.Add("@fecha", SqlDbType.Date).Value = pago.fecha;
            this.Command.Parameters.Add("@formaPago", SqlDbType.VarChar).Value = pago.formaPago;

            this.Connector.Open();
            this.Command.ExecuteNonQuery();
            this.Connector.Close();

        }

        public void altaFacturasPago(int idPago, List<int> numFacturas)
        {
            var query = "INSERT INTO PIZZA.Factura_por_pago (factPago_pago, factPago_factura) VALUES ";

            foreach(int numFactura in numFacturas)
            {
                query += "("+idPago+","+numFactura+"),";
            }
            query.Remove(query.Count() - 1);

            this.Command = new SqlCommand(query, this.Connector);

            this.Connector.Open();
            this.Command.ExecuteNonQuery();
            this.Connector.Close();
        }

    }
}
