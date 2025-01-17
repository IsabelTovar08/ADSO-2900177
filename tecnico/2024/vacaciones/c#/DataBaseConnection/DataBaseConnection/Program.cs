using System.Data;

namespace DataBaseConnection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataBaseConnection db = DataBaseConnection.GetInstance();

            //string query1 = "INSERT INTO Productos VALUES ('otro', 5000.00, 10, 'Electrónica', 11.00);";
            //int ra = db.ExecuteNonQuery(query1);
            //Console.WriteLine("Filas afectadas " + ra);

            string query1 = "DELETE FROM Productos WHERE id = 5;";
            int ra = db.ExecuteNonQuery(query1);
            Console.WriteLine("Filas afectadas " + ra);

            string query = "SELECT * FROM productos";
            DataTable dt = db.ExecuteQuery(query);
            foreach (DataRow row in dt.Rows)
            {
                Console.WriteLine($"id: {row["id"]}, id: {row["nombre"]}");

            }
            
        }
    }
}
