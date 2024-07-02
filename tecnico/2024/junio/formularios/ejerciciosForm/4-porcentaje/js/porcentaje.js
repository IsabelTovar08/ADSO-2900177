/**
 * Funcion Porcentaje
 * Autor: María Isabel Tovar Pastrana
 * Fecha: 24 de Junio del 2024
 */
function porcentaje() {
    let numero = parseInt(document.getElementById('txtNumero').value);
    let porcentaje;

    porcentaje = numero/100;

    document.getElementById('porcentaje').innerHTML = `<strong>${porcentaje}</strong>`;
    return false;
}
