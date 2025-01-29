import { Routes } from '@angular/router';
import { LandingComponent } from './componets/landing/landing.component';
import { IndiceProductosComponent } from './componets/indice-productos/indice-productos.component';
import { EditarProductoComponent } from './componets/editar-producto/editar-producto.component';
import { CrearProductosComponent } from './componets/crear-productos/crear-productos.component';

export const routes: Routes = [
    {path: '', component: LandingComponent},
    {path: 'productos', component: IndiceProductosComponent},
    {path: 'productos/crear', component: CrearProductosComponent},
    {path: 'productos/editar/:id', component: EditarProductoComponent}

];
