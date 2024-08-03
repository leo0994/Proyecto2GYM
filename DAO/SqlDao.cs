using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class SqlDAO
    {
        private string _connectionString;
        private static SqlDAO? _instance;
        private SqlDAO()
        {
            _connectionString = "Server=tcp:gym-proyecto2server.database.windows.net,1433;Initial Catalog=GYM-Proyecto-2;Persist Security Info=False;User ID=sysman;Password=Cenfotec123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        }

        public static SqlDAO GetInstance()
        {
            if (_instance == null)
            {
                _instance = new SqlDAO();
            }
            return _instance;
        }

        public void ExecuteProcedure(SqlOperation sqlOperation)
        {
            // Cual BD se va a usar
            using (var conn = new SqlConnection(_connectionString))
            {
                //Cual SP se va a usar
                using (var command = new SqlCommand(sqlOperation.ProcedureName, conn)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    //Recorremos la lista de parametros y los agregamos a la ejecucion
                    foreach (var param in sqlOperation.Parameters)
                    {
                        command.Parameters.Add(param);

                    }

                    //Ejecutamos "contra" la base datos
                    conn.Open();
                    command.ExecuteNonQuery();
                    //command.ExecuteReader
                }

            }
        }

        public List<Dictionary<string, object>> ExecuteQueryProcedure(SqlOperation sqlOperation)
        {
            var result = new List<Dictionary<string, object>>();
            using (var conn = new SqlConnection(_connectionString))
            {
                //Cual SP se va a usar
                using (var command = new SqlCommand(sqlOperation.ProcedureName, conn)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    foreach (var param in sqlOperation.Parameters) // Might throw exception since RetrieveAll receives no params
                    {
                        command.Parameters.Add(param);
                    }

                    //Ejecutamos "contra" la base datos
                    conn.Open();

                    var reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var row = new Dictionary<string, object>();
                            for (var i = 0; i < reader.FieldCount; i++)
                            {
                                row[reader.GetName(i)] = reader.GetValue(i);
                            }
                            result.Add(row);
                        }
                    }

                }
            }

            return result;
        }
    }
}
