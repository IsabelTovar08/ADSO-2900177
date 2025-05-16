import { Component, inject, Input, numberAttribute, OnInit } from '@angular/core';
import { LaptopService } from '../../services/laptop.service';
import { CrearLaptop, Laptop } from '../../models/laptop.models';
import { FormularioProductoComponent } from "../formulario-producto/formulario-producto.component";
import { loadavg } from 'os';
import { Router } from 'express';

@Component({
  selector: 'app-editar-producto',
  // imports: [FormularioProductoComponent],
  templateUrl: './editar-producto.component.html',
  styleUrl: './editar-producto.component.css'
})
export class EditarProductoComponent implements OnInit{
  @Input({transform: numberAttribute})
  id!: number;

  laptopService = inject(LaptopService);
  router = inject(Router)

  modelo?: Laptop;

  ngOnInit(): void {
    this.laptopService.ObtenerPorId(this.id).subscribe(laptop => {
      this.modelo = laptop
    })
  }
  guardarCambios(laptop: CrearLaptop){
    this.laptopService.ActualizarLaptop(this.id, laptop).subscribe(() =>{
      this.router.navegate(['/productos'])
    })
  }


 
}
