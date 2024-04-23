let nota1;
let nota2;
let nota3;

// Con parámetros
function promedio(pnota1,pnota2,pnota3){
    nota1 = pnota1;
    nota2 = pnota2;
    nota3 = pnota3; 
    let resultado;
    resultado = (nota1 + nota2 + nota3)/3;
    return resultado;
}
// Como expresión
const promedioExp = function(pnota1,pnota2,pnota3){
    nota1 = pnota1;
    nota2 = pnota2;
    nota3 = pnota3; 
    let resultado;
    resultado = (nota1 + nota2 + nota3)/3;
    return resultado;
}