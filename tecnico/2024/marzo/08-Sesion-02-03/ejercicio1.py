# Capturar la cantidad invertida por cada persona
invUno=float(input("Digite la cantidad invertida por la persona uno: "))
invDos=float(input("Digite la cantidad invertida por la persona dos: "))
invTres=float(input("Digite la cantidad invertida por la persona tres: "))

# Obtener el valor total de la inversión
invTotal=invUno+invDos+invTres

# Obtener el porcentaje invertido por cada persona
porcentajeUno=(invUno*100)/invTotal
porcentajeDos=(invDos*100)/invTotal
porcentajeTres=(invTres*100)/invTotal

# Salida de datos
print("El total de la inversión fue $"+str(invTotal))
print("La primera persona invirtió "+str(invUno)+" que equivale al "+str(porcentajeUno)+" %")
print("La segunda persona  invirtió "+str(invDos)+" que equivale al "+str(porcentajeDos)+" %")
print("La tercera persona invirtió "+str(invDos)+" que equivale al "+str(porcentajeTres)+" %")