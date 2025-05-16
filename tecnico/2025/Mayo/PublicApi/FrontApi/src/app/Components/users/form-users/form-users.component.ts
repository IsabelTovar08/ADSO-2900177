import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Inject, Input, Output } from '@angular/core';
import { ReactiveFormsModule, FormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MAT_DIALOG_DATA, MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { MatFormField } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import Swal from 'sweetalert2';
import { FormAlbumsComponent } from '../../albums/form-albums/form-albums.component';
import { GatewayService } from '../../../services/gateway/gateway.service';

@Component({
  selector: 'app-form-users',
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatFormField,
    MatInputModule,
    MatDialogModule,
    MatButtonModule,
    MatSelectModule, MatInputModule, FormsModule
  ],
  templateUrl: './form-users.component.html',
  styleUrl: './form-users.component.css'
})
export class FormUsersComponent {
  @Input() module: any;
  @Output() cerrar = new EventEmitter<boolean>();
  titulo?: string;

  users?: any[];

  moduleForm!: FormGroup;
  isEditMode = false;
  constructor(private fb: FormBuilder, private gatewayService: GatewayService, public dialogRef: MatDialogRef<FormAlbumsComponent>,
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
      userName: [this.module?.userName || '', Validators.required],
      email: [this.module?.email || '', Validators.required],
      phone: [this.module?.phone || '', Validators.required],
      isDeleted : false
    });
  }

  guardarform() {
    const formulario = this.moduleForm.value;
    if (this.isEditMode) {
      this.titulo = "Editando User"
      this.gatewayService.updateUsers( formulario).subscribe(() => {
        console.log("update");
        this.dialogRef.close('reload');
        Swal.fire({
          title: 'User Actualizado Exitosamente',
          icon: 'success',
          confirmButtonColor: '#765dfb',
          cancelButtonColor: '#d5d7f9',
          confirmButtonText: 'Aceptar'
        })
      })
    }
   
  }
}
