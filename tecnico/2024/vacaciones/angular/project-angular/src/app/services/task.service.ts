import { Injectable } from '@angular/core';
import { Task } from '../models/task.interface';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TaskService {

  constructor() { 
    this.getTasks();
  }

  tasks: Task[] = []
  taskChanged = new Subject<Task[]>()

  getTasks(): Task[]{
    this.getFromLocalStorage();
    return this.tasks
  }

  addTask(task: Task): void{
    this.tasks.push(task);
    this.setLocalStorage();
    this.taskChanged.next(this.tasks.slice());
  }

  deleteTask(id:number): void{
    this.tasks = this.tasks.filter((task) => task.id !== id);
    this.setLocalStorage();
    this.taskChanged.next(this.tasks.slice());

  }

  completeTask(id: number): void{
    const task = this.tasks.find((task) => task.id === id)
    if(task){
      task.completed = !task.completed;
      this.setLocalStorage();
    this.taskChanged.next(this.tasks.slice());

    }
  }

  getFromLocalStorage(){
    if(typeof(Storage) !== 'undefined'){
      const savedTask = localStorage.getItem('tasks');
      if(savedTask){
        this.tasks = JSON.parse(savedTask);
    this.taskChanged.next(this.tasks.slice());

      }
    }
  }

  setLocalStorage(){
    if(typeof(Storage) !== 'undefined'){
      localStorage.setItem('tasks', JSON.stringify(this.tasks));
    }
  }
}
