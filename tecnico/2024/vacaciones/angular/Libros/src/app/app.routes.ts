import { Routes } from '@angular/router';
import { ListaLibrosComponent } from './Componets/lista-libros/lista-libros.component';
import { CrearLibroComponent } from './Componets/crear-libro/crear-libro.component';
import { EditarLibroComponent } from './Componets/editar-libro/editar-libro.component';

export const routes: Routes = [
    { path: '', component: ListaLibrosComponent },
    { path: 'crearLibro', component: CrearLibroComponent },
    { path: 'editarLibro/:id', component: EditarLibroComponent }
];
