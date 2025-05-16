<?php
include('libreria/saludo.php'); 
$saludar = new saludo();
$mensaje = '';

if (!empty($_POST['nombre'])) {
    $nombre = $_POST['nombre'];
    $saludar->setSaludar($nombre); // Ajustado
    $mensaje = $saludar->getSaludar(); // Obtén el saludo aquí
} else {
    $mensaje = 'No se proporcionó un nombre.';
}
?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Saludo</title>
    <link rel="stylesheet" href="css/estilos.css">
</head>
<body>
    <div class="contenedor">
        <div class="respuesta">
            <div class="formulario">
                <form action="" method="post">
                    <label for="nombre">Saluda:</label><br>
                    <input type="text" id="nombre" name="nombre" required>
                    <br><br>
                    <button type="submit" value="Enviar">Enviar</button>
                </form>
            </div>
            <div id="respuesta">
                <h1><?php echo $mensaje; ?></h1>
            </div>
        </div>
    </div>
</body>
</html>
