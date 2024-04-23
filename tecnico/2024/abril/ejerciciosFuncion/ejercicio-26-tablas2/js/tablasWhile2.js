// Con parámetros
function tablasMultiplicarDos(pnum){
    let numero = pnum;
    let tabla = 0;
    let multiplicar;
    let resultado = 0;
    let par = 0;
    let impar = 0;
    while(tabla < numero){
        tabla++;
        multiplicar = 0;
        while (multiplicar < numero){
            resultado = tabla *(multiplicar+1);
            console.log(tabla+" x "+(multiplicar+1)+" = "+resultado);
            if(resultado %2 == 0){
                par++;
                console.log("buzz");
            }
                else{
                    impar++;
                    console.log("bass");
                }
                multiplicar++;
        }
    }
    console.log("Total pares: "+par);
    console.log("Total impares: "+impar);
}
// como expresión
function tablasMultiplicarDosExp(pnum){
    let numero = pnum;
    let tabla = 0;
    let multiplicar;
    let resultado = 0;
    let par = 0;
    let impar = 0;
    while(tabla < numero){
        tabla++;
        multiplicar = 0;
        while (multiplicar < numero){
            resultado = tabla *(multiplicar+1);
            console.log(tabla+" x "+(multiplicar+1)+" = "+resultado);
            if(resultado %2 == 0){
                par++;
                console.log("buzz");
            }
                else{
                    impar++;
                    console.log("bass");
                }
                multiplicar++;
        }
    }
    console.log("Total pares: "+par);
    console.log("Total impares: "+impar);
}