// Con parámetros
function salario(pdias,pvalor){
    let diasTrabaj = pdias;
    let valor = pvalor;
    let sueldo;
    sueldo = diasTrabaj*valor;
    return sueldo; 
}
function salud(pdias,pvalor){
    let sueldo = salario(pdias,pvalor);
    let saludT;
    saludT=(sueldo*0.12);
    return saludT;
}
function pension(pdias,pvalor) {
    let sueldo = salario(pdias,pvalor);
    let pensionT;
    pensionT=(sueldo*0.16);
    return pensionT;
}
function arl(pdias,pvalor){
    let sueldo = salario(pdias,pvalor);
    let arlT;
    arlT=(sueldo*0.052);
    return arlT;
}
function sueldoTotal(pdias,pvalor) {
    let sueldo = salario(pdias,pvalor);
    let saludT =  salud(sueldo);
    let pensionT = pension(sueldo); 
    let arlT = arl(sueldo);
    let total;
    total=sueldo-(saludT+pensionT+arlT);
    return total;
}

// Como expresión
const salarioExp = function(pdias,pvalor){
    let diasTrabaj = pdias;
    let valor = pvalor;
    let sueldo;
    sueldo = diasTrabaj*valor;
    return sueldo; 
}
const saludExp = function(pdias,pvalor){
    let sueldo = salario(pdias,pvalor);
    let saludT;
    saludT=(sueldo*0.12);
    return saludT;
}
const pensionExp = function(pdias,pvalor) {
    let sueldo = salario(pdias,pvalor);
    let pensionT;
    pensionT=(sueldo*0.16);
    return pensionT;
}
const arlExp = function(pdias,pvalor){
    let sueldo = salario(pdias,pvalor);
    let arlT;
    arlT=(sueldo*0.052);
    return arlT;
}
const sueldoTotalExp = function(pdias,pvalor) {
    let sueldo = salario(pdias,pvalor);
    let saludT =  salud(sueldo);
    let pensionT = pension(sueldo); 
    let arlT = arl(sueldo);
    let total;
    total=sueldo-(saludT+pensionT+arlT);
    return total;
}