/**
 * Ejercicio Arreglos
 * Autor: María Isabel Tovar Pastrana
 * Fecha: 08/05/2024
 */

let arreglo = [];
let numeroDatos;
let iteracion;
let datosArreglo = "";

arreglo = [2,4,6,8,10,12,14,16];

numeroDatos = arreglo.length;
console.log("Valores iniciales: "+arreglo);
console.log("Numero de Datos: "+numeroDatos);

arreglo.push(18);
arreglo.push(20);
arreglo.push(22);

numeroDatos = arreglo.length;
console.log("Valores finales: "+arreglo);
console.log("Numero de Datos: "+numeroDatos);

for(iteracion=0; iteracion<numeroDatos; iteracion++){
    console.log("Datos "+iteracion+" : "+arreglo[iteracion]);
    datosArreglo+="Datos "+iteracion+" : "+arreglo[iteracion]+"\n";
}
alert(datosArreglo);