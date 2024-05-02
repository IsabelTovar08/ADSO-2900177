Algoritmo gallet
	Definir cantGalletas,cantidadHarina,cantidadAzucar,cantidadMantequilla Como Real
	Definir cantNecesariaHarina,cantNecesariaAzucar,cantNecesariaMantequilla Como Real 
	Definir cantidadHuevosNecesarios Como Entero
	cantidadHarina = 200 / 10
	cantidadAzucar = 100 / 10
	cantidadMantequilla = 100 / 10
	cantidadHuevosNecesarios = 1
	Escribir "Ingrese la cantidad de galletas que desea preparar: "
	Leer cantGalletas
	cantNecesariaHarina = cantGalletas*cantidadHarina
	cantNecesariaAzucar = cantGalletas*cantidadAzucar
	cantNecesariaMantequilla = cantGalletas*cantidadMantequilla
	
	Si cantGalletas > 19
        cantidadHuevosNecesarios = redon(cantGalletas/10)
	SiNo
		cantidadHuevosNecesarios=cantidadHuevosNecesarios
    finsi

	Escribir "Para preparar ",cantGalletas, " galletas, necesita: "
	Escribir cantidadHuevosNecesarios, " huevos"
	Escribir cantNecesariaHarina, " gr de harina "
	Escribir cantNecesariaAzucar, " gr de azucar "
	Escribir cantNecesariaMantequilla, " gr de mantequilla"
FinAlgoritmo
