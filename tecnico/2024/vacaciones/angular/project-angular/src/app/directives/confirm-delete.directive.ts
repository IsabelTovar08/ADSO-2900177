import { Directive, HostListener, Input } from '@angular/core';

@Directive({
  selector: '[appConfirmDelete]',
  standalone: false
})
export class ConfirmDeleteDirective {

  constructor() { }
  @Input('appConfirmDelete') taskTitle: string = ''
  @HostListener('click', ['$event']) onClick(event: Event){
    event.preventDefault();
    event.stopPropagation();

    const confirmed = confirm(`¿Estas seguro de eliminar la tarea ${this.taskTitle}?`);
    if(confirmed){
      alert('Tarea eliminada');
    }
  }
}
