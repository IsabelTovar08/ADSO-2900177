import { NgModule } from '@angular/core';
import { BrowserModule, provideClientHydration, withEventReplay } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { addComponet } from './componets/addTask/add.component';
import { ListTaskComponent } from './componets/list-task/list-task.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { StatusTaskDirective } from './directives/status-task.directive';
import { ConfirmDeleteDirective } from './directives/confirm-delete.directive';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent,
    addComponet,

    ListTaskComponent,
    StatusTaskDirective,
    ConfirmDeleteDirective
    // addComponet
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [
    provideClientHydration(withEventReplay())
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
