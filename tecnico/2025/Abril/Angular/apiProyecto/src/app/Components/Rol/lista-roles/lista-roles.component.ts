import { Component } from '@angular/core';
import { ApiService } from '../../../../services/api.service';
import { MatCardModule } from '@angular/material/card';
import { FormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatTableModule } from '@angular/material/table';
import { MatDialog } from '@angular/material/dialog';
import Swal from 'sweetalert2';
import { FormUserComponent } from '../../User/form-user/form-user.component';
import { FormularioComponent } from '../formulario/formulario.component';
import { CommonModule } from '@angular/common';
import { MatSlideToggle } from '@angular/material/slide-toggle';

@Component({
  selector: 'app-lista-roles',
  imports: [CommonModule, MatSlideToggle,MatCardModule, MatTableModule, MatIconModule, MatButtonModule, MatFormFieldModule, FormsModule, MatInputModule],
  templateUrl: './lista-roles.component.html',
  styleUrl: './lista-roles.component.css'
})
export class ListaRolesComponent {
  roles: [] = [];
  roleseleccionado?: any;
  nombreuser: String = '';
  filteredroles: any[] = [];


  displayedColumns: string[] = ['name', 'description', 'status', 'actions'];

  constructor(private dialog: MatDialog, private apiService: ApiService) { }

  ngOnInit(): void {
    this.cargarroles();
  }
cargarroles(){
  this.apiService.ObtenerTodo('rol').subscribe(roles => {
    this.roles = roles;
    console.log(roles)
  })
}
  openFormCreate(): void {
    const dialogRef = this.dialog.open(FormularioComponent, {
      width: '400px',
      data: null
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result === 'reload') {
        this.cargarroles(); // Recarga la tabla
        console.log("cargar");
      }
    });
  }

  editroles(roles: any): void {
    // Abre el formulario con los datos del roles
    const dialogRef = this.dialog.open(FormularioComponent, {
      width: '400px',
      data: this.roleseleccionado
    });
    dialogRef.afterClosed().subscribe(result => {
      if (result === 'reload') {
        this.cargarroles(); // Recarga la tabla
        console.log("cargar");
      }
    });
  }

  deleteroles(roles: any): void {
    Swal.fire({
      title: '¿Estás seguro?',
      text: `¿Quieres eliminar el roles: ${roles.name}?`,
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#765dfb',
      cancelButtonColor: '#d5d7f9',
      confirmButtonText: 'Eliminar',
      cancelButtonText: 'Cancelar'
    }).then((result) => {
      if (result.isConfirmed) {
       this.apiService.delete('rol', roles.id).subscribe(() => {
        this.cargarroles();
       })
      }
    });
  }

  toggleIsActive(rol : any){
    this.apiService.deleteLogic('rol', rol.id).subscribe(() => {
      Swal.fire({
        title: `Actualización exitosa`,
        icon: 'success',
        confirmButtonColor: '#765dfb',
        cancelButtonColor: '#d5d7f9',
        confirmButtonText: 'Aceptar',
      })
    });
  }
}
