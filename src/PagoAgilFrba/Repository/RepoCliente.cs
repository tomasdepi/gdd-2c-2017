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

    }
}
