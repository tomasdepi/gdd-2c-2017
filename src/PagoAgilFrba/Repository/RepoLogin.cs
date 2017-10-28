using PagoAgilFrba.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.Repository
{
    public class RepoLogin : Repo
    {

        public int validarUsuario(string username, string password)
        {
            var query = "SELECT usr_password, usr_intentosLogin FROM PIZZA.Usuario WHERE usr_usuario = @user";

            this.Command = new SqlCommand(query, this.Connector);

            this.Command.Parameters.Add("@user", SqlDbType.VarChar).Value = username;

            this.Connector.Open();
            SqlDataReader data = Command.ExecuteReader();

            bool hasRows = data.FieldCount > 0 ? true : false;
         
            data.Read();
            
            int intentos = Int32.Parse(data["usr_intentosLogin"].ToString());
            string hashedPassword = data["usr_password"].ToString();

            this.Connector.Close();

            if (intentos >= 3)
                return 0;

            string hashedInput = SHA256Encrypt(password);

            if (hashedInput == hashedPassword)
                return 1;

            if (hasRows)
                this.aniadirIntentoFallido(username);

            return 2;

        }

        private void aniadirIntentoFallido(string username)
        {
            var query = "UPDATE PIZZA.Usuario SET usr_intentosLogin = usr_intentosLogin + 1 WHERE usr_usuario = @user";

            this.Command = new SqlCommand(query, this.Connector);

            this.Command.Parameters.Add("@user", SqlDbType.VarChar).Value = username;

            this.Connector.Open();
            this.Command.ExecuteNonQuery();
            this.Connector.Close();
        }

        private string SHA256Encrypt(string input)
        {
            SHA256CryptoServiceProvider provider = new SHA256CryptoServiceProvider();

            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashedBytes = provider.ComputeHash(inputBytes);

            StringBuilder output = new StringBuilder();

            for (int i = 0; i < hashedBytes.Length; i++)
                output.Append(hashedBytes[i].ToString("x2").ToLower());

            return output.ToString();
        }

        public List<Sucursal> getSucursalesDeUsuario(string username)
        {
            List<Sucursal> sucursales = new List<Sucursal>();

            var query = "SELECT suc_nombre, suc_codPostal FROM PIZZA.User_por_sucursal ";
            query += "JOIN PIZZA.Sucursal on usrSuc_sucursal = suc_codPostal ";
            query += "WHERE usrSuc_usuario = @user and suc_habilitado = 1";

            this.Command = new SqlCommand(query, this.Connector);

            this.Command.Parameters.Add("@user", SqlDbType.VarChar).Value = username;

            this.Connector.Open();
            SqlDataReader sucursalesData = Command.ExecuteReader();

            while (sucursalesData.Read())
            {
                Sucursal suc = new Sucursal();
                suc.codigoPostal = Int32.Parse(sucursalesData["suc_codPostal"].ToString());
                suc.nombre = sucursalesData["suc_nombre"].ToString();
                sucursales.Add(suc);
            }

            this.Connector.Close();

            return sucursales;
        }


    }
}
