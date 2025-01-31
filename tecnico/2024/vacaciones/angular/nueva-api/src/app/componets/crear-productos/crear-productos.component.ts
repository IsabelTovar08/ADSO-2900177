import { Component, Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { LaptopService } from '../../services/laptop.service';
import { Router } from '@angular/router';
import { LaptopCreacion } from '../../models/laptop.models';
import { extraerErrores } from '../compartidos/funciones/extraerErrores';

@Component({
  selector: 'app-crear-productos',
  standalone: false,
  
  templateUrl: './crear-productos.component.html',
  styleUrl: './crear-productos.component.css'
})
export class CrearProductosComponent {
  // laptopService = Inject(LaptopService);
  // router = Inject(Router);
  errores:string[] = [];

  constructor(private laptopService: LaptopService, private router: Router) { }

  guardarCambios(laptop: LaptopCreacion){
    this.laptopService.CrearLaptop(laptop).subscribe({
      next:() => {
        this.router.navigate(["productos"]);
      },
      error: err => {
        const errores = extraerErrores(err)
        this.errores = errores;
      }
    })
  }
}
