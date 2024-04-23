// Con parámetros
function TablaFor(pmult,pnum){
    let tabla = pmult;
    let numero = pnum;
    let resultado = 0;

    for(let contar=1; contar<=numero; contar++){
        resultado=tabla*contar;
        if(resultado%2==0){
            console.log(tabla+"x"+contar+"="+resultado+" Es par");
        }else{
            console.log(tabla+"x"+contar+"="+resultado+" Es impar");
        }
    }
}
// como expresión
const TablaForExp = function(pmult,pnum){
    let tabla = pmult;
    let numero = pnum;
    let resultado = 0;

    for(let contar=1; contar<=numero; contar++){
        resultado=tabla*contar;
        if(resultado%2==0){
            console.log(tabla+"x"+contar+"="+resultado+" Es par");
        }else{
            console.log(tabla+"x"+contar+"="+resultado+" Es impar");
        }
    }
}