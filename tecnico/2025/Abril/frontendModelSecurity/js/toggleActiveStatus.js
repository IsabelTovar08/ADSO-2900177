function confirmarToggle(id, nuevoEstado, entidad, checkbox) {
    const texto = nuevoEstado ? "activar" : "desactivar";

    Swal.fire({
        title: `¿Estás seguro de ${texto} este elemento?`,
        icon: "warning",
        showCancelButton: true,
        confirmButtonText: `Sí, ${texto}`,
        cancelButtonText: "Cancelar",
    }).then((result) => {
        if (result.isConfirmed) {
            fetch(`http://localhost:5150/api/${entidad}/toggleActive/${id}`, {
                method: "PATCH"
            })
            .then(res => {
                if (!res.ok) throw new Error("No se pudo actualizar el estado.");
                return res.json();
            })
            .then(() => {
                Swal.fire("¡Éxito!", `El estado fue actualizado.`, "success");
            })
            .catch(error => {
                console.error(error);
                Swal.fire("Error", "Hubo un problema al cambiar el estado", "error");
                checkbox.checked = !nuevoEstado; // revertir toggle si falla
            });
        } else {
            checkbox.checked = !nuevoEstado; // revertir toggle si cancela
        }
    });
}
