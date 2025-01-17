from tkinter import *
from PIL import ImageTk, Image
import tkinter

ventana = Tk()
ventana.title("Imagenes")
ventana.geometry("400x400")

primera_img = tkinter.PhotoImage(file=r"c:\Users\Usuario\OneDrive\Imágenes\logo.png")
primera = tkinter.Label(ventana, image=primera_img)
primera.pack()

segunda_img = Image.open("python/img13.jpg")
segunda_img = segunda_img.resize((300, 300), Image.Resampling.LANCZOS)

segunda_img = ImageTk.PhotoImage(segunda_img)
segunda = tkinter.Label(ventana, image=segunda_img)
segunda.pack()

ventana.mainloop()