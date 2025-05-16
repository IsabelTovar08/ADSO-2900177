document.getElementById('formOperaciones').addEventListener('submit', function(event) {
    event.preventDefault();

    let numeroUno = document.getElementById('txtNumUno').value;
    let numeroDos = document.getElementById('txtNumDos').value;
    let operacionSeleccionada = document.getElementById('operacionSelect').value;

    fetch('libreria/calcular.php', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            numero1: numeroUno,
            numero2: numeroDos,
            operacion: operacionSeleccionada
        })
    })
    .then(response => response.json())
    .then(data => {
        // Limpiamos los resultados anteriores
        document.getElementById('resultadiSuma').textContent = '';
        document.getElementById('resultadoResta').textContent = '';
        document.getElementById('resultadoMultiplicacion').textContent = '';
        document.getElementById('resultadoDivision').textContent = '';

        if (data.error) {
            alert(data.error);
        } else {
            if (operacionSeleccionada === 'suma') {
                document.getElementById('resultadiSuma').textContent = `Suma: ${data.suma}`;
            } else if (operacionSeleccionada === 'resta') {
                document.getElementById('resultadoResta').textContent = `Resta: ${data.resta}`;
            } else if (operacionSeleccionada === 'multiplicacion') {
                document.getElementById('resultadoMultiplicacion').textContent = `Multiplicación: ${data.multiplicacion}`;
            } else if (operacionSeleccionada === 'division') {
                document.getElementById('resultadoDivision').textContent = `División: ${data.division}`;
            } else if (operacionSeleccionada === 'todas') {
                document.getElementById('resultadiSuma').textContent = `Suma: ${data.suma}`;
                document.getElementById('resultadoResta').textContent = `Resta: ${data.resta}`;
                document.getElementById('resultadoMultiplicacion').textContent = `Multiplicación: ${data.multiplicacion}`;
                document.getElementById('resultadoDivision').textContent = `División: ${data.division}`;
            }
        }
    })
    .catch(error => console.error('Error: ', error));
});
