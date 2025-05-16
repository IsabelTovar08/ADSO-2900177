import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private router: Router) {}

  logout(): void {
    localStorage.removeItem('jwt');  // Elimina el token
    this.router.navigate(['/login']);  // Redirige al login
  }

  isLoggedIn(): boolean {
    const token = localStorage.getItem('jwt');
    return !!token && !this.isTokenExpired(token);
  }

  private isTokenExpired(token: string): boolean {
    try {
      const payload = JSON.parse(atob(token.split('.')[1]));
      const exp = payload.exp;
      const now = Math.floor(Date.now() / 1000);
      return now > exp;
    } catch {
      return true;
    }
  }
}
