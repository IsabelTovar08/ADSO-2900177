/**
 * Funcion Contar
 * Autor: María Isabel Tovar Pastrana
 * Fecha: 06 de Julio del 2024
 */
function contar() {
    let numero = parseInt(document.getElementById('txtNumero').value);
    let resultado = funcionContar(numero);

    document.getElementById('resultado').innerHTML = resultado;
    return false;
}

function funcionContar(pnum) {
    let contar = 0;
    let num = pnum;
    let resultado = "";
    if (isNaN(num) || num < 1) {
        return "Por favor, introduce un número válido.";
    }else{
        while (contar < num) {
            contar += 1;
            resultado += `${contar}<br>`;
        }
    
        return resultado;
    }   
}