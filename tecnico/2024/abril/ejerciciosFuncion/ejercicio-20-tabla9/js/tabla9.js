// Con parámetros
function funcionTabla(pmult,pnum){
    let contador = 0;
    let tabla = pmult;
    let numero = pnum;
    let resultado = 0;
    while(contador<numero){
        contador++;
        resultado=tabla*contador;
        if(resultado%2==0){
            console.log(tabla+"x"+contador+"="+resultado+" Es par");
        }else{
            console.log(tabla+"x"+contador+"="+resultado+" Es impar");
        }
    }
}
// como expresión
const funcionTablaExp = function (pmult,pnum){
    let contador = 0;
    let tabla = pmult;
    let numero = pnum;
    let resultado = 0;
    while(contador<numero){
        contador++;
        resultado=tabla*contador;
        if(resultado%2==0){
            console.log(tabla+"x"+contador+"="+resultado+" Es par");
        }else{
            console.log(tabla+"x"+contador+"="+resultado+" Es impar");
        }
    }
}