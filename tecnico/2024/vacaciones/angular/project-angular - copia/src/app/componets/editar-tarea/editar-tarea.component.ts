import { ContentObserver } from '@angular/cdk/observers';
import { Component, Input, numberAttribute, OnInit } from '@angular/core';
import { ApiService } from '../../services/api.service';
import { Task } from '../../models/task.interface';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-editar-tarea',
  standalone: false,

  templateUrl: './editar-tarea.component.html',
  styleUrl: './editar-tarea.component.css'
})
export class EditarTareaComponent implements OnInit {
  @Input({ transform: numberAttribute }) id!: number;

  listas?: Task;
  formActualizar!: FormGroup;

  // constructor(){
  //   console.log(this.id)
  // }
  constructor(private apiService: ApiService, private fb: FormBuilder, private router: Router){
    this.formActualizar = this.fb.group({
      nombre: ['', [Validators.required, Validators.minLength(5), Validators.maxLength(15)]],
      completada: [false]
    })

  }



  ngOnInit(): void {
    this.apiService.ObtenerPorId(this.id).subscribe(tarea => {
      this.listas = tarea;
      this.formActualizar.patchValue(this.listas)
      let tara = this.formActualizar.value as Task;
      console.log(this.listas)
      console.log(tara)
    })
  }

  ActualizarTarea() {
    let tara = this.formActualizar.value as Task;

    console.log(tara); 

    this.apiService.EditarTarea(this.id, tara).subscribe(() => {
        console.log("Tarea actualizada con éxito");
        this.router.navigate(['/']);
    });
}


}
