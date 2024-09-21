function realizarOperaciones(){
    fetch('libreria/calcular.php', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            numero1: 24,
            numero2: 5
        })
    })
    .then(response => response.json())
    .then(data => {
        if(data.error){
            alert(data.error);
        } else{
            document.getElementById('resultadiSuma').textContent = `Suma: ${data.suma}`;
            document.getElementById('resultadoResta').textContent = `Resta: ${data.resta}`;
            document.getElementById('resultadoMultiplicacion').textContent = `Multiplicacion: ${data.multiplicacion}`;
        }
    })
    .catch(error => console.error('Error: ', error));
}
document.addEventListener("DOMContentLoaded", function() {
    realizarOperaciones();
});