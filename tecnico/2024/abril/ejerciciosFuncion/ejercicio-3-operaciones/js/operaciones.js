/**
 * Operaciones aritméticas aplicando funciones como una expresión
 * Autor: María Isabel Tovar Pastrana
 * Lunes 01 de abril de 2024
 */

let numUno;
let numDos;

// Con parámetros
function suma (pnumUno, pnumDos){
    let sumar;
    numUno = pnumUno;
    numDos = pnumDos;
    sumar = numUno + numDos;
    return sumar;
}
function resta (pnumUno, pnumDos){
    let restar;
    numUno = pnumUno;
    numDos = pnumDos;
    restar = numUno - numDos;
    return restar;
}
function multiplicacion (pnumUno, pnumDos){
    let multiplicar;
    numUno = pnumUno;
    numDos = pnumDos;
    multiplicar = numUno * numDos;
    return multiplicar;
}
function division (pnumUno, pnumDos){
    let dividir;
    numUno = pnumUno;
    numDos = pnumDos;
    dividir = numUno / numDos;
    return dividir;
}
function operaciones (poperador, pnumUno, pnumDos){
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
        return "Error!! no se reconoce el operador.";
    }
}

// Como expresión
const sumaExp = function(pnumUno, pnumDos){
    let sumar;
    numUno = pnumUno;
    numDos = pnumDos;
    sumar = numUno + numDos;
    return sumar;
}
const restaExp = function(pnumUno, pnumDos){
    let restar;
    numUno = pnumUno;
    numDos = pnumDos;
    restar = numUno - numDos;
    return restar;
}
const multiplicacionExp = function(pnumUno, pnumDos){
    let multiplicar;
    numUno = pnumUno;
    numDos = pnumDos;
    multiplicar = numUno * numDos;
    return multiplicar;
}
const divisionExp = function(pnumUno, pnumDos){
    let dividir;
    numUno = pnumUno;
    numDos = pnumDos;
    dividir = numUno / numDos;
    return dividir;
}
const operacionesExp = function(poperador, pnumUno, pnumDos){
    let operador = poperador;
    numUno = pnumUno;
    numDos = pnumDos;
    if(operador == "suma"){
        return sumaExp(numUno, numDos);
    }
    else if(operador == "resta"){
        return restaExp(numUno, numDos);
    }
    else if(operador == "multiplicacion"){
        return multiplicacionExp(numUno, numDos);
    }
    else if(operador == "division"){
        return divisionExp(numUno, numDos);
    }
    else{
        return "Error!! no se reconoce el operador.";
    }
}
