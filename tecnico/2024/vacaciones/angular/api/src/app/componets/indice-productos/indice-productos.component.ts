import { Component, inject } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { RouterLink } from '@angular/router';
import { LaptopService } from '../../services/laptop.service';
import { Laptop } from '../../models/laptop.models';
import {MatTableModule} from '@angular/material/table';

@Component({
  selector: 'app-indice-productos',
  imports: [ MatButtonModule, RouterLink, MatTableModule],
  templateUrl: './indice-productos.component.html',
  styleUrl: './indice-productos.component.css'
})
export class IndiceProductosComponent {
  laptopService = inject(LaptopService);
  laptops?: Laptop[];
  columnasMostrar = ['nombre', 'acciones']

  constructor(){
    this.cargarProductos();
    console.log("Constructor para cargar productos")
  }

  cargarProductos(){
    this.laptopService.ObtenerTodos().subscribe(laptops => {
      this.laptops = laptops;
    console.log("Cargado"+ laptops)
    })
  }

  eliminar(id: number){
    this.laptopService.EliminarLaptop(id).subscribe(() =>{
      this.cargarProductos();
    })
  }
}
