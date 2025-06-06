import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatDialog } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatTableModule } from '@angular/material/table';
import Swal from 'sweetalert2';
import { ApiService } from '../../../../services/api.service';
import { FormUserComponent } from '../../User/form-user/form-user.component';
import { FormModuleComponent } from '../form-module/form-module.component';

@Component({
  selector: 'app-list-module',
  imports: [MatCardModule, MatTableModule, MatIconModule, MatButtonModule, MatFormFieldModule, FormsModule, MatInputModule],
  templateUrl: './list-module.component.html',
  styleUrl: './list-module.component.css'
})
export class ListModuleComponent {
  modules: [] = [];
  moduleseleccionado?: any;
  filteredmodules: any[] = [];


  displayedColumns: string[] = ['name', 'description', 'status', 'actions'];

  constructor(private dialog: MatDialog, private apiService: ApiService) { }

  ngOnInit(): void {
    this.cargarmodules();
  }
cargarmodules(){
  this.apiService.ObtenerTodo('module').subscribe(modules => {
    this.modules = modules;
    console.log(modules)
  })
}
  openFormCreate(): void {
    const dialogRef = this.dialog.open(FormModuleComponent, {
      width: '400px',
      data: null
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result === 'reload') {
        this.cargarmodules(); // Recarga la tabla
        console.log("cargar");
      }
    });
  }

  editmodules(modules: any): void {
    // Abre el formulario con los datos del modules
    const dialogRef = this.dialog.open(FormModuleComponent, {
      width: '400px',
      data: this.moduleseleccionado
    });
    dialogRef.afterClosed().subscribe(result => {
      if (result === 'reload') {
        this.cargarmodules(); // Recarga la tabla
        console.log("cargar");
      }
    });
  }

  deletemodules(modules: any): void {
    Swal.fire({
      title: '¿Estás seguro?',
      text: `¿Quieres eliminar el modules: ${modules.name}?`,
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#765dfb',
      cancelButtonColor: '#d5d7f9',
      confirmButtonText: 'Eliminar',
      cancelButtonText: 'Cancelar'
    }).then((result) => {
      if (result.isConfirmed) {
       this.apiService.delete('module', modules.id).subscribe(() => {
        this.cargarmodules();
       })
      }
    });
  }
}
