import { ChangeDetectionStrategy, Component, EventEmitter, inject, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormControl, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { provideNativeDateAdapter } from '@angular/material/core';
import { MatNativeDateModule, MAT_DATE_LOCALE } from '@angular/material/core';
import { CommonModule } from '@angular/common';
import { Libro, LibroCrear } from '../../Models/Libro.nodels';

@Component({
  selector: 'app-formulario',
  providers: [
    provideNativeDateAdapter(),
    { provide: MAT_DATE_LOCALE, useValue: 'es-ES' }
  ],
  imports: [
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatDatepickerModule,
    MatNativeDateModule,
    CommonModule
  ],
  changeDetection: ChangeDetectionStrategy.OnPush,
  templateUrl: './formulario.component.html',
  styleUrl: './formulario.component.css'
})
export class FormularioComponent implements OnInit {
  @Input({ required: true }) titulo!: string

  @Input() modeloLibro?: Libro

  @Output() posteoFormulario = new EventEmitter<LibroCrear>

  private readonly fb = inject(FormBuilder)


  form = this.fb.group({
    titulo: [''],
    autor: [''],
    fechaPublicacion: new FormControl<Date | null>(null) 
  })

  ngOnInit(): void {
    if (this.modeloLibro != undefined) {
      this.form.patchValue(this.modeloLibro)
    }
  }

  guardarCambios() {
    console.log(this.form.value)
    console.log("llego")
    let libro = this.form.value as LibroCrear
    this.posteoFormulario.emit(libro)
  }
}
