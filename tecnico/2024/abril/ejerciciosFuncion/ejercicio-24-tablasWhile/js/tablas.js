// Con parámetros
function tablasMult(limiteTabla,limiteMult){
    let ctabla = 0;
    let tabla = limiteTabla;
    let cMult;
    let multiplicar = limiteMult;
    let resultado = 0;
    let par = 0;
    let impar = 0;

    while(ctabla<tabla){
        cMult=0;
        ctabla=ctabla+1;
        while (cMult<multiplicar){
            cMult=cMult+1;
            resultado=ctabla*cMult;
            if (resultado%2==0){
                par=par+1;
                console.log(ctabla+"x"+cMult+"="+resultado+" Es par. Buzz");
            }else{
                impar=impar+1;
                console.log(ctabla+"x"+cMult+"="+resultado+" Es impar. Bass");
            }
        }
    }
    console.log("Hay "+par+" numeros pares y "+impar+" numeros impares.");
}
// Como expresión
const tablasMultExp = function (limiteTabla,limiteMult){
    let ctabla = 0;
    let tabla = limiteTabla;
    let cMult;
    let multiplicar = limiteMult;
    let resultado = 0;
    let par = 0;
    let impar = 0;

    while(ctabla<tabla){
        cMult=0;
        ctabla=ctabla+1;
        while (cMult<multiplicar){
            cMult=cMult+1;
            resultado=ctabla*cMult;
            if (resultado%2==0){
                par=par+1;
                console.log(ctabla+"x"+cMult+"="+resultado+" Es par. Buzz");
            }else{
                impar=impar+1;
                console.log(ctabla+"x"+cMult+"="+resultado+" Es impar. Bass");
            }
        }
    }
    console.log("Hay "+par+" numeros pares y "+impar+" numeros impares.");
}

function par(par){
    console.log(ctabla+"x"+cMult+"="+resultado+" Es par. Buzz");
    par ++;
} 