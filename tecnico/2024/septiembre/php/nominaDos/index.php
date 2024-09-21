<?php
    include('libreria/nomina.php');

    $valores = new datosNomina();
    $nomina = new nomina();
    $valores -> setDiasTrabajados(20);
    $valores -> setValorDia(1000);

    $nomina -> calcularSalario($valores->getDiasTrabajados(),$valores->getValorDia());
?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
</head>
<body>
    <?php
        echo "Salario: ".$nomina -> calcularSalario($valores->getDiasTrabajados(),$valores->getValorDia())."<br>";
        echo "salud: ".$nomina->calcularSalud()."<br>";
        echo "pension: ".$nomina->calcularPension()."<br>";
        echo "arl: ".$nomina->calcularArl()."<br>";
        echo "transporte: ". $nomina->calcularTransporte()."<br>";
        echo "retencion: ".$nomina->calcularRetencion()."<br>";
        echo "descuento: ".$nomina->calcularDescuento()."<br>";
        echo "Pago total: ".$nomina->calcularPagoTotal()."<br>";
    ?>
</body>
</html>