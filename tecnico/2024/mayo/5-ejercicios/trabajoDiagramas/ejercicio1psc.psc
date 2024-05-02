Algoritmo sin_titulo
	Definir pesoInicial, pesoNeto, cantLomo, cantBrazo, cantPierna, cantCostilla, cantTocino, cantHueso Como Real
	Definir precioKgCerdo, precioLomo, precioBrazo, precioPierna, precioCostilla, precioTocino, precioHueso Como Real
	Definir precioInc, totalLomo, totalbrazo, totalPierna, totalCostilla, totalTocino, totalHueso, precioFin, gananciaP Como Real
	Escribir 'Digite el peso neto del cerdo'
	Leer peso
	Escribir 'Digite el precio en kg'
	Leer precioKg
	precioInc <- peso*precioKg
	Escribir 'El precio inicial del cerdo es: $', precioInc
	Escribir 'Ingrese la cantidad en kg de Lomo de Cerdo'
	Leer cantLomo
	Escribir 'Ingrese el precio de Lomo de Cerdo en kg: '
	Leer precioLomo
	Escribir 'Ingrese la cantidad en kg de Brazo de Cerdo'
	Leer cantBrazo
	Escribir 'Ingrese el precio de Brazo de Cerdo en kg: '
	Leer precioBrazo
	Escribir 'Ingrese la cantidad en kg de Pierna de Cerdo'
	Leer cantPierna
	Escribir 'Ingrese el precio de Pierna de Cerdo en kg: '
	Leer precioPierna
	Escribir 'Digite la cantidad en kg de Costilla de Cerdo'
	Leer cantCostilla
	Escribir 'Ingrese el precio de la Costilla de Cerdo en kg'
	Leer precioCostilla
	Escribir 'Ingrese la cantidad en kg de Tocino'
	Leer cantTocino
	Escribir 'Ingrese el precio del Tocino en kg: '
	Leer precioTocino
	Escribir 'Ingrese la cantidad en kg de Hueso de Cerdo'
	Leer cantHueso
	Escribir 'Ingrese el precio de Hueso de Cerdo en kg: '
	Leer precioHueso
	totalLomo <- cantLomo*precioLomo
	totalbrazo <- cantBrazo*precioBrazo
	totalPierna <- cantPierna*precioPierna
	totalCostilla <- cantCostilla*precioCostilla
	totalTocino <- cantTocino*precioTocino
	
	totalHueso <- cantHueso*precioHueso
	pesoNeto <- cantLomo+cantBrazo+cantPierna+cantCostilla+cantTocino+cantHueso
	precioFin <- totalLomo+totalbrazo+totalPierna+totalCostilla+totalTocino+totalHueso
	gananciaP <- precioFin-precioInc
	Escribir 'El valor total de Lomo de Cerdo es: $', totalLomo
	Escribir 'El valor total de Brazo de Cerdo es: $', totalbrazo
	Escribir 'El valor total de Pierna de Cerdo es: $', totalPierna
	Escribir 'El valor total de la costilla es: $', totalCostilla
	Escribir 'El valor total de Tocino es: $', totalTocino
	Escribir 'El valor total de Hueso de Cerdo es: $', totalHueso
	Escribir 'El peso total neto del cerdo es: $', pesoNeto
	Escribir 'El valor final del cerdo es: $', precioFin
	Si precioInc==precioFin Entonces
		Escribir '¡No se presentaron ganancias!, el valor inicial es igual a el valor final'
	SiNo
		Si precioFin<precioInc Entonces
			Escribir '¡No se presentaron ganancias, hubo una pérdida de: $', Abs(gananciaP), '!'
		SiNo
			Escribir '¡Hubo una ganancia de :$ ', gananciaP
		FinSi
	FinSi
FinAlgoritmo
