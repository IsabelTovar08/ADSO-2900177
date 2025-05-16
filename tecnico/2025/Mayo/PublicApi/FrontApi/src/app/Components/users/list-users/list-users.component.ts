import { Component } from '@angular/core';
import { GenericTableComponent } from "../../generic-table/generic-table.component";
import { FormUsersComponent } from '../form-users/form-users.component';
import Swal from 'sweetalert2';
import { MatDialog } from '@angular/material/dialog';
import { ApiService } from '../../../services/api.service';
import { GatewayService } from '../../../services/gateway/gateway.service';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
export interface User {
  id: number,
  name: string;
  username: string;
  email: string;
  phone: string;
  isDeleted: boolean
}
@Component({
  selector: 'app-list-users',
  imports: [GenericTableComponent, CommonModule, MatButtonModule],
  templateUrl: './list-users.component.html',
  styleUrl: './list-users.component.css'
})
export class ListUsersComponent {
  users: any[] = [];
  usersGuardados: any[] = [];

  displayedColumns = ['name', 'username', 'email', 'phone', 'actions', 'agregar'];
  displayedColumns2 = ['name', 'userName', 'email', 'phone', 'actions'];

  verGuardados: boolean = false;

  constructor(private apiService: ApiService, private dialog: MatDialog, private gateWayService: GatewayService) {
    this.obtenerusers();
    this.obtenerusersGuardados();
  }


  obtenerusers() {
    this.gateWayService.getUsersPublic().subscribe((data) => {
      this.users = data;
    });
  }

  obtenerusersGuardados() {
    this.gateWayService.getUsers().subscribe((data) => {
      this.usersGuardados = data;
    });
  }

  save(postSeleccionado: any) {
    console.log(postSeleccionado)
    const dialogRef = this.dialog.open(FormUsersComponent, {
      width: '400px',
      data: postSeleccionado
    });
    dialogRef.afterClosed().subscribe(result => {
      if (result === 'reload') {
        this.obtenerusers(); // Recarga la tabla
        console.log("cargar");
      }
    });
  }
  deleteusers(id: number) {
    Swal.fire({
      showCancelButton: true,
      title: '¿Estás seguro de eliminar el User seleccionado?',
      text: `A continuación se eliminará el User.`,
      icon: 'warning',
      confirmButtonColor: '#765dfb',
      cancelButtonColor: '#d5d7f9',
      cancelButtonText: 'Cancelar',
      confirmButtonText: 'Aceptar'
    }).then((result) => {
      if (result.isConfirmed) {
        this.gateWayService.deleteUser(id).subscribe({
          next: () => {
            Swal.fire({
              title: 'User Eliminado Exitosamente',
              text: `Se ha eliminado el User.`,
              icon: 'success',
              confirmButtonColor: '#765dfb',
              confirmButtonText: 'Aceptar'
            }).then(() => {
              this.obtenerusersGuardados();
            });
          },
          error: (e) => {
            console.error(e);
            Swal.fire('Error', 'No se pudo eliminar el usuario.', 'error');
          }
        });
      }
    }).catch((e) => {
      console.error(e);
    });
  }


  onSelectionChanged(selectedUsers: User[]) {
    console.log('Usuarios seleccionados:', selectedUsers);
    // Aquí puedes guardar esta lista o enviarla a un servicio
  }

  onGuardarSeleccionados(items: any[]) {
    // Aquí haces lo que necesites con los elementos seleccionados
    this.gateWayService.enviarUsers(items).subscribe({
      next: () =>
        Swal.fire({
          title: 'Registros Guardados existosamente',
          icon: 'success',
          confirmButtonColor: '#765dfb',
          confirmButtonText: 'Aceptar'
        }).then(() => {
          this.obtenerusersGuardados();
        }),
      error: err => alert('Error al guardar: ' + err.message)
    });
  }
}
