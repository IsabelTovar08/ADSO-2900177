/**
 * Funcion Porcentaje tres notas
 * Autor: María Isabel Tovar Pastrana
 * Fecha: 24 de Junio del 2024
 */
function promNotas() {
    let notaUno = parseInt(document.getElementById('txtNotaUno').value);
    let notaDos = parseInt(document.getElementById('txtNotaDos').value);
    let notaTres = parseInt(document.getElementById('txtNotaTres').value);
    let porcUno;
    let porcDos;
    let porcTres;
    let porcentajeTotal;

    porcUno = notaUno*0.3;
    porcDos = notaDos*0.3;
    porcTres = notaTres*0.4;
    porcentajeTotal = porcUno + porcDos + porcTres;

    document.getElementById('totalNotas').innerHTML = 
    `
    Porcentaje Uno: <strong>${porcUno}</strong><br>
    Porcentaje Dos: <strong>${porcDos}</strong><br>
    Porcentaje Tres: <strong>${porcTres}</strong><br>
    <strong>Nota Total: ${porcentajeTotal}</strong>`;
    return false;
}
