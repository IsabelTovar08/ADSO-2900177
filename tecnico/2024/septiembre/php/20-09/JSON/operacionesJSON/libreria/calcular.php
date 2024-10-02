<?php
    include 'numero.php';
    include 'operaciones.php';

    $data = json_decode(file_get_contents('php://input'), true);
    $num1 = new numero($data['numero1']);
    $num2 = new numero($data['numero2']);

    $operaciones = new operaciones(numeroUno: $num1, numeroDos: $num2);

    $response = [];
    
    $response['suma'] = $operaciones->sumar();
    $response['resta'] = $operaciones->restar();
    $response['multiplicacion'] = $operaciones->multiplicar();
    $response['division'] = $operaciones->dividir();

    header('Content-Type: application/json');
    echo json_encode($response);
?>
