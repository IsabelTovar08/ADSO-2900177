import tkinter
from tkinter import *
import tkinter.messagebox
from PIL import ImageTk, Image
import conexion
# import tkinter.messagebox


ventana = Tk()
ventana.title("Lista")
ventana.geometry("300x200")

lista = tkinter.Listbox(ventana)
lista.insert(1, "Hola")

# persona = conexion.Database.conectar()

from conexion2 import db_manager, datos_cargados

# Usar la instancia directamente
print("Datos cargados:", datos_cargados)
datos_persona = datos_cargados

# index = 0
# for persona in datos_persona:
#     lista.insert(index, persona[1])
#     index = index +1
    
for index, persona in enumerate(datos_persona):
    lista.insert(index, persona[1])
    
def seleccionado():
    for item in lista.curselection():
        print(lista.get(item))
        etiqtera = tkinter.Label(text=lista.get(item)).pack()
        
boton_seleccion = tkinter.Button(ventana, text="ver", command=seleccionado)
boton_seleccion.pack()

texto = tkinter.Label(ventana, text="Buscador").pack()
input = Entry(ventana, fg= 'red')
input.pack()

def buscar():
    flag = 0
    
    for persona in datos_persona:
        if persona[1] == input.get():
            flag = flag +1
            la = Label(ventana, text=persona).pack()
            # lista.insert(flag, persona[1])
    if flag == 0:
        tkinter.messagebox.showinfo("", "No hay datos para "+input.get())
    
otrobtn = Button(ventana, text="buscar", command=buscar).pack()

t_nombre = tkinter.Label(ventana, text="Nombre").pack()
nombre = Entry(ventana)
nombre.pack()

t_apellido = tkinter.Label(ventana, text="Apellido").pack()
apellido = Entry(ventana)
apellido.pack()

t_telefono = tkinter.Label(ventana, text="Telefono").pack()
telefono = Entry(ventana)
telefono.pack()

# Función para enviar datos
def enviar_datos():
    query = "INSERT INTO persona (nombre, apellido, telefono) VALUES (%s, %s, %s);"
    datos = (nombre.get(), apellido.get(), telefono.get())
    try:
        db_manager.insertar(query, datos)
        print("Datos enviados con éxito.")
    except Exception as e:
        print(f"Error al enviar los datos: {e}")
    

btn_enviar = tkinter.Button(ventana, text="enviar", command=enviar_datos).pack()

# db_manager.insertar("INSERT INTO persona(nombre, apellido, telefono) VALUES ('eee', 'iiiii', '111');")
# Realizar más consultas si es necesario
nuevos_datos = db_manager.consultar()
print("Más datos:", nuevos_datos)


lista.pack()
ventana.mainloop()