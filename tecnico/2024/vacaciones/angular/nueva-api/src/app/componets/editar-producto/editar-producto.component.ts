import { Component, Input, numberAttribute, OnInit } from '@angular/core';
import { LaptopService } from '../../services/laptop.service';
import { Laptop, LaptopCreacion } from '../../models/laptop.models';
import { Router } from '@angular/router';
import { extraerErrores } from '../compartidos/funciones/extraerErrores';

@Component({
  selector: 'app-editar-producto',
  standalone: false,
  
  templateUrl: './editar-producto.component.html',
  styleUrl: './editar-producto.component.css'
})
export class EditarProductoComponent implements OnInit {
  @Input({ transform: numberAttribute }) id!: number;
  modelo?: Laptop;
  errores: string[] = [];

  
  constructor(private laptopService: LaptopService, private router: Router) { }
  
  ngOnInit(): void {
    this.laptopService.ObtenerPorId(this.id).subscribe(laptop => {
      this.modelo = laptop;
    })
  }

  guardarCambios(laptop: LaptopCreacion){
    this.laptopService.Actualizar(this.id, laptop).subscribe({
      next: () => {
        this.router.navigate(['/productos']);
      }, error: err => {
        const errores = extraerErrores(err);
        this.errores = errores;
      }
    })
  }
}
