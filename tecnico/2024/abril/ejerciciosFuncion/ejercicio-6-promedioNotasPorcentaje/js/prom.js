let nota;
let porcentaje;

// Con parámetros
function porcNota(pnota,pporcentaje){
    nota=pnota;
    porcentaje=pporcentaje;
    let resultado;
    resultado=nota*porcentaje;
    return resultado;
}
// Como expresión
const porcNotaExp = function(pnota,pporcentaje){
    nota=pnota;
    porcentaje=pporcentaje;
    let resultado;
    resultado=nota*porcentaje;
    return resultado;
}
