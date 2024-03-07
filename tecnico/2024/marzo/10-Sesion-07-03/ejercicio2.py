x = True
while x == True:
    try:
        n=float(input("Ingrese un número: "))
        if n%2 ==0:
            if n>0:
                print("El número es par y positivo")
            else:
                print("El número es par y negativo")
            x= False
        else:
            if n>0:
                print("El número es impar y positivo")
            else:
                print("El número es impar y negativo")
            x= False
    except:
        print("Error. introduzca un dato válido")