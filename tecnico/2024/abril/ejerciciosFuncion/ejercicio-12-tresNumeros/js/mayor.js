let num1;
let num2;
let num3;
// Con parámetros
function numMayor(pnum1,pnum2,pnum3){
    num1 = pnum1;
    num2 = pnum2;
    num3 = pnum3;
    if  (num1 != num2 && num2 != num3 && num1 != num3) { 
        if (num1 > num2 &&  num1 > num3) {
            return "El número mayor es: "+num1+ " el número uno.";
         } else if (num2>num1 && num2>num3) {
            return "El número mayor es: "+num2+ " el número dos.";
         } 
         else{
             return "El número mayor es: "+num3 +" el número tres.";  
         }
     }else{
       return "Los números son iguales";
    }
}
// Como expresion
const numMayorExp = function(pnum1,pnum2,pnum3){
    num1 = pnum1;
    num2 = pnum2;
    num3 = pnum3;
    if  (num1 != num2 && num2 != num3 && num1 != num3) { 
        if (num1 > num2 &&  num1 > num3) {
            return "El número mayor es: "+num1+ " el número uno.";
         } else if (num2>num1 && num2>num3) {
            return "El número mayor es: "+num2+ " el número dos.";
         } 
         else{
             return "El número mayor es: "+num3 +" el número tres.";  
         }
     }else{
       return "Los números son iguales";
    }
}