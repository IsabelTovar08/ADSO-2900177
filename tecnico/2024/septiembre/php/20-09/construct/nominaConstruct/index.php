<?php
    include 'libreria/nomina.php';

    $dias = new encapsular(30);
    $valor = new encapsular(50000);

    $nomina = new nomina($dias,$valor)
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
        echo 'SALARIO: '. $nomina->calcularSalario().'<br>';
        echo 'SALUD: '. $nomina->calcularSalud().'<br>';
        echo 'PENSIÓN: '. $nomina->calcularPension().'<br>';
        echo 'ARL: '. $nomina->calcularArl().'<br>';
        echo 'SUB. TRANSPORTE: '. $nomina->calcularTransporte().'<br>';
        echo 'PAGO RETENCIÓN: '. $nomina->calcularRetencion().'<br>';
        echo 'DESCUENTO: '. $nomina->calcularDescuento().'<br>';
        echo 'PAGO TOTAL: '. $nomina->calcularPagoTotal().'<br>';
    ?>
</body>
</html>