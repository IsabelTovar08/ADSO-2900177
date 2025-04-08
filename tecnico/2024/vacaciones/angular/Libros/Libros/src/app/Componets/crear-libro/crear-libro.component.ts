import { Component, inject } from '@angular/core';
import { FormularioComponent } from "../formulario/formulario.component";
import { LibrosService } from '../../Services/libros.service';
import { LibroCrear } from '../../Models/Libro.nodels';
import { Router } from '@angular/router';

@Component({
  selector: 'app-crear-libro',
  imports: [FormularioComponent],
  templateUrl: './crear-libro.component.html',
  styleUrl: './crear-libro.component.css'
})
export class CrearLibroComponent {
  private libroService = inject(LibrosService)
  router = inject(Router)

  crearLibro(libro: LibroCrear){
    console.log(libro)
    this.libroService.CrearLibro(libro).subscribe(() => {
      this.router.navigate(['/']);
    })
  }
}
