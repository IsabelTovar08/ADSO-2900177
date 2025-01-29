import { Component, inject } from '@angular/core';
import { ApiService } from '../../services/api.service';

@Component({
  selector: 'app-landing',
  imports: [],
  templateUrl: './landing.component.html',
  styleUrl: './landing.component.css'
})
export class LandingComponent {
  apiServicio = inject(ApiService)
    climas: any[] = [];
  
    constructor() {
      this.apiServicio.ObtenerClima().subscribe(datos => {
        this.climas = datos;
      })
    }
}
