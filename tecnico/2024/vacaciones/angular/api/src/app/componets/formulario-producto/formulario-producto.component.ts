import { Component } from '@angular/core';
import { FormGroup, FormControl, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-formulario-producto',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './formulario-producto.component.html' // Apunta al archivo HTML
})
export class FormularioProductoComponent {
  // Definir el formulario reactivo
  productoForm = new FormGroup({
    nombre: new FormControl(''),
    descripcion: new FormControl(''),
    precio: new FormControl('')
  });

  // Función que se ejecuta al enviar el formulario
  onSubmit() {
    console.log('Producto creado:', this.productoForm.value);
    // Aquí puedes agregar lógica para enviar los datos del formulario a un servicio, por ejemplo
  }
}
