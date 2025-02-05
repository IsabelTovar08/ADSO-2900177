import { Component, Input, Output, EventEmitter,OnChanges, SimpleChanges } from '@angular/core';
import { Task } from '../../models/task.interface';
import { ApiService } from '../../services/api.service';

@Component({
  selector: 'app-list-task',
  standalone: false,
  
  templateUrl: './list-task.component.html',
  styleUrl: './list-task.component.css'
})
export class ListTaskComponent {
    climas: any[] = [];
  tareaas?: any[] = [];

  
    constructor(private apiService: ApiService) {
      this.apiService.ObtenerApi().subscribe(clima => {
        this.climas = clima;
      })
      
      this.ObtenerLasTareas()
    }
   public ObtenerLasTareas(){
    this.apiService.ObtenerTareas().subscribe(tarea => {
      this.tareaas = tarea;
    })
   }
   TareaCompletada(tarea:any){
    var editada = tarea as Task; 
    editada.completada = !editada.completada;
    this.apiService.EditarTarea(tarea.id, editada).subscribe(() => {
      this.ObtenerLasTareas()
      console.log("Tarea Completa")
    })
   }
   public EliminarTarea(id:number){
    this.apiService.EliminarTarea(id).subscribe(() => {
      this.tareaas = undefined
      this.ObtenerLasTareas()

    })

   }
}

