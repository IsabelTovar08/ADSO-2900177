<?php
    class datosNomina{
        private $diasTrabajados;
        private $valorDia;

        public function setDiasTrabajados($diasTrabajados){
            $this->diasTrabajados = $diasTrabajados;
        }
        public function getDiasTrabajados(){
            return $this->diasTrabajados;
        }
        public function setValorDia($valorDia){
            $this->valorDia = $valorDia;
        }
        public function getValorDia(){
            return $this->valorDia;
        }

    }

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
        public $SMMLV;

        public function calcularSalario($diasTrabajados,$valorDia) {
            $this-> diasTrabajados = $diasTrabajados;
            $this-> valorDia = $valorDia;
            $this->salario = $this->diasTrabajados * $this->valorDia;
            return $this->salario;
        }
        public function calcularSalud() {
            $this->salud = $this->salario * 0.12;
            return $this->salud;
        }
        public function calcularPension() {
            $this->pension = $this->salario * 0.16;
            return $this->pension;
        }
        public function calcularArl() {
            $this->arl = $this->salario * 0.052;
            return $this->arl;
        }
        public function calcularTransporte() {
            $this->SMMLV = 1300000;
            $this->transporte = ($this->salario < 2 * $this->SMMLV) ? 114000 : 0;
            return $this->transporte;
        }
        public function calcularRetencion() {
            $this->SMMLV = 1300000;
            $this->retencion = ($this->salario > 4 * $this->SMMLV) ? $this->salario * 0.04 : 0;
            return $this->retencion;
        }
        public function calcularDescuento() {
            $this->descuento = $this->salud + $this->pension + $this->arl;
            return $this->descuento;
        }
        public function calcularPagoTotal() {
            $this->total = ($this->salario + $this->transporte) - ($this->descuento + $this->retencion);
            return $this->total;
        }
    }
?>
