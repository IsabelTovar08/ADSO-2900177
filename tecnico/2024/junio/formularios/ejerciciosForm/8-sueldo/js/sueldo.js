/**
 * Funcion Sueldo de una persona
 * Autor: María Isabel Tovar Pastrana
 * Fecha: 24 de Junio del 2024
 */
function sueldo(){
    let diasTrabajados = parseInt(document.getElementById('txtDias').value);
    let valorDia = parseInt(document.getElementById('txtValor').value);
    let sueldo;
    let salud;
    let pension;
    let arl;
    let descuento;
    let total;

    sueldo = diasTrabajados*valorDia;
    salud = sueldo*0.12;
    pension = sueldo*0.16;
    arl = sueldo*0.052;
    descuento = salud+pension+arl;
    total = sueldo-descuento;
    
    document.getElementById('sueldo').innerHTML =
    `Sueldo: <strong>${sueldo}</strong><br>
    Salud: <strong>${salud}</strong><br>
    Pensión: <strong>${pension}</strong><br>
    ARL: <strong>${arl}</strong><br>
    Descuento: <strong>${descuento}</strong><br>
    <strong>TOTAL: ${total}</strong><br></br>`;
    return false;
}