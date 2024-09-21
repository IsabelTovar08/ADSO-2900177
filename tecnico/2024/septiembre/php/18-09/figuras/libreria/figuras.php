<?php
class figuras{
    public $lado;
    public $base;
    public $altura;
    public $cuadrado;
    public $rectangulo;
    public $triangulo;

    public function cuadrado($lado){
        $cuadrado = $lado * $lado;
        return $cuadrado;
    }
    public function triangulo($base,$altura){
        $triangulo = ($base * $altura) /2;
        return $triangulo;
    }
    public function rectangulo($base,$altura){
        $rectangulo = $base * $altura;
        return $rectangulo;
    }
}
?>