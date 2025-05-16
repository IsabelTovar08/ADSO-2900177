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
import { AuthService } from '../../../../services/auth-service.service';
<<<<<<< HEAD

@Component({
  selector: 'app-lista-roles',
  imports: [CommonModule, MatSlideToggle,MatCardModule, MatTableModule, MatIconModule, MatButtonModule, MatFormFieldModule, FormsModule, MatInputModule],
=======
import { MatTooltipModule } from '@angular/material/tooltip';


@Component({
  selector: 'app-lista-roles',
  imports: [CommonModule, MatSlideToggle, MatCardModule, MatTableModule, MatIconModule, MatButtonModule, MatFormFieldModule, FormsModule, MatInputModule, MatTooltipModule],
>>>>>>> mayo
  templateUrl: './lista-roles.component.html',
  styleUrl: './lista-roles.component.css'
})
export class ListaRolesComponent {
  roles: [] = [];
<<<<<<< HEAD
=======
  rolesAc: [] = [];
>>>>>>> mayo
  roleseleccionado?: any;
  nombreuser: String = '';
  filteredroles: any[] = [];
  isAdmin = false;

  displayedColumns: string[] = ['name', 'description', 'actions'];

<<<<<<< HEAD
  constructor(private dialog: MatDialog, private apiService: ApiService, private authService: AuthService) { 
=======
  constructor(private dialog: MatDialog, private apiService: ApiService, private authService: AuthService) {
>>>>>>> mayo
    this.isAdmin = this.authService.getUserRoles().includes('Admin');
    if (this.isAdmin) {
      this.displayedColumns.push('status')
    }
  }

  ngOnInit(): void {
<<<<<<< HEAD
    this.cargarroles();
  }
cargarroles(){
  this.apiService.ObtenerTodo('rol').subscribe(roles => {
    if (!this.isAdmin) {
      this.roles = roles.filter((r: any) => r.status === true || r.status === 1);
    } else {
      this.roles = roles;
    }
    console.log(roles)
  })
}
=======
    if (this.isAdmin) {
      this.cargarroles();
    }
    else {
      this.cargarrolesActive();
    }
  }
  cargarroles() {
    this.apiService.ObtenerTodo('rol').subscribe(roles => {
      this.roles = roles;
    })
  }
  cargarrolesActive() {
    this.apiService.ObtenerActivos('rol').subscribe(roles => {
      this.roles = roles;
    })
  }
>>>>>>> mayo
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

<<<<<<< HEAD
  editroles(roles: any): void {
=======
  isDisabled(rol: any): boolean {
    return !rol.status && !this.isAdmin;
  }


  editroles(): void {
>>>>>>> mayo
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
<<<<<<< HEAD
       this.apiService.delete('rol', roles.id).subscribe(() => {
        this.cargarroles();
       })
=======
        if (this.isAdmin) {
          this.apiService.delete('rol', roles.id).subscribe(() => {
            this.cargarroles();
          })
        }
        else {
          this.toggleIsActive(roles);
          this.cargarrolesActive();
        }
>>>>>>> mayo
      }
    });
  }

<<<<<<< HEAD
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
=======

  toggleIsActive(rol: any) {
    this.apiService.deleteLogic('rol', rol.id).subscribe({
      next: (response: boolean) => {
        if (response) {
          Swal.fire({
            title: `Actualización exitosa`,
            icon: 'success',
            confirmButtonColor: '#765dfb',
            cancelButtonColor: '#d5d7f9',
            confirmButtonText: 'Aceptar',
          }).then((result) => {
            if (result.isConfirmed) {
              if (!this.isAdmin) {
                this.cargarrolesActive();
              }
            }
          });
        } else {
          // Cuando la API responde false (operación fallida)
          Swal.fire({
            title: 'Error',
            text: 'No se pudo actualizar el rol.',
            icon: 'error',
            confirmButtonColor: '#765dfb'
          });
        }
      },
      error: (err) => {
        // Cuando ocurre un error en la petición
        console.error('Error al actualizar el rol:', err);
        Swal.fire({
          title: 'Error del servidor',
          text: 'Ocurrió un error inesperado. Intente más tarde.',
          icon: 'error',
          confirmButtonColor: '#765dfb'
        });
      }
    });

>>>>>>> mayo
  }
}
