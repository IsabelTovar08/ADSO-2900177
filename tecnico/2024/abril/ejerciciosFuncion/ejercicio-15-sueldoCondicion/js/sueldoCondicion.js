let SMMLV = 1300000;
// Con parámetros
function salario(pdias,pvalor){
    let diasTrabaj = pdias;
    let valor = pvalor;
    let sueldo;
    sueldo = diasTrabaj*valor;
    return sueldo; 
}
function condicionTrans(pdias,pvalor){
    let SMMLV = 1300000;
    let sueldo = salario(pdias,pvalor);
    let subTransporte;
    if(sueldo<=2*SMMLV){
        return subTransporte=114000;
    }else{
        return subTransporte=0;
    }
}
function condicionRetencion(pdias,pvalor) {
    let SMMLV = 1300000;
    let sueldo = salario(pdias,pvalor);
    let retencion;
    if(sueldo>=4*SMMLV){
       return retencion=sueldo*0.04;
    }
    else{
        return retencion=0;
    }
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
const descuentos = function(pdias,pvalor){
    let saludT =  salud(pdias,pvalor);
    let pensionT = pension(pdias,pvalor); 
    let arlT = arl(pdias,pvalor);
    let retencion = condicionRetencion(pdias,pvalor);
    let descuento;
    descuento=saludT+pensionT+arlT+retencion;
    return descuento;
}
function sueldoTotal(pdias,pvalor) {
    let sueldo = salario(pdias,pvalor);
    let descuento = descuentos(pdias,pvalor);
    let subTransporte = condicionTrans(pdias,pvalor);
    let total;
    total=(sueldo-descuento)+subTransporte;
    return total;
}
// Como expresión
const salarioExp = function (pdias,pvalor){
    let diasTrabaj = pdias;
    let valor = pvalor;
    let sueldo;
    sueldo = diasTrabaj*valor;
    return sueldo; 
}
const condicionTransExp = function (pdias,pvalor){
    let SMMLV = 1300000;
    let sueldo = salario(pdias,pvalor);
    let subTransporte;
    if(sueldo<=2*SMMLV){
        return subTransporte=114000;
    }else{
        return subTransporte=0;
    }
}
const condicionRetencionExp = function (pdias,pvalor) {
    let SMMLV = 1300000;
    let sueldo = salario(pdias,pvalor);
    let retencion;
    if(sueldo>=4*SMMLV){
       return retencion=sueldo*0.04;
    }
    else{
        return retencion=0;
    }
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
const descuentosExp = function (pdias,pvalor){
    let saludT =  salud(pdias,pvalor);
    let pensionT = pension(pdias,pvalor); 
    let arlT = arl(pdias,pvalor);
    let retencion = condicionRetencion(pdias,pvalor);
    let descuento;
    descuento=saludT+pensionT+arlT+retencion;
    return descuento;
}
const sueldoTotalExp = function (pdias,pvalor) {
    let sueldo = salario;
    let descuento = descuentos(pdias,pvalor);
    let subTransporte = condicionTrans(pdias,pvalor);
    let total;
    total=(sueldo-descuento)+subTransporte;
    return total;
}