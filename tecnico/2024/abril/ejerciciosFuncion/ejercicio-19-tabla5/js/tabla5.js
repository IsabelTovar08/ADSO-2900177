// Con parámetros
function funcionTabla( pnum, pmult) {
    let contador = 0;
    let tabla = pmult;
    let numero = pnum;
    let resultado = 0;

    while (contador < numero) {
        contador++;
        resultado = tabla * contador;
        console.log(tabla + "x" + contador + "=" + resultado);
    }
}
// como expresión
const funcionTablaExp = function (pnum,pmult){
    let contador = 0;
    let tabla = pmult;
    let numero = pnum;
    let resultado = 0;

    while(contador<numero){
        contador++;
        resultado=tabla*contador;
        console.log(tabla+"x"+contador+"="+resultado);
    }
}