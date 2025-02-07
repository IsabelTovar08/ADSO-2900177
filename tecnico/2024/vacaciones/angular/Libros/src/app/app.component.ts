import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ListaLibrosComponent } from "./Componets/lista-libros/lista-libros.component";
import { MenuComponent } from "./Componets/menu/menu.component";

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, ListaLibrosComponent, MenuComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'Libros';
}
