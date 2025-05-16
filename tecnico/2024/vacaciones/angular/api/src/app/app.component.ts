import { Component, inject } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ApiService } from './services/api.service';
import { MenuComponent } from './componets/menu/menu.component';

@Component({
  selector: 'app-root',
  imports: [ MenuComponent, RouterOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  apiServicio = inject(ApiService)
  climas: any[] = [];

  constructor() {
    this.apiServicio.ObtenerClima().subscribe(datos => {
      this.climas = datos;
    })
  }
}
