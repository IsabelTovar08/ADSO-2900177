import tkinter
from tkinter import *
from PIL import ImageTk, Image

ventana = tkinter.Tk()
ventana.title("Ejercicio Python")
ventana.geometry("800x500")
# ventana.resizable(0,0)

titulo = tkinter.Label(ventana, text = "¡Hola Python!").pack()

def saludo():
    tkinter.Label(ventana, text= "HOLAAAAA").pack()
    
def salir():
    ventana.destroy()
    
boton = tkinter.Button(ventana, text="Mostrar Saludo", command=saludo, fg="blue")
boton.pack()
# boton.place(x=200, y=100)
# boton.place(width=180, height=120)

botonSalir = tkinter.Button(ventana, text="Salir", command=salir, fg="red")
botonSalir.pack()

ventana.mainloop()
