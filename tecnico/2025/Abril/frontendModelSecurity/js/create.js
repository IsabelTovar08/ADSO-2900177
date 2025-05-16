var entidad;
var idActualizar = '';
function mostrarModal(data = {}, titulo, entidadP) {
    idActualizar = data?.id;
    const containerId = document.getElementById("id");
    entidad = entidadP;
    // Limpiar el formulario antes de crear o editar 
    const inputs = document.querySelectorAll("#crear input");
    inputs.forEach(input => input.value = '');
    containerId.innerText = "";


    // Mostrar título en el formulario: Crear/Editar 
    const tituloVar = document.querySelector(".titulo");
    tituloVar.innerHTML = titulo;


    console.log(data)
    // Mostrar datos en el formulario para Editar
    if (data) {
        containerId.innerText = `Id: ${data.id}`;
        console.log(data.id)

        containerId.style.display = 'block';
        for (let campo in data) {
            const input = document.getElementById(campo);
            if (input) {
                input.value = data[campo]; // Asigna el valor automáticamente
            }
        }
    } else {
        // Si no hay datos, muestra el formulario vacío para crear 
        console.log("Crear");
    }

}


document.querySelector("#formulario").addEventListener("submit", function (e) {
    e.preventDefault();

    const form = e.target;
    // const id = document.getElementById("id").innerText.trim();

    // Armar el objeto con los datos del formulario
    const data = {};
    const inputs = form.querySelectorAll("input");
    inputs.forEach(input => {
        data[input.id] = input.value;
    });
    const selects = form.querySelectorAll("select");
    selects.forEach(select => {
        data[select.id] = select.value;
    });
    if (entidad == "Person") {
        data.nameComplet = ""
    }
    if (entidad == "ModuleForm") {
        data.nameModule = ""
        data.nameForm = ""

    }
    data.status = 1;
    // Si es edición, agregamos el ID al objeto (no en la URL)
    data.id = idActualizar;
    let metodo;
    let url;
    // Determinar método y URL (misma URL para ambos casos)
    if (idActualizar) {
        metodo = "PUT";
        url = `http://localhost:5150/api/${entidad}/update`;

    }
    else {
        metodo = idActualizar ? "PUT" : "POST";
        url = `http://localhost:5150/api/${entidad}`;
    }

    console.log(metodo, url)
    console.log(data)

    // Petición
    fetch(url, {
        method: metodo,
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(data)
    })
        .then(res => res.ok ? res.json() : Promise.reject("Error al guardar"))
        .then(() => {
            // location.reload();
            Swal.fire("Éxito", idActualizar ? "Registro actualizado" : "Registro creado", "success");

        })

        .catch(err => {
            console.error(err);
            Swal.fire("Error", "Ocurrió un error al guardar", "error");
        });
});
