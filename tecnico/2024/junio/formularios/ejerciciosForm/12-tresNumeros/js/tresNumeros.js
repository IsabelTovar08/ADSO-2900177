/**
 * Funcion Número mayor
 * Autor: María Isabel Tovar Pastrana
 * Fecha: 26 de Junio del 2024
 */
function tresNumeros(){
    let numeroUno = parseInt(document.getElementById("txtNumeroUno").value);
    let numeroDos = parseInt(document.getElementById("txtNumeroDos").value);
    let numeroTres = parseInt(document.getElementById("txtNumeroTres").value);
    let mayor;

    if  (numeroUno != numeroDos && numeroDos != numeroTres && numeroUno != numeroTres) { 
        if (numeroUno > numeroDos &&  numeroUno > numeroTres) {
            mayor = "El número mayor es: "+numeroUno+ " el número uno.";
         } else if (numeroDos>numeroUno && numeroDos>numeroTres) {
            mayor = "El número mayor es: "+numeroDos+ " el número dos.";
         } 
         else{
             mayor = "El número mayor es: "+numeroTres +" el número tres.";  
         }
     }else{
       mayor = "Los números son iguales";
    }

    document.getElementById('mayor').innerHTML = mayor;
    return false;
}