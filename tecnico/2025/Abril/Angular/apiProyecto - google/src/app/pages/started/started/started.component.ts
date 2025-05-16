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
import { AuthService } from '../../../../services/auth-service.service';
declare const google: any;

@Component({
  selector: 'app-started',
  imports: [ CommonModule, FormsModule, ReactiveFormsModule, MatInputModule, MatFormFieldModule, MatButtonModule, MatIconModule],
  templateUrl: './started.component.html',
  styleUrl: './started.component.css',
  animations: [
    trigger('iconExpand', [
      state('initial', style({ transform: 'scale(0.2)', opacity: 0 })),
      state('expanded', style({ transform: 'scale(1)', opacity: 1 })),
      transition('initial => expanded', animate('500ms ease-out'))
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
    private router: Router,
    private authService: AuthService
  ) {
    this.loginForm = this.fb.group({
      userName: ['', Validators.required],
      password: ['', [
        Validators.required,
        // Validators.minLength(6),
        // Validators.pattern(/^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{6,}$/)
      ]]
    });
  }

  ngOnInit(): void {
    this.startAnimations();
  }
  
  startAnimations(): void {
    setTimeout(() => {
      this.iconState = 'expanded';
      setTimeout(() => {
        this.showExtras = true;
        this.loadGoogleButton(); // Google solo se carga después de mostrar extras
      }, 200);
    }, 500);
  }
  
  loadGoogleButton(): void {
    const checkGoogleLoaded = () => {
      if ((window as any).google) {
        google.accounts.id.initialize({
          client_id: '140227784056-arlnkaj5j7frl6k3uku5ft0e178dq42m.apps.googleusercontent.com',
          callback: this.handleCredentialResponse.bind(this)
        });
  
        google.accounts.id.renderButton(
          document.getElementById('google-signin-button'),
          { theme: 'outline', size: 'large' }
        );
      } else {
        setTimeout(checkGoogleLoaded, 100);
      }
    };
  
    checkGoogleLoaded();
  }
  
  handleCredentialResponse(response: any) {
    const tokenId = response.credential;
    this.api.loginWithGoogle(tokenId).subscribe({
      next: (data) => {
        localStorage.setItem('jwt', data.token);
  
        Swal.fire({
          icon: 'success',
          title: '¡Inicio de sesión exitoso!',
          text: 'Bienvenido con Google.',
          timer: 2000,
          showConfirmButton: false
        });
  
        this.router.navigate(['/dashboard']);
      },
      error: err => {
        console.error('Error con login de Google', err);
  
        Swal.fire({
          icon: 'error',
          title: 'Oops...',
          text: 'Error al iniciar sesión con Google.'
        });
      }
    });
  }

  login() {
    if (this.loginForm.invalid) return;

    const credentials = this.loginForm.value;

    this.api.login(credentials).subscribe({
      next: (data) => {
        const token = data.token;
        this.authService.setToken(token)
        Swal.fire({
          icon: 'success',
          title: 'Inicio de sesión exitoso',
          showConfirmButton: false,
          timer: 1500
        });

        var roles = this.authService.getUserRoles();
        console.log(roles)
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

  
  iconState: 'initial' | 'expanded' = 'initial';
  showExtras = false;

}
