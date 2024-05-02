Algoritmo controlMilk
	Definir lLunes,lMartes,lMiercoles,ljueves,lViernes,diferenciaLitros,porcentajeCambio Como Real
	Definir lTotal,preciolitro,precioTotal,promedioDiario,cantPasada Como Real
	Escribir "Ingrese el precio por litro de leche de vaca"
	Leer preciolitro
	Escribir "Ingrese los litros de leche vaca recogidos el día Lunes"
	Leer lLunes
	Escribir "Ingrese los litros de leche vaca recogidos el día Martes"
	Leer lMartes
	Escribir "Ingrese los litros de leche vaca recogidos el día Miércoles"
	Leer lMiercoles
	Escribir "Ingrese los litros de leche vaca recogidos el día Jueves"
	Leer ljueves
	Escribir "Ingrese los litros de leche vaca recogidos el día Viernes"
	Leer lViernes
	Escribir "Ingrese la cantidad de leche de vaca producida durante la semana pasada"
	Leer cantPasada
	lTotal=lLunes+lMartes+lMiercoles+ljueves+lViernes
	precioTotal=preciolitro*lTotal
	promedioDiario=lTotal/5
	diferenciaLitros = lTotal - cantPasada
	porcentajeCambio = (diferenciaLitros / cantPasada) * 100
    Si lTotal=lTotalSemanaPasada Entonces
		Escribir "La producción de leche se mantuvo igual en comparación con la semana pasada."
    Sino Si lTotalSemanaPasada>lTotal Entonces
			Escribir "La producción de leche disminuyó un ", Abs(porcentajeCambio), "% en comparación con la semana pasada."
		Sino
			Escribir "La producción de leche aumentó un ", Abs(porcentajeCambio), "% en comparación con la semana pasada."
		FinSi
    Fin Si
	Escribir "los litros de leche le vaca recogidos durante toda la semana fueron: ",lTotal, " litros."
	Escribir "El precio total fue: $",precioTotal
	Escribir "El promedio diario de leche es: ",promedioDiario," litros."
FinAlgoritmo
