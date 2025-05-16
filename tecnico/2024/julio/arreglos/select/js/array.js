/**
 * Número del 1 al 10
 * Autor: María Isabel Tovar Pastrana
 * Fecha: 08 de Julio del 2024
 */
let arreglo = [];
let iteracion;
let resultadoLista = "";
let numero;

arreglo = [1,2,3,4,5,6,7,8,9,10];

for (iteracion = 0; iteracion < arreglo.length; iteracion++) {
    resultadoLista += '<option>'+ arreglo[iteracion] +'</option>';
}
document.getElementById('resultadoLista').innerHTML = resultadoLista;

arreglo = [];
for (iteracion = 0; iteracion < 10; iteracion++) {
    numero = iteracion +1;
    arreglo.push(numero);
}

resultadoLista = "";
for (iteracion = 0; iteracion < arreglo.length; iteracion++) {
    resultadoLista += '<option>'+ arreglo[iteracion] +'</option>';
}
document.getElementById('resultadoListaDos').innerHTML = resultadoLista;