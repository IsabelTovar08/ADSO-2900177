msgProm="Para calcular la nota promedio de "
msgExamen=" ingrese la nota obtenida en el examen: "
msgTarea="Ingrese la nota obtenida en la tarea "
msgError="Error, ingrese un número válido."
msgOk="Ok, dato válido"

examenM=float(input(msgProm+"Matemáticas"+msgExamen))
if examenM>0 and examenM<=5:
    print(msgOk)
    tareaUnoM=float(input(msgTarea+"1: "))
    if tareaUnoM>0 and tareaUnoM<=5:
        print(msgOk)
        tareaDosM=float(input(msgTarea+"2: "))
        if tareaDosM>0 and tareaUnoM<=5:
            print(msgOk)
            tareaTresM=float(input(msgTarea+"3: "))
            if tareaTresM>0 and tareaTresM<=5:
                examenF=float(input(msgProm+"Física"+msgExamen))
                if examenF>0 and examenF<=5:
                    print(msgOk)
                    tareaUnoF=float(input(msgTarea+"1: "))
                    if tareaUnoF>0 and tareaUnoF<=5:
                        print(msgOk)
                        tareaDosF=float(input(msgTarea+"2: "))
                        if tareaDosF>0 and tareaDosF<=5:
                            print(msgOk)
                            examenQ=float(input(msgProm+"química"+msgExamen))
                            if examenQ>0 and examenQ<=5:
                                print(msgOk)
                                tareaUnoQ=float(input(msgTarea+"1: "))
                                if tareaUnoQ>0 and tareaUnoQ<=5:
                                    print(msgOk)
                                    tareaDosQ=float(input(msgTarea+"2: "))
                                    if tareaDosQ>0 and tareaDosQ<=5:
                                        print(msgOk)
                                        tareaTresQ=float(input(msgTarea+"3: "))
                                        if tareaTresQ>0 and tareaTresQ<=5:
                                            print(msgOk)
                                            if tareaTresQ>0 and tareaTresQ<=5:
                                                print(msgOk)
                                                # Obtener los porcentajes
                                                promM=(examenM*0.9+((tareaUnoM+tareaDosM+tareaTresM)/3)*0.1)
                                                promF=(examenF*0.8+((tareaUnoF+tareaDosF)/2)*0.2)
                                                promQ=(examenQ*0.85+((tareaUnoQ+tareaDosQ+tareaTresQ)/3)*0.15)
                                                promG=(promM+promF+promQ)/3

                                                # Salida de datos
                                                print("El promedio general obtenido es: "+str(promG))
                                                print("La nota promedio de Matemáticas es: "+str(promM))
                                                print("La nota promedio de Física es: "+str(promF))
                                                print("La nota promedio de Química es: "+str(promQ))
                                            else:
                                                print(msgError)
                                        else:
                                            print(msgError)
                                    else:
                                        print(msgError)
                                else:
                                    print(msgError)
                            else:
                                print(msgError)
                        else:
                            print(msgError)
                    else:
                        print(msgError)
                else:
                    print(msgError)
            else:
                print(msgError)
        else:
            print(msgError)
    else:
        print(msgError)
else:
    print(msgError)