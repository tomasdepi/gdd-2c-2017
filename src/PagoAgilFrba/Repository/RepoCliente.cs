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
    class RepoCliente : Repo
    {
        public void altaCliente(Cliente cliente)
        {
            var query = "INSERT INTO PIZZA.Cliente (clie_dni, clie_nombre, clie_apellido, clie_telefono, clie_mail, clie_direccion, clie_codPostal, clie_fechaNac) ";
            query += "VALUES (@dni, @nombre, @apellido, @telefono, @mail, @direccion, @codigoPostal, @fechaNac)";

            this.Command = new SqlCommand(query, this.Connector);

            this.Command.Parameters.Add("@dni", SqlDbType.Int).Value = cliente.dni;
            this.Command.Parameters.Add("@nombre", SqlDbType.VarChar).Value = cliente.nombre;
            this.Command.Parameters.Add("@apellido", SqlDbType.VarChar).Value = cliente.apellido;
            this.Command.Parameters.Add("@telefono", SqlDbType.Int).Value = cliente.telefono;
            this.Command.Parameters.Add("@mail", SqlDbType.VarChar).Value = cliente.mail;
            this.Command.Parameters.Add("@direccion", SqlDbType.VarChar).Value = cliente.direccion;
            this.Command.Parameters.Add("@codigoPostal", SqlDbType.VarChar).Value = cliente.codigoPostal;
            this.Command.Parameters.Add("@fechaNac", SqlDbType.VarChar).Value = cliente.fechaNac;

            this.Connector.Open();
            this.Command.ExecuteNonQuery();
            this.Connector.Close();
        }

        public void setHabilitacionCliente(int clienteDni, bool hab)
        {
            var query = "UPDATE PIZZA.Cliente SET clie_habilitado = @hab WHERE clie_dni = @dni";
            this.Command = new SqlCommand(query, this.Connector);
            this.Command.Parameters.Add("@dni", SqlDbType.Int).Value = clienteDni;
            this.Command.Parameters.Add("@hab", SqlDbType.Int).Value = hab ? 1 : 0;

            this.Connector.Open();
            this.Command.ExecuteNonQuery();
            this.Connector.Close();
        }

        public List<Cliente> getClientes(int dni, string nombre, string apellido)
        {
            List<Cliente> listaClientes = new List<Cliente>();

            var query = "SELECT * FROM PIZZA.Cliente WHERE clie_dni like '%@dni%' AND clie_nombre like '%@nombre%' AND clie_apellido like '%@apellido%'";
            this.Command = new SqlCommand(query, this.Connector);
            this.Command.Parameters.Add("@dni", SqlDbType.Int).Value = dni;
            this.Command.Parameters.Add("@nombre", SqlDbType.VarChar).Value = nombre;
            this.Command.Parameters.Add("@apellido", SqlDbType.VarChar).Value = apellido;

            this.Connector.Open();
            SqlDataReader clientes = Command.ExecuteReader();

            while (clientes.Read())
            {
                listaClientes.Add(crearCliente(clientes));
            }

            this.Connector.Close();

            return listaClientes;
        }

        public Cliente crearCliente(SqlDataReader cliente)
        {
            Cliente clie = new Cliente();
            clie.dni = (int)cliente["clie_dni"];
            clie.nombre = cliente["clie_nombre"].ToString();
            clie.apellido = cliente["clie_apellido"].ToString();
            clie.direccion = cliente["clie_direccion"].ToString();
            clie.mail = cliente["clie_mail"].ToString();
            clie.codigoPostal = cliente["clie_codPostal"].ToString();
            clie.fechaNac = cliente["clie_fechaNac"].ToString();
            clie.telefono = (int)cliente["clie_telefono"];
            clie.habilitado = (int)cliente["dni"] == 1 ? true : false  ;

            return clie;
        }

        public void updateCliente(Cliente clie)
        {
            var sql = "UPDATE PIZZA.Cliente SET clie_nombre=@nombre, clie_apellido=@apellido, clie_direccion=@direccion, clie_telefono=@telefono, clie_codPostal=@codPostal, clie_fechaNac=@fechaNac WHERE clie_dni = @dni";

            this.Command = new SqlCommand(sql, this.Connector);
            this.Command.Parameters.Add("@dni", SqlDbType.Int).Value = clie.dni;
            this.Command.Parameters.Add("@nombre", SqlDbType.VarChar).Value = clie.nombre;
            this.Command.Parameters.Add("@apellido", SqlDbType.VarChar).Value = clie.apellido;
            this.Command.Parameters.Add("@direccion", SqlDbType.VarChar).Value = clie.direccion;
            this.Command.Parameters.Add("@fecNac", SqlDbType.VarChar).Value = clie.fechaNac;
            this.Command.Parameters.Add("@codPostal", SqlDbType.VarChar).Value = clie.codigoPostal;
            this.Command.Parameters.Add("@telefono", SqlDbType.Int).Value = clie.telefono;

            this.Connector.Open();
            this.Command.ExecuteNonQuery();
            this.Connector.Close();

        }
    }
}


