/**
 * Operaciones aritméticas aplicando funciones como una expresión
 * Autor: María Isabel Tovar Pastrana
 * Lunes 01 de abril de 2024
 */

let numUno;
let numDos;

const suma = function(pnumUno, pnumDos){
    let sumar;
    numUno = pnumUno;
    numDos = pnumDos;
    sumar = numUno + numDos;
    return sumar;
}
const resta = function(pnumUno, pnumDos){
    let restar;
    numUno = pnumUno;
    numDos = pnumDos;
    restar = numUno - numDos;
    return restar;
}
const multiplicacion = function(pnumUno, pnumDos){
    let multiplicar;
    numUno = pnumUno;
    numDos = pnumDos;
    multiplicar = numUno * numDos;
    return multiplicar;
}
const division = function(pnumUno, pnumDos){
    let dividir;
    numUno = pnumUno;
    numDos = pnumDos;
    dividir = numUno / numDos;
    return dividir;
}
const operaciones = function(poperador, pnumUno, pnumDos){
    let operador = poperador;
    numUno = pnumUno;
    numDos = pnumDos;
    if(operador == "suma"){
        return suma(numUno, numDos);
    }
    else if(operador == "resta"){
        return resta(numUno, numDos);
    }
    else if(operador == "multiplicacion"){
        return multiplicacion(numUno, numDos);
    }
    else if(operador == "division"){
        return division(numUno, numDos);
    }
    else{
        return "Error!! no se reconoce el operador,";
    }
}