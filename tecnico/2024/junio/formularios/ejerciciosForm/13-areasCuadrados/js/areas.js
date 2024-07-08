/**
 * Funcion Áreas de tres cuadrados
 * Autor: María Isabel Tovar Pastrana
 * Fecha: 26 de Junio del 2024
 */
function areaCuadrados(){
    let ladoUno = parseInt(document.getElementById("txtLadoUno").value);
    let ladoDos = parseInt(document.getElementById("txtLadoDos").value);
    let ladoTres = parseInt(document.getElementById("txtLadoTres").value);
    let mayor;
    let mensaje;
    let areaUno = areaCuadrado(ladoUno);
    let areaDos = areaCuadrado(ladoDos);
    let areaTres = areaCuadrado(ladoTres);
    
    if ((isNaN(areaUno) || areaUno < 1) || (isNaN(areaDos) || areaDos < 1) || (isNaN(areaTres) || areaTres < 1)) {
        mensaje = "Por favor, introduce un número válido.";
    } else {
        // Inicializar mensaje vacío
        mensaje = "";

        // Encontrar el mayor
        if (areaUno >= areaDos && areaUno >= areaTres) {
            mayor = areaUno;
            mensaje = "El mayor es " + mayor + ", área del cuadrado uno.";
        } else if (areaDos >= areaUno && areaDos >= areaTres) {
            mayor = areaDos;
            mensaje = "El mayor es " + mayor + ", área del cuadrado dos.";
        } else if (areaTres >= areaUno && areaTres >= areaDos) {
            mayor = areaTres;
            mensaje = "El mayor es " + mayor + ", área del cuadrado tres.";
        } else {
            mensaje = "No hay un único mayor.";
        }

        // Verificar si hay áreas iguales
        if (areaUno == areaDos && areaUno == areaTres) {
            mensaje = "Los tres cuadrados tienen el mismo área.";
        } else {
            if (areaUno == areaDos && areaUno != areaTres) {
                mensaje += '<br>' + "El área del cuadrado uno y dos son iguales.";
            } else if (areaUno == areaTres && areaUno != areaDos) {
                mensaje += '<br>' + "El área del cuadrado uno y tres son iguales.";
            } else if (areaDos == areaTres && areaDos != areaUno) {
                mensaje += '<br>' + "El área del cuadrado dos y tres son iguales.";
            }
        }
    }

    document.getElementById('mayor').innerHTML =
    `El área uno es: <strong>${areaUno}</strong><br>
    El area dos es: <strong>${areaDos}</strong><br>
    El área tres es; <strong>: ${areaTres}</strong><br>
    ${mensaje}`;
    return false;
}
function areaCuadrado(plado){
    let lado = plado;
    let cuad;
    cuad = lado**2;
    return  cuad ;
}