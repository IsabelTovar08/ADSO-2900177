import { Component, inject } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { PersonaService } from '../services/persona.service';
import {MatCardModule} from '@angular/material/card';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, MatCardModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'apiProyecto';
  
  persona?: any[] = [];
  roles?: any[] = [];

  ps = inject(PersonaService);

  constructor() {
    console.log("constructor")

    this.ListarPersona()
    this.ListarRol()
  }
  // constructor(){
  //   console.log("constructor")
  // }
  ListarPersona(){
    this.ps.ObtenerTodo("Person").subscribe(persona => {
      this.persona = persona;
      console.log(this.persona)
    })
  } 
  ListarRol(){
    this.ps.ObtenerTodo("Role").subscribe(persona => {
      this.roles = persona;
      console.log(this.persona)
    })
  } 

}
