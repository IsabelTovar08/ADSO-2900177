/**
 * Tablas de Multiplicar con Array
 * Autor: María Isabel Tovar Pastrana
 * Fecha: 10 de Julio del 2024
 */

document.addEventListener('DOMContentLoaded',function(){
    let bingo = [];
    let iteracionBingos;
    let iteracionLetras;
    let iteracionF;
    let iteracionC;
    let iteracion1;
    let iteracion2;
    let contador = 0;
    let contadorBingos=0;
    let tabla;
    let letras = ['B','I','N','G','O'];
    let resultadoMostrar = "";

    for (iteracion1 = 0; iteracion1 < 5; iteracion1++) {
        let interno = [];
        for (iteracion2 = 0; iteracion2 < 5; iteracion2++) {
            contador=contador+1;
            tabla=contador*3;
            interno.push(tabla);
        }
        bingo.push(interno);
    }

    for(iteracionBingos=1; iteracionBingos<=8; iteracionBingos++){
        resultadoMostrar += '<table class="table table-bordered tabla" id="bingo">';
        resultadoMostrar += '<tr>'
        for(iteracionLetras=0; iteracionLetras<5; iteracionLetras++){
            resultadoMostrar += '<th scope="col" class="letras">'+letras[iteracionLetras]+'</th>';
        };
        resultadoMostrar+='</tr>';
        for(iteracionC=0; iteracionC<5; iteracionC++){
            resultadoMostrar += '<tr>';
            for(iteracionF=0; iteracionF<5; iteracionF++){
                if(iteracionBingos>1){
                    // Seleccionar las filas de cada Letra: B, I, N, G, O
                    if(iteracionF==contadorBingos){
                        resultadoMostrar += '<th class="letra">'+bingo[iteracionC][iteracionF]+'</th>';
                    }
                    // Seleccionar X grande
                    else if(iteracionBingos==7 && iteracionC==iteracionF){
                        resultadoMostrar += '<th class="letra">'+bingo[iteracionC][iteracionF]+'</th>';
                    }
                    else if(iteracionBingos==7 && (4-iteracionC)==(iteracionF)){
                        resultadoMostrar += '<th class="letra">'+bingo[iteracionC][iteracionF]+'</th>';
                    }
                    // Primera X
                    else if(iteracionBingos==8 && (iteracionC+1)==(iteracionF) && iteracionC<=2){
                        resultadoMostrar += '<th class="letra rojo">'+bingo[iteracionC][iteracionF]+'</th>';
                    }
                    else if(iteracionBingos==8 && (3-iteracionC)==(iteracionF) && iteracionC<=2){
                        resultadoMostrar += '<th class="letra rojo">'+bingo[iteracionC][iteracionF]+'</th>';
                    }
                    // Segunda X
                    else if(iteracionBingos==8 && (iteracionC)==(iteracionF+2)){
                        resultadoMostrar += '<th class="letra verde">'+bingo[iteracionC][iteracionF]+'</th>';
                    }
                    else if(iteracionBingos==8 && (iteracionC)==(4-iteracionF) && iteracionC>=2){
                        resultadoMostrar += '<th class="letra verde">'+bingo[iteracionC][iteracionF]+'</th>';
                    }
                    // Tercera X
                    else if(iteracionBingos==8 && (iteracionC)==(iteracionF) && iteracionC>=2){
                        resultadoMostrar += '<th class="letra morado">'+bingo[iteracionC][iteracionF]+'</th>';
                    }
                    else if(iteracionBingos==8 && (6-iteracionC)==(iteracionF) && iteracionF>=2){
                        resultadoMostrar += '<th class="letra morado">'+bingo[iteracionC][iteracionF]+'</th>';
                    }
                    else{
                    resultadoMostrar += '<td>'+bingo[iteracionC][iteracionF]+'</td>';
                    }}
                else{
                    resultadoMostrar += '<td>'+bingo[iteracionC][iteracionF]+'</td>';
                }
            };
            resultadoMostrar += '</tr>';
        };
        resultadoMostrar+='</table>';
        if(iteracionBingos>1){
            contadorBingos=contadorBingos+1;
        }else{}
    };
    document.getElementById('bingo').innerHTML = resultadoMostrar;
});