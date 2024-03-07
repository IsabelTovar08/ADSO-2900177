msgInput="Ingrese un número para saber si es positivo o negativo: "

# Capturar el número
n=float(input(msgInput))

# Comprobar si es positivo o negativo
if n>0:
    print("El número ",n,"es positivo")
else:
    print("El número ",n,"es negativo")