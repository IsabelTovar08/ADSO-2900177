/**
 * Funcion Saludar
 * Autor: María Isabel Tovar Pastrana
 * Fecha: 24 de Junio del 2024
 */

function saludar(){
    let saludo = document.getElementById('txtSaludo').value;
    document.getElementById('saludo').innerHTML = `<strong>${saludo}</strong>`
    return false;
}