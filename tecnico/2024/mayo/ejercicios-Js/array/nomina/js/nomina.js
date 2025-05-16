/**
 * Nómina con Arrays
 * 15 de Mayo de 2024
 * Autor: María Isabel Tovar Pastrana
 */

let nomina = [];
let pagoNomina = [];
let sueldo;
let salud;
let pension;
let arl;
let retencion;
let retencionMayor;
let transporte;
let valorAbono;
let retencionEstato;
let deducibles;
let abonosTotales;
let sueldoTotalPagar;

nomina=[
    {id:1, cedula:7777777, nombres:'Andrés',apellidos:'MN', edad:44, estrato:6, valorDia:500000, diasTrabaj: 30},
    {id:2, cedula:1084866876, nombres:'Maria Isabel',apellidos:'Tovar Pastrana', edad:17, estrato:2, valorDia:25000, diasTrabaj: 30},
    {id:3, cedula:187540976, nombres:'Sergio Andrés',apellidos:'Leguizamo', edad:17, estrato:1, valorDia:10000, diasTrabaj: 30},
    {id:4, cedula:6789865437, nombres:'Andrés Mauricio',apellidos:'Noscue Cerquera', edad:17, estrato:2, valorDia:30000, diasTrabaj: 30},
    {id:5, cedula:1084866876, nombres:'Jhoan Camilo',apellidos:'Charry', edad:21, estrato:2, valorDia:35000, diasTrabaj: 30},
    {id:6, cedula:1097654356, nombres:'Jesus Fernando',apellidos:'Carvajal', edad:18, estrato:2, valorDia:40000, diasTrabaj: 30},
    {id:7, cedula:1345685432, nombres:'Juan Manuel',apellidos:'Gutierrez', edad:17, estrato:2, valorDia:38000, diasTrabaj: 30},
    {id:8, cedula:1787567909, nombres:'Isabella',apellidos:'Carrera', edad:17, estrato:3, valorDia:50000, diasTrabaj: 30},
    {id:9, cedula:1567867265, nombres:'Natalia',apellidos:'Osorio', edad:17, estrato:2, valorDia:42000, diasTrabaj: 30},
    {id:10, cedula:1084866876, nombres:'Santiago',apellidos:'Chaparro', edad:17, estrato:2, valorDia:50000, diasTrabaj: 30},
];
// Salario
function salario(pdias,pvalor){
    let diasTrabaj = pdias;
    let valor = pvalor;
    let sueldo;
    sueldo = diasTrabaj*valor;
    return sueldo; 
}

// Salud
function saludFunct(pdias,pvalor){
    let sueldo = salario(pdias,pvalor);
    let saludT;
    saludT=(sueldo*0.12);
    return saludT;
}
// Pension
function pensionFunct(pdias,pvalor) {
    let sueldo = salario(pdias,pvalor);
    let pensionT;
    pensionT=(sueldo*0.16);
    return pensionT;
}
// Arl
function arlFunct(pdias,pvalor){
    let sueldo = salario(pdias,pvalor);
    let arlT;
    arlT=(sueldo*0.052);
    return arlT;
}

// Retenciones
function condicionRetencion(pdias,pvalor) {
    let SMMLV = 1300000;
    let sueldo = salario(pdias,pvalor);
    let retencion;
    if(sueldo>=4*SMMLV){
       return retencion=sueldo*0.03;
    }
    else{
        return retencion=0;
    }
}
function condicionRetencionMayor(pdias,pvalor) {
    let SMMLV = 1300000;
    let sueldo = salario(pdias,pvalor);
    let retencion;
    if(sueldo>=6*SMMLV){
       return retencion=sueldo*0.04;
    }
    else{
        return retencion=0;
    }
}
function condicionRetencionEstrato(pdias,pvalor, pestrato) {
    let SMMLV = 1300000;
    let sueldo = salario(pdias,pvalor);
    let estrato = pestrato;
    let retencion;
    if(sueldo>=8*SMMLV && estrato==6){
       return retencion=sueldo*0.05;
    }
    else{
        return retencion=0;
    }
}

// Transporte
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

// Abono
function condicionAbonos(pdias,pvalor,pestrato){
    let SMMLV = 1300000;
    let sueldo = salario(pdias,pvalor);
    let estrato = pestrato;
    let abonos;
    if(sueldo<=SMMLV && estrato==1 || estrato==2){
        return abonos=100000;
    }else{
        return abonos=0;
    }
}
// Abonos Totales
function abonoTotal(pdias,pvalor,pestrato){
    let subTransporte = condicionTrans(pdias,pvalor);
    let abono = condicionAbonos(pdias,pvalor,pestrato);
    let totalAbonos;
    totalAbonos =  subTransporte+abono;
    return totalAbonos;
}
// Total Deducibles
const descuentos = function(pdias,pvalor,pestrato){
    let saludT =  saludFunct(pdias,pvalor);
    let pensionT = pensionFunct(pdias,pvalor); 
    let arlT = arlFunct(pdias,pvalor);
    let retencion = condicionRetencion(pdias,pvalor);
    let retencionMayor = condicionRetencionMayor(pdias,pvalor);
    let retencionEstato = condicionRetencionEstrato(pdias,pvalor, pestrato);
    let descuento;
    descuento=saludT+pensionT+arlT+retencion+retencionMayor+retencionEstato;
    return descuento;
}
// Sueldo Total a Pagar
function sueldoTotal(pdias,pvalor,pestrato) {
    let sueldo = salario(pdias,pvalor);
    let descuento = descuentos(pdias,pvalor,pestrato);
    let abonos = abonoTotal(pdias,pvalor,pestrato);
    let total;
    total=(sueldo-descuento)+abonos;
    return total;
}
// Mostrar Datos
for(iteracion=0; iteracion<nomina.length; iteracion++){
    sueldo = salario(nomina[iteracion].valorDia,nomina[iteracion].diasTrabaj);
    salud = saludFunct(nomina[iteracion].valorDia,nomina[iteracion].diasTrabaj);
    pension = pensionFunct(nomina[iteracion].valorDia,nomina[iteracion].diasTrabaj);
    arl = arlFunct(nomina[iteracion].valorDia,nomina[iteracion].diasTrabaj);
    retencion = condicionRetencion(nomina[iteracion].valorDia,nomina[iteracion].diasTrabaj);
    retencionMayor = condicionRetencionMayor(nomina[iteracion].valorDia,nomina[iteracion].diasTrabaj);
    retencionEstato = condicionRetencionEstrato(nomina[iteracion].valorDia,nomina[iteracion].diasTrabaj,nomina[iteracion].estrato);
    transporte = condicionTrans(nomina[iteracion].valorDia,nomina[iteracion].diasTrabaj);
    valorAbono = condicionAbonos(nomina[iteracion].valorDia,nomina[iteracion].diasTrabaj,nomina[iteracion].estrato);
    deducibles = descuentos(nomina[iteracion].valorDia,nomina[iteracion].diasTrabaj,nomina[iteracion].estrato);
    abonosTotales = abonoTotal(nomina[iteracion].valorDia,nomina[iteracion].diasTrabaj,nomina[iteracion].estrato);
    sueldoTotalPagar = sueldoTotal(nomina[iteracion].valorDia,nomina[iteracion].diasTrabaj,nomina[iteracion].estrato);
    pagoNomina.push({
        datosNombres:nomina[iteracion].nombres, 
        datosApellidos:nomina[iteracion].apellidos, 
        edad:nomina[iteracion].edad, 
        estrato:nomina[iteracion].estrato,
        dvalorDia:nomina[iteracion].valorDia,
        diasTrabaj:nomina[iteracion].diasTrabaj,
        sueldo:sueldo,
        valorSalud:salud,
        valorPension:pension,
        valorArl:arl,
        retencion:retencion,
        retencionMayor:retencionMayor,
        retencionEstato:retencionEstato,
        transporte:transporte,
        abono:valorAbono,
        deducibles:deducibles,
        abonosTotales:abonosTotales,
        totalPagar:sueldoTotalPagar
    })
}
console.log(pagoNomina);