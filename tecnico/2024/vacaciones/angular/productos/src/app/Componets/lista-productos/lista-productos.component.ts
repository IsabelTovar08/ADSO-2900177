import { Component, inject, OnInit } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatToolbarModule } from '@angular/material/toolbar';
import {MatCardModule} from '@angular/material/card';
import { Router, RouterLink } from '@angular/router';
import { CrearProducto } from '../../models/producto.models';
import { ProductoServiceService } from '../../Services/producto-service.service';
import { SweetAlert2Module } from '@sweetalert2/ngx-sweetalert2';
import Swal from 'sweetalert2';
import { CommonModule } from '@angular/common';


@Component({
  selector: 'app-lista-productos',
  // standalone: true,
  imports: [MatToolbarModule, MatIconModule, MatButtonModule, RouterLink, MatCardModule, RouterLink, SweetAlert2Module, CommonModule],
  templateUrl: './lista-productos.component.html',
  styleUrl: './lista-productos.component.css'
})
export class ListaProductosComponent implements OnInit {
  productoService = inject(ProductoServiceService)
  router = inject(Router)

  productos?: any[] = [];
  bancos?: any[] = [];
  mostrarTexto: boolean = false;

  constructor(){
    // this.cargarProductos()
  }
  ngOnInit(): void {
    this.ListarBancos()
  }

  ListarBancos(){
    this.productoService.ObtenerTodo('Banco').subscribe((bancos) => {
      this.bancos = bancos.data;

      console.log(this.bancos)
    })
  }

  cargarProductos(){
    this.productoService.ObtenerProductos().subscribe(producto => {
      this.productos = producto;
    });
  }

  eliminar(id: number){
    this.productoService.Eliminar(id).subscribe(() => {
      this.cargarProductos()
    })
  }

  mostrarTextoFuncion(){
    this.mostrarTexto = !this.mostrarTexto;
    console.log(this.mostrarTexto);
    
  }
}
