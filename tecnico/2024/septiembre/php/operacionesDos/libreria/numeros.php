<?php
    class datos {
        private $numeroUno;
        private $numeroDos;

        public function setNumUno($numeroUno) {
            $this->numeroUno = $numeroUno;
        }

        public function getNumUno() {
            return $this->numeroUno;
        }

        public function setNumDos($numeroDos) {
            $this->numeroDos = $numeroDos;
        }

        public function getNumDos() {
            return $this->numeroDos;
        }
    }

    class operadores {
        public function sumar($numeroUno, $numeroDos) {
            return $numeroUno + $numeroDos;
        }

        public function restar($numeroUno, $numeroDos) {
            return $numeroUno - $numeroDos;
        }

        public function multiplicar($numeroUno, $numeroDos) {
            return $numeroUno * $numeroDos;
        }

        public function dividir($numeroUno, $numeroDos) {
            // Controlar la división por cero
            if ($numeroDos != 0) {
                return $numeroUno / $numeroDos;
            } else {
                return "Error: División por cero.";
            }
        }
    }
?>