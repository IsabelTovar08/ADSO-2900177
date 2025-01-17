import psycopg2

class Database:
    def __init__(self, host, port, database, user, password):
        self.host = host
        self.port = port
        self.database = database
        self.user = user
        self.password = password
        self.conexion = None
        self.cursor = None

    def conectar(self):
        try:
            self.conexion = psycopg2.connect(
                host=self.host,
                port=self.port,
                database=self.database,
                user=self.user,
                password=self.password
            )
            self.cursor = self.conexion.cursor()
            print("Conexión exitosa a la base de datos")
        except Exception as e:
            print(f"Error al conectar a la base de datos: {e}")

    def consultar(self):
        try:
            if self.cursor:
                self.cursor.execute("SELECT * FROM persona;")
                return self.cursor.fetchall()
                # for persona in personas:
                #     print(persona)
            else:
                print("Cursor no inicializado. Conéctese primero.")
                return []
        except Exception as e:
            print(f"Error al obtener datos: {e}")
            return []
        
    def insertar(self, query, datos=None):
        try:
            if self.cursor:
                self.cursor.execute(query, datos)

                # return self.cursor.fetchall()
                self.conexion.commit()
            else:
                print("Cursor no inicializado. Conéctese primero.")
                return []
        except Exception as e:
            print(f"Error al obtener datos: {e}")
            return []
    # def insertar(self, query, datos=None):
    #     try:
    #         if self.cursor:
    #             self.cursor.execute(query, datos)
    #             self.conexion.commit()
    #             print("Consulta ejecutada con éxito.")
    #         else:
    #             print("Cursor no inicializado. Conéctese primero.")
    #     except Exception as e:
    #         print(f"Error al ejecutar la consulta: {e}")

    def cerrar_conexion(self):
        try:
            if self.cursor:
                self.cursor.close()
            if self.conexion:
                self.conexion.close()
            print("Conexión cerrada.")
        except Exception as e:
            print(f"Error al cerrar la conexión: {e}")


# Instancia preconfigurada de Database
db_manager = Database(
    host="localhost",
    port=5432,
    database="python",
    user="postgres",
    password="123456"
)

# Conectar y cargar los datos al importar el archivo
db_manager.conectar()
# db_manager.consultar()
# db_manager.insertar("INSERT INTO persona(nombre, apellido, telefono) VALUES ('eee', 'iiiii', '111');")

datos_cargados = db_manager.consultar()
