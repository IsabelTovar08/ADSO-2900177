/**
 * Funcion Áreas de tres cuadrados
 * Autor: María Isabel Tovar Pastrana
 * Fecha: 26 de Junio del 2024
 */
function areaCuadrados(){
    let ladoUno = parseInt(document.getElementById("txtLadoUno").value);
    let ladoDos = parseInt(document.getElementById("txtLadoDos").value);
    let ladoTres = parseInt(document.getElementById("txtLadoTres").value);
    let mayor;
    let mensaje;
    let areaUno = areaCuadrado(ladoUno);
    let areaDos = areaCuadrado(ladoDos);
    let areaTres = areaCuadrado(ladoTres);
    

   
    if(areaUno!=areaDos || areaDos!=areaTres || areaUno!=areaTres){
        if(areaUno>areaDos && areaUno>areaTres){
            mayor = areaUno;
            mensaje = "El área del cuadrado uno: "+areaUno+" es mayor."
        }
        else{
            if (areaDos>areaUno && areaDos>areaTres) {
                mayor = areaDos;
                mensaje = "El área del cuadrado dos: "+areaDos+" es mayor."
            } else {
                mayor = areaTres;
                mensaje = "El área del cuadrado tres: "+areaTres+" es mayor."
            }
        }
    }
    if(areaUno==areaDos && areaDos!=areaTres){
        mensaje = "Área uno y área dos son iguales. El mayor es: "+mayor
    }
    else if(areaUno==areaTres && areaDos!=areaTres){
        mensaje = "Área uno y área tres son iguales. El mayor es: "+mayor
    }
    else if(areaDos==areaTres && areaUno!=areaTres){
        mensaje = "Área dos y área tres son iguales. El mayor es: "+mayor
    }
    else{
        mensaje = "Las tres áreas son iguales."
    }

    document.getElementById('mayor').innerHTML =
    `El área uno es: <strong>${areaUno}</strong><br>
    El area dos es: <strong>${areaDos}</strong><br>
    El área tres es; <strong>: ${areaTres}</strong><br>
    ${mensaje}`;
    return false;
}
function areaCuadrado(plado){
    let lado = plado;
    let cuad;
    cuad = lado**2;
    return  cuad ;
}