import { Component, inject, Input, numberAttribute, OnInit } from '@angular/core';
import { FormularioComponent } from "../formulario/formulario.component";
import { LibrosService } from '../../Services/libros.service';
import { Libro, LibroCrear } from '../../Models/Libro.nodels';
import { Router } from '@angular/router';

@Component({
  selector: 'app-editar-libro',
  imports: [FormularioComponent],
  templateUrl: './editar-libro.component.html',
  styleUrl: './editar-libro.component.css'
})
export class EditarLibroComponent implements OnInit {
  @Input({transform: numberAttribute}) id!: number;

  modeloLibro?: Libro

  libroService = inject(LibrosService)
  router = inject(Router)

  ngOnInit(): void {
    this.libroService.ObtenrrLibroPorId(this.id).subscribe((libro) => {
      this.modeloLibro = libro
    })
  }

  EditarLibro(libro : LibroCrear) {
    this.libroService.ActualizarLibro(this.id, libro).subscribe(() => {
      this.router.navigate(['/'])
    })
  }
}
