// Con parámetros
function areaC(pladoCuad){
    let ladoCuadrado = pladoCuad;
    let cuadrado;
    cuadrado = ladoCuadrado*ladoCuadrado;
    return  cuadrado ;
}
function areaR(pbaseRec,palturaRec){
    let baseRectangulo = pbaseRec;
    let alturaRectangulo = palturaRec;
    let rectangulo;
    rectangulo = (baseRectangulo*alturaRectangulo)/2;
    return rectangulo;
}
function areaT(pbaseTri,palturaTri){
    let baseTriangulo = pbaseTri;
    let alturaTriangulo = palturaTri;
    let triangulo;
    triangulo = (baseTriangulo*alturaTriangulo)/2;
    return triangulo;
}

// Como expresión
const areaCExp = function (pladoCuad){
    let ladoCuadrado = pladoCuad;
    let cuadrado;
    cuadrado = ladoCuadrado*ladoCuadrado;
    return  cuadrado ;
}
const areaRExp =  function(pbaseRec,palturaRec){
    let baseRectangulo = pbaseRec;
    let alturaRectangulo = palturaRec;
    let rectangulo;
    rectangulo = (baseRectangulo*alturaRectangulo)/2;
    return rectangulo;
}
const areaTExp =  function(pbaseTri,palturaTri){
    let baseTriangulo = pbaseTri;
    let alturaTriangulo = palturaTri;
    let triangulo;
    triangulo = (baseTriangulo*alturaTriangulo)/2;
    return triangulo;
}
