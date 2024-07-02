/**
 * Funcion Operaciones
 * Autor: María Isabel Tovar Pastrana
 * Fecha: 17 de Junio del 2024
 */
function operaciones(){
    let numeroUno = parseInt(document.getElementById('txtNumeroUno').value);
    let numeroDos = parseInt(document.getElementById('txtNumeroDos').value);
    let sumar;
    let restar;
    let multiplicar;
    let dividir;
    let rsuma;
    let rresta;
    let rmultiplicacion;
    let rdivision;

    sumar = numeroUno + numeroDos;
    restar = numeroUno - numeroDos;
    multiplicar = numeroUno * numeroDos;
    dividir = numeroUno / numeroDos;

    rsuma = `<i class="fa-solid fa-plus"></i>  Suma:  ${sumar}<br>`;
    rresta = `<i class="fa-solid fa-minus"></i>  Resta:  ${restar}<br>`;
    rmultiplicacion = `<i class="fa-solid fa-xmark"></i>  Multiplicación:  ${multiplicar}<br>`;
    rdivision = `<i class="fa-solid fa-divide"></i>  División:  ${dividir}<br>`;

    document.getElementById('operaciones').innerHTML = rsuma + rresta + rmultiplicacion + rdivision;
    return false;
}