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
    public class RepoFactura : Repo
    {

        public void altaFactura(Factura factura, List<ItemFactura> items)
        {
            var query = "INSERT INTO PIZZA.Factura (fact_numero, fact_cliente, fact_empresa, fact_alta, fact_vencimiento, fact_pagada) ";
            query += "VALUES (@numero, @cliente, @empresa, @alta, @vencimiento, 0)";

            this.Command = new SqlCommand(query, this.Connector);

            this.Command.Parameters.Add("@dni", SqlDbType.Int).Value = factura.numero;
            this.Command.Parameters.Add("@cliente", SqlDbType.Int).Value = factura.cliente;
            this.Command.Parameters.Add("@empresa", SqlDbType.VarChar).Value = factura.empresa;
            this.Command.Parameters.Add("@alta", SqlDbType.Date).Value = factura.alta;
            this.Command.Parameters.Add("@vencimiento", SqlDbType.Date).Value = factura.vencimiento;

            this.Connector.Open();
            this.Command.ExecuteNonQuery();
            this.Connector.Close();

            foreach(ItemFactura item in items)
            {
                altaItemFactura(factura.numero, item);
            }

        }

        private void altaItemFactura(int numFactura, ItemFactura item)
        {
            var query = "INSERT INTO PIZZA.Item_factura (item_numFacutura, item_cantidad, item_monto) ";
            query += "VALUES (@numero, @cantidad, @monto)";

            this.Command = new SqlCommand(query, this.Connector);
            this.Command.Parameters.Add("@numero", SqlDbType.Int).Value = item.numFactura;
            this.Command.Parameters.Add("@cantidad", SqlDbType.Int).Value = item.cantidad;
            this.Command.Parameters.Add("@monto", SqlDbType.Int).Value = item.monto;

            this.Connector.Open();
            this.Command.ExecuteNonQuery();
            this.Connector.Close();
        }

        public List<Factura> getFacturas(string numFactura, string cliente, int pago)
        {
            List<Factura> facts = new List<Factura>();

            var query = "SELECT fact_num, fact_cliente, fact_empresa, fact_pagada FROM PIZZA.Factura ";
            query += "WHERE fact_num LIKE '%@numFactura%' AND fact_cliente LIKE '%@cliente%' ";

            if(pago == 1) //pagada
                query += "AND fact_pagada = 1";
            if (pago == 2) // no pagada
                query += "AND fact_pagada = 0";

            this.Command = new SqlCommand(query, this.Connector);
            this.Command.Parameters.Add("@numFactura", SqlDbType.Int).Value = numFactura;
            this.Command.Parameters.Add("@cliente", SqlDbType.Int).Value = cliente;

            this.Connector.Open();

            SqlDataReader facturas = Command.ExecuteReader();

            while (facturas.Read())
            {
                facts.Add(crearFactura(facturas));
            }

            this.Connector.Close();

            return facts;
        }

        private Factura crearFactura(SqlDataReader data)
        {
            Factura factura = new Factura();
            factura.numero = Int32.Parse(data["fact_numero"].ToString());
            factura.cliente = Int32.Parse(data["fact_cliente"].ToString());
            factura.empresa = data["fact_empresa"].ToString();
            factura.pagada = Convert.ToBoolean(data["fact_pagada"].ToString());

            return factura;
        }
    }
}
