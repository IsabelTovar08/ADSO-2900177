import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../environments/environment.development';
<<<<<<< HEAD
=======
import { Observable } from 'rxjs';
>>>>>>> mayo

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private http: HttpClient) { }
<<<<<<< HEAD
  urlBase = environment.URL +'api';

  public ObtenerTodo(entidad: string){
    console.log("uuu")
    return this.http.get<any>(`${this.urlBase}/${entidad}`);
  }
  public Crear(entidad: string, objeto: any){
    return this.http.post<any>(`${this.urlBase}/${entidad}`, objeto);
  }

  public update(entidad:string, data: any) {
    return this.http.put(`${this.urlBase}/${entidad}/update/`,data);
=======
  urlBase = environment.URL + 'api';

  public ObtenerTodo(entidad: string) {
    return this.http.get<any>(`${this.urlBase}/${entidad}`);
  }
  public ObtenerActivos(entidad: string) {
    return this.http.get<any>(`${this.urlBase}/${entidad}/active`);
  }
  public Crear(entidad: string, objeto: any) {
    return this.http.post<any>(`${this.urlBase}/${entidad}`, objeto);
  }
  public update(entidad: string, data: any) {
    return this.http.put(`${this.urlBase}/${entidad}/update/`, data);
>>>>>>> mayo
  }
  public delete(entidad: string, id: number) {
    return this.http.delete(`${this.urlBase}/${entidad}/${id}`);
  }
<<<<<<< HEAD
  public deleteLogic(entidad: string, id: number) {
    return this.http.patch(`${this.urlBase}/${entidad}/toggleActive/${id}`, null);
  }
  public login(credentials: { userName: string, password: string }) {
    return this.http.post<any>(`${this.urlBase}/Auth/login`, credentials);
  }
=======
  public deleteLogic(entidad: string, id: number): Observable<boolean>{
    return this.http.patch<boolean>(`${this.urlBase}/${entidad}/toggleActive/${id}`, null);
  }
  public login(credentials: { email: string, password: string }) {
    return this.http.post<any>(`${this.urlBase}/Auth/login`, credentials);
  }
  loginWithGoogle(tokenId: string) {
    return this.http.post<{ token: string }>(`${this.urlBase}/Auth/google`, { tokenId });
  }
  exchangeCodeForToken(code: any): Observable<any> {
    return this.http.post(`${this.urlBase}/Auth/login-google-code`, { code });
  }

>>>>>>> mayo
}
