// Con parámetros
function edad(pfechaNac){
    let fechaAct = 2024;
    let fechaNac = pfechaNac;
    let edad;
    edad = fechaAct - fechaNac;
    return edad;
} 
function mayor(edadp){
    let edad = edadp;
    if(edad>=18){
        return "Es mayor de edad, tiene "+edad+ " años.";
     }else{
         return "Es menor de edad, tiene "+edad+ " años.";
     }
}
function promedioEdad(psuma){
    let suma = psuma;
    let promedio = suma/3;
    if(promedio>=18){
        return ("El promedio es mayor de edad: "+promedio);
    }else{
        return ("El promedio es menor de edad: "+promedio);
    }
}
// Como expresión
const edadExp = function (pfechaNac){
    let fechaAct = 2024;
    let fechaNac = pfechaNac;
    let edad;
    edad = fechaAct - fechaNac;
    return edad;
} 
const mayorExp = function (edadp){
    let edad = edadp;
    if(edad>=18){
        return "Es mayor de edad, tiene "+edad+ " años.";
     }else{
         return "Es menor de edad, tiene "+edad+ " años.";
     }
}
const promedioEdadExp = function (psuma){
    let suma = psuma;
    let promedio = suma/3;
    if(promedio>=18){
        return ("El promedio es mayor de edad: "+promedio);
    }else{
        return ("El promedio es menor de edad: "+promedio);
    }
}