/**
 * Bingo con Arreglos
 * Autor: María Isabel Tovar Pastrana
 * Fecha: 08/05/2024
 */

let bingo = [];
let iteracion1;
let iteracion2;
let contador = 0;
let tabla;
let cantPares=0;
let cantImpares=0;
let letraB=[];
let letraI=[];
let letraN=[];
let letraG=[];
let letraO=[];
let primeraX=[];
let segundaX=[];
let terceraX = [];
let ultimaX = [];

for (iteracion1 = 0; iteracion1 < 5; iteracion1++) {
    let interno = [];
    for (iteracion2 = 0; iteracion2 < 5; iteracion2++) {
        contador=contador+1;
        tabla=contador*3;
        interno.push(tabla);
    }
    bingo.push(interno);
}
console.log(bingo);

for (iteracion1 = 0; iteracion1 < 5; iteracion1++) {
    for (iteracion2 = 0; iteracion2 < 5; iteracion2++) {
        if(bingo[iteracion1][iteracion2]%2 == 0) {
            cantPares=cantPares+1;
        }else{
            cantImpares=cantImpares+1;
        }
    }
}

console.log("Cantidad de Números Pares: " + cantPares);
console.log("Cantidad de Números Impares: " + cantImpares);

// LETRA B
for(iteracion1=0; iteracion1<5; iteracion1++){
    letraB.push(bingo[iteracion1][0]);
}
console.log("Letra B "+letraB);

// LETRA I
for(iteracion1=0; iteracion1<5; iteracion1++){
    letraI.push(bingo[iteracion1][1]);
}
console.log("Letra I "+letraI);

// LETRA N
for(iteracion1=0; iteracion1<5; iteracion1++){
    letraN.push(bingo[iteracion1][2]);
}
console.log("Letra N "+letraN);

// LETRA G
for(iteracion1=0; iteracion1<5; iteracion1++){
    letraG.push(bingo[iteracion1][3]);
}
console.log("Letra G "+letraG);

// LETRA O
for(iteracion1=0; iteracion1<5; iteracion1++){
    letraO.push(bingo[iteracion1][4]);
}
console.log("Letra O "+letraO);

// Última x

for (let ciclo1 = 0; ciclo1 < 5; ciclo1++) {
    ultimaX.push(bingo[ciclo1][ciclo1]);
    ultimaX.push(bingo[ciclo1][5 - 1 - ciclo1]);
   
}
ultimaX.sort((a, b) => a - b);
console.log("X Principal: "+ultimaX);


// Primera x
for(let ciclo1=0; ciclo1<3; ciclo1++){
    resultado=primeraX.push(bingo[ciclo1][ciclo1 + 1]);
    resultado=primeraX.push(bingo[ciclo1][3-ciclo1]);   
}

primeraX.sort((a, b) => a - b);
console.log("Primera X: "+primeraX);


// Segunda x
for(let ciclo1=0; ciclo1<3; ciclo1++){
    segundaX.push(bingo[ciclo1+2][ciclo1]);
    segundaX.push(bingo[ciclo1+2][2-ciclo1]);
}
segundaX.sort((a, b) => a - b);
console.log("Segunda X: "+segundaX);


// Tercera x
for(let ciclo1=0; ciclo1<3; ciclo1++){
    terceraX.push(bingo[ciclo1+2][ciclo1+2]);
    terceraX.push(bingo[ciclo1+2][5-1-ciclo1]);
}

terceraX.sort((a, b) => a - b);
console.log("Tercera X: "+terceraX);
