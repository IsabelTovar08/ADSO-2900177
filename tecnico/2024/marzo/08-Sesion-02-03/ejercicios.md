# Ejercicios
## Ejercicio 1
Tres personas deciden invertir su dinero para fundar una empresa. Cada una de ellas invierte una cantidad distinta. Obtener el porcentaje que cada quien invierte con respecto a la cantidad total invertida.
```
INICIO
    DEFINIR invUno,invDos,invTres,invTotal,porcUno.porcDos.porctres como real

    invUno=0.0
    invDos=0.0
    invTres=0.0
    invTotal=0.0
    porcUno=0.0
    porcDos=0.0
    porctres=0.0

    ESCRIBIR "Digite la cantidad de dinero invertido por la persona Uno: "
    LEER invUno

    ESCRIBIR "Digite la cantidad de dinero invertido por la persona Dos: "
    LEER invDos

    ESCRIBIR "Digite la cantidad de dinero invertido por la persona Tres: "
    LEER invTres

    invTotal=invUno+invDos+invTres
    porcUno=(invUno*100)/invTotal
    porcDos=(invDos*100)/invTotal
    porctres=(invTres*100)/invTotal

    ESCRIBIR "La inversión total fue : ",invTotal
    ESCRIBIR "El porcentaje de inversión por la persona Uno fue : ",porcUno
    ESCRIBIR "El porcentaje de inversión por la persona Dos fue : ",porcDos
    ESCRIBIR "El porcentaje de inversión por la persona Tres fue : ",porcTres
FIN
```

## Ejercicio 2
Un alumno desea saber cuál será su promedio general en las tres materias más difíciles que cursa y cuál será el promedio que obtendrá en cada una de ellas. Estas materias se evalúan como se muestra a continuación:

* La calificación de Matemáticas se obtiene de la siguiente manera: Examen 90% Promedio de tareas 10% En esta materia se pidió un total de tres tareas.

* La calificación de Física se obtiene de la siguiente manera: Examen 80% Promedio de tareas 20% En esta materia se pidió un total de dos tareas.

* La calificación de Química se obtiene de la siguiente manera: Examen 85% Promedio de tareas 15% En esta materia se pidió un promedio de tres tareas.

```
INICIO
    DEFINIR examenM,tareaUnoM,tareaDosM,tareaTresM,examenF,tareaUnoF,tareaDosF,examenQ,tareaUnoQ,tareaDosQ,tareaTresQ,promM,promF,promQ,promG como real 

    examenM=0.0
    tareaUnoM=0.0
    tareaDosM=0.0
    tareaTresM=0.0
    examenF=0.0
    tareaUnoF=0.0
    tareaDosF=0.0
    examenQ=0.0
    tareaUnoQ=0.0
    tareaDosQ=0.0
    tareaTresQ=0.0
    promM=0.0
    promF=0.0
    promQ=0.0
    promG=0.0

    ESCRIBIR "Para calcular el promedio de Matemáticas, escriba la nota obtenida en el examen: "
    LEER examenM

    ESCRIBIR "Escriba la nota obtenida en la tarea 1: "
    LEER tareaUnoM

    ESCRIBIR "Escriba la nota obtenida en la tarea 2: "
    LEER tareaDosM

    ESCRIBIR "Escriba la nota obtenida en la tarea 3: "
    LEER tareatresM

    ESCRIBIR "Para calcular el promedio de Física, escriba la nota obtenida en el examen: "
    LEER examenF

    ESCRIBIR "Escriba la nota obtenida en la tarea 1: "
    LEER tareaUnoF

    ESCRIBIR "Escriba la nota obtenida en la tarea 2: "
    LEER tareaDosF

    ESCRIBIR "Para calcular el promedio de Química, escriba la nota obtenida en el examen: "
    LEER examenQ

    ESCRIBIR "Escriba la nota obtenida en la tarea 1: "
    LEER tareaUnoQ

    ESCRIBIR "Escriba la nota obtenida en la tarea 2: "
    LEER tareaDosQ

    ESCRIBIR "Escriba la nota obtenida en la tarea 3: "
    LEER tareatresQ

    promM=(examenM*0.9+((tareaUnoM+tareaDosM+tareatresM)/3)*0.1)
    promF=(examenF*0.8+((tareaUnoF+tareaDosF)/2)*0.2)
    promQ=(examenQ*0.85+((tareaUnoQ+tareaDosQ+tareatresQ)/3)*0.15)
    promG=(promM+promF+promQ)/3

    ESCRIBIR "El promedio general fue: ",promQ
    ESCRIBIR "El promedio obtenido en Matemáticas fue: ",promM
    ESCRIBIR "El promedio obtenido en Física fue: ",promF
    ESCRIBIR "El promedio obtenido en Química fue: ",promQ
FIN
```
## Ejercicio 3
Leer un real e imprimir si el número es positivo o negativo.
```
INICIO
    DEFINIR n como real

    n=0.0

    ESCRIBIR "Escriba un número para saber si es positivo: "
    LEER n

    SI n>0 ENTONCES
        ESCRIBIR "El número ",n," es positivo"
    SiNo
        ESCRIBIR "El número ",n," es negativo"
    FinSi
FIN
```
## Ejercicio 4
Leer un real e imprimir si el número es mayor a 200 o no.
```
INICIO
    DEFINIR n como real

    n=0.0

    ESCRIBIR "Escriba un número para saber si es mayor a 200 o no: "
    LEER n

    SI n>200 ENTONCES
        ESCRIBIR "El número ",n," si es mayor a 200"
    SiNo
        ESCRIBIR "El número ",n," es menor a 200"
    FinSi
FIN
```
## Ejercicio 5
Leer un real e imprimir si el número está en el rango de 50 y 100.
```
INICIO
    DEFINIR n como real

    n=0.0

    ESCRIBIR "Escriba un número para saber si está en el rango entre 50 y 100 o no: "
    LEER n

    SI n>50 y n<100 ENTONCES
        ESCRIBIR "El número ",n," si está en el rango entre 50 y 100"
    SiNo
        ESCRIBIR "El número ",n," no está en el rango entre 50 y 100"
    FinSi
FIN
```