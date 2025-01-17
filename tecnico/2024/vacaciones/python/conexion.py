# import psycopg2

# host = "localhost"
# port = 5432 
# database = "python" 
# user = "postgres" 
# password = "123456" 

# try:
#     conexion = psycopg2.connect(
#         host=host,
#         port=port,
#         database=database,
#         user=user,
#         password=password
#     )
#     print("Conexión exitosa a la base de datos")
#     cursor = conexion.cursor()

#     cursor.execute("SELECT * FROM persona;") 
#     # resultado = cursor.fetchone()
    
#     # # print(f"Versión de PostgreSQL: {resultado[0]}")
#     # while resultado:
#     #     print(resultado)
#     #     resultado = cursor.fetchone()
    
#     # consulta = "INSERT INTO persona VALUES (2,'Laura', 'Tovar', '0123456789');"
#     # cursor.execute(consulta)
    
#     # update = "UPDATE persona set apellido = 'Pastrana' WHERE nombre = 'Laura';"
#     # cursor.execute(update)
    
#     # delete = "DELETE FROM persona WHERE nombre = 'Laura'"
#     # cursor.execute(delete)
    
#     personas = cursor.fetchall()
#     for persona in personas:
#         print(persona)
        
#     # conexion.commit()
#     cursor.close()
#     conexion.close()
#     print("Conexión cerrada.")

# except Exception as e:
#     print(f"Ocurrió un error: {e}")


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
                personas = self.cursor.fetchall()
                for persona in personas:
                    print(persona)
            else:
                print("Cursor no inicializado. Conéctese primero.")
        except Exception as e:
            print(f"Error al obtener datos: {e}")

    def insertar(self, id, nombre, apellido, telefono):
        try:
            if self.cursor:
                query = "INSERT INTO persona VALUES (%s, %s, %s, %s);"
                self.cursor.execute(query, (id, nombre, apellido, telefono))
                self.conexion.commit()
                print("Inserción exitosa.")
            else:
                print("Cursor no inicializado. Conéctese primero.")
        except Exception as e:
            print(f"Error al insertar datos: {e}")

    def actualizar(self, nombre, nuevo_apellido):
        try:
            if self.cursor:
                query = "UPDATE persona SET apellido = %s WHERE nombre = %s;"
                self.cursor.execute(query, (nuevo_apellido, nombre))
                self.conexion.commit()
                print("Actualización exitosa.")
            else:
                print("Cursor no inicializado. Conéctese primero.")
        except Exception as e:
            print(f"Error al actualizar datos: {e}")

    def eliminar(self, nombre):
        try:
            if self.cursor:
                query = "DELETE FROM persona WHERE nombre = %s;"
                self.cursor.execute(query, (nombre,))
                self.conexion.commit()
                print("Eliminación exitosa.")
            else:
                print("Cursor no inicializado. Conéctese primero.")
        except Exception as e:
            print(f"Error al eliminar datos: {e}")

    def cerrar_conexion(self):
        try:
            if self.cursor:
                self.cursor.close()
            if self.conexion:
                self.conexion.close()
            print("Conexión cerrada.")
        except Exception as e:
            print(f"Error al cerrar la conexión: {e}")
  
# Uso de la clase Database
if __name__ == "__main__":
    db_manager = Database(
        host="localhost",
        port=5432,
        database="python",
        user="postgres",
        password="123456"
    )

    db_manager.conectar()
    db_manager.consultar()
    # db_manager.insertar(2, 'Laura', 'Tovar', '0123456789')
    # db_manager.actualizar('Laura', 'Pastrana')
    # db_manager.eliminar('Laura')
    db_manager.cerrar_conexion()


# USO EN OTRO ARCHIVO 
# from database import Database

# db = Database(host="localhost", port=5432, database="other_db", user="user", password="pass")
# db.conectar()
