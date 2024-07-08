/**
 * Funcion Factorial
 * Autor: María Isabel Tovar Pastrana
 * Fecha: 06 de Julio del 2024
 */
function factorial() {
    let numero = parseInt(document.getElementById('txtNumero').value);
    let resultado = funcionFactorial(numero);

    document.getElementById('resultado').innerHTML = resultado;
    return false;
}

function funcionFactorial(pnum){
    let contador = 0;
    let num = pnum;
    let factorial=1;
    let resultado = "";
    if (isNaN(num) || num < 1) {
        return "Por favor, introduce un número válido.";
    }else{
        while(contador<num){
            contador+=1;
            factorial=factorial*contador;
            resultado += `${factorial}<br>`;
        }
        return resultado;
    }   
}
