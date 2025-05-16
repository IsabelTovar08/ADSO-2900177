/**
 * Bingo con Arreglos
 * Autor: María Isabel Tovar Pastrana
 * Fecha: 08/05/2024
 */

let tienda=[];
let iteracion;

tienda = [
    {id:1, nombreProduto:'Lentejas', tipoProducto:'granos', cantidad:1000, tipoCantidad:'gramos', precio:2300},
    {id:2, nombreProduto:'frijol', tipoProducto:'granos', cantidad:500, tipoCantidad:'gramos', precio:2300},
    {id:3, nombreProduto:'pollo entero', tipoProducto:'carnes', cantidad:1000, tipoCantidad:'gramos', precio:2300},
    {id:4, nombreProduto:'carne de cerdo', tipoProducto:'carnes', cantidad:500, tipoCantidad:'gramos', precio:2300},
    {id:5, nombreProduto:'mora', tipoProducto:'frutas', cantidad:500, tipoCantidad:'gramos', precio:2300},
    {id:6, nombreProduto:'uvas', tipoProducto:'frutas', cantidad:1000, tipoCantidad:'gramos', precio:2300},
    {id:6, nombreProduto:'tomate', tipoProducto:'verdura', cantidad:500, tipoCantidad:'gramos', precio:2300},
];
console.log(tienda);

for (iteracion = 0; iteracion < tienda.length; iteracion++) {
    // console.log(tienda[iteracion].nombreProduto);
    if(tienda[iteracion].cantidad<=500 && tienda[iteracion].tipoProducto=='granos'){
        console.log("Posición "+iteracion+": ");
        console.log(tienda[iteracion]);
    }else{
        console.log("-");
    }
}