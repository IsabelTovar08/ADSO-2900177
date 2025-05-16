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
    let num = pnum;
    let resultado = "";
    if (isNaN(num) || num < 1) {
        return "Por favor, introduce un número válido.";
    }else{
        for(let contar=1;contar <=num; contar++){
           resultado += contar + '<br>';
        }
    
        return resultado;
    }   
}