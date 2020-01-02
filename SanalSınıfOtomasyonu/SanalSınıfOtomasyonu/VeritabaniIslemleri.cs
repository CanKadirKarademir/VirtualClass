using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanalSınıfOtomasyonu
{
    public static class VeritabaniIslemleri
    {
        private static readonly string _connectionString = @"Data Source=; Initial Catalog=SanalSinifDB; Integrated Security=true;";

        public static Int32 ExecuteNonQuery(String commandText,
            SqlParameter[] parameters = null, CommandType commandType = CommandType.Text)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(commandText, conn))
                {
                    cmd.CommandType = commandType;
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public static Object ExecuteScalar(String commandText,
            SqlParameter[] parameters = null, CommandType commandType = CommandType.Text)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(commandText, conn))
                {
                    cmd.CommandType = commandType;
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    conn.Open();
                    return cmd.ExecuteScalar();
                }
            }
        }

        public static SqlDataReader ExecuteReader(String commandText,
            SqlParameter[] parameters = null, CommandType commandType = CommandType.Text)
        {
            SqlConnection conn = new SqlConnection(_connectionString);

            using (SqlCommand cmd = new SqlCommand(commandText, conn))
            {
                cmd.CommandType = commandType;
                if (parameters != null)
                    cmd.Parameters.AddRange(parameters);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                return reader;
            }
        }

        public static DataTable ExecuteDataTable(String commandText,
            SqlParameter[] parameters = null, CommandType commandType = CommandType.Text)
        {
            SqlDataReader reader = ExecuteReader(commandText, parameters, commandType);
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            return dataTable;
        }
    }
}