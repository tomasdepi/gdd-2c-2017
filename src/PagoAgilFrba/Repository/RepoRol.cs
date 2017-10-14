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

            var query = "select func_id, func_nombre, (select 1 from PIZZA.Rol_por_funcionalidad rf join PIZZA.Rol r on r.rol_id=rf.rolFunc_rol where rf.rolFunc_func=f.func_id and r.rol_nombre=@rol) tieneFunc from PIZZA.Funcionalidad f";
            this.Command = new SqlCommand(query, this.Connector);
            this.Command.Parameters.Add("@rol", SqlDbType.VarChar).Value = rol;

            this.Connector.Open();
            SqlDataReader funcionalidades = Command.ExecuteReader();

            while (funcionalidades.Read())
            {
                Funcionalidad func = new Funcionalidad();
                func.id = (int)funcionalidades["func_id"];
                func.posee = (string)funcionalidades["tieneFunc"].ToString() == "1" ? true : false;
                func.nombre = (string)funcionalidades["func_nombre"];
                listaFuncionalidades.Add(func);
            }

            this.Connector.Close();

            return listaFuncionalidades;
        }

        public int guardarNuevoRol(string nombreRol, List<Funcionalidad> funcs)
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

            this.agregarFuncionalidades(idRol, funcs);

            return idRol;
        }

        public void actualizarHabilitado(bool habilitado, int rolId)
        {
            var query = "UPDATE PIZZA.Rol set rol_habilitado = @habilitado WHERE rol_id = @rol_id";
            this.Command = new SqlCommand(query, this.Connector);
            this.Command.Parameters.Add("@habilitado", SqlDbType.TinyInt).Value = habilitado;
            this.Command.Parameters.Add("@rol_id", SqlDbType.Int).Value = rolId;

            this.Connector.Open();
            Command.ExecuteNonQuery();
            this.Connector.Close();

        }

        public void eliminarFuncionalidades(int rolId)
        {
            var query = "DELETE FROM PIZZA.Rol_por_funcionalidad WHERE rolFunc_rol = @rol_id";
            this.Command = new SqlCommand(query, this.Connector);
            this.Command.Parameters.Add("@rol_id", SqlDbType.Int).Value = rolId;

            this.Connector.Open();
            Command.ExecuteNonQuery();
            this.Connector.Close();
        }

        public void agregarFuncionalidades(int rolId, List<Funcionalidad> lista)
        {
            string values = "";
            foreach (Funcionalidad f in lista)
            {
                values += "(" + rolId + "," + f.id + "),";
            }
            values = values.Remove(values.Count() - 1);

            this.Connector.Open();
            var query = "INSERT INTO PIZZA.Rol_por_funcionalidad (rolFunc_rol, rolFunc_func) VALUES " + values;
            this.Command = new SqlCommand(query, this.Connector);
            Command.ExecuteNonQuery();
            this.Connector.Close();

        }

    }
}
