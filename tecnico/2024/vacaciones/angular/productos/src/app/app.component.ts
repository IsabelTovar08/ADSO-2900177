import { Component, inject } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ProductoServiceService } from './Services/producto-service.service';
import { MenuComponent } from "./Componets/menu/menu.component";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
  imports: [MenuComponent, RouterOutlet]
})
export class AppComponent {
  title = 'productos';

  climaServicio = inject(ProductoServiceService)

  climas: any[] = [];
  constructor(){
    this.climaServicio.ObteberClima().subscribe((clima) => {
      this.climas = clima;
    })
  }
}
