import { AfterViewInit, Component, DoCheck, OnDestroy, OnInit } from '@angular/core';
import { Task } from './models/task.interface';
import { TaskService } from './services/task.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  standalone: false,
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit, OnDestroy{

  tasks: Task[] = []
  private suscription!: Subscription;

  constructor(private service: TaskService) {
    this.suscription = this.service.taskChanged.subscribe(task =>{
      this.tasks = task;
    })
  }

  ngOnInit(): void {
    this.tasks = this.service.getTasks();
  }

  ngOnDestroy(): void {
    this.suscription.unsubscribe();
  }

  cambio: boolean = true;


  addTask(task:Task){
    this.service.addTask(task);
  }
  markTaskCompleted(task: Task){
    this.service.completeTask(task.id);
  }
  deleteTask(id: number){
    this.service.deleteTask(id);
  }





  // ngAfterViewInit(): void {
  //   console.log('AfterViewInit: Han sido inicializadas las vistas');
  // }
  // isDestroyed: boolean =  true;
  // countDown: number;
  // intervalId: any;
  // value: number = 0;
  // previousValue: number = 0;
  // changedDecected: boolean = false;

  // updateValue(): void{
  //   this.value ++
  //   setInterval(() =>{
  //     this.changedDecected = false;
  //   },2000)
  // }
  // ngDoCheck(): void {
  //   if(this.value !== this.previousValue){
  //     this.changedDecected = true;
  //     this.previousValue = this.value;
  //   }
  // }

  // constructor() {
  // this.countDown = 10;
  // this.intervalId = setInterval(() => {
  //   this.countDown--;
  //   if (this.countDown === 0) {
  //     clearInterval(this.intervalId);
  //     this.isDestroyed = false;
  //   }
  //   }, 1000);
  // }
}
