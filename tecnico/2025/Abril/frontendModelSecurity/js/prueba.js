async function Consultar(entidad, campos){
    fetch(`http://localhost:5150/api/${entidad}`)
    .then(respuesta => respuesta.json())
    .then(data => {
      let html = '<table class="table table-bordered border-primary">';
      html += '<tr>';
      campos.forEach(campo => {
        html += `<th>${campo.label}</th>`;
      });
      console.log(data)
      html += `<th>Acciones</th>
              <th>Estado</th>
            </tr>`;

      data.forEach(item => {
        html += '<tr>';
        campos.forEach(campo => {
          html += `<td>${item[campo.key]}</td>`;
        });
        const checked = item.status ? 'checked' : '';
        html += `<td>
                  <span class="material-symbols-outlined pointer" onclick='mostrarModal(${JSON.stringify(item)}, "Editar", "${entidad}")' data-bs-toggle="modal" data-bs-target="#crear">edit</span>
                  <span class="material-symbols-outlined pointer" onclick="mostrarAlerta(${item.id},'${entidad}');">delete</span>
                  <td>
                    <div class="form-check form-switch">
                    <input class="form-check-input" type="checkbox" role="switch" id="status-${entidad}-${item.id}" ${checked} onchange="confirmarToggle(${item.id}, this.checked, '${entidad}', this)">
                    <label class="form-check-label" for="status-${entidad}-${item.id}">${item.status ? 'Activo' : 'Inactivo'}</label>
                  </div>
                  </td>
                </td>`;
        html += '</tr>';
      });

      html += '</table>';
    
      document.getElementById('tabla').innerHTML = html;
    })
    .catch(error => {
      document.getElementById('tabla').innerText = 'Error al cargar los datos.';
      console.error(error);
    });
}
