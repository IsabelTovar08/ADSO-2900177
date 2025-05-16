import { NgModule } from '@angular/core';
import { BrowserModule, provideClientHydration, withEventReplay } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { addComponet } from './componets/addTask/add.component';
import { ListTaskComponent } from './componets/list-task/list-task.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { StatusTaskDirective } from './directives/status-task.directive';
import { ConfirmDeleteDirective } from './directives/confirm-delete.directive';
import { HttpClient, HttpClientModule, provideHttpClient, withFetch } from '@angular/common/http';
import { SweetAlert2Module } from '@sweetalert2/ngx-sweetalert2';

import {MatIconModule} from '@angular/material/icon';
import {MatButtonModule} from '@angular/material/button';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatFormFieldModule} from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatTableModule } from '@angular/material/table';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { EditarTareaComponent } from './componets/editar-tarea/editar-tarea.component';
import { provideRouter, RouterLink, RouterModule, withComponentInputBinding } from '@angular/router';
import { routes } from './app.routes';
import { TareasComponent } from './componets/tareas/tareas.component';

@NgModule({
  declarations: [
    AppComponent,
    addComponet,

    ListTaskComponent,
    StatusTaskDirective,
    ConfirmDeleteDirective,
    EditarTareaComponent,
    TareasComponent,
    // MenuComponent
    // addComponet
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    SweetAlert2Module.forRoot() ,

    RouterModule.forRoot(routes),
    RouterLink,
   
    MatIconModule,
    MatButtonModule,
    MatToolbarModule,
    MatFormFieldModule,
    MatInputModule,
    MatTableModule,
    MatProgressSpinnerModule
    
  ],
  providers: [
    // provideClientHydration(withEventReplay()),
    provideHttpClient(withFetch()),
    provideAnimationsAsync(),
    provideRouter(routes, withComponentInputBinding()),


  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
