// Con parámetros
function funcionFactorial(pnum){
    let contador = 0;
    let numero = pnum;
    let factorial=1;
    while(contador<numero){
        contador++;
        factorial=factorial*contador;
    }
    return factorial
}

//Funcion con expresion
const funcionFactorialExp = function (pnum){
    let contador = 0;
    let numero = pnum;
    let factorial=1;
    while(contador<numero){
        contador++;
        factorial=factorial*contador;
    }
    return factorial
}