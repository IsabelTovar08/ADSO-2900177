import { Component, inject } from '@angular/core';
import { LibrosService } from '../../Services/libros.service';
import { RouterLink } from '@angular/router';

import {MatIconModule} from '@angular/material/icon';
import {MatButtonModule} from '@angular/material/button';
import {MatTableModule} from '@angular/material/table';
import { SweetAlert2Module } from '@sweetalert2/ngx-sweetalert2';

@Component({
  selector: 'app-lista-libros',
  imports: [RouterLink, MatButtonModule, MatIconModule, MatTableModule, SweetAlert2Module],
  templateUrl: './lista-libros.component.html',
  styleUrl: './lista-libros.component.css'
})
export class ListaLibrosComponent {

  private libroService = inject(LibrosService)
  libros!: any[];
  columnasTabla = [ 'titulo', 'autor', 'Fecha_publicacion', 'acciones']

  constructor(){
   this.ObtenerLibros()
  }
  ObtenerLibros(){
    this.libroService.ObtenerLibros().subscribe(libros => {
      this.libros = libros;
    })
  }
  EliminarRegistro(id : number) {
    this.libroService.EliminarLibro(id).subscribe(() => {
      this.ObtenerLibros()
    })
  }
}
