/**
 * Funcion Porcentaje Notas
 * Autor: María Isabel Tovar Pastrana
 * Fecha: 24 de Junio del 2024
 */
function promNotas() {
    let notaUno = parseInt(document.getElementById('txtNotaUno').value);
    let notaDos = parseInt(document.getElementById('txtNotaDos').value);
    let notaTres = parseInt(document.getElementById('txtNotaTres').value);
    let porcentajeNotas;

    porcentajeNotas = (notaUno+notaDos+notaTres)/3;

    document.getElementById('promedioNotas').innerHTML = `<strong>${porcentajeNotas}</strong>`;
    return false;
}
