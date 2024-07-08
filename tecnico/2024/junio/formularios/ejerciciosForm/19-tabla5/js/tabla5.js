/**
 * Funcion Tabla
 * Autor: María Isabel Tovar Pastrana
 * Fecha: 06 de Julio del 2024
 */
function tabla() {
    let numero = parseInt(document.getElementById('txtNumero').value);
    let tabla = parseInt(document.getElementById('txtTabla').value);
    let resultado = funcionTabla(tabla,numero);

    document.getElementById('resultado').innerHTML = resultado;
    return false;
}

function funcionTabla(pmult,pnum) {
    let contador = 0;
    let tabla = pmult;
    let num = pnum;
    let resultado = 0;
    let respuesta = "";

    if (isNaN(num) || num < 1) {
        return "Por favor, introduce un número válido.";
    }else{
        while (contador < num) {
            contador+=1;
            resultado = tabla * contador;
            respuesta += tabla + "x" + contador + "=" + resultado + '<br>';
        }
        return respuesta;
    }  
}