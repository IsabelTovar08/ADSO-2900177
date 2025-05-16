using System.Runtime.InteropServices.ObjectiveC;

namespace singleton_DataBase
{
    class BDConexion
    {
        private static BDConexion instance = null;
        private static readonly object padlock = new object();
        public bool IsConnected { get; private set; }

        private BDConexion()
        {
            IsConnected = false;
        }
        public static BDConexion Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new BDConexion();
                        Console.WriteLine("Nueva instancia creadad de la conexion a la base de datos.");
                    }
                    return instance;
                }
            }
        }
        public void OpenConnection()
        {
            if (!IsConnected)
            {
                IsConnected = true;
                Console.WriteLine("Conexion a la base de datos abierta.");
            }
            else
            {
                Console.WriteLine("La conexion ya está abierta.");

            }
        }
        public void CloseConnection()
        {
            if (IsConnected)
            {
                IsConnected = false;
                Console.WriteLine("La conexion a la base de datos cerrada.");
            }
            else
            {
                Console.WriteLine("La conexion ya está cerrada");
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            BDConexion conn = BDConexion.Instance;
            conn.OpenConnection();
            BDConexion conn2 = BDConexion.Instance;
            conn2.OpenConnection();

            conn.CloseConnection();
            conn2.CloseConnection();

            Console.WriteLine(object.ReferenceEquals(conn, conn2) ? "Ambas son la misma instancia." : "Son diferentes referencias.");
        }
    }
}
