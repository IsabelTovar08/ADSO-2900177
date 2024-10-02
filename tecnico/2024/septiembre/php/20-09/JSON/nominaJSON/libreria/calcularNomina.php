<?php
    include 'encapsular.php';
    include 'nomina.php';

    $data = json_decode(file_get_contents('php://input'), true);

    if (!$data || !isset($data['diasTrabaj']) || !isset($data['valorD'])) {
        echo json_encode(['error' => 'Datos no válidos o incompletos.']);
        exit;
    }

    error_log('Días trabajados: ' . $data['diasTrabaj']);
    error_log('Valor diario: ' . $data['valorD']);

    $dias = new encapsular($data['diasTrabaj']);
    $valor = new encapsular($data['valorD']);

    $nomina = new nomina($dias, $valor);


    $response = [];
    $response['salario'] = $nomina->calcularSalario();
    $response['salud'] = $nomina->calcularSalud();
    $response['pension'] = $nomina->calcularPension();
    $response['arl'] = $nomina->calcularArl();
    $response['transporte'] = $nomina->calcularTransporte();
    $response['retencion'] = $nomina->calcularRetencion();
    $response['descuento'] = $nomina->calcularDescuento();
    $response['total'] = $nomina->calcularPagoTotal();

    header('Content-Type: application/json');
    echo json_encode($response);
?>
