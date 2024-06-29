using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class SqlDao
    {
        private static SqlDao instance = new SqlDao();
        private string _connString = "Server=localhost;Database=ISA_IEEE_DEMO;Trusted_Connection=True";
        //Server=tcp:isa-iee-server.database.windows.net,1433;Initial Catalog=isa-ieee;Persist Security Info=False;User ID=sys_ieee_admin;Password=Cenfo123*;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;

        public static SqlDao GetInstance() {
            if (instance == null)
                instance = new SqlDao();
            return instance;
        }

        //Metodo que conecta a la Base de Datos, ejecuta un stored procedure
        //que no devuelve ningun dato a la applicacion
        public void ExecuteStoredProcedure(SqlOperation operation) {
            //hacer la conexion
            string connectionString = _connString;
            SqlConnection conn = new SqlConnection(connectionString);

            //Armar el query
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = operation.ProcedureName;
            command.CommandType = CommandType.StoredProcedure;

            //Agregar los parametros
            foreach (var p in operation.parameters)
            {
                command.Parameters.Add(p);
            }
            //abrir conexion
            conn.Open();
            //Ejecutar el comando
            command.ExecuteNonQuery();
        }

        public List<Dictionary<string, object>> ExecuteStoredProcedureWithQuery(SqlOperation operation)
        {
            var conn = _connString;
            List<Dictionary<string,object>> lstResults = new List<Dictionary<string,object>>();

            var connection = new SqlConnection(conn);
            var command = new SqlCommand();
            
            //preparar el comando a ejecutar
            command.Connection = connection;
            command.CommandText = operation.ProcedureName;
            command.CommandType = CommandType.StoredProcedure;

            //Agregar los parametros
            foreach (var p in operation.parameters)
            {
                command.Parameters.Add(p);
            }

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            //Recorrer el resultado para poder armar la Lista de diccionarios
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Dictionary<string, object> diccObj = new Dictionary<string, object>();

                    for (var fieldCount = 0; fieldCount < reader.FieldCount; fieldCount++)
                    {
                        diccObj.Add(reader.GetName(fieldCount), reader.GetValue(fieldCount));
                    }
                  
                  lstResults.Add(diccObj);
                }
            }
            return lstResults;
        }
    }
}
