// Con parámetros
function funcionContar(pnum) {
    let contar = 0;
    let num = pnum;

    while (contar < num) {
        contar++;
        console.log(contar);
    }
}
// Como expresión
const funcionContarExp = function (pnum) {
    let contar = 0;
    let num = pnum;

    while (contar < num) {
        contar++;
        console.log(contar);
    }
}
