<?php include('libreria/saludo.php');
        $holaMundo = new holaMundo();
?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
</head>
<body>
    <strong><?php echo $holaMundo->saludar() ?></strong>
</body>
</html>