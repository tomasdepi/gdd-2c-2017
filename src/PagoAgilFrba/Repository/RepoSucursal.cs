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
    public class RepoSucursal : Repo
    {
        public void AltaSucursal(Sucursal sucursal)
        {
            var query = "INSERT INTO PIZZA.Sucursal (suc_codPostal, suc_nombre, suc_direccion, suc_habilitado) ";
            query += "VALUES (@codigoPostal, @nombre, @direccion, 1)";

            this.Command = new SqlCommand(query, this.Connector);

            this.Command.Parameters.Add("@codigoPostal", SqlDbType.Int).Value = sucursal.codigoPostal;
            this.Command.Parameters.Add("@nombre", SqlDbType.VarChar).Value = sucursal.nombre;
            this.Command.Parameters.Add("@direccion", SqlDbType.VarChar).Value = sucursal.direccion;

            this.Connector.Open();
            this.Command.ExecuteNonQuery();
            this.Connector.Close();
        }

        public void updateSucursal(Sucursal sucursal)
        {
            var query = "UPDATE PIZZA.Sucursal SET suc_nombre = @nombre, suc_direccion = @direccion WHERE suc_codPostal = @codigoPostal";

            this.Command = new SqlCommand(query, this.Connector);

            this.Command.Parameters.Add("@codigoPostal", SqlDbType.Int).Value = sucursal.codigoPostal;
            this.Command.Parameters.Add("@nombre", SqlDbType.VarChar).Value = sucursal.nombre;
            this.Command.Parameters.Add("@direccion", SqlDbType.VarChar).Value = sucursal.direccion;

            this.Connector.Open();
            this.Command.ExecuteNonQuery();
            this.Connector.Close();
        }

        public void setHabilitacion(int codPostal, bool habilitacion)
        {
            var query = "UPDATE PIZZA.Sucursal SET suc_habilitado = @habilitacion WHERE suc_codPostal = @codPostal";

            this.Command = new SqlCommand(query, this.Connector);

            this.Command.Parameters.Add("@codPostal", SqlDbType.Int).Value = codPostal;
            this.Command.Parameters.Add("@habilitacion", SqlDbType.Int).Value = habilitacion ? 1 : 0;

            this.Connector.Open();
            this.Command.ExecuteNonQuery();
            this.Connector.Close();
        }

        public List<Sucursal> getSucursales(string codPostal, string nombre)
        {
            List<Sucursal> sucursales = new List<Sucursal>();

            var query = "SELECT suc_codPostal, suc_nombre, suc_direccion, suc_habilitado FROM PIZZA.Sucursal WHERE suc_codPostal LIKE @codPostal AND suc_nombre LIKE @nombre";

            this.Command = new SqlCommand(query, this.Connector);

            this.Command.Parameters.Add("@codPostal", SqlDbType.VarChar).Value = "%" + codPostal +"%";
            this.Command.Parameters.Add("@nombre", SqlDbType.VarChar).Value = "%" + nombre + "%";

            this.Connector.Open();
            SqlDataReader sucursalesData = Command.ExecuteReader();

            while (sucursalesData.Read())
            {
                sucursales.Add(crearSucursal(sucursalesData));
            }

            this.Connector.Close();

            return sucursales;
        }

        private Sucursal crearSucursal(SqlDataReader data)
        {
            Sucursal suc = new Sucursal();

            suc.codigoPostal = Int32.Parse(data["suc_codPostal"].ToString());
            suc.nombre = data["suc_nombre"].ToString();
            suc.direccion = data["suc_direccion"].ToString();
            suc.habilitado = data["suc_habilitado"].ToString() == "1" ? true : false;

            return suc;
        }

        public bool validarExistencia(int codPostal)
        {
            var query = "SELECT 1 FROM PIZZA.Sucursal WHERE suc_codPostal = @codPostal";

            this.Command = new SqlCommand(query, this.Connector);

            this.Command.Parameters.Add("@codPostal", SqlDbType.Int).Value = codPostal;

            this.Connector.Open();

            SqlDataReader sucursalesData = Command.ExecuteReader();
            bool existe = sucursalesData.HasRows;

            this.Connector.Close();

            return existe;
        }

        public Sucursal getSucursal(int codPostal)
        {
            var query = "SELECT suc_codPostal, suc_nombre, suc_direccion, suc_habilitado FROM PIZZA.Sucursal WHERE suc_codPostal = @codPostal";

            this.Command = new SqlCommand(query, this.Connector);

            this.Command.Parameters.Add("@codPostal", SqlDbType.Int).Value = codPostal;

            this.Connector.Open();
            SqlDataReader sucursalData = Command.ExecuteReader();

            sucursalData.Read();

            Sucursal sucursal = crearSucursal(sucursalData);
            this.Connector.Close();

            return sucursal;

        }
    }
}
