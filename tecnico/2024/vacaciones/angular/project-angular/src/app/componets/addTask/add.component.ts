import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { NgForm, FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';
// import { title } from 'node:process';
import { Task } from '../../models/task.interface';

@Component({
    selector: 'app-addTask',
    templateUrl: './add.component.html',
    styleUrls: ['./add.component.css'],
    standalone: false
})

export class addComponet implements OnInit{
   
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
    
    tasks: Task[] = []
    numberTask: number = this.tasks.length;

    constructor(private fb: FormBuilder) { }

    form!: FormGroup;
    

    ngOnInit(): void {
        this.form = this.fb.group({
            title: new FormControl('', [Validators.required, Validators.minLength(5), Validators.maxLength(15)])
        })
    }
    sendTaskTitle(){
        if(this.form.valid && this.form.get('title')?.value !== ''){
            const newTask: Task = {
                id: Math.floor(Math.random() * 1000),
                title: this.form.value.title,
                completed: false
            }
            this.taskAdded.emit(newTask);
            this.form.reset();
        }
        else{
            this.taskActive = true;
        }
    }
    markTaskCompleted(task: Task){
        task.completed = !task.completed;
    }
    delete(id: number):void{
        this.tasks = this.tasks.filter((task) => task.id !== id);
        this.numberTask = this.tasks.length;
    }


   
    titleTask: string = '';
    isDesabled: boolean = true;

    sendTask(){
        const sizeTitle = this.titleTask.split('')
        if(sizeTitle.length > 0){
            this.isDesabled = false;
            console.log(sizeTitle.length)
        }
        else{
            this.isDesabled = true;
        }

        console.log(`Tarea Enviada. ${this.titleTask}`)
    }
    sendData(form: NgForm){
        if(form.valid){
            console.log(this.titleTask)
        }
    }

}