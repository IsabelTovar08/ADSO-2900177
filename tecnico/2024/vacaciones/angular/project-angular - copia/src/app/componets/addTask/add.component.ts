import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { NgForm, FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';
// import { title } from 'node:process';
import { Task } from '../../models/task.interface';
import { ApiService } from '../../services/api.service';
import { ListTaskComponent } from '../list-task/list-task.component';

@Component({
    selector: 'app-addTask',
    templateUrl: './add.component.html',
    styleUrls: ['./add.component.css'],
    standalone: false
})

export class addComponet implements OnInit {

    // ngOnInit() {
    //     console.log('creandose desde OnInit');
    // }
    // constructor() { 
    //     console.log('creandose desde el constructor');
    // }}
    // ngOnDestroy() {
    //     console.log(' componente destruido');
    // }
    // ngAfterContentInit() {
    //     console.log('contenido inicializado');
    // }

    @Output() taskAdded: EventEmitter<Task> = new EventEmitter<Task>();


    isActive: boolean = false;

    taskActive!: boolean;

    tasks?: any[] = []
    // numberTask: number = this.tasks.length;

    constructor(private fb: FormBuilder, private apiService: ApiService) { }

    form!: FormGroup;



    ngOnInit(): void {
        this.form = this.fb.group({
            Nombre: ['', [Validators.required, Validators.minLength(5), Validators.maxLength(15)]],
            Completada: [false]
        });
    }

    markTaskCompleted(task: Task) {
        task.completada = !task.completada;
    }

    public ObtenerLasTareas() {
        this.apiService.ObtenerTareas().subscribe(tarea => {
            this.tasks = tarea;
        })
    }

    guardarCreacion() {
        console.log(this.form.value)

        this.form.value.Completada = false;
        const tarea = this.form.value;
        this.apiService.CrearTarea(tarea).subscribe(() => {
            this.tasks = undefined
            this.ObtenerLasTareas()
        })
        this.form.reset();
    }

}