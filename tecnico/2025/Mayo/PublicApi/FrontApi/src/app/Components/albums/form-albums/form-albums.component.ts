import { Component, EventEmitter, Inject, Input, Output } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA, MatDialogModule } from '@angular/material/dialog';
import Swal from 'sweetalert2';
import { ApiService } from '../../../services/api.service';
import { FormcommentsComponent } from '../../comments/formcomments/formcomments.component';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { MatFormField } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';

@Component({
  selector: 'app-form-albums',
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatFormField,
    MatInputModule,
    MatDialogModule,
    MatButtonModule,
    MatSelectModule, MatInputModule, FormsModule
  ],
  templateUrl: './form-albums.component.html',
  styleUrl: './form-albums.component.css'
})
export class FormAlbumsComponent {
  @Input() module: any;
  @Output() cerrar = new EventEmitter<boolean>();
  titulo?: string;

  users?: any[];

  moduleForm!: FormGroup;
  isEditMode = false;
  constructor(private fb: FormBuilder, private apiService: ApiService, public dialogRef: MatDialogRef<FormAlbumsComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any) {
    this.module = data;
    console.log(this.module);

  }

  ngOnInit(): void {
    this.isEditMode = !!this.module;
    console.log(this.module)
    this.moduleForm = this.fb.group({
      id: [this.module?.id || 0],
      userId: [this.module?.userId || '', Validators.required],
      title: [this.module?.title || '', Validators.required],
    });
    this.cargarUsuarios();
  }

  guardarform() {
    const formulario = this.moduleForm.value;
    if (this.isEditMode) {
      this.titulo = "Editando Album"
      this.apiService.update('albums', formulario, formulario.id).subscribe(() => {
        console.log("update");
        this.dialogRef.close('reload');
        Swal.fire({
          title: 'Album Actualizado Exitosamente',
          text: `
            Tittle: ${formulario.title}
            Body: ${formulario.body}
            `,
          icon: 'success',
          confirmButtonColor: '#765dfb',
          cancelButtonColor: '#d5d7f9',
          confirmButtonText: 'Aceptar'
        })
      })
    }
    else {
      this.titulo = "Escribe un nuevo Album para este post."
      this.apiService.Crear('albums', formulario).subscribe(() => {
        console.log("creado");
        this.dialogRef.close('reload');
        Swal.fire({
          title: 'Album Creado Exitosamente',
          text: `
            Tittle: ${formulario.title}
            Body: ${formulario.body}
          `,
          icon: 'success',
          confirmButtonColor: '#765dfb',
          cancelButtonColor: '#d5d7f9',
          confirmButtonText: 'Aceptar'
        })
      })
    }
  }
  cargarUsuarios() {
    this.apiService.ObtenerTodo('users').subscribe((data) => {
      this.users = data;
    })
  }
}
