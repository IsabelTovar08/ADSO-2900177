import { Component, Input, Output, EventEmitter,OnChanges, SimpleChanges } from '@angular/core';
import { Task } from '../../models/task.interface';

@Component({
  selector: 'app-list-task',
  standalone: false,
  
  templateUrl: './list-task.component.html',
  styleUrl: './list-task.component.css'
})
export class ListTaskComponent {
  @Input('listTask') tasks: Task[] = [];
  @Output() taskCompleted: EventEmitter<Task> = new EventEmitter<Task>();
  @Output() taskDeleted: EventEmitter<number> = new EventEmitter<number>();

  completeTask(task: Task): void{
    this.taskCompleted.emit(task);
  }
  deleteTask(id: number): void{
    this.taskDeleted.emit(id);
  }

  // @Input('cambio') cambio: boolean = false;

  // ngOnChanges(changes: SimpleChanges): void {
  //   if(changes['cambio']){
  //     console.log('Nuevo valor de cambio', changes['cambio'].currentValue);

  //   }
  // }
}

