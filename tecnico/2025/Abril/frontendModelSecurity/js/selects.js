function cargarSelect(idSelect, entidad, campoLabel, campoValue = "id") {
    fetch(`http://localhost:5150/api/${entidad}`)
      .then(res => res.json())
      .then(data => {
        const select = document.getElementById(idSelect);
        if (!select) return console.error(`Select con id "${idSelect}" no encontrado`);
  
        select.innerHTML = '<option value="">Seleccione una opción</option>';
  
        data.forEach(item => {
          const option = document.createElement("option");
          option.value = item[campoValue];
          option.textContent = item[campoLabel];
          select.appendChild(option);
        });
      })
      .catch(err => console.error(`Error cargando datos de ${entidad}:`, err));
  }
  