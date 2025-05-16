import { Component, EventEmitter, Inject, Input, Output } from '@angular/core';
import { MatDialogModule, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ApiService } from '../../../services/api.service';
import { ReactiveFormsModule, FormGroup, FormBuilder, Validators, FormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormField } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { CommonModule } from '@angular/common';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-form-post',
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatFormField,
    MatInputModule,
    MatDialogModule,
    MatButtonModule,
    MatSelectModule,MatInputModule, FormsModule
  ],
  templateUrl: './form-post.component.html',
  styleUrl: './form-post.component.css'
})
export class FormPostComponent {
  @Input() module: any;
  @Output() cerrar = new EventEmitter<boolean>();

  users?: any[];

  moduleForm!: FormGroup;
  isEditMode = false;
  constructor(private fb: FormBuilder, private apiService: ApiService, public dialogRef: MatDialogRef<FormPostComponent>,
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
      body: [this.module?.body || '', Validators.required]


    });
    this.cargarUsuarios();
  }

  guardarform() {
    const formulario = this.moduleForm.value;
    if (this.isEditMode) {
      this.apiService.update('posts', formulario, formulario.id).subscribe(() => {
        console.log("update");
        this.dialogRef.close('reload');
        Swal.fire({
          title: 'Post Actualizado Exitosamente',
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
      this.apiService.Crear('posts', formulario).subscribe(() => {
        console.log("creado");
        this.dialogRef.close('reload');
        Swal.fire({
          title: 'Post Creado Exitosamente',
          text: `${formulario}`,
          icon: 'success',
          confirmButtonColor: '#765dfb',
          cancelButtonColor: '#d5d7f9',
          confirmButtonText: 'Aceptar'
        })
      })
    }
  }

  cargarUsuarios(){
    this.apiService.ObtenerTodo('users').subscribe((data) => {
      this.users = data;
    })
  }
}
