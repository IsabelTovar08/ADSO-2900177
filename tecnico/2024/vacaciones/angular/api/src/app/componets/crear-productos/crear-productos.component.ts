import { Component, inject } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';

@Component({
  selector: 'app-crear-productos',
  imports: [ ReactiveFormsModule, MatFormFieldModule, MatInputModule, MatButtonModule],
  templateUrl: './crear-productos.component.html',
  styleUrls: ['./crear-productos.component.css']  // Cambié 'styleUrl' a 'styleUrls'
})
export class CrearProductosComponent {
  form: FormGroup;

  constructor(private formBuilder: FormBuilder) {
    this.form = this.formBuilder.group({
      nombre: ['']
    });
  }

  cambios() {
    console.log(this.form.value);
  }
}
