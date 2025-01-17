import tkinter.messagebox
ventana = tkinter.Tk()
ventana.title("Ejercicio Python Alertass")
ventana.geometry("800x500")

titulo = tkinter.Label(ventana, text="Alertaas").pack()

tkinter.messagebox.showinfo("Probando", "Mensaje")

respuesta = tkinter.messagebox.askquestion("Títulooo", "¿Sabes Python?")
if(respuesta == 'yes'):
    tkinter.messagebox.showinfo("", "WOW")
else:
    tkinter.messagebox.showinfo("", "OHH NOO")

ventana.mainloop()