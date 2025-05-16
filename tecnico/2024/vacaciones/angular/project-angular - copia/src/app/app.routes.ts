import { Routes } from "@angular/router";
import { EditarTareaComponent } from "./componets/editar-tarea/editar-tarea.component";
import { TareasComponent } from "./componets/tareas/tareas.component";
import { AppComponent } from "./app.component";
import { ListTaskComponent } from "./componets/list-task/list-task.component";

export const routes: Routes =[
    { path: '', component: TareasComponent },
    { path: 'editar/:id', component: EditarTareaComponent}
];