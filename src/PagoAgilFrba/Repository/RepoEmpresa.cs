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
    class RepoEmpresa : Repo
    {
        public void altaEmpresa(Empresa empresa)
        {
            var query = "INSERT INTO PIZZA.Empresa (emp_cuit, emp_nombre, emp_direccion, emp_rubro, emp_fechaRendicion, emp_habilitado) ";
            query += "VALUES (@cuit, @nombre, @direccion, @rubro, @fechaRendicion, 1)";

            this.Command = new SqlCommand(query, this.Connector);
            
            this.Command.Parameters.Add("@cuit", SqlDbType.VarChar).Value = empresa.cuit;
            this.Command.Parameters.Add("@nombre", SqlDbType.VarChar).Value = empresa.nombre;
            this.Command.Parameters.Add("@direccion", SqlDbType.VarChar).Value = empresa.direccion;
            this.Command.Parameters.Add("@rubro", SqlDbType.VarChar).Value = empresa.rubro;
            this.Command.Parameters.Add("@fechaRendicion", SqlDbType.Date).Value = empresa.fechaRendicion;

            this.Connector.Open();
            this.Command.ExecuteNonQuery();
            this.Connector.Close();
        }

        public void setHabilitacionEmpresa(int empresaId, bool hab)
        {
            var query = "UPDATE PIZZA.Empresa SET emp_habilitado = @hab WHERE emp_id=@id";
            this.Command = new SqlCommand(query, this.Connector);
            this.Command.Parameters.Add("@id", SqlDbType.Int).Value = empresaId;
            this.Command.Parameters.Add("@hab", SqlDbType.Int).Value = hab ? 1 : 0;

            this.Connector.Open();
            this.Command.ExecuteNonQuery();
            this.Connector.Close();

        }

        public List<Empresa> getEmpresas(string cuit, string nombre)
        {
            List<Empresa> listaEmpresas = new List<Empresa>();

            var query = "SELECT * FROM PIZZA.Empresa WHERE emp_cuit LIKE '%" + cuit + "%' AND emp_nombre LIKE '%" + nombre + "%'";
            this.Command = new SqlCommand(query, this.Connector);

            this.Connector.Open();
            SqlDataReader empresas = Command.ExecuteReader();

            while (empresas.Read())
            {
                listaEmpresas.Add(crearEmpresa(empresas));
            }

            this.Connector.Close();

            return listaEmpresas;
        }

        public Empresa getEmpresa(int id)
        {
            Empresa empr = new Empresa();

            var query = "SELECT * FROM PIZZA.Empresa WHERE emp_id = @id";

            this.Command = new SqlCommand(query, this.Connector);
            this.Command.Parameters.Add("@id", SqlDbType.Int).Value = id;

            this.Connector.Open();
            SqlDataReader empresaDb = Command.ExecuteReader();

            empresaDb.Read();

            empr = crearEmpresa(empresaDb);

            this.Connector.Close();

            return empr;
        }

        public Empresa crearEmpresa(SqlDataReader empresa)
        {
            Empresa empr = new Empresa();
            empr.id = (int)empresa["emp_id"];
            empr.cuit = empresa["emp_cuit"].ToString();
            empr.nombre = empresa["emp_nombre"].ToString();
            empr.direccion = empresa["emp_direccion"].ToString();
            empr.rubro = empresa["emp_rubro"].ToString();
           // empr.fechaRendicion = Convert.ToDateTime(empresa["emp_fechaRendicion"].ToString());
            empr.habilitado = empresa["emp_habilitado"].ToString() == "1" ? true : false;

            return empr;
        }

        public void updateEmpresa(Empresa empr)
        {
            var sql = "UPDATE PIZZA.Empresa SET emp_cuit=@cuit, emp_nombre=@nombre, emp_direccion=@direccion, emp_rubro=@rubro, emp_fechaRendicion=@fechaRendicion WHERE emp_id=@id";

            this.Command = new SqlCommand(sql, this.Connector);
            this.Command.Parameters.Add("@id", SqlDbType.Int).Value = empr.id;
            this.Command.Parameters.Add("@cuit", SqlDbType.VarChar).Value = empr.cuit;
            this.Command.Parameters.Add("@nombre", SqlDbType.VarChar).Value = empr.nombre;
            this.Command.Parameters.Add("@direccion", SqlDbType.VarChar).Value = empr.direccion;
            this.Command.Parameters.Add("@rubro", SqlDbType.VarChar).Value = empr.rubro;
            this.Command.Parameters.Add("@fechaRendicion", SqlDbType.Date).Value = empr.fechaRendicion;

            this.Connector.Open();
            this.Command.ExecuteNonQuery();
            this.Connector.Close();
        }
    }
}
