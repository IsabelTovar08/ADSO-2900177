while True:
    try:
        n1=float(input("Ingrese el primer número: "))
        n2=float(input("Ingrese el segundo número: "))
        if n2<0 and n1%2 !=0:
            if n1>n2:
                print(n1,n2)
            else:
                print(n2,n1)
        else:
            print(n2,n1)   
        break
    except:
        print("Error, ingrese un dato válido")
