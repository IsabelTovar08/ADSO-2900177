import { Injectable } from '@angular/core';
import {jwtDecode} from 'jwt-decode';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private tokenKey = 'jwt';

  setToken(token: string): void {
    localStorage.setItem(this.tokenKey, token);
  }

  getToken(): string | null {
    return localStorage.getItem(this.tokenKey);
  }

  isAuthenticated(): boolean {
    const token = this.getToken();
    return token !== null && this.isTokenValid(token);
  }

  logout(): void {
    localStorage.removeItem(this.tokenKey);
  }

  private isTokenValid(token: string): boolean {
    try {
      const payload = JSON.parse(atob(token.split('.')[1]));
      const exp = payload.exp;
      return Date.now() < exp * 1000;
    } catch {
      return false;
    }
  }

  getUserRoles(): string[] {
    const token = localStorage.getItem('token');
    if (!token) return [];
    const decoded: any = jwtDecode(token);
    return decoded['role'] instanceof Array ? decoded['role'] : [decoded['role']];
  }
}
