﻿using PagoAgilFrba.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.Repository
{
    public class RepoFactura : Repo
    {

        public void altaFactura(Factura factura)
        {
            var query = "INSERT INTO PIZZA.Factura (fact_numero, fact_cliente, fact_empresa, fact_alta, fact_vencimiento, fact_pagada) ";
            query += "VALUES (@numero, @cliente, @empresa, @alta, @vencimiento, 0)";

            this.Command = new SqlCommand(query, this.Connector);

            this.Command.Parameters.Add("@numero", SqlDbType.Int).Value = factura.numero;
            this.Command.Parameters.Add("@cliente", SqlDbType.Int).Value = factura.cliente;
            this.Command.Parameters.Add("@empresa", SqlDbType.VarChar).Value = factura.empresa;
            this.Command.Parameters.Add("@alta", SqlDbType.Date).Value = factura.alta;
            this.Command.Parameters.Add("@vencimiento", SqlDbType.Date).Value = factura.vencimiento;

            this.Connector.Open();
            this.Command.ExecuteNonQuery();
            this.Connector.Close();
        }

        public void updateFactura(Factura factura)
        {
            var query = "UPDATE PIZZA.Factura SET fact_cliente=@cliente, fact_empresa=@empresa, fact_alta=@alta, fact_vencimiento=@vencimiento WHERE fact_numero=@numero";

            this.Command = new SqlCommand(query, this.Connector);

            this.Command.Parameters.Add("@numero", SqlDbType.Int).Value = factura.numero;
            this.Command.Parameters.Add("@cliente", SqlDbType.Int).Value = factura.cliente;
            this.Command.Parameters.Add("@empresa", SqlDbType.VarChar).Value = factura.empresa;
            this.Command.Parameters.Add("@alta", SqlDbType.Date).Value = factura.alta;
            this.Command.Parameters.Add("@vencimiento", SqlDbType.Date).Value = factura.vencimiento;

            this.Connector.Open();
            this.Command.ExecuteNonQuery();
            this.Connector.Close();
        }

        public void altaItems(List<ItemFactura> items)
        {
            foreach (ItemFactura item in items)
            {
                altaItemFactura(item);
            }
        }

        private void altaItemFactura(ItemFactura item)
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

            var query = "SELECT fact_numero, fact_cliente, fact_empresa, fact_pagada, fact_vencimiento, (SELECT sum(item_monto * item_cantidad) FROM PIZZA.Item_factura where item_numFacutura = fact_numero) importe FROM PIZZA.Factura ";
            query += "WHERE fact_numero LIKE '%"+numFactura+"%' AND fact_cliente LIKE '%"+cliente+"%' ";

            if(pago == 1) //pagada
                query += "AND fact_pagada = 1";
            if (pago == 2) // no pagada
                query += "AND fact_pagada = 0";

            this.Command = new SqlCommand(query, this.Connector);
            //this.Command.Parameters.Add("@numFactura", SqlDbType.VarChar).Value = numFactura;
            //this.Command.Parameters.Add("@cliente", SqlDbType.VarChar).Value = cliente;

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

            DateTime fechaSistema;

            try
            {
                fechaSistema = Convert.ToDateTime(ConfigurationManager.AppSettings["FechaSistema"].ToString());
            }catch
            {
                fechaSistema = Convert.ToDateTime(ConfigurationManager.AppSettings["FechaSistemaProvicional"].ToString());
            }
           

            Factura factura = new Factura();
            factura.numero = Int32.Parse(data["fact_numero"].ToString());
            factura.cliente = Int32.Parse(data["fact_cliente"].ToString());
            factura.empresa = data["fact_empresa"].ToString();
            factura.importe = Int32.Parse(data["importe"].ToString());
            factura.pagada = data["fact_pagada"].ToString() == "1" ? true : false;
            factura.vencimiento = Convert.ToDateTime(data["fact_vencimiento"].ToString());
            factura.vencida = factura.vencimiento.CompareTo(fechaSistema) > 0 ? false : true;

            return factura;
        }

        public Factura getFactura(int numFactura)
        {
            Factura factura = new Factura();

            var query = "SELECT TOP 1 *, (SELECT sum(item_monto * item_cantidad) FROM PIZZA.Item_factura where item_numFacutura = fact_numero) importe FROM PIZZA.Factura WHERE fact_numero = @numFactura ";

            this.Command = new SqlCommand(query, this.Connector);
            this.Command.Parameters.Add("@numFactura", SqlDbType.Int).Value = numFactura;

            this.Connector.Open();

            SqlDataReader facturaReader = Command.ExecuteReader();

            facturaReader.Read();

            factura = crearFactura(facturaReader);

            this.Connector.Close();


            return factura;
        }

        public List<ItemFactura> getItems(int numFactura)
        {
            List<ItemFactura> items = new List<ItemFactura>();

            var query = "SELECT item_monto, item_cantidad FROM PIZZA.Item_factura WHERE item_numFacutura = @numFactura";

            this.Command = new SqlCommand(query, this.Connector);
            this.Command.Parameters.Add("@numFactura", SqlDbType.Int).Value = numFactura;

            this.Connector.Open();

            SqlDataReader itemReader = Command.ExecuteReader();

            while (itemReader.Read())
            {
                ItemFactura item = new ItemFactura();
                item.monto = Int32.Parse(itemReader["item_monto"].ToString());
                item.cantidad = Int32.Parse(itemReader["item_cantidad"].ToString());
                items.Add(item);
            }

            this.Connector.Close();


            return items;
        }
        public int getNumFactura(int numFactura)
        {
            int resultado; 

            var query = "SELECT top 1 * FROM Pizza.Factura WHERE fact_numero= @numFactura";
           
            this.Command = new SqlCommand(query, this.Connector);
            this.Command.Parameters.Add("@numFactura", SqlDbType.Int).Value = numFactura;
           
            this.Connector.Open();
           
            SqlDataReader data = this.Command.ExecuteReader();
            if (data.Read())
            {
                resultado=1;
                
            }
            else
            {
                resultado = 0;
            }
       
            this.Connector.Close();
            return resultado;
            
        }

        public void deleteItems(int numFactura)
        {
            var query = "DELETE FROM PIZZA.Item_factura WHERE item_numFacutura = @numFactura";
            this.Command = new SqlCommand(query, this.Connector);
            this.Command.Parameters.Add("@numFactura", SqlDbType.Int).Value = numFactura;

            this.Connector.Open();
            this.Command.ExecuteNonQuery();
            this.Connector.Close();
        }

        
    }
}
