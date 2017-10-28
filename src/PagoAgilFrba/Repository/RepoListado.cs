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
    public class RepoListado : Repo
    {

        public List<Empresa> porcentajeFacturasCobradasEmpresa(int anio, int quarter)
        {
            var query = "SELECT TOP 5 f1.fact_empresa, 100 * count(fact_numero) / (SELECT count(f2.fact_numero) ";
            query += " FROM PIZZA.Factura f2 ";
            query += "WHERE DATEPART(QUARTER, f2.fact_alta) = @quarter AND DATEPART(YEAR, f2.fact_alta) = @anio ";
            query += "AND f2.fact_empresa = f1.fact_empresa ";
            query += "AND f2.fact_pagada = 1) ";
            query += "qty FROM PIZZA.Factura f1 ";
            query += "WHERE DATEPART(QUARTER, f1.fact_alta) = @quarter AND DATEPART(YEAR, f1.fact_alta) = @anio ";  
            query += "GROUP BY f1.fact_empresa";

            this.Command = new SqlCommand(query, this.Connector);

            this.Command.Parameters.Add("@anio", SqlDbType.Int).Value = anio;
            this.Command.Parameters.Add("@quarter", SqlDbType.Int).Value = quarter;

            this.Connector.Open();

            SqlDataReader data = Command.ExecuteReader();

            List<Empresa> empresas = new List<Empresa>();

            while (data.Read())
            {
                Empresa emp = new Empresa();
                emp.cuit = data["rend_empresa"].ToString();
                emp.id = Int32.Parse(data["qty"].ToString());
                empresas.Add(emp);
            }

            this.Connector.Close();

            return empresas;
        }

        public List<Empresa> empresasMayorMontoRendido(int anio, int quarter)
        {
            var query = "SELECT TOP 5 rend_empresa, emp_nombre, emp_direccion, sum(rend_totalRendicion) qty FROM PIZZA.Rendicion ";
            query += "JOIN PIZZA.Empresa ON emp_cuit = rend_empreas ";
            query += "WHERE DATEPART(QUARTER, fact_alta) = @quarter AND DATEPART(YEAR, fact_alta) = @anio ";
            query += "GROUP BY rend_empresa ";
            query += "ORDER BY sum(rend_totalRendicion) desc";

            this.Command = new SqlCommand(query, this.Connector);

            this.Command.Parameters.Add("@anio", SqlDbType.Int).Value = anio;
            this.Command.Parameters.Add("@quarter", SqlDbType.Int).Value = quarter;

            this.Connector.Open();
            SqlDataReader data = Command.ExecuteReader();

            List<Empresa> empresas = new List<Empresa>();

            while (data.Read())
            {
                Empresa emp = new Empresa();
                emp.cuit = data["rend_empresa"].ToString();
                emp.nombre = data["emp_nombre"].ToString();
                emp.direccion = data["emp_direccion"].ToString();
                emp.id = Int32.Parse(data["qty"].ToString()) ;
                empresas.Add(emp);
            }

            this.Connector.Close();

            return empresas;
        }

        public List<Cliente> clientesMasPagos(int anio, int quarter)
        {
            var query = "SELECT TOP 5 pago_cliente, clie_mail, clie_direccion, count(pago_id) qty FROM PIZZA.pago ";
            query += "JOIN PIZZA.Cliente ON pago_cliente = clie_dni ";
            query += "WHERE DATEPART(QUARTER, fact_alta) = @quarter AND DATEPART(YEAR, fact_alta) = @anio ";
            query += "GROUP BY pago_cliente ";
            query += "ORDER BY count(pago_id) desc";

            this.Command = new SqlCommand(query, this.Connector);

            this.Command.Parameters.Add("@anio", SqlDbType.Int).Value = anio;
            this.Command.Parameters.Add("@quarter", SqlDbType.Int).Value = quarter;

            this.Connector.Open();
            SqlDataReader data = Command.ExecuteReader();

            List<Cliente> clientes = new List<Cliente>();

            while (data.Read())
            {
                Cliente clie = new Cliente();
                clie.dni = Int32.Parse(data["pago_cliente"].ToString());
                clie.mail = data["clie_mail"].ToString();
                clie.direccion = data["clie_direccion"].ToString();
                clie.pagos = Int32.Parse(data["qty"].ToString());
                clientes.Add(clie);
            }

            this.Connector.Close();

            return clientes;
        }

        public List<Cliente> clientesMayorPorcentajeFacturasPagadas(int anio, int quarter)
        {
            var query = "SELECT TOP 5 f1.fact_cliente, 100 * count(f1.fact_numero)/( SELECT count(fact_numero) FROM PIZZA.Factura f2 ";
            query += "WHERE DATEPART(QUARTER, f2.fact_alta) = @quarter AND DATEPART(YEAR, f2.fact_alta) = @anio AND f2.fact_pagada = 1 ";
            query += ") qty FROM PIZZA.Factura f1 ";
            query += "WHERE DATEPART(QUARTER, f1.fact_alta) = @quarter AND DATEPART(YEAR, f1.fact_alta) = @anio ";
            query += "GROUP BY f1.fact_cliente";

            this.Command = new SqlCommand(query, this.Connector);

            this.Command.Parameters.Add("@anio", SqlDbType.Int).Value = anio;
            this.Command.Parameters.Add("@quarter", SqlDbType.Int).Value = quarter;

            this.Connector.Open();
            SqlDataReader data = Command.ExecuteReader();

            List<Cliente> clientes = new List<Cliente>();

            while (data.Read())
            {
                Cliente clie = new Cliente();
                clie.dni = Int32.Parse(data["pago_cliente"].ToString());
                clie.pagos = Int32.Parse(data["qty"].ToString());
                clientes.Add(clie);
            }

            this.Connector.Close();

            return clientes;
        }

    }

}
