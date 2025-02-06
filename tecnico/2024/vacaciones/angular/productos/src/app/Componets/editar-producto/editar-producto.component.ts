import { Component, inject, Input, numberAttribute, OnInit } from '@angular/core';
import { FormularioComponent } from "../formulario/formulario.component";
import { ProductoServiceService } from '../../Services/producto-service.service';
import { CrearProducto, Producto } from '../../models/producto.models';
import { Router } from '@angular/router';

@Component({
  selector: 'app-editar-producto',
  imports: [FormularioComponent],
  templateUrl: './editar-producto.component.html',
  styleUrl: './editar-producto.component.css'
})
export class EditarProductoComponent implements OnInit{
  @Input({transform: numberAttribute}) id!: number

  productoService = inject(ProductoServiceService)
  router = inject(Router)
  productoLlega?: Producto;


  ngOnInit(): void {
    this.productoService.ObtenerProductoPorId(this.id).subscribe((producto) => {
      this.productoLlega = producto;
      console.log(producto)
    console.log( this.productoLlega)

    })
    console.log( this.productoLlega)

  }
  constructor(){
    
  }

  ActualizarProducto(producto: CrearProducto){
    console.log( this.productoLlega)

    // this.productoService.EditarProducto(this.id, producto).subscribe(() => {
    //   this.router.navigate(['/'])
    //   console.log("Actualizado")
    // })
  }
}
