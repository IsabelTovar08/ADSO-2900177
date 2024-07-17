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
    for(iteracionTabla =0; iteracionTabla<tablas.length; iteracionTabla++){
        numeroTabla = iteracionTabla +1;
        printResultado += ' <div class="accordion-item">';
        printResultado += '<button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#flush-collapse'+numeroTabla+'" aria-expanded="false"aria-controls="flush-collapseOne">';
            printResultado += 'Tabla de multiplicar #'+ numeroTabla;
        printResultado += ' </button>';
        printResultado += '<div id="flush-collapse'+numeroTabla+'" class="accordion-collapse collapse" data-bs-parent="#accordionFlushExample">';
         for(iteracionMultiplo =0;  iteracionMultiplo<10; iteracionMultiplo++){
                numeroMultiplo = iteracionMultiplo +1;
                printResultado += '<div class="accordion-body" style="padding: 0 !important;">';
                printResultado += '<table class="table"> ';
                printResultado += '<tr style="padding: 0;margin:0;"><td  style="padding:0;margin:0;">'+numeroTabla+' x '+numeroMultiplo+' = ' +tablas[iteracionTabla][iteracionMultiplo]+'</td></tr>';
                printResultado += '</table>';
                printResultado += '</div>';
         }
         printResultado += '</div>';
         printResultado += '</div>';


    }
    
    document.getElementById('accordionFlushExample').innerHTML = printResultado;
});