import { Routes } from '@angular/router';
import { ListaProductosComponent } from './Componets/lista-productos/lista-productos.component';
import { CrearProductosComponent } from './Componets/crear-productos/crear-productos.component';
import { EditarProductoComponent } from './Componets/editar-producto/editar-producto.component';

export const routes: Routes = [
    { path : '', component: ListaProductosComponent},
    { path: 'CrearProductos', component: CrearProductosComponent}, 
    { path: 'EditarProducto/:id', component: EditarProductoComponent}
];
