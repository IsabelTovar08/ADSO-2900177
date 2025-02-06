import { Component, inject } from '@angular/core';
import { FormBuilder, Validators, FormGroup, ReactiveFormsModule } from '@angular/forms';

import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field'; 
import { MatInputModule } from '@angular/material/input';
import { ProductoServiceService } from '../../Services/producto-service.service';
import { CrearProducto } from '../../models/producto.models';
import { Router } from '@angular/router';
import { FormularioComponent } from "../formulario/formulario.component";

@Component({
  selector: 'app-crear-productos',
  standalone: true,
  imports: [
    MatButtonModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    FormularioComponent
],
  templateUrl: './crear-productos.component.html',
  styleUrl: './crear-productos.component.css'
})
export class CrearProductosComponent {
  private productoService = inject(ProductoServiceService);
  route = inject(Router)

  
  guardarProducto(producto :CrearProducto) {
    this.productoService.CrearProducto(producto).subscribe(() => {
      this.route.navigate(['/']);
    })
  }
}
