import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { LaptopService } from '../../services/laptop.service';
import { Laptop, LaptopCreacion } from '../../models/laptop.models';
import { nombreLaptopUnico } from '../compartidos/funciones/nombreLaptopEsUnico';

@Component({
  selector: 'app-formulario-producto',
  standalone: false,

  templateUrl: './formulario-producto.component.html',
  styleUrl: './formulario-producto.component.css'
})
export class FormularioProductoComponent implements OnInit {
  form!: FormGroup;

  @Input({ required: true })
  titulo!: string;

  @Input()
  modelo?: Laptop

  @Output()
  posteoFormulario = new EventEmitter<LaptopCreacion>();

  constructor(private fb: FormBuilder, private laptopService: LaptopService) {

    this.form = this.fb.group({
      nombre: ['',{ 
        validators: [Validators.required], 
        asyncValidators: [nombreLaptopUnico()],
        updateOn: 'blur'

      }]
    });
    
  }

  ObtenerErroresNombre(): string {
    let nombre = this.form.get('nombre');

    if (nombre?.errors?.['required']) {
      return 'El campo nombre es requerido'
    }
    if (nombre?.errors?.['mensaje']) {
      return nombre.getError('mensaje');
    }
    return "";
  }

  ngOnInit(): void {
    if (this.modelo != undefined) {
      this.form.patchValue(this.modelo)
    }
  }

  guardarCambios() {
    console.log(this.form.value)
    let laptop = this.form.value as LaptopCreacion;
    this.posteoFormulario.emit(laptop)
  }
}
