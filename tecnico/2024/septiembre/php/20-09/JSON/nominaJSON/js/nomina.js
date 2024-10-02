document.getElementById('nominaForm').addEventListener('submit', function(event) {
    event.preventDefault();

    const diasTrabaj = document.getElementById('diasTrabaj').value;
    const valorD = document.getElementById('valorD').value;

    console.log('Días trabajados:', diasTrabaj);
    console.log('Valor diario:', valorD);

    fetch('libreria/calcularNomina.php', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            diasTrabaj: diasTrabaj,
            valorD: valorD
        })
    })
    .then(response => {
        if (!response.ok) {
            throw new Error('Error en la respuesta del servidor');
        }
        return response.json();
    })
    .then(data => {
        console.log('Respuesta del servidor:', data);
        if (data.error) {
            alert(data.error);
        } else {
            document.getElementById('resultadoSalario').textContent = `Salario: ${data.salario}`;
            document.getElementById('resultadoSalud').textContent = `Salud: ${data.salud}`;
            document.getElementById('resultadoPension').textContent = `Pensión: ${data.pension}`;
            document.getElementById('resultadoArl').textContent = `Arl: ${data.arl}`;
            document.getElementById('resultadoTransporte').textContent = `Transporte: ${data.transporte}`;
            document.getElementById('resultadoRetencion').textContent = `Retención: ${data.retencion}`;
            document.getElementById('resultadoDescuento').textContent = `Descuento: ${data.descuento}`;
            document.getElementById('resultadoTotal').textContent = `Total a pagar: ${data.total}`;
        }
    })
    .catch(error => console.error('Error:', error));
});
