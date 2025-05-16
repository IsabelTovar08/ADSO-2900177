/**
 * Ejercicio de arreglos Llave:valor - key:valor
 * 15 de Mayo de 2024
 * Autor: María Isabel Tovar Pastrana
 */

let factura = [];
let valorTotal;
let iteracion;
let totalProducto;
let totalPagar = [];

factura=[
    {codigo:1, nombreProducto:'Malteada', cantidad:2, valorUnidad:12000},
    {codigo:2, nombreProducto:'Picada', cantidad:3, valorUnidad:25000},
    {codigo:3, nombreProducto:'Hamburguesa Mixta', cantidad:4, valorUnidad:16000},
    {codigo:4, nombreProducto:'Churrasco', cantidad:3, valorUnidad:25000},
    {codigo:5, nombreProducto:'Gaseosa', cantidad:5, valorUnidad:5000},
    {codigo:6, nombreProducto:'Limonada', cantidad:5, valorUnidad:6000}
];
// valorTotal = factura[3].cantidad * factura[3].valorUnidad;
// console.log(factura[3].nombreProducto);
// console.log("Valor Total: "+valorTotal)

for(iteracion=0; iteracion<factura.length; iteracion++){
    totalProducto = factura[iteracion].cantidad * factura[iteracion].valorUnidad;
    totalPagar.push({nombreProducto:factura[iteracion].nombreProducto, cantidad:factura[iteracion].cantidad, valorUnidad:factura[iteracion].valorUnidad, valorTotal:totalProducto})
}
console.log(totalPagar);