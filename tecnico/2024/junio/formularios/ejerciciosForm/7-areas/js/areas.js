/**
 * Funcion Área Figuras
 * Autor: María Isabel Tovar Pastrana
 * Fecha: 24 de Junio del 2024
 */
function areaFiguras(){
    let ladoCuadradoo = parseInt(document.getElementById('txtLadoCuadrado').value);
    let baseRectanguloo = parseInt(document.getElementById('txtBaseRectangulo').value);
    let alturaRectanguloo = parseInt(document.getElementById('txtAlturaRectangulo').value);
    let baseTrianguloo = parseInt(document.getElementById('txtBaseTriangulo').value);
    let alturaTrianguloo = parseInt(document.getElementById('txtAlturaTriangulo').value);
    

    let cuadradoo = areaC(ladoCuadradoo);
    let rectanguloo = areaR(baseRectanguloo, alturaRectanguloo);
    let trianguloo = areaT(baseTrianguloo, alturaTrianguloo);

    document.getElementById('areas').innerHTML =
    `Cuadrado: <strong>${cuadradoo}</strong><br>
    Rectángulo: <strong>${rectanguloo}</strong><br>
    Tiángulo: <strong>${trianguloo}</strong><br>`;
    return false;
}
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