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

            this.Command.Parameters.Add("@numero", SqlDbType.Int).Value = item.numFactura;
            this.Command.Parameters.Add("@cantidad", SqlDbType.Int).Value = item.cantidad;
            this.Command.Parameters.Add("@monto", SqlDbType.Int).Value = item.monto;

            this.Command = new SqlCommand(query, this.Connector);
            this.Connector.Open();
            this.Command.ExecuteNonQuery();
            this.Connector.Close();
        }

    }
}
