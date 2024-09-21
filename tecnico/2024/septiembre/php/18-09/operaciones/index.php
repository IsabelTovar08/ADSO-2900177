<?php
    include('libreria/operacion.php');
    $operar = new operaciones();
?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Operaciones</title>
</head>
<body>
    <?php
    echo "La suma es : ".$operar->sumar(1,2)."<br>";
    echo "La resta es : ".$operar->restar(6,1)."<br>";
    echo "La multiplicacion es : ".$operar->multiplicar(2,3)."<br>";
    echo "La división es : ".$operar->dividir(16,2)."<br>";
    ?>
</body>
</html>