msgInput="Ingrese un número para saber si está en un rango entre 50 y 100: "
msgFinal="está entre 50 y 100"

# Capturar el número
n=float(input(msgInput))

# Comprobar si está o no en el rango
if n>=50 and n<=100:
    print("El número",n,"si "+msgFinal)
else:
    print("El número",n,"no "+msgFinal)