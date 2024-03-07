while True:
    try:
        n1=float(input("Ingrese el primer número "))
        n2=float(input("Ingrese el segundo número "))
        n3=float(input("Ingrese el tercer número "))

        if n1==n2:
            print("Error, el primer número",n1,"es igual a el segundo número",n2)
        else:
            if n1==n3:
                print("Error el primer número",n1,"es igual a eñ tercer número",n3)
            else:
                if n2==n3:
                    print("Error el primer número",n1,"es igual a eñ tercer número",n3)
                else:
                    if n1>n2 and n1>n3:
                        if n2>n3:
                            print(n1,n2,n3)
                        else:
                            print(n1,n3,n2)
                    else:
                        if n2>n3 and n2>n1:
                            if n1>n3:
                                print(n2,n1,n3)
                            else:
                                print(n2,n3,n1)
                        else:
                            if n3>n1 and n3>n2:
                                if n1>n2:
                                    print(n3,n1,n2)
                                else:
                                    print(n3,n2,n1)
                            else:

                                break
    except:
        print("Error, ingrese un dato valido")
