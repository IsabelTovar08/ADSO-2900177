import { Directive, ElementRef, Input, Renderer2 } from '@angular/core';

@Directive({
  selector: '[appStatusTask]',
  standalone: false
})
export class StatusTaskDirective {

  constructor(private el:ElementRef, private renderer:Renderer2) { }
  @Input() set appStatusTask(completed:boolean){
    if(!completed){
      this.renderer.setStyle(this.el.nativeElement, 'background-color', 'red');
    }
    else{
      this.renderer.setStyle(this.el.nativeElement, 'background-color', '');
    }
  }
}
