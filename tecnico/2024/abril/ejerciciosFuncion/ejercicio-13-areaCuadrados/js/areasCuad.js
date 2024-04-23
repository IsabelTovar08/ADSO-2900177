// Con parámetros
function areaCuadrado(plado){
    let lado = plado;
    let cuad;
    cuad = lado**2;
    return  cuad ;
}
function cuadMayor(cuadUno,cuadDos,cuadTres) {
    if(cuadUno!=cuadDos && cuadDos!=cuadTres && cuadUno!=cuadTres){
        if(cuadUno>cuadDos && cuadUno>cuadTres){
            return ("El área del cuadrado uno "+cuadUno+" es mayor.");
        }
        else{
            if (cuadDos>cuadUno && cuadDos>cuadTres) {
                return ("El área del cuadrado dos "+cuadDos+" es mayor.");
            } else {
                return ("El área del cuadrado tres "+cuadTres+" es mayor.");
            }
        }
    }
    else{
        return ("Las tres áreas son iguales.");
    }
}
// Como expresión
const areaCuadradoExp = function (plado){
    let lado = plado;
    let cuad;
    cuad = lado**2;
    return  cuad ;
}
const cuadMayorExp = function (cuadUno,cuadDos,cuadTres) {
    if(cuadUno!=cuadDos && cuadDos!=cuadTres && cuadUno!=cuadTres){
        if(cuadUno>cuadDos && cuadUno>cuadTres){
            return ("El área del cuadrado uno "+cuadUno+" es mayor.");
        }
        else{
            if (cuadDos>cuadUno && cuadDos>cuadTres) {
                return ("El área del cuadrado dos "+cuadDos+" es mayor.");
            } else {
                return ("El área del cuadrado tres "+cuadTres+" es mayor.");
            }
        }
    }
    else{
        return ("Las tres áreas son iguales.");
    }
}