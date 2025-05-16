/**
 * Funcion Sueldo de una persona
 * Autor: María Isabel Tovar Pastrana
 * Fecha: 26 de Junio del 2024
 */
function notas(){
    let notaUno = parseFloat(document.getElementById('txtNotaUno').value);
    let notaDos = parseFloat(document.getElementById('txtNotaDos').value);
    let notaTres = parseFloat(document.getElementById('txtNotaTres').value);
    let porcNotaUno = notaUno*0.2;
    let porcNotaDos = notaDos*0.35;
    let porcNotaTres = notaTres*0.45;
    let promedio = porcNotaUno + porcNotaDos + porcNotaTres;
    let total = condicionporcentaje(promedio);

    document.getElementById('notas').innerHTML =
    `La nota uno es: <strong>: ${notaUno}</strong>, equivale a ${porcNotaUno}<br></br>
    La nota dos es: <strong>${notaDos}</strong>, equivale a ${porcNotaDos}<br></br>
    La nota tres es: <strong>${notaTres}</strong>, equivale a ${porcNotaTres}<br></br>
    <strong>${total}</strong>: ${promedio}`;
    return false;
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