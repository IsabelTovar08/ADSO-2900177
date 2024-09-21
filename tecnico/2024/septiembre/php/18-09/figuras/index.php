<?php
    include('libreria/figuras.php');
    $area = new figuras();
?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Área Figuras</title>
</head>
<body>
    <?php
        echo "Área cuadrado: ".$area->cuadrado(4)."<br>";
        echo "Área rectangulo: ".$area->triangulo(3,8)."<br>";
        echo  "Área triangulo: ".$area->rectangulo(4,6)."<br>";
    ?>
</body>
</html>