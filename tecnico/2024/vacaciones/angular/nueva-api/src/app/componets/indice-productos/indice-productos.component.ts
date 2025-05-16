import { Component } from '@angular/core';
import { LaptopService } from '../../services/laptop.service';
import { Laptop } from '../../models/laptop.models';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-indice-productos',
  standalone: false,
  templateUrl: './indice-productos.component.html',
  styleUrl: './indice-productos.component.css'
})
export class IndiceProductosComponent {
  laptops?: Laptop[];
  columnasAMostrar = ['nombre', 'acciones']

  constructor(private laptopService: LaptopService) {
    this.cargarPoductos()
  }

  cargarPoductos() {
    this.laptopService.ObtenerTodos().subscribe(laptops => {
      this.laptops = laptops;
    })
  }

  eliminar(id: number) {
    this.laptopService.Eliminar(id).subscribe(() => {
      this.laptops = undefined
      Swal.fire({
        title: "Exitoso",
        text: "El registro ha sido eliminado.",
        icon: "success"
      });  
      
      this.cargarPoductos()
    })
  }

}
