<?php
    include('libreria/nomina.php');
    $nomina = new nomina();
    $salario = $nomina -> calcularSalario(30,10000);
    $salud = $nomina -> calcularSalud($salario);
    $pension = $nomina -> calcularPension($salario);
    $arl = $nomina -> calcularArl($salario);
    $transporte = $nomina -> calcularTransporte($salario);
    $retencion = $nomina -> calcularRetencion($salario);
    $descuento = $nomina -> calcularDescuento($salud,$pension,$arl);
    $total = $nomina -> calcularPagoTotal($salario, $transporte, $descuento, $retencion);
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
        echo "Salario: ".$salario."<br>";
        echo "salud: ".$salud."<br>";
        echo "pension: ".$pension."<br>";
        echo "arl: ".$arl."<br>";
        echo "transporte: ". $transporte."<br>";
        echo "retencion: ".$retencion."<br>";
        echo "descuento: ".$descuento."<br>";
        echo "Pago total: ".$total."<br>";
    ?>
</body>
</html>