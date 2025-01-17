# 1. HOLA MUNDO 
# print("Hola Mundo");

# 2. SUMA DOS NÚMEROS 
# n1 = int(input("Escribe el número uno: "))
# n2 = int(input("Escribe el número dos: "))

# def calcularSuma(n1,n2):
#     resultado = n1 + n2
#     return print("La suma de los dos números es: "+ str(resultado))
# calcularSuma(n1,n2)

# 3. OPERACIONES
# n1 = int(input("Escribe el número uno: "))
# n2 = int(input("Escribe el número dos: "))

# def calcularSuma(n1,n2):
#     resultado = n1 + n2
#     return print("La suma de los dos números es: "+ str(resultado))

# def calcularResta(n1,n2):
#     resultado = n1 - n2
#     return print("La resta de los dos números es: "+ str(resultado))

# def calcularMultiplicacion(n1,n2):
#     resultado = n1 * n2
#     return print("La multiplicación de los dos números es: "+ str(resultado))

# def calcularDivision(n1, n2):
#     try:
#         resultado = n1 / n2
#         print("La división de los dos números es:", resultado)
#     except ZeroDivisionError:
#         print("Error en división. No se puede dividir por 0.")

# calcularSuma(n1,n2)
# calcularResta(n1,n2)
# calcularMultiplicacion(n1,n2)
# calcularDivision(n1,n2)

# 4. PORCENTAJE 
# n = int(input("Escribe un número entero para calcular su porcentaje: "))

# def calcularPorcentaje(n):
#     porcentaje = n /100
#     print("El porcentaje de "+str(n)+" es "+str(porcentaje))

# calcularPorcentaje(n)

# 5. PROMEDIO DE TRES NOTAS 
# n1 = float(input("Escribe la primera nota: "))
# n2 = float(input("Escribe la segunda nota: "))
# n3 = float(input("Escribe la tercera nota: "))

# def calcularPromedio(n1,n2,n3):
#     promedio = (n1 + n2 + n3) / 3
#     return print("El promedio de las tres notas es: "+ str(promedio))

# calcularPromedio(n1,n2,n3)

# 6. PROMEDIO DE TRES NOTAS CON DISTINTO PORCENTAJE
# n1 = float(input("Escribe la primera nota, la cual equivale al 30%: "))
# n2 = float(input("Escribe la segunda nota, la cual equivale al 30%: "))
# n3 = float(input("Escribe la tercera nota, la cual equivale al 40%: "))

# def calculatTresNotas(n1,n2,n3):
#     nota1 = n1 * 0.3
#     nota2 = n2 * 0.3
#     nota3 = n3 * 0.4
#     promedio = (nota1 + nota2 + nota3) 
#     return print("El promedio de las tres notas es: "+ str(promedio))

# calculatTresNotas(n1,n2,n3) 

# 7. ÁREA DE LAS FIGURAS GEOMÉTRICAS
# def opcionFigura():
#     while True:
#         try: 
#             opcion = int(input("Selecciona la figura a la que le quieres calcular su area: \n 1. Cuadrado. \n 2. Rectángulo. \n 3. Triángulo \n Selecciona una opción: "))
#             match opcion:
#                 case 1:
#                     ladoC = float(input("Escribe la medida del lado del cuadrado: "))
#                     calcularCuadrado(ladoC)
#                     break
#                 case 2:
#                     baseR = float(input("Escribe la medida de la base del rectángulo: "))
#                     altoR = float(input("Escribe la medida de la altura del rectángulo: "))
#                     calcularRectangulo(baseR, altoR)
#                     break
#                 case 3:
#                     baseT = float(input("Escribe la medida de la base del triángulo: "))
#                     altoT = float(input("Escribe la medida de la altura del triángulo: "))
#                     calcularTriangulo(baseT, altoT)
#                     break
#                 case _:
#                     print("Opción no válida.")
#         except ValueError:
#             print("Debes ingresar un valor numérico.")

# def calcularCuadrado(lado):
#     area = lado ** 2
#     return print("El área del cuadrado es: "+ str(area))
# def calcularRectangulo(base,alto):
#     area = base * alto
#     return print("El área del rectángulo es: "+ str(area))
# def calcularTriangulo(base,alto):
#     area = (base * alto) / 2
#     return print("El área del triángulo es: "+ str(area))

# opcionFigura() 

# 8. NÓMINA
# def ingresarValores():
#     while True:
#         try:
#             dias = int(input("Para calcular su nómina, ingrese los días trabajados: "))
#             try:
#                 valor = float(input("Ingrese el valor del día: "))
#                 calcularSalario(dias, valor)
#                 break
#             except ValueError:
#                 print("Debes ingresar un valor numérico para el valor del día. Intenta de nuevo.")
#         except ValueError:
#             print("Debes ingresar un número entero para los días trabajados. Intenta de nuevo.")
#         except Exception as e:
#             print("Error inesperado: ", e)
#             break

# def calcularSalario(dias, valor):
#     salario = dias * valor
#     print(f"Su salario es: {salario}")
    
#     salud = calcularSalud(salario)
#     pension = calcularPension(salario)
#     arl = calcularArl(salario)
    
#     total = salario - (salud + pension + arl)
#     print(f"Su salario total después de deducciones es: {total}")

# def calcularSalud(salario):
#     salud = salario * 0.12
#     print(f"Su aporte a salud es: {salud}")
#     return salud

# def calcularPension(salario):
#     pension = salario * 0.16
#     print(f"Su aporte a pensión es: {pension}")
#     return pension

# def calcularArl(salario):
#     arl = salario * 0.052
#     print(f"Su aporte a ARL es: {arl}")
#     return arl

# ingresarValores()

# 9. MAYOR DE DOS NÚMEROS
# n1 = int(input("Para compara dos números, ingresa el número uno: "))
# n2 = int(input("Iingresa el número dos: "))
# if n1 > n2:
#     print(f"El número uno: {n1}, es mayor que {n2}")
# else:
#     print(f"El número dos: {n2}, es mayor que {n1}")

# 10. MAYOR O IGUAL DE DOS NÚMEROS
# n1 = int(input("Para compara dos números, ingresa el número uno: "))
# n2 = int(input("Iingresa el número dos: "))
# if(n1==n2):
#     print(f"El número uno: {n1}, es igual que el número dos: {n2}")
# elif(n1>n2):
#     print(f"El número uno: {n1}, es mayor que {n2}")
# else:
#     print(f"El número dos: {n2}, es mayor que {n1}")

# 11. CALCULAR EDAD
# from datetime import datetime

# def calcularEdad():
#     while True:
#         try:
#             fecha_nacimiento = input("Ingrese su fecha de nacimiento en formato (dd/mm/aaaa): ")
#             calcular(fecha_nacimiento)
#             break
#         except ValueError:
#             print("Error: Por favor, ingresa la fecha en el formato correcto (dd/mm/aaaa).")
#         except Exception as e:
#             print(f"Error inesperado: {e}")

# def calcular(nacimiento):
#     fecha_nacimiento = datetime.strptime(nacimiento, "%d/%m/%Y")
#     fecha_actual = datetime.now()
#     edad = fecha_actual.year - fecha_nacimiento.year
#     if (fecha_actual.month, fecha_actual.day) < (fecha_nacimiento.month, fecha_nacimiento.day):
#         edad -= 1
#     print(f"Tu edad es: {edad} años.")

# calcularEdad()

# 12. MAYOR DE TRES NÚMEROS
# n1 = int(input("Para compara tres números, ingresa el número uno: "))
# n2 = int(input("Iingresa el número dos: "))
# n3 = int(input("Iingresa el número tres: "))
# if n1 > n2 and n1 > n3:
#     print(f"El número uno: {n1}, es mayor que {n2} y {n3}")
# elif n2 > n1 and n2 > n3:
#     print(f"El número dos: {n2}, es mayor que {n1} y {n3}")
# elif(n3>n2 and n3>n1):
#     print(f"El número tres: {n3}, es mayor que {n1} y {n2}")
# else:
#     print("Los números son iguales")

# 13. ÁREA DE TRES CUADRADOS
# l1 = int(input("Para calcular el área de tres cuadrados, ingresa la longitud del lado del primer cuadrado: "))
# l2 = int(input("Ingresa la longitud del lado del segundo cuadrado: "))
# l3 = int(input("Ingresa la longitud del lado del tercer cuadrado: "))

# def calcularArea(lado):
#     return lado * lado

# area1 = calcularArea(l1)
# area2 = calcularArea(l2)
# area3 = calcularArea(l3)

# print(f"El área del primer cuadrado es: {area1} \nEl área del segundo cuadrado es: {area2} \nEl área del tercer cuadrado es: {area3}")

# 14. COMPARAR TRES EDADES
# from datetime import datetime
# def tresEdades():
#     while True:
#         try:
#             nac1 = input("Para comparar las tres edades, ingrese la fecha de nacimiento de la primera persona en formato dd/mm/aaaa: ")
#             nac2 = input("Ingrese la fecha de nacimiento de la segunda persona en formato dd/mm/aaaa: ")
#             nac3 = input("Ingrese la fecha de nacimiento de la tercera persona en formato dd/mm/aaaa: ")
#             edad1 = calcularEdades(nac1)
#             edad2 = calcularEdades(nac2)
#             edad3 = calcularEdades(nac3)
#             print(f"La edad de la persona 1 es: {edad1}")
#             es_mayor(edad1)
#             print(f"La edad de la persona 2 es: {edad2}")
#             es_mayor(edad2)
#             print(f"La edad de la persona 3 es: {edad3}")
#             es_mayor(edad3)
#             calcularProm(edad1,edad2,edad3)
#             break
#         except ValueError:      
#             print("Error, revisa las fechas ingresadas. Por favor ingrese la fecha en formato dd/mm/aaaa.")
#         except Exception as e:
#             print(f"Error: {e}")   
            
# def calcularEdades(nacimiento):
#     fecha_nacimiento = datetime.strptime(nacimiento, "%d/%m/%Y")
#     fecha_actual = datetime.now()
#     edad = fecha_actual.year - fecha_nacimiento.year
#     if((fecha_actual.month, fecha_actual.day) < (fecha_nacimiento.month, fecha_nacimiento.day)):
#         edad -= 1
#     return edad

# def es_mayor(edad):
#     if(edad >= 18):
#         print(f"Es mayor de edad: {edad} años")
#     else:
#         print(f"Es menor de edad: {edad} años")

# def calcularProm(edad1,edad2,edad3):
#     prom = (edad1 + edad2 + edad3)/3 
#     print(f"La edad promedio es: {prom} años. ")
#     es_mayor(prom)
    
# tresEdades()

# 15. SALARIO CONDICIONAL
# SMMLV = 1300000
# def ingresarValores():
#     while True:
#         try:
#             dias = int(input("Para calcular su nómina, ingrese los días trabajados: "))
#             try:
#                 valor = float(input("Ingrese el valor del día: "))
#                 calcularSalario(dias, valor)
#                 break
#             except ValueError:
#                 print("Debes ingresar un valor numérico para el valor del día. Intenta de nuevo.")
#         except ValueError:
#             print("Debes ingresar un número entero para los días trabajados. Intenta de nuevo.")
#         except Exception as e:
#             print("Error inesperado: ", e)
#             break

# def calcularSalario(dias, valor):
#     salario = dias * valor
#     print(f"Su salario es: {salario}")
    
#     salud = calcularSalud(salario)
#     pension = calcularPension(salario)
#     arl = calcularArl(salario)
#     transporte = calcularTransporte(salario)
#     retencion = calcularDeduccion(salario)
    
#     total =( salario + transporte) - (salud + pension + arl + retencion)
#     print(f"Su salario total después de deducciones es: ${total}")

# def calcularSalud(salario):
#     salud = salario * 0.12
#     print(f"Su aporte a salud es: {salud}")
#     return salud

# def calcularPension(salario):
#     pension = salario * 0.16
#     print(f"Su aporte a pensión es: {pension}")
#     return pension

# def calcularArl(salario):
#     arl = salario * 0.052
#     print(f"Su aporte a ARL es: {arl}")
#     return arl

# def calcularTransporte(sueldo):
#     if(sueldo >= 2*SMMLV):
#         print("La persona no recibe subsidio de transporte.")
#         return 0
#     else:
#         print("La persona recibe subsidio de transporte de $114.000.")
#         return 114000
    
# def calcularDeduccion(sueldo):
#     if(sueldo >= 4*SMMLV):
#         retencion = sueldo * 0.04
#         print(f"La persona gana más de 4 salarios mínimos y se le hace una deducción de: {retencion}")
#         return retencion
#     else:
#         return 0
    
# ingresarValores()

# 16. RANGO TRES NOTAS
# n1 = float(input("Escribe la primera nota, la cual equivale al 20%: "))
# n2 = float(input("Escribe la segunda nota, la cual equivale al 35%: "))
# n3 = float(input("Escribe la tercera nota, la cual equivale al 45%: "))

# def calculatTresNotas(n1,n2,n3):
#     nota1 = n1 * 0.2
#     nota2 = n2 * 0.35
#     nota3 = n3 * 0.45
#     promedio = (nota1 + nota2 + nota3) 
#     if(promedio>4.5):
#         return print("El promedio de las tres notas es: "+ str(promedio) + " es una nota alta.")
#     elif(promedio<=4.5 and promedio >3.5):
#         return print("El promedio de las tres notas es: "+ str(promedio) + " es una nota buena.")
#     elif(promedio<=3.5 and promedio >=3):
#             return print("El promedio de las tres notas es: "+ str(promedio) + " es una nota media.")
#     elif(promedio <3):
#         return print("El promedio de las tres notas es: "+ str(promedio) + " es una nota mala.")

# calculatTresNotas(n1,n2,n3) 

# 17. NÚMEROS DE 1 A 5 CON WHILE 
# iteracion = 1
# while iteracion <= 5:
#     print(iteracion)
#     iteracion += 1
    
# 18. FACTORIAL DE 5 CON WHILE 
# iteracion = 1
# factorial = 1
# while iteracion <= 5:
#     factorial = factorial * iteracion
#     iteracion += 1
#     print(factorial)

# 19. TABLA DEL 5 QUE MULTIPLICA HASDTA 5 CON WHILE
# iteracion = 1
# tabla = 5
# numero = 5
# while iteracion <= numero:
#     resultado = tabla * iteracion
#     print(f"{tabla} x {iteracion} = {resultado}")
#     iteracion = iteracion +1

# 20. TABLA DEL 9 QUE MULTIPLICA HASTA 5 E IDENTIFICA PARES E EMPARES CON WHILE 
# iteracion = 1
# tabla = 9
# numero = 5
# while iteracion <= numero:
#     resultado = tabla * iteracion
#     if resultado % 2 == 0:
#         print(f"{tabla} x {iteracion} = {resultado} es par")
#     else:
#         print(f"{tabla} x {iteracion} = {resultado} es impar")
#     iteracion = iteracion +1

# 21. NÚMEROS DE 1 A 5 CON FOR
# for iteracion in range(1,6):
#     print(iteracion)

# 22. TABLA DEL 5 QUE MULTIPLICAS HASTA 5 CON FOR 
# tabla = 5
# for iteracion in range(1,6):
#     resultado = tabla * iteracion
#     print(f"{tabla} x {iteracion} = {resultado}")

# 23. TABLA DEL 9 QUE MULTIPLICA HASTA 5 CON FOR
# tabla = 9
# for iteracion in range(1,6):
#     resultado = tabla * iteracion
#     print(f"{tabla} x {iteracion} = {resultado}")

# 24. TABLA DEL 9 QUE MULTIPLICA HASTA 5 E IDENTIFICANDO PARES E IMPARES CON FOR
# tabla = 9
# for iteracion in range(1,6):
#     resultado = tabla * iteracion
#     if resultado % 2 == 0:
#         print(f"{tabla} x {iteracion} = {resultado} es par")
#     else:
#         print(f"{tabla} x {iteracion} = {resultado} es impar")

# 25. TABLAS DEL 1 AL 5 QUE MUULTIPLICAN HASTA 5 CON WHILE 
# iteracion1 = 0
# tabla = 5
# numero = 5
# par = 0
# impar = 0

# while iteracion1 < tabla:
#     iteracion1 = iteracion1 + 1
#     iteracion2 = 1
#     while iteracion2<= numero:
#         resultado = iteracion1 * iteracion2
#         if(resultado % 2 == 0):
#             print(f"{iteracion1} x {iteracion2} = {resultado} es par. Buzz")
#             par = par + 1
#         else:
#             print(f"{iteracion1} x {iteracion2} = {resultado} es impar. Bass")
#             impar = impar + 1
#         iteracion2 = iteracion2 + 1
# print(f"Hay {par} números pares, y {impar}, números impares.")

# 26. TABLAS DEL 1 AL 5 QUE MUULTIPLICAN HASTA 5 CON FOR
par = 0
impar = 0
for tabla in range(1,6):
    for numero in range(1,6):
        resultado = tabla * numero
        if(resultado % 2 == 0):
            print(f"{tabla} x {numero} = {resultado} es par. Buzz")
            par = par + 1
        else:
            print(f"{tabla} x {numero} = {resultado} es impar. Bass")
            impar = impar + 1
print(f"Hay {par} números pares, y {impar}, números impares.")