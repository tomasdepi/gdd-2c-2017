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
    class RepoRol : Repo
    {

        public List<Rol> getRoles()
        {
            List<Rol> listaRoles = new List<Rol>();

            var query = "SELECT rol_id, rol_nombre, rol_habilitado FROM [PIZZA].[Rol]";
            this.Command = new SqlCommand(query, this.Connector);

            this.Connector.Open();
            SqlDataReader roles = Command.ExecuteReader();

            while (roles.Read())
            {
                Rol rol = new Rol();
                rol.id = (int)roles["rol_id"];
                rol.nombre = (string)roles["rol_nombre"];
                rol.habilitado = roles["rol_habilitado"].ToString() == "1" ? true : false;
                listaRoles.Add(rol);
            }

            this.Connector.Close();

            return listaRoles;
        }

        public List<Funcionalidad> getFuncionalidades()
        {
            List<Funcionalidad> listaFuncionalidades = new List<Funcionalidad>();

            var query = "SELECT func_id, func_nombre FROM [PIZZA].[Funcionalidad]";
            this.Command = new SqlCommand(query, this.Connector);

            this.Connector.Open();
            SqlDataReader funcionalidades = Command.ExecuteReader();

            while (funcionalidades.Read())
            {
                Funcionalidad func = new Funcionalidad();
                func.id = (int)funcionalidades["func_id"];
                func.nombre = (string)funcionalidades["func_nombre"];
                listaFuncionalidades.Add(func);
            }

            this.Connector.Close();

            return listaFuncionalidades;
        }

        public List<Funcionalidad> getFuncionalidadesDeRol(string rol)
        {
            List<Funcionalidad> listaFuncionalidades = new List<Funcionalidad>();

            var query = "select func_nombre, (select 1 from PIZZA.Rol_por_funcionalidad rf join PIZZA.Rol r on r.rol_id=rf.rolFunc_rol where rf.rolFunc_func=f.func_id and r.rol_nombre=@rol) tieneFunc from PIZZA.Funcionalidad f";
            this.Command = new SqlCommand(query, this.Connector);
            this.Command.Parameters.Add("@rol", SqlDbType.VarChar).Value = rol;

            this.Connector.Open();
            SqlDataReader funcionalidades = Command.ExecuteReader();

            while (funcionalidades.Read())
            {
                Funcionalidad func = new Funcionalidad();
                func.id = (int)funcionalidades["func_id"];
                func.nombre = (string)funcionalidades["func_nombre"];
                listaFuncionalidades.Add(func);
            }

            this.Connector.Close();

            return listaFuncionalidades;
        }

        public void guardarNuevoRol(string nombreRol, List<Funcionalidad> funcs)
        {
            var query = "INSERT INTO PIZZA.Rol (rol_nombre, rol_habilitado) values (@nombre, 1)";
            this.Command = new SqlCommand(query, this.Connector);
            this.Command.Parameters.Add("@nombre", SqlDbType.VarChar).Value = nombreRol;

            this.Connector.Open();
            Command.ExecuteNonQuery();

            query = "SELECT rol_id FROM PIZZA.Rol WHERE rol_nombre = @nombre";
            this.Command = new SqlCommand(query, this.Connector);
            this.Command.Parameters.Add("@nombre", SqlDbType.VarChar).Value = nombreRol;
            SqlDataReader funcionalidades = Command.ExecuteReader();
            funcionalidades.Read();
            int idRol = (int)funcionalidades["rol_id"];
            this.Connector.Close();

            string values = "";
            foreach(Funcionalidad f in funcs)
            {
                values += "(" + idRol + "," + f.id + "),";
            }
            values = values.Remove(values.Count() - 1);

            this.Connector.Open();
            query = "INSERT INTO PIZZA.Rol_por_funcionalidad VALUES "+values;
            this.Command = new SqlCommand(query, this.Connector);
            //Command.ExecuteNonQuery();
            this.Connector.Close();

        }

    }
}
