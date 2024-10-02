<?php
    include 'encapsular.php';
    include 'fuguras.php';

    $data = json_decode(file_get_contents('php://input'), true);
    $baseFigura = new encapsular($data['bases']);
    $alturaFigura = new encapsular($data['alturas']);

    $cuadrado = new figuras($baseFigura, $baseFigura);
    $areaFiguras = new figuras(base: $baseFigura, altura: $alturaFigura);

    $response = [];
    
    $response['cuadrado'] = $cuadrado->cCuadrado();
    $response['rectangulo'] = $areaFiguras->cRectangulo();
    $response['triangulo'] = $areaFiguras->cTriangulo();

    header('Content-Type: application/json');
    echo json_encode($response);
?>
