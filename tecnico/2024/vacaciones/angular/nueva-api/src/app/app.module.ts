import { importProvidersFrom, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { MenuComponent } from './componets/menu/menu.component';

import {MatIconModule} from '@angular/material/icon';
import {MatButtonModule} from '@angular/material/button';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatFormFieldModule} from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatTableModule } from '@angular/material/table';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';

import { provideRouter, RouterLink, RouterModule, withComponentInputBinding } from '@angular/router';
import { LandingComponent } from './componets/landing/landing.component';
import { IndiceProductosComponent } from './componets/indice-productos/indice-productos.component';
import { routes } from './app.routes';
import { CrearProductosComponent } from './componets/crear-productos/crear-productos.component';
import { ReactiveFormsModule } from '@angular/forms';
import { EditarProductoComponent } from './componets/editar-producto/editar-producto.component';
import { FormularioProductoComponent } from './componets/formulario-producto/formulario-producto.component';

import { SweetAlert2Module } from '@sweetalert2/ngx-sweetalert2';
import { LoadingComponent } from './componets/compartidos/componentes/loading/loading.component';
import { MostrarErroresComponent } from './componets/compartidos/componentes/mostrar-errores/mostrar-errores.component';

@NgModule({
  declarations: [
    AppComponent,
    MenuComponent,
    LandingComponent,
    IndiceProductosComponent,
    CrearProductosComponent,
    EditarProductoComponent,
    FormularioProductoComponent,
    LoadingComponent,
    MostrarErroresComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,

    MatIconModule,
    MatButtonModule,
    MatToolbarModule,
    MatFormFieldModule,
    MatInputModule,
    MatTableModule,
    MatProgressSpinnerModule,

    RouterModule.forRoot(routes),
    RouterLink,
    ReactiveFormsModule,
    SweetAlert2Module.forRoot() 
  ],
  providers: [
    provideAnimationsAsync(),
    provideRouter(routes, withComponentInputBinding()),
    // importProvidersFrom([SweetAlert2Module.forRoot()])
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
