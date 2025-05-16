import { Component, computed, signal } from '@angular/core';
import { GenericTableComponent } from "../../generic-table/generic-table.component";
import { ApiService } from '../../../services/api.service';
import { MatDialog } from '@angular/material/dialog';
import { FormPostComponent } from '../../Posts/form-post/form-post.component';
import Swal from 'sweetalert2';
import { FormAlbumsComponent } from '../form-albums/form-albums.component';
import { GatewayService } from '../../../services/gateway/gateway.service';
import { MatButton, MatButtonModule } from '@angular/material/button';

@Component({
  selector: 'app-lista-albums',
  imports: [GenericTableComponent, MatButtonModule],
  templateUrl: './lista-albums.component.html',
  styleUrl: './lista-albums.component.css'
})
export class ListaAlbumsComponent {
  albums: any[] = [];
  displayedColumns = ['title', 'username', 'actions', 'agregar'];
  constructor(private apiService:ApiService, private dialog: MatDialog, private gateWayService: GatewayService){
    this.obtenerAlbums();
  }


  obtenerAlbums() {
    this.apiService.ObtenerTodo('albums').subscribe((albumsData) => {
      this.apiService.ObtenerTodo('users').subscribe((usersData) => {
        // Enlaza el nombre de usuario a cada álbum
        this.albums = albumsData.map((album: any) => {
          const user = usersData.find((u: any) => u.id === album.userId);
          return {
            ...album,
            username: user ? user.username : 'Desconocido'
          };
        });
      });
    });
  }
  
  save(postSeleccionado: any){
    console.log(postSeleccionado)
    const dialogRef = this.dialog.open(FormAlbumsComponent, {
      width: '400px',
      data: postSeleccionado
    });
    dialogRef.afterClosed().subscribe(result => {
      if (result === 'reload') {
        this.obtenerAlbums(); // Recarga la tabla
        console.log("cargar");
      }
    });
  }
  deleteAlbums(id: number){
    Swal.fire({
      showCancelButton: true,
      title: '¿Estás seguro de eliminar el Album seleccionado?',
      text: `A continuación se eliminará el Album con id ${id}.`,
      icon: 'warning',
      confirmButtonColor: '#765dfb',
      cancelButtonColor: '#d5d7f9',
      cancelButtonText: 'Cancelar',
      confirmButtonText: 'Aceptar'
    }).then((result) => {
      if(result.isConfirmed){
        this.apiService.delete('albums', id).subscribe(() => {
          Swal.fire({
            title: 'Album Eliminado Exitosamente',
            text: `Se ha eliminado el Album con id ${id}`,
            icon: 'success',
            confirmButtonColor: '#765dfb',
            cancelButtonColor: '#d5d7f9',
            confirmButtonText: 'Aceptar'
          })
        });
      }
    })
    .catch((e) => {
      console.error(e);
    })
  }
  addAlbums(){
    Swal.fire({
      showCancelButton: true,
      title: '¿Estás seguro de agregar el Album seleccionado?',
      text: `A continuación el registro seleccionado se almacenará permanentemente.`,
      icon: 'warning',
      confirmButtonColor: '#765dfb',
      cancelButtonColor: '#d5d7f9',
      cancelButtonText: 'Cancelar',
      confirmButtonText: 'Aceptar'
    })
  }
onSelectionChanged(selectedUsers: any[]) {
    console.log('Usuarios seleccionados:', selectedUsers);
    // Aquí puedes guardar esta lista o enviarla a un servicio
  }

  onGuardarSeleccionados(items: any[]) {
    // Aquí haces lo que necesites con los elementos seleccionados
    this.gateWayService.enviarUsers(items).subscribe({
      next: () => alert('¡Usuarios guardados con éxito!'),
      error: err => alert('Error al guardar: ' + err.message)
    });
  }
}
