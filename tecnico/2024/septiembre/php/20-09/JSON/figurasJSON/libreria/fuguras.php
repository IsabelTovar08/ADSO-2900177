<?php
    class figuras{
        private $lado;
        private $base;
        private $altura;
        private $cuadrado;
        private $rectangulo;
        private $triangulo;

        public function __construct(encapsular $base, encapsular $altura){
            $this-> base = $base ->getValor();
            $this-> altura = $altura ->getValor();
        }
        public function cCuadrado(){
            $this->cuadrado = $this->base * $this->altura;
            return $this->cuadrado;
        }
        public function cRectangulo(){
            $this->rectangulo = $this->base * $this->altura;
            return $this->rectangulo;
        }
        public function cTriangulo(){
            $this->triangulo =($this->base * $this->altura)/2;
            return $this->triangulo;
        }
    }