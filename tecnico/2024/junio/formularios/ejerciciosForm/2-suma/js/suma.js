/**
 * Funcion Suma de dos números
 * Autor: María Isabel Tovar Pastrana
 * Fecha: 24 de Junio del 2024
 */

function sumar(){
    let numeroUno = parseInt(document.getElementById('txtNumeroUno').value);
    let numeroDos = parseInt(document.getElementById('txtNumeroDos').value);
    let suma;

    suma = numeroUno + numeroDos;

    document.getElementById('suma').innerHTML = 
    `<strong>Resultado</strong><br>
    <strong>${numeroUno} + ${numeroDos} = ${suma}</strong>`
    return false;
}