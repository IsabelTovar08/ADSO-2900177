/**
 * Tablas de Multiplicar con Array
 * Autor: María Isabel Tovar Pastrana
 * Fecha: 10 de Julio del 2024
 */
document.addEventListener('DOMContentLoaded',function(){
    let tablas = [];
    let multiplo = [];
    let iteracionTabla ;
    let iteracionMultiplo;
    let resultado;
    let numeroTabla;
    let numeroMultiplo;
    let printResultado = '';

    for(iteracionTabla=0; iteracionTabla<6; iteracionTabla++){
        multiplo = [];
        numeroTabla = iteracionTabla + 1;
        for(iteracionMultiplo=0; iteracionMultiplo<10; iteracionMultiplo++){
            numeroMultiplo = iteracionMultiplo + 1;
            resultado = numeroTabla * numeroMultiplo;
            multiplo.push(resultado);
        }
        tablas.push(multiplo);
    }
    for(iteracionTabla=0; iteracionTabla<tablas.length; iteracionTabla++){
        pr
    }
    document.getElementById('')
});