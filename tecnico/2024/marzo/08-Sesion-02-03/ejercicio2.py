# Capturar las notas obtenidas
# Matemáticas
examenM=float(input("Para calcular la nota promedio de Matemáticas, ingrese la nota obtenida en el examen: "))
tareaUnoM=float(input("Ingrese la nota obtenida en la tarea 1: "))
tareaDosM=float(input("Ingrese la nota obtenida en la tarea 2: "))
tareaTresM=float(input("Ingrese la nota obtenida en la tarea 3: "))
# Física
examenF=float(input("Para calcular la nota promedio de Física, ingrese la nota obtenida en el examen: "))
tareaUnoF=float(input("Ingrese la nota obtenida en la tarea 1: "))
tareaDosF=float(input("Ingrese la nota obtenida en la tarea 2: "))
# Química
examenQ=float(input("Para calcular la nota promedio de Química, ingrese la nota obtenida en el examen: "))
tareaUnoQ=float(input("Ingrese la nota obtenida en la tarea 1: "))
tareaDosQ=float(input("Ingrese la nota obtenida en la tarea 2: "))
tareaTresQ=float(input("Ingrese la nota obtenida en la tarea 3: "))

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
