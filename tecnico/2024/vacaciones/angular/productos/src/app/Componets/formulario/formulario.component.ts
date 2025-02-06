import { Component, EventEmitter, inject, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { CrearProducto, Producto } from '../../models/producto.models';
import { ProductoServiceService } from '../../Services/producto-service.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-formulario',
  imports: [MatButtonModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule
  ],
  templateUrl: './formulario.component.html',
  styleUrl: './formulario.component.css'
})
export class FormularioComponent implements OnInit {
  @Input({ required: true }) titulo!: string;

  @Input() productoLlega?: Producto

  @Output() posteo = new EventEmitter<CrearProducto>();

  private readonly fb = inject(FormBuilder);
  private productoService = inject(ProductoServiceService);
  route = inject(Router)

  constructor(){
    console.log("formm"+this.productoLlega)
    console.log(this.form.value)


  }
  form = this.fb.group({
    nombre: ['', Validators.required],
    descripcion: ['', Validators.required],
    precio: [0],
    stock: [0]
  });
  
  ngOnInit(): void {
      console.log("lleho"+ this.productoLlega)
    
    if(this.productoLlega !== undefined){
      this.form.patchValue(this.productoLlega)
      console.log("formm"+this.form.value)
    }
  }

  guardarCambios() {
    console.log(this.form.value)
    let producto = this.form.value as CrearProducto;
    this.posteo.emit(producto)
  }
}
