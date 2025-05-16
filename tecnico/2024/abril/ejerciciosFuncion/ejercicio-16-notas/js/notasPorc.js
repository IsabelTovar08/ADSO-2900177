// Con parámetros
function porcNota(pnota,pporcentaje){
    let nota=pnota;
    let porcentaje=pporcentaje;
    let resultado;
    resultado=nota*porcentaje;
    return resultado;
}
function condicionporcentaje(porcentajeTotalp){
    let porcTotal = porcentajeTotalp;
    if(porcTotal>4.5){
        return (" La nota promedio es Superior.");
    }
    else{
        if(porcTotal<=4.5  && porcTotal>3.5) {
            return (" La nota promedio es Buena.");
        }
        else{
            if(porcTotal<=3.5 && porcTotal>=3){
                return (" La nota promedio es Media.");
            }
            else{
                return (" La nota promedio es Mala.");
            }
        }
    }
}
// Como expresión
const porcNotaExp = function (pnota,pporcentaje){
    let nota=pnota;
    let porcentaje=pporcentaje;
    let resultado;
    resultado=nota*porcentaje;
    return resultado;
}
const condicionporcentajeExp = function (porcentajeTotalp){
    let porcTotal = porcentajeTotalp;
    if(porcTotal>4.5){
        return (" La nota promedio es Superior.");
    }
    else{
        if(porcTotal<=4.5  && porcTotal>3.5) {
            return (" La nota promedio es Buena.");
        }
        else{
            if(porcTotal<=3.5 && porcTotal>=3){
                return (" La nota promedio es Media.");
            }
            else{
                return (" La nota promedio es Mala.");
            }
        }
    }
}