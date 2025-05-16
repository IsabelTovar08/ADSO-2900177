/**
 * Funcion Número mayor
 * Autor: María Isabel Tovar Pastrana
 * Fecha: 26 de Junio del 2024
 */
function tresNumeros(){
    let numeroUno = parseInt(document.getElementById("txtNumeroUno").value);
    let numeroDos = parseInt(document.getElementById("txtNumeroDos").value);
    let numeroTres = parseInt(document.getElementById("txtNumeroTres").value);
    let mayor;
    let mensaje = "";

    if ((isNaN(numeroUno) || numeroUno < 1) || (isNaN(numeroDos) || numeroDos < 1) || (isNaN(numeroTres) || numeroTres < 1)) {
        mensaje = "Por favor, introduce un número válido.";
    } else {
        // Inicializar mensaje vacío
        mensaje = "";

        // Encontrar el mayor
        if (numeroUno >= numeroDos && numeroUno >= numeroTres) {
            mayor = numeroUno;
            mensaje = "El mayor es " + mayor + ", número uno.";
        } else if (numeroDos >= numeroUno && numeroDos >= numeroTres) {
            mayor = numeroDos;
            mensaje = "El mayor es " + mayor + ", número dos.";
        } else if (numeroTres >= numeroUno && numeroTres >= numeroDos) {
            mayor = numeroTres;
            mensaje = "El mayor es " + mayor + ", número tres.";
        } else {
            mensaje = "No hay un único mayor.";
        }

        // Verificar si hay números iguales
        if (numeroUno == numeroDos && numeroUno == numeroTres) {
            mensaje = "Los tres números son iguales.";
        } else {
            if (numeroUno == numeroDos && numeroUno != numeroTres) {
                mensaje += '<br>' + "El número uno y dos son iguales.";
            } else if (numeroUno == numeroTres && numeroUno != numeroDos) {
                mensaje += '<br>' + "El número uno y tres son iguales.";
            } else if (numeroDos == numeroTres && numeroDos != numeroUno) {
                mensaje += '<br>' + "El número dos y tres son iguales.";
            }
        }
    }

    document.getElementById('mayor').innerHTML = mensaje;
    return false;
}