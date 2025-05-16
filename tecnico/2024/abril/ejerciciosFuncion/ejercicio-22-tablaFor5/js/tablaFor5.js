// con parámetros
function tablaFor(pmult,pnum){
    let tabla=pmult;
    let numero=pnum;
    let resultado=0;

    for(let contar=1; contar<=numero; contar++){
        resultado=tabla*contar;
        console.log(tabla+"x"+contar+"="+resultado);
    }
}
// como expresión
const tablaForExp = function (pmult,pnum){
    let tabla=pmult;
    let numero=pnum;
    let resultado=0;

    for(let contar=1; contar<=numero; contar++){
        resultado=tabla*contar;
        console.log(tabla+"x"+contar+"="+resultado);
    }
}