// Con parámetros
function edad(pfechaNac){
    let fechaAct = 2024;
    let fechaNac = pfechaNac;
    let edad;
    edad = fechaAct - fechaNac;
    if(edad>=18){
        return "Es mayor de edad, tiene "+edad+ " años.";
     }else{
         return "Es menor de edad, tiene "+edad+ " años.";
     }
}
// Como expresion
const edadExp = function(pfechaNac) {
    let fechaAct = 2024;
    let fechaNac = pfechaNac;
    let edad;
    edad = fechaAct - fechaNac;
    if(edad>=18){
        return "Es mayor de edad, tiene "+edad+ " años.";
     }else{
         return "Es menor de edad, tiene "+edad+ " años.";
     }
}
