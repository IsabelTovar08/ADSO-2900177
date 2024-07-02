/**
 * Funcion Sueldo de una persona
 * Autor: María Isabel Tovar Pastrana
 * Fecha: 26 de Junio del 2024
 */
function sueldoCondicion(){
    let diasTrabajados = parseInt(document.getElementById('txtDias').value);
    let valorDia = parseInt(document.getElementById('txtValor').value);
    let sueldo;
    let salud;
    let pension;
    let arl;
    let transporte;
    let retencion;
    let descuento;
    let total;

    sueldo = salario(diasTrabajados*valorDia);
    salud = sueldo*0.12;
    pension = sueldo*0.16;
    arl = sueldo*0.052;
    transporte = condicionTrans(diasTrabajados,valorDia);
    retencion = condicionRetencion(diasTrabajados,valorDia);
    descuento = salud+pension+arl+retencion;
    total = (sueldo-descuento)+transporte;
    
    document.getElementById('sueldo').innerHTML =
    `Sueldo: <strong>${sueldo}</strong><br>
    Salud: <strong>${salud}</strong><br>
    Pensión: <strong>${pension}</strong><br>
    ARL: <strong>${arl}</strong><br>
    Transporte: <strong>${transporte}</strong><br>
    Retención: <strong>${retencion}</strong><br>
    Descuento: <strong>${descuento}</strong><br>
    <strong>TOTAL: ${total}</strong><br></br>`;
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
         subTransporte=114000;
    }else{
         subTransporte=0;
    }
}
function condicionRetencion(pdias,pvalor) {
    let SMMLV = 1300000;
    let sueldo = salario(pdias,pvalor);
    let retencion;
    if(sueldo>=4*SMMLV){
        retencion=sueldo*0.04;
    }
    else{
         retencion=0;
    }
}