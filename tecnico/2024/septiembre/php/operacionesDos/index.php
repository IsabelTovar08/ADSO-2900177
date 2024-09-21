<?php
    include 'libreria/numeros.php';

    $dato = new datos();
    $operaciones = new operadores();

    $dato->setNumUno(4);  // Asigna el número 1
    $dato->setNumDos(3);  // Asigna el número 2
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
        echo "Suma: " . $operaciones->sumar($dato->getNumUno(), $dato->getNumDos()) . "<br>";
        echo "Resta: " . $operaciones->restar($dato->getNumUno(), $dato->getNumDos()) . "<br>";
        echo "Multiplicación: " . $operaciones->multiplicar($dato->getNumUno(), $dato->getNumDos()) . "<br>";
        echo "División: " . $operaciones->dividir($dato->getNumUno(), $dato->getNumDos()) . "<br>";
    ?>
</body>
</html>
