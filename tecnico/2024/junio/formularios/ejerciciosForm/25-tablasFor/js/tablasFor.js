/**
 * Funcion Total Tablas ciclo For
 * Autor: María Isabel Tovar Pastrana
 * Fecha: 06 de Julio del 2024
 */
function tablas() {
    let numero = parseInt(document.getElementById('txtNumero').value);
    let tabla = parseInt(document.getElementById('txtTabla').value);
    let resultado = tablasMult(tabla,numero);

    document.getElementById('resultado').innerHTML = resultado;
    return false;
}
function tablasMult(limiteTabla,limiteMult){
    let tabla = limiteTabla;
    let multiplicar = limiteMult;
    let resultado = 0;
    let par = 0;
    let impar = 0;
    let respuesta = "";

    if ((isNaN(tabla) || tabla < 1) || (isNaN(multiplicar) || multiplicar < 1)) {
        return "Por favor, introduce un número válido.";
    }else{
        for(let ctabla = 1; ctabla <= tabla; ctabla++){
            for(let cMult=1; cMult<=multiplicar; cMult++){
                resultado=ctabla * cMult;
                if (resultado%2==0){
                    par=par+1;
                    respuesta += ctabla+"x"+cMult+"="+resultado+" Es par. Buzz" + '<br>';
                }else{
                    impar=impar+1;
                    respuesta += ctabla+"x"+cMult+"="+resultado+" Es impar. Bass" + '<br>';
                }
            }
        }
        return respuesta + '<br>' + "Hay "+par+" numeros pares y "+impar+" numeros impares.";

    }
}   