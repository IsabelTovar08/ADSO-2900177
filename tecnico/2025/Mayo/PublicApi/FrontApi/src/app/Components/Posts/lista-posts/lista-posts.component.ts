import { Component } from '@angular/core';
import { ApiService } from '../../../services/api.service';
import { MatCardModule } from '@angular/material/card';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { FormPostComponent } from '../form-post/form-post.component';
import { MatDialog } from '@angular/material/dialog';
import { FormcommentsComponent } from '../../comments/formcomments/formcomments.component';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-lista-posts',
  imports: [
    MatCardModule, 
    CommonModule,
     RouterLink,
      MatIconModule, 
      MatButtonModule
    ],

  templateUrl: './lista-posts.component.html',
  styleUrl: './lista-posts.component.css'
})
export class ListaPostsComponent {
  result: any[] = [];
  comentarios: any[] = [];

  postIdActual: number | null = null;
  postSeleccionado: any;
  commentSeleccionado: any;

  constructor(private apiService: ApiService, private dialog: MatDialog) {
    this.cargarPosts();
  }

  // POSTS 
  cargarPosts() {
    this.apiService.ObtenerTodo('posts').subscribe((data) => {
      this.result = data;
    });
  }

  // Abrir Modal para Crear o Actializar un Post 
  savePosts(): void {
    // Abre el formulario con los datos del modules
    const dialogRef = this.dialog.open(FormPostComponent, {
      width: '400px',
      data: this.postSeleccionado
    });
    dialogRef.afterClosed().subscribe(result => {
      if (result === 'reload') {
        this.cargarPosts(); // Recarga la tabla
        console.log("cargar");
      }
    });
  }
  deletePost(id: number) {
    Swal.fire({
      showCancelButton: true,
      title: '¿Estás seguro de eliminar el post seleccionado?',
      text: `A continuación se eliminará el post con id ${id}.`,
      icon: 'warning',
      confirmButtonColor: '#765dfb',
      cancelButtonColor: '#d5d7f9',
      cancelButtonText: 'Cancelar',
      confirmButtonText: 'Aceptar'
    }).then((result) => {
      if(result.isConfirmed){
        this.apiService.delete('posts', id).subscribe(() => {
          Swal.fire({
            title: 'Post Eliminado Exitosamente',
            text: `Se ha eliminado el post con id ${id}`,
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

  // COMENTARIOS 
  cargarComentarios(postId: number) {
    if (this.postIdActual === postId) {
      // Si se vuelve a hacer clic, oculta los comentarios
      this.postIdActual = null;
    } else {
      this.apiService.ObtenerTodo('comments').subscribe((data) => {
        this.comentarios = data.filter((d: any) => d.postId === postId);
        this.postIdActual = postId;
      });
    }
  }
  saveComments() {
    const dialogRef = this.dialog.open(FormcommentsComponent, {
      width: '400px',
      data: this.commentSeleccionado
    });
    // Límpia el objeto para que no se guarde el valor anterior
    this.commentSeleccionado = null;

    dialogRef.afterClosed().subscribe(result => {
      if (result === 'reload') {
        this.cargarPosts(); // Recarga la tabla
        console.log("cargar");
      }
    });
  }
  deleteComent(id: number){
    Swal.fire({
      showCancelButton: true,
      title: '¿Estás seguro de eliminar el comentario seleccionado?',
      text: `A continuación se eliminará el comentario con id ${id}.`,
      icon: 'warning',
      confirmButtonColor: '#765dfb',
      cancelButtonColor: '#d5d7f9',
      cancelButtonText: 'Cancelar',
      confirmButtonText: 'Aceptar'
    }).then((result) => {
      if(result.isConfirmed){
        this.apiService.delete('comments', id).subscribe(() => {
          Swal.fire({
            title: 'comentario Eliminado Exitosamente',
            text: `Se ha eliminado el comentario con id ${id}`,
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

}
