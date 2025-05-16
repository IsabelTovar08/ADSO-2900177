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
import { FormFormComponent } from '../form-form/form-form.component';

@Component({
  selector: 'app-list-form',
  imports: [MatCardModule, MatTableModule, MatIconModule, MatButtonModule, MatFormFieldModule, FormsModule, MatInputModule],
  templateUrl: './list-form.component.html',
  styleUrl: './list-form.component.css'
})
export class ListFormComponent {
  forms: [] = [];
  formseleccionado?: any;
  nombreuser: String = '';
  filteredforms: any[] = [];


  displayedColumns: string[] = ['name', 'description', 'status', 'actions'];

  constructor(private dialog: MatDialog, private apiService: ApiService) { }

  ngOnInit(): void {
    this.cargarforms();
  }
cargarforms(){
  this.apiService.ObtenerTodo('form').subscribe(forms => {
    this.forms = forms;
    console.log(forms)
  })
}
  openFormCreate(): void {
    const dialogRef = this.dialog.open(FormFormComponent, {
      width: '400px',
      data: null
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result === 'reload') {
        this.cargarforms(); // Recarga la tabla
        console.log("cargar");
      }
    });
  }

  editforms(forms: any): void {
    // Abre el formulario con los datos del forms
    const dialogRef = this.dialog.open(FormFormComponent, {
      width: '400px',
      data: this.formseleccionado
    });
    dialogRef.afterClosed().subscribe(result => {
      if (result === 'reload') {
        this.cargarforms(); // Recarga la tabla
        console.log("cargar");
      }
    });
  }

  deleteforms(forms: any): void {
    Swal.fire({
      title: '¿Estás seguro?',
      text: `¿Quieres eliminar el forms: ${forms.name}?`,
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#765dfb',
      cancelButtonColor: '#d5d7f9',
      confirmButtonText: 'Eliminar',
      cancelButtonText: 'Cancelar'
    }).then((result) => {
      if (result.isConfirmed) {
       this.apiService.delete('form', forms.id).subscribe(() => {
        this.cargarforms();
       })
      }
    });
  }
}
