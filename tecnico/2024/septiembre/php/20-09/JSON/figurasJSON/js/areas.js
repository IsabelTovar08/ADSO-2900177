function calcularAreas(){
    fetch('libreria/calcularFiguras.php', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            bases: 24,
            alturas: 5
        })
    })
    .then(response => response.json())
    .then(data => {
        if(data.error){
            alert(data.error);
        } else{
            document.getElementById('resultadoCuadrado').textContent = `Cuadrado: ${data.cuadrado}`;
            document.getElementById('resultadoRectangulo').textContent = `Rectángulo: ${data.rectangulo}`;
            document.getElementById('resultadoTriangulo').textContent = `Triángulo: ${data.triangulo}`;

        }
    })
    .catch(error => console.error('Error: ', error));
}
document.addEventListener("DOMContentLoaded", function() {
    calcularAreas();
});