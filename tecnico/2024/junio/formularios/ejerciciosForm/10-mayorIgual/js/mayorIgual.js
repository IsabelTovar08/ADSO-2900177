/**
 * Funcion Número Mayor
 * Autor: María Isabel Tovar Pastrana
 * Fecha: 26 de Junio del 2024
 */
function mayorIgual(){
    let numeroUno = parseInt(document.getElementById("txtNumeroUno").value);
    let numeroDos = parseInt(document.getElementById("txtNumeroDos").value);
    let mayor;

    if  (numeroUno != numeroDos) { 
        if (numeroUno > numeroDos) {
             mayor = "El número mayor es: "+numeroUno+ " el número uno.";
         } else {
             mayor = "El número mayor es: "+numeroDos+ " el número dos.";
         }  
     }else{
        mayor= "Los números son iguales";
    }

    document.getElementById('mayor').innerHTML = mayor;
    return false;
}