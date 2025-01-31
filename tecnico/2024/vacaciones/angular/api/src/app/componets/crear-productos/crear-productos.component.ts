import { Component } from '@angular/core';
import { CommonModule } from '@angular/common'; // 🔹 Importar CommonModule
import { FormBuilder, FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';

@Component({
  selector: 'app-crear-productos',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, MatFormFieldModule, MatInputModule, MatButtonModule], // 🔹 Agregado CommonModule
  templateUrl: './crear-productos.component.html',
  styleUrls: ['./crear-productos.component.css']
})
export class CrearProductosComponent {
  form: FormGroup;

  constructor(private formBuilder: FormBuilder) {
    this.form = this.formBuilder.group({
      nombre: new FormControl('', Validators.required) // 🔹 Se asegura de que tiene 'Validators.required'
    });
  }

  sendData() {
    if (this.form.valid) {
      console.log(this.form.value);
    }
  }
}
