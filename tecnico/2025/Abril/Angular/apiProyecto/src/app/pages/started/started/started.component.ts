import { trigger, transition, style, animate, state } from '@angular/animations';
import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';
import { ApiService } from '../../../../services/api.service';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'app-started',
  imports: [ CommonModule, FormsModule, ReactiveFormsModule, MatInputModule, MatFormFieldModule, MatButtonModule, MatIconModule],
  templateUrl: './started.component.html',
  styleUrl: './started.component.css',
  animations: [
    trigger('iconExpand', [
      state('initial', style({ transform: 'scale(0.2)', opacity: 0 })),
      state('expanded', style({ transform: 'scale(1)', opacity: 1 })),
      transition('initial => expanded', animate('1000ms ease-out'))
    ]),
    trigger('fadeIn', [
      transition(':enter', [
        style({ opacity: 0, transform: 'scale(0.5)' }),
        animate('600ms 300ms ease-out', style({ opacity: 1, transform: 'scale(1)' }))
      ])
    ])
  ]
})
export class StartedComponent {
  loginForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private api: ApiService,
    private router: Router
  ) {
    this.loginForm = this.fb.group({
      userName: ['', Validators.required],
      password: ['', Validators.required]
    });
  }

  login() {
    if (this.loginForm.invalid) return;

    const credentials = this.loginForm.value;

    this.api.login(credentials).subscribe({
      next: (data) => {
        const token = data.token;
        localStorage.setItem('jwt', token);

        Swal.fire({
          icon: 'success',
          title: 'Inicio de sesión exitoso',
          showConfirmButton: false,
          timer: 1500
        });

        const roles = this.getUserRoles(token);
        if (roles.includes('Admin')) {
          console.log('Es admin');
        } else {
          console.log('No es admin');
        }
      this.router.navigate(['/dashboard'])

      },
      error: () => {
        Swal.fire({
          icon: 'error',
          title: 'Error de autenticación',
          text: 'Usuario o contraseña incorrectos'
        });
      }
    });
  }

  getUserRoles(token: string): string[] {
    const payload = this.parseJwt(token);
    const roles = payload?.role;
    return Array.isArray(roles) ? roles : [roles];
  }

  parseJwt(token: string): any {
    try {
      const base64Payload = token.split('.')[1];
      const decodedPayload = atob(base64Payload);
      return JSON.parse(decodedPayload);
    } catch (e) {
      console.error('Error al decodificar el token:', e);
      return null;
    }
  }
  iconState: 'initial' | 'expanded' = 'initial';
  showExtras = false;

  ngOnInit(): void {
    setTimeout(() => {
      this.iconState = 'expanded';
      setTimeout(() => this.showExtras = true, 800); // ¡importante!
    }, 500);
  }
  


}
