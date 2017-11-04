using PagoAgilFrba.Entities;
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
    public abstract class Repo
    {
        public SqlConnection Connector { get; set; }
        public SqlDataAdapter Adapter { get; set; }
        public DataSet Dataset { get; set; }
        public SqlCommand Command { get; set; }

        public Repo()
        {
            //ustedes usen el que dice cnLocalhost, no me borren la otra linea, solo comentenla
            var connectionString = ConfigurationManager.ConnectionStrings["cnLocalhost"].ConnectionString;
            //var connectionString = ConfigurationManager.ConnectionStrings["cnDepi"].ConnectionString;
            Connector = new SqlConnection(connectionString);
        }

        

    }
}
