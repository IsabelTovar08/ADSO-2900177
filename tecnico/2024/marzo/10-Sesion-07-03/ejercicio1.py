x = True
while x == True:
    try:
        n=float(input("Ingrese un número: "))
        if n%2 ==0:
            print("El número es par")
        else:
            print("El número es impar")
        x= False
    except:
        print("Error. introduzca un dato válido")
