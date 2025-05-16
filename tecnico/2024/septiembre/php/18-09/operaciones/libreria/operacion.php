<?php
class operaciones{
    public $numeroUno;
    public $numeroDos;
    public $suma;
    public $resta;
    public $multiplicacion;
    public $division;

    public function sumar($numeroUno, $numeroDos) {
        $suma = $numeroUno + $numeroDos;
        return $suma;
    }
    public function restar($numeroUno, $numeroDos) {
        $resta = $numeroUno - $numeroDos;
        return $resta;
    }
    public function multiplicar($numeroUno, $numeroDos) {
        $multiplicacion = $numeroUno * $numeroDos;
        return $multiplicacion;
    }
    public function dividir($numeroUno, $numeroDos){
        $division = ($numeroDos !=0) ? $numeroUno / $numeroDos : "no se puede dividir por cero " ;
        return $division;
    }
}
?>