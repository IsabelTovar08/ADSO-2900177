Algoritmo CalificacionExamen
	definir calificacion Como Real
    Escribir "Ingrese la calificaci�n del examen (0-5.0):"
    Leer calificacion
    Si calificacion < 0 o calificacion > 5 Entonces
        Escribir "La calificaci�n ingresada no es v�lida."
    Sino
        Si calificacion >= 3 Entonces
            Escribir "�Felicidades! Usted aprob� el examen."
            Si calificacion >= 4 Entonces
                Escribir "Obtuvo una calificaci�n alta."
            Sino
                Escribir "Obtuvo una calificaci�n baja."
            Fin Si
            
        Sino
            Escribir "Lo siento, usted reprob� el examen."
        Fin Si
    Fin Si
FinAlgoritmo