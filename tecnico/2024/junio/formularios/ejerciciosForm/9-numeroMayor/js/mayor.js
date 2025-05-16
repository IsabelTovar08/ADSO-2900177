/**
 * Funcion Número mayor
 * Autor: María Isabel Tovar Pastrana
 * Fecha: 26 de Junio del 2024
 */
function numMayor(){
    let num1 = parseInt(document.getElementById('numeroUno').value);
    let num2 = parseInt(document.getElementById('numeroDos').value);
    let mayor = 0;

    if (num1 > num2) {
       mayor = num1;
     } else {
        mayor= num2;
     } 
     
    document.getElementById('mayor').innerHTML =  `El número mayor es: <strong>${mayor}</strong><br>`;
    return false;
}