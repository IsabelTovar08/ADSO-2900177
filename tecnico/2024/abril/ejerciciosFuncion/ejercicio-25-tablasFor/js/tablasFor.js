// con parámetros
function tablasFor(limiteTabla,limiteMult){
    let tabla = limiteTabla;
    let multiplicar = limiteMult;
    let resultado = 0;
    let par = 0;
    let impar = 0;

    for(let ctabla = 1; ctabla <= tabla; ctabla++){
        for(let cMult=1; cMult<=multiplicar; cMult++){
            resultado=ctabla * cMult;
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
// como expresión
const tablasForExp = function (limiteTabla,limiteMult){
    let tabla = limiteTabla;
    let multiplicar = limiteMult;
    let resultado = 0;
    let par = 0;
    let impar = 0;

    for(let ctabla = 1; ctabla <= tabla; ctabla++){
        for(let cMult=1; cMult<=multiplicar; cMult++){
            resultado=ctabla * cMult;
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