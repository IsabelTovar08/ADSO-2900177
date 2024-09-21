<?php
    class nomina {
        public $diasTrabajados;
        public $valorDia;
        public $salario;
        public $salud;
        public $pension;
        public $arl;
        public $transporte;
        public $retencion;
        public $descuento;
        public $total;

        public function calcularSalario($diasTrabajados, $valorDia) {
            $salario = $diasTrabajados * $valorDia;
            return $salario;
        }
        public function calcularSalud($salario) {
            $salud = $salario * 0.12;
            return $salud;
        }
        public function calcularPension($salario) {
            $pension = $salario * 0.16;
            return $pension;
        }
        public function calcularArl($salario) {
            $arl = $salario * 0.052;
            return $arl;
        }
        public function calcularTransporte($salario) {
            $SMMLV = 1300000;
            $transporte = ($salario < 2 * $SMMLV) ? 114000 : 0;
            return $transporte;
        }
        public function calcularRetencion($salario) {
            $smm = 1300000;
            $retencion = ($salario > 4 * $smm) ? $salario * 0.04 : 0;
            return $retencion;
        }
        public function calcularDescuento($salud, $pension, $arl) {
            $descuento = $salud + $pension + $arl;
            return $descuento;
        }
        public function calcularPagoTotal($salario, $transporte, $descuento, $retencion) {
            $total = ($salario + $transporte) - ($descuento + $retencion);
            return $total;
        }
    }
?>
