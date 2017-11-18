using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagoAgilFrba.Entities;

namespace PagoAgilFrba.Repository
{
    public class RepoRendicion : Repo
    {

        public void altaRendicion(Entities.Rendicion rend)
        {
            var query = "INSERT INTO PIZZA.Rendicion (rend_fecha, rend_cantFacturas, rend_importeComision, rend_empresa, rend_porcentComision, rend_totalRendicion, rend_devuelta)";
            query += "VALUES (@fecha, @cantFacturas, @importeComision, @empresa, @porcentComision, @totalRendicion, 0)";

            this.Command = new SqlCommand(query, this.Connector);
            this.Command.Parameters.Add("@fecha", SqlDbType.Date).Value = rend.fecha;
            this.Command.Parameters.Add("@cantFacturas", SqlDbType.Int).Value = rend.cantFacturas;
            this.Command.Parameters.Add("@importeComision", SqlDbType.Int).Value = rend.importeComision;
            this.Command.Parameters.Add("@empresa", SqlDbType.VarChar).Value = rend.empresa;
            this.Command.Parameters.Add("@porcentComision", SqlDbType.Int).Value = rend.porcentComision;
            this.Command.Parameters.Add("@totalRendicion", SqlDbType.Int).Value = rend.totalRendicion;

            this.Connector.Open();
            this.Command.ExecuteNonQuery();
            this.Connector.Close();

        }

        public int getIdRendicion(int anio, int mes, string empresa)
        {
            var query = "SELECT rend_id FROM PIZZA.Rendicion WHERE YEAR(rend_fecha) = @anio AND MONTH(rend_fecha) = @mes AND rend_empresa = @empresa ";

            this.Command = new SqlCommand(query, this.Connector);
            this.Command.Parameters.Add("@mes", SqlDbType.Int).Value = mes;
            this.Command.Parameters.Add("@anio", SqlDbType.Int).Value = anio;
            this.Command.Parameters.Add("@empresa", SqlDbType.VarChar).Value = empresa;

            this.Connector.Open();
            SqlDataReader reader = this.Command.ExecuteReader();

            reader.Read();
            int id = Int32.Parse(reader["rend_id"].ToString());

            this.Connector.Close();

            return id;

        }

        public void altaFacturas(List<Factura> facts, int idRendicion)
        {
            foreach(Factura f in facts)
            {
                altaFacturaRendicion(f.numero, idRendicion);
            }
        }

        private void altaFacturaRendicion(int idFactura, int idRendicion)
        {
            var query = "INSERT INTO PIZZA.Factura_por_rendicion (factRend_factura, factRend_rendicion) VALUES (@factura, @rendicion)";

            this.Command = new SqlCommand(query, this.Connector);
            this.Command.Parameters.Add("@factura", SqlDbType.Int).Value = idFactura;
            this.Command.Parameters.Add("@rendicion", SqlDbType.Int).Value = idRendicion;

            this.Connector.Open();
            this.Command.ExecuteNonQuery();
            this.Connector.Close();
        }

        public bool validarExistenciaRendicion(int anio, int mes, string empresa)
        {
            bool existe = false;

            var query = "SELECT 1 FROM PIZZA.Rendicion WHERE YEAR(rend_fecha) = @anio AND MONTH(rend_fecha) = @mes AND rend_empresa = @empresa AND rend_devuelta = 0";

            this.Command = new SqlCommand(query, this.Connector);
            this.Command.Parameters.Add("@mes", SqlDbType.Int).Value = mes;
            this.Command.Parameters.Add("@anio", SqlDbType.Int).Value = anio;
            this.Command.Parameters.Add("@empresa", SqlDbType.VarChar).Value = empresa;

            this.Connector.Open();
            SqlDataReader reader = this.Command.ExecuteReader();

            if (reader.HasRows) existe = true;

            this.Connector.Close();

            return existe;
        }

        public List<Factura> getFacturasARendir(int anio, int mes, string empresa)
        {
            List<Factura> facturas = new List<Factura>();

            var query = "SELECT fact_numero, sum(item_monto * item_cantidad) factura_monto FROM PIZZA.Factura ";
            query += "JOIN PIZZA.Item_factura on item_numFacutura = fact_numero ";
            query +=  "JOIN PIZZA.Factura_por_pago on factPago_factura = fact_numero ";
            query += "JOIN PIZZA.Pago on pago_id = factPago_pago ";
            query += "WHERE fact_pagada = 1 AND YEAR(pago_fecha) = @anio AND MONTH(pago_fecha) = @mes AND fact_empresa = @empresa ";
            query += "GROUP BY fact_numero";

            this.Command = new SqlCommand(query, this.Connector);
            this.Command.Parameters.Add("@mes", SqlDbType.Int).Value = mes;
            this.Command.Parameters.Add("@anio", SqlDbType.Int).Value = anio;
            this.Command.Parameters.Add("@empresa", SqlDbType.VarChar).Value = empresa;
            
            this.Connector.Open();
            SqlDataReader reader = this.Command.ExecuteReader();

            if (reader.Read())
            {
                Factura factura = new Factura();
                factura.numero = Int32.Parse(reader["fact_numero"].ToString());
                factura.importe = Int32.Parse(reader["factura_monto"].ToString());
                facturas.Add(factura);
            }

            this.Connector.Close();


            return facturas;
        }

        public List<Entities.Rendicion> buscarRendiciones(string CuitEmpresa)
        {
            var query = "SELECT rend_id, rend_empresa, rend_fecha FROM PIZZA.Rendicion WHERE rend_empresa = @empresa AND rend_devuelta = 0";

            this.Command = new SqlCommand(query, this.Connector);
            this.Command.Parameters.Add("@empresa", SqlDbType.VarChar).Value = CuitEmpresa;

            this.Connector.Open();
            SqlDataReader reader = this.Command.ExecuteReader();

            List<Entities.Rendicion> rendiciones = new List<Entities.Rendicion>();

            while (reader.Read())
            {
                rendiciones.Add(crearRendicion(reader));
            }

            this.Connector.Close();

            return rendiciones;
        }

        private Entities.Rendicion crearRendicion(SqlDataReader reader)
        {
            Entities.Rendicion rendicion = new Entities.Rendicion();
            rendicion.id = Int32.Parse(reader["rend_id"].ToString());
            rendicion.empresa = reader["rend_empresa"].ToString();
            rendicion.fecha = Convert.ToDateTime(reader["rend_fecha"].ToString());

            return rendicion;
        }

    }
}
