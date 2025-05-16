<?php
    include 'libreria/fuguras.php';

    $base = new encapsular(7);
    $altura = new encapsular(3);

    $cuadrado = new figuras($base,$base);
    $figura = new figuras($base,$altura);

?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
</head>
<body>
    <?php echo "Área del Cuadrado: ". $cuadrado ->cuadrado() ?><br>
    <?php echo "Área del Rectangulo: ". $figura ->rectangulo() ?><br>
    <?php echo "Área del Triángulo: ". $figura ->triangulo() ?><br>

</body>
</html>