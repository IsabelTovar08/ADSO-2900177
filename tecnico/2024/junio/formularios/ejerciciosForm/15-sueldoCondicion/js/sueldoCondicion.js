/**
 * Funcion Sueldo de una persona
 * Autor: María Isabel Tovar Pastrana
 * Fecha: 26 de Junio del 2024
 */
function sueldoCondicion(){
    let diasTrabajados = parseInt(document.getElementById('txtDias').value);
    let valorDia = parseFloat(document.getElementById('txtValor').value);
    let sueldo;
    let salud;
    let pension;
    let arl;
    let transporte;
    let retencion;
    let descuento;
    let total;

    sueldo = salario(diasTrabajados,valorDia);
    salud = saludF(diasTrabajados,valorDia);
    pension = pensionF(diasTrabajados,valorDia);
    arl = arlF(diasTrabajados,valorDia);
    transporte = condicionTrans(diasTrabajados,valorDia);
    retencion = condicionRetencion(diasTrabajados,valorDia);
    descuento = descuentosF(diasTrabajados,valorDia);
    total = sueldoTotalF(diasTrabajados,valorDia);
    
    document.getElementById('sueldo').innerHTML =
    `Sueldo: <strong>${sueldo}</strong><br>
    Salud: <strong>${salud}</strong><br>
    Pensión: <strong>${pension}</strong><br>
    ARL: <strong>${arl}</strong><br>
    Transporte: <strong>${transporte}</strong><br>
    Retención: <strong>${retencion}</strong><br>
    Descuento: <strong>${descuento}</strong><br>
    <strong>TOTAL: ${total}</strong><br>`;
    return false;
}
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
function saludF(pdias,pvalor){
    let sueldo = salario(pdias,pvalor);
    let saludT;
    saludT=(sueldo*0.12);
    return saludT;
}
function pensionF(pdias,pvalor) {
    let sueldo = salario(pdias,pvalor);
    let pensionT;
    pensionT=(sueldo*0.16);
    return pensionT;
}
function arlF(pdias,pvalor){
    let sueldo = salario(pdias,pvalor);
    let arlT;
    arlT=(sueldo*0.052);
    return arlT;
}
function descuentosF(pdias,pvalor){
    let saludT =  saludF(pdias,pvalor);
    let pensionT = pensionF(pdias,pvalor); 
    let arlT = arlF(pdias,pvalor);
    let retencion = condicionRetencion(pdias,pvalor);
    let descuento;
    descuento=saludT+pensionT+arlT+retencion;
    return descuento;
}
function sueldoTotalF(pdias,pvalor) {
    let sueldo = salario(pdias,pvalor);
    let descuento = descuentosF(pdias,pvalor);
    let subTransporte = condicionTrans(pdias,pvalor);
    let total;
    total=(sueldo-descuento)+subTransporte;
    return total;
}