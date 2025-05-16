msgError = "Error, inversión no válida."
msgOk = "Inversión correcta."
msgInput = "Por Favor, ingrese la inversión de la persona "
msgFin1= " tiene una inversión total de $" 
msgFin2 = " y su porcentaje fue de "
# Cuando se ingresa un dato de tipo String, para un datos que recibe un flaot, se debe usar el try-except

inv1 = float(input(msgInput + "1: "))
if inv1 > 0:
    print(msgOk)
    inv2 = float(input(msgInput + "2: "))
    if inv2 > 0:        
        print(msgOk)
        inv3 = float(input(msgInput + "3: "))
        if inv3 > 0:
            print(msgOk)
            invTotal = inv1 + inv2 + inv3

            pInv1 = (inv1*100)/invTotal
            pInv2 = (inv2*100)/invTotal
            pInv3 = (inv3*100)/invTotal

            #Salida 
            print("La persona 1"+msgFin1+str(inv1)+msgFin2+str(pInv1)+"%.")
            print("La persona 2"+msgFin1+str(inv2)+msgFin2+str(pInv2)+"%.")
            print("La persona 3"+msgFin1+str(inv3)+msgFin2+str(pInv3)+"%.")
        else: 
            print(msgError)
    else: 
        print(msgError)

else: 
    print(msgError)