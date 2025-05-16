let num1;
let num2;
// Con parámetros
function numMayor(pnum1,pnum2){
    num1 = pnum1;
    num2 = pnum2;
     if (num1 > num2) {
        return "El número mayor es: "+num1+ " el número uno.";
     } else {
        return "El número mayor es: "+num2+ " el número dos.";
     }  
}
// Como expresion
const numMayorExp = function(pnum1,pnum2){
    num1 = pnum1;
    num2 = pnum2;
     if (num1 > num2) {
        return "El número mayor es: "+num1+ " el número uno.";
     } else {
        return "El número mayor es: "+num2+ " el número dos.";
     }  
}
