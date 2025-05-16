Algoritmo CalificacionExamen
	definir calificacion Como Real
    Escribir "Ingrese la calificación del examen (0-5.0):"
    Leer calificacion
    Si calificacion < 0 o calificacion > 5 Entonces
        Escribir "La calificación ingresada no es válida."
    Sino
        Si calificacion >= 3 Entonces
            Escribir "¡Felicidades! Usted aprobó el examen."
            Si calificacion >= 4 Entonces
                Escribir "Obtuvo una calificación alta."
            Sino
                Escribir "Obtuvo una calificación baja."
            Fin Si
            
        Sino
            Escribir "Lo siento, usted reprobó el examen."
        Fin Si
    Fin Si
FinAlgoritmo