import { AfterViewInit, Component, DoCheck, OnDestroy, OnInit } from '@angular/core';
import { Task } from './models/task.interface';
import { TaskService } from './services/task.service';
import { Subscription } from 'rxjs';
import { ApiService } from './services/api.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  standalone: false,
  styleUrl: './app.component.css'
})
export class AppComponent{

  tasks: Task[] = []
  private suscription!: Subscription;


  constructor(private service: TaskService, private apiService: ApiService) {
    // this.suscription = this.service.taskChanged.subscribe(task =>{
    //   this.tasks = task;
    // })
  }


}
