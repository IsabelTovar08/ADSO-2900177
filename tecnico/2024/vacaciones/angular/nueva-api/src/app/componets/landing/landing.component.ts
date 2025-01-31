import { Component } from '@angular/core';
import { ApiService } from '../../services/api.service';

@Component({
  selector: 'app-landing',
  standalone: false,
  
  templateUrl: './landing.component.html',
  styleUrl: './landing.component.css'
})
export class LandingComponent {
  climas: any[] = [];

  constructor(private apiService: ApiService) {
    // Aquí inyectamos ApiService a través del constructor
    this.apiService.ObtenerClima().subscribe(datos => {
      this.climas = datos;
    });
  }
}
