<?php 
    include 'encapsular.php';

    class nomina{
        private $diasTrabajados;
        private $valorDia;
        public $salario;
        public $salud;
        public $pension;
        public $arl;
        public $transporte;
        public $retencion;
        public $descuento;
        public $total;
        public $SMMLV;

        public function __construct(encapsular $diasTrabajados, encapsular $valorDia){
            $this-> diasTrabajados = $diasTrabajados ->getValor();
            $this-> valorDia = $valorDia ->getValor();
        }
        public function calcularSalario() {
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