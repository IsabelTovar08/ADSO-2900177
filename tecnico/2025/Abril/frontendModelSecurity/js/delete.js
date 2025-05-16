function mostrarAlerta(id, entidad) {
  Swal.fire({
    title: `¿Estás seguro de eliminar el registro con ID ${id}?`,
    text: 'Esta acción no se puede deshacer.',
    icon: 'warning',
    showCancelButton: true,
    confirmButtonText: 'Sí, eliminar',
    cancelButtonText: 'Cancelar'
  }).then(result => {
    if (result.isConfirmed) {
      fetch(`http://localhost:5150/api/${entidad}/${id}`, {
        method: "DELETE"
      })
      .then(res => res.ok ? res.text() : Promise.reject("Error al eliminar"))
      .then(() => {
        Swal.fire('Eliminado', 'El registro fue eliminado.', 'success');
        
      })
      .catch(err => console.error(err));
    }
  });
  
}