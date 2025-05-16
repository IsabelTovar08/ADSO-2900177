<?php
    include('liberia/operaciones.php');

    $numeroUno = new numero(valor: 5);
    $numeroDos = new numero(valor: 1);

    $operaciones = new operaciones(numeroUno:$numeroUno, numeroDos:$numeroDos)
 ?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Operaciones con Construct</title>
</head>
<body>
    <?php echo "Resultado de la suma: ". $operaciones-> sumar()?><br>
    <?php echo "Resultado de la Resta: ".  $operaciones-> restar()?><br>
    <?php echo "Resultado de la Multiplicacion: ".  $operaciones-> multiplicar()?><br>
    <?php echo "Resultado de la Division: ".  $operaciones-> dividir()?>

</body>
</html>