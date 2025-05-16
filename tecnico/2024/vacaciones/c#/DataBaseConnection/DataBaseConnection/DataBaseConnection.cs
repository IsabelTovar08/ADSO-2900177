using System;
using System.Data;
using System.Data.OleDb;

namespace DataBaseConnection
{
    internal class DataBaseConnection
    {
        private static DataBaseConnection instance = null;
        private OleDbConnection connection;
        private string connectionString = "Provider=SQLOLEDB;Data Source=DESKTOP-2EU3UD6;Initial Catalog=ventas;Integrated Security=SSPI;";

        private DataBaseConnection()
        {
            connection = new OleDbConnection(connectionString);
        }

        public static DataBaseConnection GetInstance()
        {
            if (instance == null)
            {
                instance = new DataBaseConnection();
            }
            return instance;
        }
        public void OpenConnection()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
                Console.WriteLine("Conexión abierta");
            }
        }
        public void CloseConnection()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
                Console.WriteLine("Conexión cerrada");
            }
        }
        public DataTable ExecuteQuery(string query)
        {
            DataTable dt = new DataTable();
            try
            {
                OpenConnection();
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    using (OleDbDataAdapter da = new OleDbDataAdapter(command))
                    {
                        da.Fill(dt);
                    }
; }
            }
            catch (Exception ex) {
             
                Console.WriteLine("Error " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
            return dt;
        }

        public int ExecuteNonQuery(string query)
        {
            int rowsAffected = 0;

            try
            {
                OpenConnection();

                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    rowsAffected = command.ExecuteNonQuery();
                }

            }
            catch (Exception ex) 
            {
                Console.WriteLine("Error ejecutando la consulta "+ex.Message);
            }
            finally
            {
                CloseConnection() ;
            }
            return rowsAffected;
        }
    }
}
