/**
 * Factorial
 * Autor: María Isabel Tovar Pastrana
 * Fecha: 08 de Julio del 2024
 */
let arreglo = [];
let iteracion;
let resultadoLista = "";
let numero;
let factorial;
let resultado;
factorial = 1;
numero = 5;

for (iteracion = 1; iteracion <= numero; iteracion++) {
    factorial = factorial * iteracion;
    arreglo.push(factorial);
}
for (iteracion = 0; iteracion < arreglo.length; iteracion++) {
    resultadoLista += '<tbody><tr><th scope="row" id="resultadoNumero"></th><td id="resultadoFactorial">'+arreglo[iteracion]+'</td></tr></tbody>';
}

document.getElementById('resultadoFactorial').innerHTML = resultadoLista;