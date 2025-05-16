import { Component, EventEmitter, Inject, Input, Output } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA, MatDialogModule } from '@angular/material/dialog';
import { ApiService } from '../../../services/api.service';
import Swal from 'sweetalert2';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { MatFormField } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';

@Component({
  selector: 'app-formcomments',
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatFormField,
    MatInputModule,
    MatDialogModule,
    MatButtonModule,
    MatSelectModule,MatInputModule, FormsModule
  ],
  templateUrl: './formcomments.component.html',
  styleUrl: './formcomments.component.css'
})
export class FormcommentsComponent {
  @Input() module: any;
  @Output() cerrar = new EventEmitter<boolean>();
  titulo?: string;

  users?: any[];

  moduleForm!: FormGroup;
  isEditMode = false;
  constructor(private fb: FormBuilder, private apiService: ApiService, public dialogRef: MatDialogRef<FormcommentsComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any) {
    this.module = data;
    console.log(this.module);

  }

  ngOnInit(): void {
    this.isEditMode = !!this.module;
    console.log(this.module)
    this.moduleForm = this.fb.group({
      id: [this.module?.id || 0],
      name: [this.module?.name || '', Validators.required],
      email: [this.module?.email || '', Validators.required],
      body: [this.module?.body || '', Validators.required]
    });
  }

  guardarform() {
    const formulario = this.moduleForm.value;
    if (this.isEditMode) {
      this.titulo = "Editando comentario"
      this.apiService.update('comments', formulario, formulario.id).subscribe(() => {
        console.log("update");
        this.dialogRef.close('reload');
        Swal.fire({
          title: 'Comentario Actualizado Exitosamente',
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
      this.titulo = "Escribe un nuevo comentario para este post."
      this.apiService.Crear('comments', formulario).subscribe(() => {
        console.log("creado");
        this.dialogRef.close('reload');
        Swal.fire({
          title: 'Comentario Creado Exitosamente',
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
}
